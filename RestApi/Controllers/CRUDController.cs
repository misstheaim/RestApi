using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.Controllers
{
    public class CRUDController : Controller
    {
        ApplicationContext db;

        public CRUDController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //return View();
            return Json(db.Product.ToList());
        }
        [HttpGet]
        public IActionResult GetFiltered(string param)
        {
            Console.WriteLine(param);
            List<Product> products = db.Product.Where(p => p.Name.StartsWith(param)).ToList();
            return Json(products);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            Console.WriteLine(product.Name + "3");
            product.Id = Guid.NewGuid();
            db.Product.Add(product);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update([FromBody] Product product)
        {
            Console.WriteLine(product.Name + "  " +  product.Id + "  " + product.Id.GetType());
            db.Product.Update(product);
            db.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(Guid param)
        {
            //Product? product = db.Products.FirstOrDefault(prod => prod.Id == id);
            //if (product != null)
            //{
            //    db.Products.Remove(product);
            //    db.SaveChanges();
            //}
            Product product = new Product { Id = param };
            db.Entry(product).State = EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}
