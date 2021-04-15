using Culture_kg.Domain.Repositiries.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Culture_kg.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IServicesItemsRepository ServiceItems { get; set; }

        public DataManager(ITextFieldsRepository textFieldsRepository, IServicesItemsRepository serviceItemsRepository)
        {
            TextFields = textFieldsRepository;
            ServiceItems = serviceItemsRepository;
        }
    }

}
