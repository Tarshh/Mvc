using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bikeshop.Models
{
    public class ShoppingBag
    {
        public ShoppingBag()
        {
            Items = new List<ShoppingItem>();
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public Customer Customer { get; set; }
        public List<ShoppingItem> Items { get; set; }
    }
}
