using Culture_kg.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Culture_kg.Domain.Repositiries.Abstract
{
    public interface IServicesItemsRepository
    {
        IQueryable<ServiceItem> GetServiceItems();
        ServiceItem GetServiceItemById(Guid id);
        void SaveServiceItem(ServiceItem entity);
        void DeleteServiceItem(Guid id);
    }
}

