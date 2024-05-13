using Rubiconmp_RectangleTask.Data;

namespace Rubiconmp_RectangleTask.Application.Contracts
{
    public interface IRectangleRepository
    {
        Task<IEnumerable<Rectangle>> IntersectsSegmentAsync(Segment segment, CancellationToken cancellationToken = default);
        Task SeedDataAsync(int elementCount);
    }
}
