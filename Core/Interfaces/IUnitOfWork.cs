using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }


        Task<bool> Complete();  

        bool HasChanges();
    }
}