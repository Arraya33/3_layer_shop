using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Cart()
        {
            return View();
        }
    }
}
