using Domain.Entities;

namespace Domain.Repository;

public interface ICustomerRepository
{
    Customer GetById(Guid customerId);
    void Insert(Customer customer);
}
