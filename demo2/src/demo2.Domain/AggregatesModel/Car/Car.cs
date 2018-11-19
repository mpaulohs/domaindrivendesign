using System.Collections.Generic;

namespace demo2.Domain.AggregatesModel
{
    public class Car 
    {
        public string State { get; set; }
        public string LicensePlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        public List<RecordOfSale> SaleHistory { get; set; }
    }
}
