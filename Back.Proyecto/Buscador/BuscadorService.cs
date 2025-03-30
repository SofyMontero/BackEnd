using Back.Proyecto.Shared.Models;

namespace Back.Proyecto.Buscador;   
public class BuscadorService : IBuscadorService
{
    private readonly IBuscadorDatosReader _reader;

    public BuscadorService(IBuscadorDatosReader reader)
    {
        _reader = reader;
    }

    public async Task<IEnumerable<Producto>> ObtenerProductosAsync()
    {
        return await _reader.GetProductosAsync("");
    }
}