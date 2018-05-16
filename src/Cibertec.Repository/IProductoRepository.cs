using Cibertec.Models;
using System.Collections;
using System.Collections.Generic;

namespace Cibertec.Repository
{
   public interface IProductoRepository : IRepository<Producto>
    {
        IEnumerable<Producto> GetProductosSinStock();
    }
}
