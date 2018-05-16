using Cibertec.Business;
using Cibertec.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Cibertec.Web.Controllers
{
    public class ProductoController : Controller
    {
        private IProductoBusiness _productoBusiness;
        public ProductoController(IProductoBusiness productoBusiness)
        {
            _productoBusiness = productoBusiness;
        }
        public IActionResult Index()
        {
            var response = _productoBusiness.GetProductos();
            return View(response);
        }
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Producto producto) {
            if (_productoBusiness.InsertProducto(producto) > 0) {
                return Redirect("Index");
            }
            return View(producto);
        }
        public IActionResult Delete(int id)
        {
            var param = new Producto() { Id = id };
            if (_productoBusiness.DeleteProducto(param) > 0) return RedirectToAction("Index");
            return View();
        }
        public IActionResult Edit(int id) {
            var entidad = _productoBusiness.GetProducto(id);
            return View(entidad);
        }
    }
}

