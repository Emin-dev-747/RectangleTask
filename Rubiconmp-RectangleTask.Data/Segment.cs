namespace Rubiconmp_RectangleTask.Data
{
    public struct Segment
    {
        public Segment(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
        }
        public Point Point1 { readonly get; set; }
        public Point Point2 { readonly get; set; }
    }
}
