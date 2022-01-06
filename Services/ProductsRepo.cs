using AutoMapper;
using Data;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductsRepo : IProductsRepo
    {
        private readonly AdventureWorks2019Context _context;
        private readonly IMapper _mapper;
        public ProductsRepo(AdventureWorks2019Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public ICollection<ProductDto> GetAllProducts (short locationId)
        {
            List<Product> products;
            if (locationId == 0) {
                var productIds = _context.ProductInventories
                    .Where(x => x.LocationId == locationId).Select(x => x.ProductId).ToList();
                products = _context.Products.Where(x => productIds.Contains(x.ProductId)).ToList();
            }
            else
            {
                products = _context.Products.ToList();
            }

            return _mapper.Map<ICollection<ProductDto>>(products);
        }

        public ProductDto GetProductById(int productId)
        {
            var product = _context.Products.Where(x => x.ProductId == productId).FirstOrDefault();
            return _mapper.Map<ProductDto>(product);
        }

        public bool CreateProduct(ProductDto product)
        {
            var success = false;
            try
            {
                _context.Products.Add(_mapper.Map<Product>(product));
                success = true;
            }catch(Exception ex)
            {

            }
            return success;
        }

        public bool UpdateProduct(ProductDto product)
        {
            var success = false;
            try
            {
                _context.Products.Update(_mapper.Map<Product>(product));
                success = true;
            }catch(Exception ex)
            {
                //return error message
            }
            return success;
        }

        public bool DeleteProduct(int productId)
        {
            var success = false;
            try
            {
                var productToRemove = _context.Products.Where(x => x.ProductId == productId).FirstOrDefault();
                _context.Products.Remove(_mapper.Map<Product>(productToRemove));
                success = true;
            }
            catch (Exception ex)
            {
                //return error message
            }
            return success;
        }

    }
}
