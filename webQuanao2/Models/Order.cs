using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webQuanao2.Models
{
	public class Order
	{
		[Key]
		public int OrderId { get; set; }
		public DateTime CreatedDate { get; set; }
		[ForeignKey("User")]
		public int userId { get; set; }
		public virtual User? User { get; set; }
		public string? Name { get; set; }
		public string? Phone { get; set; }
		[DisplayName("Tỉnh")]
		public string? tinh { get; set; }
		[DisplayName("Thị xã")]
		public string? thixa { get; set; }
		[DisplayName("xã/phường")]
		public string? phuong { get; set; }

	}
}
