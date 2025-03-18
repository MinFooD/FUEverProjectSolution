using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.RepositoryContracts
{
	public interface IFeedbackRepository
    {
		Task<List<TopFeedbackViewModel>> GetTopFeedbacksAsync();
	}
}
