using System.Data;
using Dapper;
using Back.Proyecto.Shared.Models;

namespace  Back.Proyecto.Buscador.MSQL;

public class BuscadorDatosReader: IBuscadorDatosReader
{
 private readonly IDbConnection _dbConnection;

        public BuscadorDatosReader(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Producto>> GetProductosAsync(string nombre)
        {
            string query_buscar = @"
                SELECT * FROM producto";

            return await _dbConnection.QueryAsync<Producto>(query_buscar);
        }
        
}