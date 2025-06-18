using DaoNgocLinh.Models;
using Microsoft.AspNetCore.Mvc;

namespace DaoNgocLinh.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        OnlineShopContext DB;
        List<Product> products;

        public ProductViewComponent(OnlineShopContext db)
        {
            DB = db;
            products = DB.Products.Where(p => p.Available).ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderProduct", products);
        }
    }
}
