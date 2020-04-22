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
            InformationViewModel model = new InformationViewModel { Name = "Статья", Content = @"<p>Статья текст текст текст текст текст 
                текст текст текст<br> текст текст текст текст текст текст текст</p>" };

            return View(model);
        }
    }
}
