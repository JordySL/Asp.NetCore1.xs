using System.Collections.Generic;
using Cibertec.Models;
using Cibertec.Repository;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace Cibertec.DADapper
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        public ProductoRepository(string connectionString) :
            base(connectionString)
        {

        }
        public IEnumerable<Producto> GetProductosSinStock()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Producto>("dbo.GetProductoSinStock", commandType: CommandType.StoredProcedure);
            }
        }
    }
}
