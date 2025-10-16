using ProductApi.Models;

namespace ProductApi.Services
{
    public class ProductService
    {
        private readonly List<Product> _products = new List<Product>();

        public List<Product> GetAll() => _products;

        public Product GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            if (_products.Any(p => p.Id == product.Id))
                throw new Exception("Product with this ID already exists");

            _products.Add(product);
        }

        public bool Update(int id, Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
                return true; 
            }
            return false;
        }
    }
}
