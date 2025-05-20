using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using PrimeraAPI.Models;
using PrimeraAPI.Data;
using System.Reflection.Metadata.Ecma335;

namespace PrimeraAPI.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ProductoService _service;

        public ProductosController(ProductoService service)
        { 
            _service = service;
        }

        [HttpGet] // /api/productos
        public async Task<IActionResult> GetAll()
        {
            var lista = await _service.GetAllAsync();
            return Ok(lista); 
        }

        [HttpGet("{id}")]   // GET  /api/productos/1
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null) return NotFound();
            else return Ok(product);
        }

        [HttpPost]  // POST   /api/ productos
        public async Task<IActionResult> Create(Producto nuevo)
        {
           var created = await _service.CreateAsync(nuevo);
            return CreatedAtAction(nameof(GetById), new { id = created.id }, created);
        }

        [HttpPut("{id}")]  // put  / api/productos/1
        public async Task<IActionResult> Update(int id, Producto actualizado)
        {
            var updated = await _service.UpdateAsync(id, actualizado);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]  // DELETE  / api/productos/1
        public async Task<IActionResult> Delete(int id)
        {
             var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }

}


