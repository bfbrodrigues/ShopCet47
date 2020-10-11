namespace ShopCet47.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using ShopCet47.Web.Data.Entities;

    public class ProductViewModel: Product
    {
        [Display(Name  = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
