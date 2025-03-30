namespace  Back.Proyecto.BuscarEspecifica;
using Back.Proyecto.Shared.Models;

public interface IBuscadorDatosEspReader
{
Task<IEnumerable<Producto>> GetProductoEspecificoAsync(string nombre);
}
