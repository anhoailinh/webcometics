namespace webQuanao2.Models.ViewModels
{
    public class PagingInfo
    {
        // bnh sp
        public int TotalItems { get; set; }
        // bn sp tren 1 trang
       public int ItemsPerPage { get; set; }
        // trang hiện tại là 
        public int CurentPage { get; set; }
        // tổng số trang 1 page
        public int TotalPage => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}
