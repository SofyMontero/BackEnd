namespace  Back.Proyecto.Buscador;
using Back.Proyecto.Shared.Models;

public interface IBuscadorDatosReader
{
 Task<IEnumerable<Producto>> GetProductosAsync(string nombre);

}
