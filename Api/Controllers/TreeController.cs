using DataLayer.BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api.Controllers
{
    public class TreeController : Controller
    {
        public ActionResult NewNode(NodeData model)
        {
            ViewBag.Success = false;

            if (ModelState.IsValid)
            {
                if (model.Age != 0)
                {
                    MyApiController mac = new MyApiController();
                    mac.Post(model.Age, model.Name);
                    ViewBag.Success = true;
                }
            }
            return View();
        }
    }
}
