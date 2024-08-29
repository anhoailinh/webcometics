using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webQuanao2.Models
{
	public class Products
	{
		[Key]
		[DisplayName("Mã sản phẩm")]
		public int Id { get; set; }
		[Required]
		[DisplayName("Tên sản phẩm")]
		public string? Name { get; set; }
        [Required]
		[DisplayName("Mô tả")]
		public string? Description { get; set; } //mo ta
		[DisplayName("Mô tả chi tiết")]
		public string? Descriptionall { get; set; }
        [Required]
		[DisplayName("Ảnh")]
		public string? ImageUrl { get; set; }
		[Required]
		[DisplayName("Ảnh 1")]
		public string? Img1 { get; set; }
		[DisplayName("Ảnh 2")]
		public string? Img2 { get; set; }
		[DisplayName("Ảnh 3")]
		public string? Img3 { get; set; }
		[DisplayName("Giá")]
		public decimal Price { get; set; }
		[DisplayName("Sản phẩm nổi bật")]
		public bool ProductsHot { get; set; }
		[DisplayName("Số lượng")]
		public int Quatity { get; set; }
		[DisplayName(" giảm giá")]
		public decimal? Discount { get; set; }
		//khóa ngoài
		[ForeignKey("Category")]
        [Required]
		[DisplayName(" danh mục")]
		public int CategoryID { get; set; }
		public virtual Category? category { get; set; }
		[ForeignKey("Color")]
		[DisplayName("Màu")]
		public int ColorId { get; set; }
		public virtual Color? Color { get; set; }
		[ForeignKey("Size")]
		[DisplayName("Size")]
		public int SizeId { get; set; }
		public virtual Size? Size { get; set;}
	}
}
