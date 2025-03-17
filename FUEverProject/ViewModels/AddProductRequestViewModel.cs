using System.ComponentModel.DataAnnotations;

namespace FUEverProject.ViewModels
{
	public class AddProductRequestViewModel
	{
		public Guid ProductID { get; set; }

		[StringLength(50)]
		public string ProductName { get; set; }

		[StringLength(200)]
		public string Description { get; set; }

		public DateTime ManufacturingDate { get; set; }

		public DateTime ExpirationDate { get; set; }

		public int StockQuantity { get; set; }

		[StringLength(5)]
		public string Size { get; set; }

		[StringLength(100)]
		public string Image { get; set; }

		public Guid StoreID { get; set; }
		public Guid CategoryID { get; set; }
	}
}
