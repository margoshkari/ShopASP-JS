using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shop.Pages
{
    public class ProductsModel : PageModel
    {
        public string category { get; set; } = "";
        public void OnGet(string isadd)
        {
        }
        public void OnPost(string productname, int price, string imagename, string categoryname)
        {
            string idCategory = string.Empty;
            idCategory = SqlOperations.GetCategoryId(categoryname);
            if (idCategory != string.Empty)
            {
                if (SqlOperations.AddProduct(productname, price, imagename, idCategory))
                    category = "exist";
            }
            else
            {
                category = "notexist";
            }
        }
        public IActionResult OnPostDelete(string productname)
        {
            string idProduct = string.Empty;
            if (productname != null)
            {
                idProduct = SqlOperations.GetProductId(productname);
            }
            if (idProduct != string.Empty)
            {
                if (SqlOperations.DeleteProduct(idProduct))
                    return Redirect("/Index");
            }

            return Redirect("/Products");
        }
    }
}
