using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;

//singleton exists to manage interactions to repository 

//In this pattern, a class has only one instance in the program that provides a global point of access to it.
namespace Project0.StoreApplication.Client.Singletons
{
  public sealed class CustomerSingleton
  {
    private static CustomerSingleton _customerSingleton;
    private static readonly CustomerRepository _customerRepository = new CustomerRepository();

    public List<Customer> Customers { get; private set; }
    public static CustomerSingleton Instance
    {
      get
      {
        if (_customerSingleton == null)
        {
          _customerSingleton = new CustomerSingleton();
        }

        return _customerSingleton;
      }
    }
    private CustomerSingleton()
    {
      Customers = _customerRepository.Select();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="customer"></param>
    public void Add(Customer customer)
    {
      _customerRepository.Insert(customer);
      Customers = _customerRepository.Select();
    }
  }
}