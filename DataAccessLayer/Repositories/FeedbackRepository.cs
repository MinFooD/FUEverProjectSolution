using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
	public class FeedbackRepository : IFeedbackRepository
	{
		private readonly FueverDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;

		public FeedbackRepository(FueverDbContext context, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public async Task<List<TopFeedbackViewModel>> GetTopFeedbacksAsync()
		{
			// Lấy tất cả các user từ _userManager
			var allUsers = await _userManager.Users.ToListAsync();

			// Lọc các user có vai trò "PetOwner"
			var petOwnerIds = new List<Guid>();

			foreach (var user in allUsers)
			{
				var roles = await _userManager.GetRolesAsync(user);
				petOwnerIds.Add(user.Id);  // Lưu tất cả các user ID vào danh sách petOwnerIds
			}

			// Truy vấn feedbacks và lấy feedback có rating cao nhất của mỗi người
			var query = from f in _context.Feedbacks
						join b in _context.Bookings on f.BookingID equals b.BookingID
						join p in _context.Pets on b.PetID equals p.PetID
						where petOwnerIds.Contains(p.PetOwnerID)  // Lọc theo các PetOwnerID
						select new
						{
							f.FeedbackID,
							f.Rating,
							f.Text,
							PetOwnerID = p.PetOwnerID,
							PetOwnerName = p.PetOwner.UserName,
							Image = p.PetOwner.ProfileImage
						};

			// Chuyển sang client-side để xử lý group và order
			var feedbackList = await query.ToListAsync();

			// Group feedbacks theo PetOwnerID và lấy feedback cao nhất của mỗi người
			var topFeedbacks = feedbackList
				.GroupBy(f => f.PetOwnerID)
				.Select(g => g.OrderByDescending(f => f.Rating).FirstOrDefault())
				.OrderByDescending(f => f.Rating)
				.Take(3)
				.Select(f => new TopFeedbackViewModel
				{
					FeedbackID = f.FeedbackID,
					Rating = f.Rating,
					FeedbackText = f.Text,
					PetOwnerName = f.PetOwnerName,
					Image = f.Image
				})
				.ToList();

			return topFeedbacks;
		}
	}

	}
public class TopFeedbackViewModel
{
	public Guid FeedbackID { get; set; }
	public decimal Rating { get; set; }
	public string FeedbackText { get; set; }
	public string PetOwnerName { get; set; }
	public string Image { get; set; }
}
