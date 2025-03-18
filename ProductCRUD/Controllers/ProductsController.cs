using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCRUD.Models;
using ProductCRUD.Repository;

namespace ProductCRUD.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ProductRepository _repository;

        public ProductsController(IConfiguration configuration)
        {
            _repository = new ProductRepository(configuration);
        }

        // GET: ProductsController
        public ActionResult Index()
        {
            IEnumerable<Product> products = _repository.GetAllProducts();
            return View(products);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            var product = _repository.GetProductById(id);
            if (product == null)
            {
                return NotFound(); // Return 404 if product not found
            }
            return View(product);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.AddProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _repository.GetProductById(id);
            return View(product);            
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _repository.GetProductById(id);
            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _repository.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
