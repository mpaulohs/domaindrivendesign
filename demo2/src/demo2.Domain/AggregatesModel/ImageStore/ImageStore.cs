using demo2.Domain.SeedWork;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo2.Domain.AggregatesModel.ImageStore
{
    //[Table("ImageStore")]
    public class ImageStore : Entity, IAggregateRoot
    {
        
        public string ImageBase64String { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
