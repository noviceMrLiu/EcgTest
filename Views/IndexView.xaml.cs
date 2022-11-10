using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace EcgTest.Views
{
    /// <summary>
    /// IndexView.xaml 的交互逻辑
    /// </summary>
    public partial class IndexView : UserControl
    {
        public IndexView()
        {
            InitializeComponent();
            DesignPane_Loaded();
            Draw(myGrid);
        }
        private DrawingBrush _gridBrush;
        private void DesignPane_Loaded()
        {
            if (_gridBrush == null)
            {
                _gridBrush = new DrawingBrush(new GeometryDrawing(
                    new SolidColorBrush(Colors.White),
                         new Pen(new SolidColorBrush(Colors.Red), 0.2),
                             new RectangleGeometry(new Rect(0, 0, 10, 10))));
                _gridBrush.Stretch = Stretch.None;
                _gridBrush.TileMode = TileMode.Tile;
                _gridBrush.Viewport = new Rect(0.0, 0.0, 10, 10);
                _gridBrush.ViewportUnits = BrushMappingMode.Absolute;
                myGrid.Background = _gridBrush;
            }             
        }
        public void Draw(Canvas canvas)
        {
            
            var gridBrush = new SolidColorBrush { Color = Color.FromRgb(255, 0, 0) };

            double scaleX = 50;
            double currentPosY = 0;
            currentPosY += scaleX;
            while (currentPosY < 3000)
            {
                Line line = new Line
                {
                    X1 = 0,
                    Y1 = currentPosY,
                    X2 = 3000,
                    Y2 = currentPosY,
                    Stroke = gridBrush,
                    StrokeThickness = 1
                };
                canvas.Children.Add(line);
                currentPosY += scaleX;
            }

            double scaleY = 50;
            double currentPosX = 0;
            currentPosX += scaleY;
            while (currentPosX < 3000)
            {
                Line line = new Line
                {
                    X1 = currentPosX,
                    Y1 = 0,
                    X2 = currentPosX,
                    Y2 = 3000,
                    Stroke = gridBrush,
                    StrokeThickness = 1
                };
                canvas.Children.Add(line);
                currentPosX += scaleY;
            }
        }

    }
}
