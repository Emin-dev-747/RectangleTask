using Microsoft.AspNetCore.Mvc;
using Rubiconmp_RectangleTask.Application.Contracts;
using Rubiconmp_RectangleTask.Data;

namespace Rubiconmp_RectangleTask.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RectangleController : ControllerBase
    {
        private readonly IRectangleRepository _rectangleRepository;

        public RectangleController(IRectangleRepository rectangleRepository)
        {
            _rectangleRepository = rectangleRepository;
        }

        [HttpPost]
        public IActionResult FindIntersectingRectangles(Segment segment, CancellationToken cancellationToken)
        {
            var result = _rectangleRepository.IntersectsSegment(segment, cancellationToken);
            return Ok(result);
        }

        [HttpPost("SeedData")]
        public async Task<IActionResult> SeedData(int elementCount)
        {
            await _rectangleRepository.SeedDataAsync(elementCount);
            return Ok();
        }
    }
}
