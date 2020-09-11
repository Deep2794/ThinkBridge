using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBridgeMVC.Models;
using System.Net.Http;

namespace ShopBridgeMVC.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            try
            {
                IEnumerable<mvcItemModel> ItemList;
                HttpResponseMessage response = GlobalVariables.WebAPIClient.GetAsync("Item").Result;
                ItemList = response.Content.ReadAsAsync<IEnumerable<mvcItemModel>>().Result;
                return View(ItemList);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }
        public ActionResult Add(int id = 0)
        {
            return View(new mvcItemModel());
        }
        [HttpPost]
        public ActionResult Add(mvcItemModel Item)
        {
            try
            {
                HttpResponseMessage response = GlobalVariables.WebAPIClient.PostAsJsonAsync("Item", Item).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error");

            }
        }
        public ActionResult ViewItems(int id = 0)
        {
            try
            {
               
                HttpResponseMessage response = GlobalVariables.WebAPIClient.GetAsync("Item/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcItemModel>().Result);
            }
            catch
            {
                return RedirectToAction("Error");

            }

        }
        public ActionResult DeleteItems(int id = 0)
        {
            try
            {
                HttpResponseMessage response = GlobalVariables.WebAPIClient.DeleteAsync("Item/" + id.ToString()).Result;
                TempData["SuccessMessage"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error");

            }
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}