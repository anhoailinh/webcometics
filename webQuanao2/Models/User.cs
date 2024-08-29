using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace webQuanao2.Models
{
	public class User
	{
		[Key]
		[DisplayName("Mã user")]
		public int Id { get; set; }
		[DisplayName("Tên tài khoản")]
		public string? Name { get; set; }
		[DisplayName("Email")]
		[EmailAddress]
		public string? Email { get; set; }
		[DisplayName("Mật khẩu")]
		public string? Password { get; set; }
		
		public string? Role { get; set; }
	}
}
