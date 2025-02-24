using System.Linq.Expressions;
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface ICustomerService
{
    Task<bool> CreateCustomerAsync(CustomerRegistrationForm form);
    Task<bool> CustomerExistsAsync(Expression<Func<CustomerEntity, bool>> expression);
    Task DeleteCustomer(Customer customer);
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<Customer> GetCustomerAsync(string customerName);
    Task UpdateCustomer(Customer customer);
}