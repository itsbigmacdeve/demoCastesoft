using AutoMapper;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalogDbContext _context;

        private readonly IMapper _mapper;
        //Me falta ponerle el contexto y el mapper
        public UnitOfWork(CatalogDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        

        public IProductRepository _productRepository => new ProductRepository(_context, _mapper);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
            
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
            
        }

    }
}