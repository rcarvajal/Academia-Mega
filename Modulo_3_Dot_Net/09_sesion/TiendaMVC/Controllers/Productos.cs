using Microsoft.AspNetCore.Mvc;
using TiendaMVC.Models;
using TiendaMVC.Services;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace TiendaMVC.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductoApiService _api;
        public ProductosController(IProductoApiService api) => _api = api;

        //GET /Productos
        public async Task<IActionResult> Index()
        {
            var products = await _api.GetAllAsync();
            return View(products);
        }


        // GET Productos/Create
        public IActionResult Create() => View();

        // POST /Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (!ModelState.IsValid) return View(producto);

            var created = await _api.CreateAsync(producto);
            if (created == null)
            {
                ModelState.AddModelError("", "Error al crear el producto");
                return View(producto);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _api.GetByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _api.GetByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto producto)
        { 
            if (id )
        }
    

    }
}