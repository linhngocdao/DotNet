using DaoNgocLinh.Models;
using Microsoft.AspNetCore.Mvc;

namespace DaoNgocLinh.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        OnlineShopContext DB;
        List<Category> categories;
        public CategoryViewComponent(OnlineShopContext db)
        {
            DB = db;
            categories = DB.Categories.ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderCategory", categories);
        }
    }
}
