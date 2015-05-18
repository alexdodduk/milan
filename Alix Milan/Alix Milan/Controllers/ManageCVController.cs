using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Alix_Milan;
using Alix_Milan.Models;
using Alix_Milan.ViewModels;
using System.IO;

namespace Alix_Milan.Controllers
{
    public class ManageCVController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ManageCV
        public ActionResult Index()
        {
            return View(db.CVs.ToList());
        }

        // GET: ManageCV/View
        public ActionResult Details()
        {
            var cv = db.CVs.SingleOrDefault();

            if (cv == null)
            {
                return HttpNotFound();
            }

            MemoryStream output = new MemoryStream();
            output.Write(cv.File, 0, cv.File.Length);
            output.Position = 0;

            HttpContext.Response.AddHeader("content-disposition", "inline; filename=CV.pdf");

            // Return the output stream
            return File(output, "application/pdf"); 
        }

        // GET: ManageCV/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageCV/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,File")] EnterCV cv)
        {
            if (ModelState.IsValid == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            var newCV = new CV();

            if (cv.File != null && cv.File.ContentLength > 0)
            {
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(cv.File.InputStream))
                {
                    fileData = binaryReader.ReadBytes(cv.File.ContentLength);
                }

                newCV.File = fileData;
            }

                db.CVs.Add(newCV);
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: ManageCV/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CV cv = db.CVs.Find(id);

            if (cv == null)
            {
                return HttpNotFound();
            }

            var cvViewModel = new EnterCV
            {
                ID = cv.ID,
                ExistingFile = cv.File
            };

            return View(cvViewModel);
        }

        // POST: ManageCV/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,File")] EnterCV cvViewModel)
        {
            var cv = db.CVs.Find(cvViewModel.ID);

            if (ModelState.IsValid == false || cv == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            if (cvViewModel.File != null && cvViewModel.File.ContentLength > 0)
            {
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(cvViewModel.File.InputStream))
                {
                    fileData = binaryReader.ReadBytes(cvViewModel.File.ContentLength);
                }

                cv.File = fileData;
            }

            db.Entry(cv).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ManageCV/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CV cV = db.CVs.Find(id);
            if (cV == null)
            {
                return HttpNotFound();
            }
            return View(cV);
        }

        // POST: ManageCV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CV cV = db.CVs.Find(id);
            db.CVs.Remove(cV);
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
