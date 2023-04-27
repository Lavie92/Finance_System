﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinanceSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace FinanceSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]

    public class UserInformationsController : Controller
    {

        private FinanceSystemDBContext db = new FinanceSystemDBContext();
        // GET: Admin/UserInformations
        public ActionResult Index()
        {        
            
            return View(db.AspNetUsers.ToList());
            
        }

        // GET: Admin/UserInformations/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
               return View("~/Views/Shared/Error.cshtml");
            }
            var transaction = db.Transactions.Where(x => x.Wallet.UserId == id).ToList();
            var wallet = db.Wallets.Where(x => x.UserId == id).ToList();
            if (wallet.Count == 0)
            {
                ViewBag.Total = 0;
			}
            else 
            {
				ViewBag.Total = db.Wallets.Where(x => x.UserId == id).Sum(x => x.AccountBalance.Value);
			}
           
            ViewBag.Image = db.UserInformations.FirstOrDefault(x => x.UserId == id).Image;
            ViewBag.Id = id;
            return View(transaction);

        }

        // GET: Admin/UserInformations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/UserInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,FirstName,LastName,BirthDate,Gender,Image")] UserInformation userInformation)
        {
            if (ModelState.IsValid)
            {
                db.UserInformations.Add(userInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userInformation);
        }

        // GET: Admin/UserInformations/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
               return View("~/Views/Shared/Error.cshtml");
            }
            UserInformation userInformation = db.UserInformations.Find(id);
            if (userInformation == null)
            {
                return HttpNotFound();
            }
            return View(userInformation);
        }

        // POST: Admin/UserInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstName,LastName,BirthDate,Gender,Image")] UserInformation userInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userInformation);
        }

        // GET: Admin/UserInformations/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
               return View("~/Views/Shared/Error.cshtml");
            }
            UserInformation userInformation = db.UserInformations.Find(id);
            if (userInformation == null)
            {
                return HttpNotFound();
            }
            return View(userInformation);
        }


        // POST: Admin/UserInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserInformation userInformation = db.UserInformations.Find(id);
            db.UserInformations.Remove(userInformation);
            AspNetUser aspNetUser = db.AspNetUsers.FirstOrDefault(x => x.Id == id);
            db.AspNetUsers.Remove(aspNetUser);
            var transaction = db.Transactions.Where(x => x.Wallet.UserId == id).ToList();
            if (transaction.Count > 0)
            {
                foreach (var item in transaction)
                {
                    db.Transactions.Remove(item);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
