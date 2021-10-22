using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GalaxyWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Rectangle rect;

        public MainWindow()
        {
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(255, 0, 0));

            rect = new Rectangle {
                Width = 250,
                Height = 250,
                Fill = brush,
                StrokeThickness = 3,
                Stroke = Brushes.Black
            };

            Canvas.SetLeft(rect, 50);

            InitializeComponent();

            MainCanvas.Children.Add(rect);
        }

        private void MainCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Keydown event occurred");
        }

        private void MainCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Canvas canvas)
            {
                _ = canvas.Focus();
            }
        }
    }
}
