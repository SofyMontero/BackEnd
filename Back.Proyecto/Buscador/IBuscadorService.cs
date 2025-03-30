using Back.Proyecto.Shared.Models;

namespace Back.Proyecto.Buscador;

public interface IBuscadorService
{
     Task<IEnumerable<Producto>> ObtenerProductosAsync();
     
}