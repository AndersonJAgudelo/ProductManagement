using Microsoft.AspNetCore.Mvc;
using ProductsManagement.Interfaces;
using ProductsManagement.Models;

namespace ProductsManagement.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public IActionResult Check()
        {
            var database = HttpContext.Session.GetString("database") ?? "persistent";
            if (database.Equals("memory"))
                HttpContext.Session.SetString("database", "persistent");
            else
                HttpContext.Session.SetString("database", "memory");

            return RedirectToAction(nameof(Index));
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var database = HttpContext.Session.GetString("database") ?? "persistent";

            return View(await _productServices.GetProducts(database));
        }

        //// GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: Products/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ProductNumber,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                var database = HttpContext.Session.GetString("database") ?? "persistent";
                await _productServices.CreateProduct(product, database);

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }
    }
}