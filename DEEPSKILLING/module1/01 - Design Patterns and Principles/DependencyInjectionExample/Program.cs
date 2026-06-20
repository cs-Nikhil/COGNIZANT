using System;
using DependencyInjectionExample.Repositories;
using DependencyInjectionExample.Services;

namespace DependencyInjectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomerRepository repository = new CustomerRepositoryImpl();

            CustomerService service = new CustomerService(repository);

            var customer = service.GetCustomer(101);

            Console.WriteLine("Customer ID: " + customer.Id);
            Console.WriteLine("Customer Name: " + customer.Name);
        }
    }
}