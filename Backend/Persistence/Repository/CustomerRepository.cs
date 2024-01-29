using Domain.Entities;
using Domain.Repository;

namespace Persistence.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly RepositoryDbContext _dbContext;
    public CustomerRepository(RepositoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Customer GetById(Guid customerId)
    {
        return _dbContext.Customers.FirstOrDefault(x => x.Id == customerId)!;
    }

    public void Insert(Customer customer)
    {
        var exists = _dbContext.Customers.Any(x => x.Username.Equals(customer.Username));

        if (!exists) _dbContext.Customers.Add(customer);
    }

}
