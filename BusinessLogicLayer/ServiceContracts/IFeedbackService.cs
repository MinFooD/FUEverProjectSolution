﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServiceContracts
{
    public interface IFeedbackService
    {
		Task<List<TopFeedbackViewModel>> GetTopFeedbacksAsync();
	}
}
