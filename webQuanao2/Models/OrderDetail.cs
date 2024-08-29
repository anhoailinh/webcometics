using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webQuanao2.Models
{
	public class OrderDetail
	{
		[Key] 
		public int OrderDetailId { get; set; }
		[ForeignKey("Order")]
		public int OrderId { get; set; }
		public virtual Order Order { get; set; }
		[ForeignKey("Products")]
		public int ProductId { get; set; }
		public virtual Products? Products { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
	}
}
