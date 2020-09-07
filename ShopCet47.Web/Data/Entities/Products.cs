﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCet47.Web.Data.Entities
{
    public class Products
    {
        public int Id { get; set; }




        public int Name { get; set; }



        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode =false)]
        public decimal Price { get; set; }



        [Display(Name ="Image")]
        public string Image { get; set; }



        [Display(Name = "Last Purchase")]
        public DateTime LastPurchase { get; set; }



        [Display(Name = "Last Sale")]
        public DateTime LastSale { get; set; }



        [Display(Name = "Is Available?")]
        public bool isAvailable { get; set; }



        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }


    }
}
