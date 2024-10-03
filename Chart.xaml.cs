using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Color = System.Drawing.Color;
using Point = System.Windows.Point;

namespace RGINPO_WPF
{
    /// <summary>
    /// Interaction logic for Chart.xaml
    /// </summary>
    public partial class Chart : UserControl
    {
        protected Data[] _points = {};
        private readonly Pen _pen;
        private Rectangle _drawingArea;
        private Rectangle _componentArea;

        public Chart()
        {
            InitializeComponent();
            _pen = new Pen(new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0)), 2);
            _drawingArea = new Rectangle(new Data(-10, -10), new Data(10, 10));
            _componentArea = new Rectangle(new Data(0, 500), new Data(500, 0));
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (_points.Length > 1)
            {
                StreamGeometry streamGeometry = new StreamGeometry();

                using (StreamGeometryContext ctx = streamGeometry.Open())
                {
                    ctx.BeginFigure(UtilsLibrary.TranslatePointFromDrawAreaToApplicationArea(_points[0], _drawingArea, _componentArea), false, false);

                    for (int i = 1; i < _points.Length; i++)
                    {
                        ctx.LineTo(UtilsLibrary.TranslatePointFromDrawAreaToApplicationArea(_points[i], _drawingArea, _componentArea), true, false);
                    }
                }

                drawingContext.DrawGeometry(null, _pen, streamGeometry);
            }
        }

        public void UpdatePoints(Data[] points)
        {
            _points = points;
            InvalidateVisual();
        }
    }
}
