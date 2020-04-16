using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Product(string productAlias)
        {
            return View();
        }

        public ActionResult List(string categoryAlias)
        {
            return View();
        }
    }
}
