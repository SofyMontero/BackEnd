using System.Data;
using Dapper;
using Back.Proyecto.Shared.Models;

namespace Back.Proyecto.BuscarEspecifica.MSQL;

public class BuscadorEspReader : IBuscadorDatosEspReader
{
    private readonly IDbConnection _dbConnection;

    public BuscadorEspReader(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<Producto>> GetProductoEspecificoAsync(string nombre)
    {
        string query_bucar_especifico = @"
        SELECT * FROM producto
        WHERE (@Nombre IS NULL OR nombre LIKE CONCAT('%', @Nombre, '%'))";

        return await _dbConnection.QueryAsync<Producto>(query_bucar_especifico, new { Nombre = nombre });
    }
        
}