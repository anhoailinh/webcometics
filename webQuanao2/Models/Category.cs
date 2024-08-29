using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace webQuanao2.Models
{
	public class Category
	{
		[Key]
		[DisplayName("Mã danh mục")]
		public int Id { get; set; }
		[Required]
		[DisplayName("Tên danh mục")]
		public string? Name { get; set; }
	}
}
