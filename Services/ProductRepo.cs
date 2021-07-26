using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ProductRepo : IProductRepo
    {
        private AdventureWorks2019Context _context;
        public ProductRepo(AdventureWorks2019Context context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Product>> FindAll() => 
            await _context.Products.ToListAsync();
    }
}