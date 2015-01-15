using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Exerciser.Models;

namespace Exerciser.Services
{
    public class ProductRepository : IProductRepository
    {
        private IEnumerable<Product> _Products;
        public async Task<IEnumerable<Product>> All()
        {
            if (_Products == null)
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync("");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync<IEnumerable<Product>>();
            }
        }
    }
}
