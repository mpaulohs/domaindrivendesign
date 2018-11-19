using demo2.Domain.SeedWork;
using System;

namespace demo2.Domain.AggregatesModel
{
    public class RecordOfSale : Entity, IAggregateRoot
    {
       // public int RecordOfSaleId { get; set; }
        public DateTime DateSold { get; set; }
        public decimal Price { get; set; }

        public string CarState { get; set; }
        public string CarLicensePlate { get; set; }
        public Car Car { get; set; }
    }
}
