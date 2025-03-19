using System.Data;
using Depper;
using Back.Proyecto.Shared.Models;

namespace  Back.Proyecto.Buscador.MSQL;

public class BuscadorDatosReader: IBuscadorDatosReader
{
 private readonly IDbConnection _dbConnection;

        public BuscadorDatosReader(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Producto>> BuscarProductosPorNombreAsync(string nombre)
        {
            string query = @"
                SELECT nombre 
                FROM PRODUCTO
                WHERE nombre LIKE @Nombre";

            return await _dbConnection.QueryAsync<Producto>(query, new { Nombre = $"%{nombre}%" });
        }
}