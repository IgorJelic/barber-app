namespace Domain.Repository;

public interface IUnitOfWork
{
    void SaveChanges();
}
