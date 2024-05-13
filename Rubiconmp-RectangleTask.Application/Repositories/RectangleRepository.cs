using Microsoft.EntityFrameworkCore;
using Rubiconmp_RectangleTask.Application.Contracts;
using Rubiconmp_RectangleTask.Data;
using System.Collections.Concurrent;

namespace Rubiconmp_RectangleTask.Application.Repositories
{
    internal sealed class RectangleRepository : IRectangleRepository
    {
        private readonly ApplicationDbContext _context;

        public RectangleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedDataAsync(int elementCount)
        {
            var rectangles = new List<Rectangle>();

            Random random = new Random();

            for (var i = 0; i < elementCount; i++)
            {
                rectangles.Add(new Rectangle(random.Next(-100,100), random.Next(-100, 100), random.Next(-500,500), random.Next(-100, 100)));
            }
            _context.AddRange(rectangles);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Rectangle>> IntersectsSegmentAsync(Segment segment, CancellationToken cancellationToken)
        {
            var rectangles = await _context.Rectangles.ToListAsync();

            if (rectangles == null)
            {
                return Enumerable.Empty<Rectangle>();
            }

            var intersectsRectangles = new ConcurrentBag<Rectangle>();

            var options = new ParallelOptions()
            {
                CancellationToken = cancellationToken
            };

            await Task.Run(() =>
                Parallel.ForEach(rectangles, options, rect =>
                {
                    if (IntersectsSegment(rect, segment))
                    {
                        intersectsRectangles.Add(rect);
                    }
                })
            );
            return intersectsRectangles ?? Enumerable.Empty<Rectangle>();
        }
        private static bool IntersectsSegment(Rectangle rectangle, Segment segment)
        {
            // Segment coordinates
            double x1 = segment.Point1.X;
            double y1 = segment.Point1.Y;
            double x2 = segment.Point2.X;
            double y2 = segment.Point2.Y;

            // Rectangle coordinates
            double rectX1 = rectangle.X;
            double rectY1 = rectangle.Y;
            double rectX2 = rectangle.X + rectangle.Width;
            double rectY2 = rectangle.Y + rectangle.Height;

            // Check if the segment intersects with any side of the rectangle

            // Check if the segment intersects with the top side of the rectangle
            if (LineIntersectsLine(x1, y1, x2, y2, rectX1, rectY1, rectX2, rectY1))
            {
                return true;
            }

            // Check if the segment intersects with the right side of the rectangle
            if (LineIntersectsLine(x1, y1, x2, y2, rectX2, rectY1, rectX2, rectY2))
            {
                return true;
            }

            // Check if the segment intersects with the bottom side of the rectangle
            if (LineIntersectsLine(x1, y1, x2, y2, rectX1, rectY2, rectX2, rectY2))
            {
                return true;
            }

            // Check if the segment intersects with the left side of the rectangle
            if (LineIntersectsLine(x1, y1, x2, y2, rectX1, rectY1, rectX1, rectY2))
            {
                return true;
            }

            return false;
        }
        private static bool LineIntersectsLine(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double dx12 = x2 - x1;
            double dy12 = y2 - y1;
            double dx34 = x4 - x3;
            double dy34 = y4 - y3;

            double denominator = (dy12 * dx34 - dx12 * dy34);

            if (denominator == 0)
            {
                return false;
            }

            double t1 =
                ((x1 - x3) * dy34 + (y3 - y1) * dx34)
                    / denominator;

            if (t1 < 0 || t1 > 1)
            {
                return false;
            }

            double t2 =
                ((x3 - x1) * dy12 + (y1 - y3) * dx12)
                    / -denominator;

            return (t2 >= 0 && t2 <= 1);
        }
    }
}
