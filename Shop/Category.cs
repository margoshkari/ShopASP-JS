namespace Shop
{
    public class Category
    {
        public int idCategory { get; set; }
        public string CategoryName { get; set; }
        public Category(string categoryName)
        {
            CategoryName = categoryName;
            idCategory = 0;
        }
    }
}
