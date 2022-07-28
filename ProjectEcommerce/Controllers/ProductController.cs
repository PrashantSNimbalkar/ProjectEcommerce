using EcommerceProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectEcommerce.DAL;
using System;

namespace ProjectEcommerce.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index()
        {
            var model = ProductDAL.GetAllProducts();
            return View(model);
        }
        public ActionResult Admin()
        {
            var model = ProductDAL.GetAllProducts();
            return View(model);
        }

        public ActionResult AddToCart(int p_id)
        {
            int user_id = Convert.ToInt32(HttpContext.Session.GetString("userid"));
            string user_name =  HttpContext.Session.GetString("username");
            int result= CartDAL.AddToCart(p_id,user_id);
            return View("Index");
        }
        public ActionResult DeletefromCart(int id)
        {
            int result = CartDAL.DeletefromCart(id);
            return View();
        }
        public ActionResult ViewCart(int id)
        {
            string name = HttpContext.Session.GetString("username");
            var model = CartDAL.GetAllCartItems();
            return View(model);
        }
        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var model= ProductDAL.GetProductById(id);

            return View(model);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product prod)
        {
            try
            {
                int result = ProductDAL.AddProduct(prod);
                if (result == 1)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            Product p = ProductDAL.GetProductById(id);
            return View(p);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product prod)
        {
            
            try
            {
                
                Product product = ProductDAL.GetProductById(id);
                if (product != null)
                {
                    ProductDAL.UpdateProduct(prod);
                    
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            Product p = ProductDAL.GetProductById(id);
            return View(p);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product prod)
        {
            try
            {
                int result;
                if (ProductDAL.GetProductById(id) != null)
                    result=ProductDAL.DeleteProduct(id);
                 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
