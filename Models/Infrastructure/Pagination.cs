namespace Models.Infrastructure
{
    public class Pagination
    {
        //{"TotalCount":22,"PageSize":10,"CurrentPage":1,"TotalPages":3,"HasNext":true,"HasPrevious":false}
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }


    }
}