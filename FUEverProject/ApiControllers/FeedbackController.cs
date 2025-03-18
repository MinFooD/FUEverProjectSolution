using BusinessLogicLayer.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FUEverProject.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
		private readonly IFeedbackService _feedbackService;

		public FeedbackController(IFeedbackService feedbackService)
		{
			_feedbackService = feedbackService;
		}

		[HttpGet("GetTopFeedbacks")]
		public async Task<ActionResult<List<TopFeedbackViewModel>>> GetTopFeedbacks()
		{
			try
			{
				// Call the method to get top feedbacks
				var topFeedbacks = await _feedbackService.GetTopFeedbacksAsync();

				if (topFeedbacks == null || topFeedbacks.Count == 0)
				{
					return NotFound("No feedbacks found.");
				}
				return Ok(topFeedbacks);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
	}
}
