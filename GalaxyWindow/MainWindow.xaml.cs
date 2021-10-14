using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GalaxyWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            int r = 255;
            int g = 255;
            int b = 255;

            var brush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            Rectangle rect = new Rectangle {
                Width = 250,
                Height = 250,
                Fill = brush,
                StrokeThickness = 3,
                Stroke = Brushes.Black
            };
            Canvas.SetLeft(rect, 50);

            InitializeComponent();

            mainCanvas.Children.Add(rect);
        }
    }
}
