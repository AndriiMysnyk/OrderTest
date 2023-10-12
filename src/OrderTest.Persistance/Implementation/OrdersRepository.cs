using Microsoft.EntityFrameworkCore;

using OrderTest.Domain.Orders;
using OrderTest.Read.Repositories;
using OrderTest.Write.Repositories;

namespace OrderTest.Persistance.Implementation;

internal class OrdersRepository : IOrdersReadRepository, IOrdersWriteRepository
{
    private OrdersContext _context = new OrdersContext();

    public Task<List<Order>> GetAll()
    {
        return _context.Orders.ToListAsync();
    }

    public Task<Order?> Find(Guid id)
    {
        return _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task Create(Order order)
    {
        await _context.Orders.AddAsync(order);
        _context.SaveChanges();
    }

    public void CommitChanges()
    {
        _context.SaveChanges();
    }
}
