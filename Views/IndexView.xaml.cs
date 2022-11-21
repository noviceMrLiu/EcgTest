using LiveCharts.Wpf;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace EcgTest.Views
{
    /// <summary>
    /// IndexView.xaml 的交互逻辑
    /// </summary>
    public partial class IndexView : UserControl
    {
        //鼠标是否按下
        bool _isMouseDown = false;
        //鼠标按下的位置
        Point _mouseDownPosition;
        //鼠标按下控件的位置
        Point _mouseDownControlPosition;
        double scale;
        public IndexView()
        {
            InitializeComponent();
            scale = 1;

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
        ScaleTransform transfrom = new ScaleTransform();
        private void ContentControl_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (e.Delta < 0)
                {
                    scale -= 0.1;
                }
                else
                {
                    scale += 0.1;
                }
                // scale += (double)e.Delta / 35000;

                transfrom.ScaleX = transfrom.ScaleY = scale;
                this.RenderTransform = transfrom;
            }
        }

        private void ContentControl_MouseMove(object sender, MouseEventArgs e)
        {
            //if (_isMouseDown && Keyboard.IsKeyDown(Key.LeftCtrl))
            //{
            //    var c = sender as Control;
            //    var pos = e.GetPosition(this);
            //    var dp = pos - _mouseDownPosition;
            //    var transform = c.RenderTransform as TranslateTransform;
            //    transform.X = _mouseDownControlPosition.X + dp.X;
            //    transform.Y = _mouseDownControlPosition.Y + dp.Y;
            //}

        }

        private void ContentControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //var c = sender as Control;
            //_isMouseDown = true;
            //_mouseDownPosition = e.GetPosition(this);
            //var transform = c.RenderTransform as TranslateTransform;
            //if (transform == null)
            //{
            //    transform = new TranslateTransform();
            //    c.RenderTransform = transform;
            //}
            //_mouseDownControlPosition = new Point(transform.X, transform.Y);
            //c.CaptureMouse();
        }

        private void ContentControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //var c = sender as Control;
            //_isMouseDown = false;
            //c.ReleaseMouseCapture();
        }
    }
}
