namespace webQuanao2.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Products> Products { get; set; } = Enumerable.Empty<Products>(); 
        public PagingInfo PagingInfo { get; set; } = new PagingInfo();
		public List<Size> Sizes { get; set; } // Thêm thuộc tính Sizes để lưu trữ danh sách kích thước
	}
}
