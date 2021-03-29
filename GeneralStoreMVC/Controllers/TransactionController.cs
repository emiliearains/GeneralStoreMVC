using GeneralStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                _db.Transactions.Add(transaction);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }

        // GET: (ALL) Transactions 
        // GET: Transaction/{CustomerID}
        // GET: Transaction/{TransactionID}

        // UPDATE : Edit Transaction by TransactionID
        // Verify product changes
        // Update product inventory to reflect updated transaction
    }
}