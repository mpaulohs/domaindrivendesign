using System;
using System.Collections.Generic;
using Equinox.Application.EventSourcedNormalizers;
using Equinox.Application.ViewModels;
using Equinox.Domain.Models;

namespace Equinox.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        void Register(Customer customerViewModel);
        IEnumerable<Customer> GetAll();
        CustomerViewModel GetById(Guid id);
        void Update(CustomerViewModel customerViewModel);
        void Remove(Guid id);
        IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
