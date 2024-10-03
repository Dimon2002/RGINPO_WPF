using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RGINPO_WPF
{
    public class UtilsLibrary
    {
        public static double RoundUpToPrecision(double number, double precision)
        {
            return Math.Ceiling(number / precision) * precision;
        }

        public static Point TranslatePointFromDrawAreaToApplicationArea(Data point, Rectangle drawingArea, Rectangle componentArea)
        {
            double coefficientX = (point.X - drawingArea.LeftBottom.X) / drawingArea.Width;
            double coefficientY = (point.Y - drawingArea.LeftBottom.Y) / drawingArea.Height;

            return new Point((int)(componentArea.LeftBottom.X + componentArea.Width * coefficientX), (int)(componentArea.RightTop.Y - componentArea.Height * (1 - coefficientY)));
        }

        public static Point TranslatePointFromApplicationAreaToDrawArea(Data point, Rectangle drawingArea, Rectangle componentArea)
        {
            return TranslatePointFromDrawAreaToApplicationArea(point, componentArea, drawingArea);
        }
    }
}
