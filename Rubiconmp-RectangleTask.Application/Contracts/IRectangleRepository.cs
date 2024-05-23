using Rubiconmp_RectangleTask.Data;

namespace Rubiconmp_RectangleTask.Application.Contracts
{
    public interface IRectangleRepository
    {
        IEnumerable<Rectangle> IntersectsSegment(Segment segment, CancellationToken cancellationToken = default);
        Task SeedDataAsync(int elementCount);
    }
}
