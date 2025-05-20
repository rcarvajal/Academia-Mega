using Microsoft.AspNetCore.Mvc;
using TiendaMVC.Models;
using System.Collections.Generic;

namespace TiendaMVC.Controllers
{

    public class ProductosController : Controller
    {
        private static readonly List<Producto> _producto = new()
        {
            new Producto { id = 1, Nombre = "Xioami 14", Precio = 33000.00m },
            new Producto { id = 2, Nombre = "Honor Magic 7", Precio = 29000.00m }
        };

        public IActionResult Index()
        {
            return View(_producto);
        }

        public IActionResult Details(int id)
        {
            var product = _producto.FirstOrDefault(p => p.id == id);
            if (product == null) return NotFound();
            return View(product);
        }

    }

}