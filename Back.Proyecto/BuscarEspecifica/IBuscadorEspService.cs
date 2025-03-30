using Back.Proyecto.Shared.Models;

namespace Back.Proyecto.BuscarEspecifica;

public interface IBuscadorEspService
{
      Task<IEnumerable<Producto>> GetProductoEspecificoAsync(string nombre);
     
}