using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace webQuanao2.Models
{
	public class Size
	{
		[Key]
		[DisplayName("Mã Size")]
		public int SizeId { get; set; }
		[Required]
		[DisplayName("Tên Size")]
		public string? SizeName { get; set; }
	}
}
