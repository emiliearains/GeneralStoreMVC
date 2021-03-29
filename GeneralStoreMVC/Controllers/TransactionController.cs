using GeneralStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GeneralStoreMVC.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
         

        // GET: Transaction
        public ActionResult Index()
        {
            List<Transaction> transactionList = _db.Transactions.ToList();
            List<Transaction> orderedTransactionList = transactionList.OrderBy(x=>x.TransID).ToList();
            
            return View(orderedTransactionList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<Product> products = _db.Products.OrderBy(x => x.Name).ToList();
            List<Customer> customers = _db.Customers.OrderBy(x => x.LastName).ToList();

            ViewBag.Products = products;
            ViewBag.Customers = customers;
            return View();
        }

        // POST: Transaction
        // Verify ProductID is in stock
        // Verify there is enough product to complete transaction
        // Remove products that were purchased
        [HttpPost]
        public ActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                transaction.DateofTransaction = DateTime.Now;
                _db.Transactions.Add(transaction);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }

        // GET: (ALL) Transactions 
        // GET: Transaction/{CustomerID}
        // GET: Details/Transaction/{TransactionID}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = _db.Transactions.Find(id);
            
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // UPDATE : Edit Transaction by TransactionID
        // Verify product changes
        // Update product inventory to reflect updated transaction
    }
}