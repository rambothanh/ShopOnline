using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.API.Models.UserModels;

namespace ShopOnline.API.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public DateTime? DateCreate {get;set;} = DateTime.UtcNow.AddHours(7);
        public DateTime? DateDue {get;set;}
        public string Name { get; set; }
        public bool IsComplete { get; set; } = false;
        [ForeignKey("User")]
        public int UserRefId { get; set; } =1;
        public User User { get; set; }
        
    }
}
