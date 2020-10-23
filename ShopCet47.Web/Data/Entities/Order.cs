using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCet47.Web.Data.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }


        [Required]
        [Display(Name = "Order date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)] //Mostra assim mas guarda conforme manda a BD
        public DateTime OrderDate { get; set; }


        [Required]
        [Display(Name = "Delivery date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime? DeliveryDate { get; set; }   //DateTime? - O ponto de interrogação significa que permite passar valores nulos



        [Required]
        public User User { get; set; }


        public IEnumerable<OrderDetail> Items { get; set; }


        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Quantity { get { return this.Items == null ? 0 : this.Items.Sum(i => i.Quantity); } } //Operador ternário


        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Value { get { return this.Items == null ? 0 : this.Items.Sum(i => i.Value);  } }
    }

}
