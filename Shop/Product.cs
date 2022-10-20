namespace Shop
{
    public class Product
    {
        public string ImageName { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public Product(string imagename, string productName, int price)
        {
            ImageName = imagename;
            ProductName = productName;  
            Price = price;  
        }
    }
}
