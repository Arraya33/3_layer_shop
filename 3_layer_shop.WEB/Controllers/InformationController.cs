using _3_layer_shop.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Controllers
{
    public class InformationController : Controller
    {
        public ActionResult Article(string articleAlias)
        {
            InformationPageViewModel model = new InformationPageViewModel { Name = "Статья", Content = @"<p>Статья текст текст текст текст текст 
                текст текст текст<br> текст текст текст текст текст текст текст</p>" };

            return View(model);
        }
    }
}
