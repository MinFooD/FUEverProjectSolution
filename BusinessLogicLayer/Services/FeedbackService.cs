using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
	public class FeedbackService : IFeedbackService
	{
		private readonly IFeedbackRepository _feedbackRepository;
		public FeedbackService(IFeedbackRepository feedbackRepository)
		{
			_feedbackRepository = feedbackRepository;
		}

		public Task<List<TopFeedbackViewModel>> GetTopFeedbacksAsync()
		{
			return _feedbackRepository.GetTopFeedbacksAsync();
		}
	}
}
