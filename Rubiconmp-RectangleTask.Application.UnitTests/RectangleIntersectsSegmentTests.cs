using FluentAssertions;
using NSubstitute;
using Rubiconmp_RectangleTask.Application.Contracts;
using Rubiconmp_RectangleTask.Data;

namespace Rubiconmp_RectangleTask.Application.UnitTests
{
    public class RectangleIntersectsSegmentTests
    {
        private readonly IRectangleRepository _rectangleRepository;

        public RectangleIntersectsSegmentTests()
        {
            _rectangleRepository = Substitute.For<IRectangleRepository>();
        }

        [Theory]
        [InlineData(3, 4, 12, 5)]
        [InlineData(13, 54, 92, 78)]
        [InlineData(6.2, 8.5, 14, -56)]
        [InlineData(-12, 4.5, 22, 5.7)]
        [InlineData(30, -17.7, 87.4, -5)]
        public  void Should_Return_A_ListOf_Rectangles(double x1, double y1, double x2, double y2)
        {
            // Arrange
            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);

            var segment = new Segment(point1, point2);
            // Act
            var result = _rectangleRepository.IntersectsSegment(segment, default);

            // Assert
            result.Should().NotBeNull();
        }
    }
}
