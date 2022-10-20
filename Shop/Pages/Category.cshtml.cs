using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shop.Pages
{
    public class CategoryModel : PageModel
    {
        public string isAdd = "add";
        public string categoryadd { get; set; } = "";
        public string categorydelete { get; set; } = "";
        public void OnGet(string isadd)
        {
            if (isadd == "add")
                isAdd = "add";
            else
                isAdd = "delete";
        }
        public void OnPost(string categoryname)
        {
            if (isAdd == "add")
            {
                if (!SqlOperations.isCategoryExist(categoryname))
                {
                    categoryadd = "notexist";
                    SqlOperations.AddCategory(categoryname);
                }
                else
                    categoryadd = "exist";
            }
        }
        public void OnPostDelete(string categoryname)
        {
            if (!SqlOperations.isCategoryExist(categoryname))
            {
                categorydelete = "notexist";
            }
            else
            {
                SqlOperations.DeleteAllProductInCategory(categoryname);
                SqlOperations.DeleteCategory(categoryname);
                categorydelete = "exist";
            }
        }

    }
}
