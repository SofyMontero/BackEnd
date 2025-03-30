using Microsoft.AspNetCore.Mvc;
using Back.Proyecto.Buscador;
using Back.Proyecto.Shared.Models;
using Back.Proyecto.BuscarEspecifica;
using Back.Proyecto.InsertDatos;



namespace Back.Proyecto.Lambda.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuscadorController : ControllerBase
{
    private readonly IBuscadorService _buscador;
    private readonly IBuscadorEspService _service;
    private readonly IInsertService _insert;

    public BuscadorController(IBuscadorEspService service, IBuscadorService buscador, IInsertService insert)
    {
        _service = service;
        _buscador = buscador;
        _insert = insert;
    }

    [HttpGet("productos")]
    public async Task<ActionResult<IEnumerable<Producto>>> ObtenerProductos()
    {
        var productos = await _buscador.ObtenerProductosAsync();
        return Ok(productos);
    }

    [HttpPost("productoEspecifico")]
    public async Task<ActionResult<IEnumerable<Producto>>> ObtenerProductoEspecifico([FromQuery] string nombre)
    {
        var productos = await _service.GetProductoEspecificoAsync(nombre);
        return Ok(productos);
    }
    [HttpPost("insertarProducto")]
    public async Task<IActionResult> InsertarProducto([FromBody] Producto producto)
    {
        var resultado = await _insert.InsertarProductoAsync(producto);
        if (resultado > 0)

        {
            return Ok(new { mensaje = "Producto insertado correctamente.", id = resultado });
        }else
        {
            return BadRequest("Error al insertar el producto.");
        }
    }
}