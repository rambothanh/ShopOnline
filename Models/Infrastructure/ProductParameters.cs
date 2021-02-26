namespace Models.Infrastructure
{
    public class ProductParameters : QueryStringParameters
    {
        public string ProductName { get; set; }
        public ProductParameters()
        {
            OrderBy = "name";

        }
    }
}