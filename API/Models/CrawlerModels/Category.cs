using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api.Models.CrawlerModels
{
    public class Category{
       
        public long Id { get; set; }
        
        public string Text {get;set;}
        ICollection<News> News {get;set;}
        
    }
}