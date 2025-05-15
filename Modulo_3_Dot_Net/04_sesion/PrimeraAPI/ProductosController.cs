using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;


[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProductosController : ControllerBase
{
    public static readonly List<Producto> _datos = new List<Producto>
    {
        new Producto { id = 1, nombre = "iPhone 16", precio = 20000.0m },
        new Producto { id = 2, nombre = "Galaxy 25", precio = 18000.0m }
    };

    [HttpGet] // /api/productos
    public ActionResult<IEnumerable<Producto>> GetAll()
    {
        return Ok(_datos);
    }

    [HttpPost]  // POST   /api/ productos
    public ActionResult<Producto> Create(Producto nuevo)
    {
        nuevo.id = _datos.Max(p => p.id) + 1;
        _datos.Add(nuevo);
        return CreatedAtAction(nameof(GetById), new { id = nuevo.id }, nuevo);
    }

    [HttpPut("{id}")]  // put  / api/productos/1
    public IActionResult Update(int id, Producto actualizado)
    {
        var product = _datos.FirstOrDefault(p => p.id == id);
        if (product == null) return NotFound();

        product.nombre = actualizado.nombre;
        product.precio = actualizado.precio;

        //return NoContent();
        return Ok("El valor se ha actualizado correctamente");
    }

    [HttpDelete("{id}")]  // DELETE  / api/productos/1
    public IActionResult Delete(int id)
    {
        var product = _datos.FirstOrDefault(p => p.id == id);
        if (product == null) return NotFound();
        _datos.Remove(product);

        //return NoContent();
        return Ok("El valor se ha eliminado correctamente");
    }

    [HttpGet("{id}")]   // GET  /api/productos/1
    public ActionResult<Producto> GetById(int id)
    {
        var product = _datos.FirstOrDefault(p => p.id == id);
        if (product == null) return NotFound();
        else return Ok(product);
    }

}

// Modelo producto
public class Producto()
{
    public int id { get; set; }
    public string nombre { get; set; } = string.Empty;
    public decimal precio { get; set; }
    
}

