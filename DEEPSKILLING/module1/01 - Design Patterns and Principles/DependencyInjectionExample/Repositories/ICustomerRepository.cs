using DependencyInjectionExample.Models;

namespace DependencyInjectionExample.Repositories
{
    public interface ICustomerRepository
    {
        Customer FindCustomerById(int id);
    }
}