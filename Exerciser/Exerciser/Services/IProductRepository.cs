using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exerciser.Models;

namespace Exerciser.Services
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> All();
    }
}
