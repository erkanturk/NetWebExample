using _19_DapperExample.Data;
using _19_DapperExample.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace _19_DapperExample.Controllers
{
    public class ProductController:Controller
    {
        private readonly DapperContext _context;
        public ProductController(DapperContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            var query = "select * from Products inner join Categories on Products.CategoryId = Categories.CategoryId";
            using (var connection = _context.CreateConnetion())
            {

                var products = await connection.QueryAsync<Product, Category, Product>(
                    query,
                    (product, category) =>
                    {
                        product.Category = category;
                        return product;
                    },
                    splitOn: "CategoryId" // Kategorileri ayırmak için kullanılan sütun
                    );

                return View(products.ToList());

            }

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var query = "Insert into Products (Name,Price,CategoryId) Values (@name,@price,@categoryId)";
            using (var connetion = _context.CreateConnetion())
            {
                await connetion.ExecuteAsync(query, product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var query = "Select * from Products Where ProductId=@Id";
            using (var connection = _context.CreateConnetion())
            {
                var product = await connection.QuerySingleOrDefaultAsync<Product>(query, new { Id = id });
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            var query = "Update Products Set Name=@name,Price=@price,CategoryId=@categoryId where ProductId=@productId";
            using (var connection = _context.CreateConnetion())
            {
                await connection.ExecuteAsync(query, product);
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var query = "Select * from Products where ProductId=@id";
            using (var connection = _context.CreateConnetion())
            {
                var product = await connection.QuerySingleOrDefaultAsync<Product>(query, new { Id = id });
                if (product == null)
                {
                    return NotFound("Product Not Found");
                }
                return View(product);
            }
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var query = "Delete from Product where ProductId=@Id";
            using (var connection = _context.CreateConnetion())
            {
                var result = await connection.ExecuteAsync(query, new { Id = id });
                if (result > 0)
                {
                    ViewBag.Message = "Product Delete Successfully";
                }
                else
                {
                    ViewBag.Message = "Product Delete Failed";
                }
                return View("DeleteResult");
            }
        }
        public async Task<IActionResult> Details(int id)
        {
            var query = "Select * from Products where ProductId=@Id";
            using (var connection = _context.CreateConnetion())
            {
                var product = await connection.QuerySingleOrDefaultAsync<Product>(query, new { Id = id });
                if (product == null)
                {
                    return NotFound("Product Not Found");
                }
                return View(product);
            }
        }
    }
}
