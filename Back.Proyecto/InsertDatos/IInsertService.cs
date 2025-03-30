using Back.Proyecto.Shared.Models;

namespace Back.Proyecto.InsertDatos;

public interface IInsertService
{
    
     Task<int> InsertarProductoAsync(Producto producto);
     
}