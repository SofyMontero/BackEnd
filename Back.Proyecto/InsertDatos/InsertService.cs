using Back.Proyecto.Shared.Models;

namespace Back.Proyecto.InsertDatos;

public class InsertEspService : IInsertService
{
    private readonly IInsertDatosReader _reader;

    public InsertEspService(IInsertDatosReader reader)
    {
        _reader = reader;
    }

    public async Task<int> InsertarProductoAsync(Producto producto)
    {
        return await _reader.InsertarProductoAsync(producto);
    }
}

