using Microsoft.AspNetCore.Mvc;
using Stock.Models;

namespace Stock.Controllers
{
    public class ProduitController : Controller
    {
        public IActionResult Produit()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProduitModel());
        }

        [HttpPost]
        public IActionResult Create(ProduitModel produit)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(produit); 
        }
    }
}
