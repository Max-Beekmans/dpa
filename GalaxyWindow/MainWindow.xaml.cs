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
        private IDictionary<Guid, Ellipse> _entities;
        private IDictionary<string, SolidColorBrush> _brushDictionary;

        public MainWindow()
        {
            _sim = Simulation.GetInstance();
            _entities = new Dictionary<Guid, Ellipse>();
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

            foreach (var body in _sim.Galaxy.Bodies)
            {
                // Set new positions for shapes
                if (_entities.TryGetValue(body.Id, out var ellipse))
                {
                    Canvas.SetLeft(ellipse, body.XPos);
                    Canvas.SetTop(ellipse, body.YPos);
                } else
                {
                    SolidColorBrush brush;

                    if (!_brushDictionary.TryGetValue(body.Color, out brush))
                    {
                        brush = Brushes.Black;
                    }

                    // Add new shapes
                    var e = new Ellipse
                    {
                        Stroke = brush,
                        Fill = brush,
                        Width = body.Radius,
                        Height = body.Radius
                    };
                    _entities.Add(body.Id, e);

                    bodyIds.Remove(body.Id);

                    // Remove deleted bodies from shapes
                    foreach (var bodyId in bodyIds)
                    {
                        _entities.Remove(bodyId);
                    }
                }

                Redraw();
            }
        }

        private void Redraw()
        {
            MainCanvas.Children.Clear();
            foreach (var entity in _entities)
            {
                MainCanvas.Children.Add(entity.Value);
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
