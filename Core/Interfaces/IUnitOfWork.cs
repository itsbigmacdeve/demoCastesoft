namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository _productRepository { get; }


        Task<bool> Complete();  

        bool HasChanges();
    }
}