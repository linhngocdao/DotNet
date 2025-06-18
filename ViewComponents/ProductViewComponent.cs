using DaoNgocLinh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DaoNgocLinh.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        OnlineShopContext DB;
        List<Product> products;

        public ProductViewComponent(OnlineShopContext db)
        {
            DB = db;
            //products = DB.Products.Where(p => p.Available).ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync(string category = null)
        {
            // Lấy danh sách sản phẩm có sẵn
            var query = DB.Products.Where(p => p.Available);

            // Lọc theo danh mục nếu category được chỉ định
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category.Name == category);
            }

            // Lấy danh sách sản phẩm
            var products = await query.ToListAsync();

            // Thay thế "New Product" bằng tên sinh viên
            foreach (var product in products)
            {
                if (product.Name == "New Product")
                {
                    product.Name = "Đào Ngọc Linh";
                }
            }

            return View("RenderProduct", products);
        }
    }
}
