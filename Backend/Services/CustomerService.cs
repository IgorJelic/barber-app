using Domain.Repository;
using Services.Abstractions;

namespace Services;

public class CustomerService : ICustomerService
{
    private readonly IRepositoryManager _repositoryManager;
    public CustomerService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
}
