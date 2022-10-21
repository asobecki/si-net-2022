
using _2022_6.Models;
using Microsoft.AspNetCore.Mvc;

namespace _2022_6.Controllers;

public class RoutingController : Controller {

    private Dictionary<long, Product> Catalog;

    public RoutingController() {
        InitializeCatalog();
    }

    public Dictionary<long, Product> ListRaw() {
        return Catalog;
    }


    [HttpGet]
    [ActionName("List")]
    public IActionResult List() {
        return View("List", Catalog);
    }

    [HttpGet("GetProduct/{id:required}")]
    public IActionResult GetProduct(int id) {
        Product p = null;
        if(!Catalog.TryGetValue(id, out p)) {
            TempData["message"] = "Nie mogę znaleźć produktu o id: "+id;

            return RedirectToAction("");
        }

        return View("Details", p);
    }

    public IActionResult Delete(int id) {
        bool status = DeleteProduct(id);
        TempData["message"] = "Usunięto produkt o id "+id;

        return RedirectToAction("List");
    }

    [HttpPost]
    public IActionResult Add([Bind("id,Name,Price,Category")] Product product) {

        if(!ModelState.IsValid) {
            Console.WriteLine("Walidacja nie przeszła");
            ViewData["message"] = "Walidacja nie przeszła;";
        }
        if(product != null && !Catalog.ContainsKey(product.id)) {
            Catalog.Add(product.id, product);
            TempData["message"] = "Dodano produkt do katalogu";
        } else {
            TempData["message"] = "Nie udało się dodać produktu do katalogu";
        }
        return RedirectToAction("List");
    }



    private void InitializeCatalog() {
        Catalog = new Dictionary<long, Product> {
            {1, new Product(1, "Samsung Galaxy S90", "9000", "Smartphone")},
            {2, new Product(2, "WiPhone XiMax 1000", "10000", "Smarthpone-zupa")},
            {3, new Product(3, "Ksiaomi Mi 5 HD Ultra", "4 pesos", "Smarthpone")}
        };
    }

    private bool DeleteProduct(int id) {
        if(!Catalog.ContainsKey(id)) return false;
        Catalog.Remove(id);
        return true;
    }
}
