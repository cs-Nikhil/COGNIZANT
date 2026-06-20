using DependencyInjectionExample.Models;
using DependencyInjectionExample.Repositories;

namespace DependencyInjectionExample.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository repository;

        public CustomerService(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        public Customer GetCustomer(int id)
        {
            return repository.FindCustomerById(id);
        }
    }
}