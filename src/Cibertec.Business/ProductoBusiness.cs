using Cibertec.Business.Rules;
using Cibertec.Models;
using Cibertec.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace Cibertec.Business
{
    public interface IProductoBusiness
    {
        IEnumerable<Producto> GetProductoSinStock();
        IEnumerable<Producto> GetProductos();
        int InsertProducto(Producto producto);
        int DeleteProducto(Producto producto);
        Producto GetProducto(int id);
    }

    public class ProductoBusiness : IProductoBusiness
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IEnumerable<IRule> _rules;
        public ProductoBusiness(IUnitOfWork unitofwork, IEnumerable<IRule> rules)
        {
            _rules = rules;
            _unitofwork = unitofwork;
        }
        public IEnumerable<Producto> GetProductos() => _unitofwork.productos.GetList();
        public IEnumerable<Producto> GetProductoSinStock() => _unitofwork.productos.GetProductosSinStock();

        public int InsertProducto(Producto producto)
        {
            var clase = _rules.FirstOrDefault(x=>x.IsApplicable(producto));
            clase.Process(producto);
            return _unitofwork.productos.Insert(producto);
        }

        public int DeleteProducto(Producto producto)
        {
            return _unitofwork.productos.Delete(producto);
        }

        public Producto GetProducto(int id)
        {
            return _unitofwork.productos.GetById(id);
        }
    }
}
