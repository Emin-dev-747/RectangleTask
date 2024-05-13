using Microsoft.EntityFrameworkCore;

namespace Rubiconmp_RectangleTask.Data
{
    public class Rectangle
    {
        public int Id { get; set; }
        // Parameters:
        //   location:
        //     A System.Drawing.Point that represents the upper-left corner of the rectangular
        //     region.
        //
        //   size:
        //     A System.Drawing.Size that represents the width and height of the rectangular
        //     region.
        public Rectangle(Point point, double width, double height)
        {
            X = point.X;
            Y = point.Y;
            Width = width;
            Height = height;
        }
        // Parameters:
        //   x:
        //     The x-coordinate of the upper-left corner of the rectangle.
        //
        //   y:
        //     The y-coordinate of the upper-left corner of the rectangle.
        //
        //   width:
        //     The width of the rectangle.
        //
        //   height:
        //     The height of the rectangle.
        public Rectangle(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        // Summary:
        //     Gets or sets the x-coordinate of the upper-left corner of this System.Drawing.Rectangle
        //     structure.
        //
        public double X { get; set; }
        // Summary:
        //     Gets or sets the y-coordinate of the upper-left corner of this System.Drawing.Rectangle
        //     structure.
        //
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
