using Back.Proyecto.Shared.Models;

namespace Back.Proyecto.BuscarEspecifica;   
public class BuscadorEspService : IBuscadorEspService
{
    private readonly IBuscadorDatosEspReader _reader;

    public BuscadorEspService(IBuscadorDatosEspReader reader)
    {
        _reader = reader;
    }   
    public async Task<IEnumerable<Producto>> GetProductoEspecificoAsync(string nombre)
    {
        return await _reader.GetProductoEspecificoAsync("");
    }
}
 
