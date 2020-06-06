using _3_layer_shop.WEB.Models.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Models.ViewModels
{
    public class ProductPageViewModel : PageViewModel
    {
        [Required(ErrorMessage = "Введите наименование")]
        [Display(Name = "Наименование*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите цену")]
        [Display(Name = "Цена*")]
        public int Price { get; set; }

        [Display(Name = "Цена по скидке")]
        public int DiscountPrice { get; set; }

        [Display(Name = "Краткое описание")]
        public string IntroText { get; set; }

        [Display(Name = "Основное изображение")]
        public ImageViewModel MainImage { get; set; }

        [Display(Name = "Изображения")]
        public IList<ImageViewModel> Images { get; set; }

        [Display(Name = "Количество на складе")]
        public int Quantity { get; set; }
        public IEnumerable<ProductPageViewModel> RelatedProducts { get; set; }

        [Display(Name = "Сопутствующие товары")]
        public int[] RelatedProductIds { get; set; }
    }
}
