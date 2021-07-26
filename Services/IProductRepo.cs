using System.Collections.Generic;
using System.Threading.Tasks;
using Data;

namespace Services
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> FindAll();
    }
}