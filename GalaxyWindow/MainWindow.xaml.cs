using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using GalaxyLib;
using GalaxyLib.Model;
using GalaxyLib.Msg;

namespace GalaxyWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IObserver
    {
        private Simulation _sim;
        private List<Ellipse> _ellipses;
        private List<Line> _lines;
        private IDictionary<string, SolidColorBrush> _brushDictionary;

        public MainWindow()
        {
            _sim = Simulation.GetInstance();
            _lines = new List<Line>();
            _sim.Galaxy.Attach(this);
            _brushDictionary = new Dictionary<string, SolidColorBrush>
            {
                {"blue", Brushes.Blue},
                {"orange", Brushes.Orange},
                {"grey", Brushes.Gray},
                {"brown", Brushes.Brown},
                {"pink", Brushes.Pink},
                {"purple", Brushes.Purple},
                {"black", Brushes.Black}
            };

            InitializeComponent();
        }

        private void DrawGalaxy(Galaxy galaxy)
        {
            //var galaxy = _sim.Galaxy.Bodies.ToList();
            var bodyIds = new List<Guid>(galaxy.Bodies.Select(x => x.Id).ToList());
            _ellipses = new List<Ellipse>();

            foreach (var body in galaxy.Bodies)
            {
                SolidColorBrush brush;

                if (!_brushDictionary.TryGetValue(body.Color, out brush))
                {
                    brush = Brushes.Black;
                }

                var e = new Ellipse
                {
                    Stroke = brush,
                    Fill = brush,
                    Width = body.Radius,
                    Height = body.Radius
                };

                Canvas.SetLeft(e, body.XPos);
                Canvas.SetTop(e, body.YPos);

                _ellipses.Add(e);
            }

            DrawNeighbours(galaxy);

            Redraw();
        }

        private void DrawNeighbours(Galaxy galaxy)
        {
            var list = new List<string>();
            _lines = new List<Line>();

            foreach (var body in galaxy.Planets)
            {
                foreach (var other in body.Neighbours)
                {
                    if (list.Contains($"{other.Name}{body.Name}") ||
                        list.Contains($"{body.Name}{other.Name}"))
                        continue;

                    Line line = new Line
                    {
                        Stroke = Brushes.Black,
                        X1 = body.XPos + (body.Radius / 2),
                        Y1 = body.YPos + (body.Radius / 2),
                        X2 = other.XPos + (other.Radius / 2),
                        Y2 = other.YPos + (other.Radius / 2),
                        StrokeThickness = 1
                    };
                    _lines.Add(line);
                    list.Add($"{body.Name}{other.Name}");
                }
            }
        }

        private void Redraw()
        {
            MainCanvas.Children.Clear();

            foreach (var line in _lines)
            {
                MainCanvas.Children.Add(line);
            }

            foreach (var ellipse in _ellipses)
            {
                MainCanvas.Children.Add(ellipse);
            }
        }

        private void MainCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            _sim.KeyMap.GesturePressed(e.Key.ToString());
        }

        private void MainCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Canvas canvas)
            {
                _ = canvas.Focus();
            }
        }

        private void Keybinding_OnClick(object sender, RoutedEventArgs e)
        {
            KeyConfigWindow window = new KeyConfigWindow(_sim.KeyMap);
            window.Show();
        }

        public void Update(ISubject subject)
        {
            var galaxy = (Galaxy) subject;
            Dispatcher.BeginInvoke(new Action(() =>
            {
                DrawGalaxy(galaxy);
            }), DispatcherPriority.Background);
        }
    }
}
