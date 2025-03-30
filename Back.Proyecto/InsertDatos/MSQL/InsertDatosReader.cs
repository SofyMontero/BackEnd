using System.Data;
using Dapper;
using Back.Proyecto.Shared.Models;

namespace Back.Proyecto.InsertDatos.MSQL;

public class InsertReader : IInsertDatosReader
{
    private readonly IDbConnection _dbConnection;

    public InsertReader(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<int> InsertarProductoAsync(Producto producto)
    {
        string query_insert = @"
        INSERT INTO producto (nombre, descripcion, precio, stock, imagen_url, marca_id, categoria_id, disponible, fecha_creacion)
        VALUES (@nombre, @descripcion, @precio, @stock, @imagen_url, @marca_id, @categoria_id, @disponible, @fecha_creacion);
        SELECT LAST_INSERT_ID();";
        var id = await _dbConnection.ExecuteScalarAsync<int>(query_insert, producto);
        return id;


    }
}