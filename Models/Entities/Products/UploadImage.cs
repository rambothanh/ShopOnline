namespace Models.Entities.Products
{
    public class UploadImage
    {
        public int ProductId { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
    }
}