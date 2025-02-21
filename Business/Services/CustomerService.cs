using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<bool> CreateCustomerAsync(CustomerRegistrationForm form)
    {
        if (await _customerRepository.ExistsAsync(x => x.CustomerName == form.CustomerName))
            return false;

        await _customerRepository.BeginTransactionAsync();

        try
        {
            await _customerRepository.CreateAsync(CustomerFactory.Create(form));
            await _customerRepository.SaveAsync();
            await _customerRepository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _customerRepository.RollbackTransactionAsync();
            return false;
        }
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        var entities = await _customerRepository.GetAllAsync();
        var customers = entities.Select(CustomerFactory.Create);
        return customers ?? [];
    }

    public async Task<Customer> GetCustomerAsync(string customerName)
    {
        var entity = await _customerRepository.GetAsync(x => x.CustomerName == customerName);
        if (entity == null)
            return null!;

        var customer = CustomerFactory.Create(entity);
        return customer ?? null!;
    }

    public bool UpdateCustomer(Customer customer)
    {
        return _customerRepository.Update(CustomerFactory.Create(customer));
    }

    public bool DeleteCustomer(Customer customer)
    {
        return _customerRepository.Delete(CustomerFactory.Create(customer));
    }

    public async Task<bool> CustomerExistsAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        var result = await _customerRepository.ExistsAsync(expression);
        return result;
    }
}
