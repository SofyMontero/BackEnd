namespace  Back.Proyecto.Buscador;
using Back.Proyecto.Shared.Models;

public interface IBuscadorDatosReader
{
 Task<IEnumerable<Producto>> BuscarProductosPorNombreAsync(string nombre);
}
