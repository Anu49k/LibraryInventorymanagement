using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryInventoryManagementSystem.Models;
namespace LibraryInventoryManagementSystem.Controllers
{
    public class BookStoreController : Controller
    {
        private BookstoreEntities dbmodel = new BookstoreEntities();
        // GET: /BookStore/Index
        
        public ActionResult Index(string search)
        {

            var books = from b in dbmodel.BookDetails
                        select b;

            if (!string.IsNullOrEmpty(search))
            {
                return View(dbmodel.BookDetails.Where(x => x.Title.Contains(search)|| x.Author.Contains(search)|| x.ISBN.Contains(search)));
            }
     
            else
            {
                return View(books);
            }
            //if (!string.IsNullOrEmpty(title))
            //{
            //    return View(dbmodel.BookDetails.Where(x => x.Title.Contains(title)));
            //}
            //if (!string.IsNullOrEmpty(author))
            //{
            //    return View(dbmodel.BookDetails.Where(x => x.Author.Contains(author)));
            //}
            //if (!string.IsNullOrEmpty(id))
            //{
            //    return View(dbmodel.BookDetails.Where(x => x.ISBN.Contains(id)));
            //}
            //else
            //{
            //    return View(books);
            //}
        }
        // GET: BookStore/Details/5
        public ActionResult Details(string id)
        {
            return View(dbmodel.BookDetails.Where(x => x.ISBN == id).FirstOrDefault());
        }

        // GET: BookStore/Addnew
        public ActionResult Addnew()
        {
           
            return View();
        }

        // POST: BookStore/Addnew
        [HttpPost]
        public ActionResult Addnew(BookDetail book)
        {
            try
            {
                // TODO: Add insert logic here
                
                    dbmodel.BookDetails.Add(book);
                    dbmodel.SaveChanges();
                    return RedirectToAction("Index");
                }
                //else
                //{
                //   // ViewBag.Error = TempData["Year should be between 1500 and " + Convert.ToInt32(book.Year)];
                //   // TempData["error"]="Year should be between 1500 and " + Convert.ToInt32(book.Year);
                //   //  Response.Write("Year should be between 1500 and " + Convert.ToInt32(book.Year));
                //   //("Year should be between 1500 and " + Convert.ToInt32(book.Year));
                //    return RedirectToAction("Index");

                //}
           // }
            catch
            {
                return View();
            }
        }

        // GET: BookStore/Edit/5
        public ActionResult Edit(string id)
        {
            
            return View(dbmodel.BookDetails.Where(x => x.ISBN == id).FirstOrDefault());
        }

        // POST: BookStore/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, BookDetail book)
        {
            try
            {
                // TODO: Add update logic here
                dbmodel.Entry(book).State = EntityState.Modified;
                dbmodel.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookStore/Delete/5
        public ActionResult Delete(string id)
        {
            return View(dbmodel.BookDetails.Where(x => x.ISBN == id).FirstOrDefault());
        }

        // POST: BookStore/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                BookDetail book = dbmodel.BookDetails.Where(x => x.ISBN == id).FirstOrDefault();
                dbmodel.BookDetails.Remove(book);
                dbmodel.SaveChanges();
             
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
