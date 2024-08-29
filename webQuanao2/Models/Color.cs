
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace webQuanao2.Models
{
	public class Color
	{
		[Key]
		[DisplayName("Mã màu")]
		public int ColorId { get; set; }
		[Required]
		[DisplayName("Tên màu")]
		public string? ColorName { get; set; }
	}
}
