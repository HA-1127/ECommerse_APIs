namespace ECommerce.API.Repositories.IRepositories
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        Task CreateRangeAsync(List<OrderItem> orderItems);
    }
}
