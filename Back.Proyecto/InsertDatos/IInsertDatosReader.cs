namespace Back.Proyecto.InsertDatos;
using Back.Proyecto.Shared.Models;

public interface IInsertDatosReader
{
 Task<int> InsertarProductoAsync(Producto producto);
}
