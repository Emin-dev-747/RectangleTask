namespace Rubiconmp_RectangleTask.Data
{
    public struct Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { readonly get; set; }
        public double Y { readonly get; set; }
    }
}
