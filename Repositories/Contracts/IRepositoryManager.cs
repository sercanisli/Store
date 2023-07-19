using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IProductRepository Products { get; }
        ICategoryRepository Category { get; }
        IOrderRepository Order { get; }
        void Save();
    }
}
