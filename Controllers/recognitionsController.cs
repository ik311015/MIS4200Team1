using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using MIS4200Team1.DAL;
using MIS4200Team1.Models;

namespace MIS4200Team1.Controllers
{
    [Authorize]
    public class recognitionsController : Controller
    {
        private centricContext db = new centricContext();

        // GET: recognitions
        public ActionResult Index()
        {
            var recognitions = db.recognitions.Include(r => r.Profile);
            return View(recognitions.ToList());
        }

        // GET: recognitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recognition recognition = db.recognitions.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            return View(recognition);
        }

        // GET: recognitions/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.Profiles, "ID", "fullName");
            return View();
        }

        // POST: recognitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "recognitionID,description,values,id")] recognition recognition)
        {
            if (ModelState.IsValid)
            {
                db.recognitions.Add(recognition);
                db.SaveChanges();
                SmtpClient myClient = new SmtpClient();
                // the following line has to contain the email address and password of someone
                // authorized to use the email server (you will need a valid Ohio account/password
                // for this to work)
                myClient.Credentials = new NetworkCredential("AuthorizedUser", "UserPassword");
                MailMessage myMessage = new MailMessage();
                // the syntax here is email address, username (that will appear in the email)
                MailAddress from = new MailAddress("jg346015@ohio.edu", "SysAdmin");
                myMessage.From = from;
                // first, the customer found in the order is used to locate the customer record
                var profile = db.Profiles.Find(recognition.ID);
                // then extract the email address from the customer record
                var profileEmail = profile.email;
                // finally, add the email address to the “To” list
                myMessage.To.Add(profileEmail);
                // note: it is possible to add more than one email address to the To list
                // it is also possible to add CC addresses
                myMessage.To.Add("jg346015@ohio.edu"); // this should be replaced with model data
                                                       // as shown at the end of this document
                myMessage.Subject = "Recognition";
                // the body of the email is hard coded here but could be dynamically created using data
                // from the model- see the note at the end of this document
                myMessage.Body = "Nice Job! You've received a recognition from a coworker! See the details on your Centric recognitions account.";
                try
                {
                    myClient.Send(myMessage);
                    TempData["mailError"] = "";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // this captures an Exception and allows you to display the message in the View
                    TempData["mailError"] = ex.Message;
                }

            }

            ViewBag.id = new SelectList(db.Profiles, "ID", "firstName", recognition.ID);
            return View(recognition);
        }

        // GET: recognitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recognition recognition = db.recognitions.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.Profiles, "ID", "firstName", recognition.ID);
            return View(recognition);
        }

        // POST: recognitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "recognitionID,description,values,id")] recognition recognition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recognition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.Profiles, "ID", "firstName", recognition.ID);
            return View(recognition);
        }

        // GET: recognitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recognition recognition = db.recognitions.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            return View(recognition);
        }

        // POST: recognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            recognition recognition = db.recognitions.Find(id);
            db.recognitions.Remove(recognition);
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
