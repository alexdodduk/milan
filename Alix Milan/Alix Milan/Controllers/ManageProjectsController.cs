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
    public class ManageProjectsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ManageProjects
        public ActionResult Index()
        {
            var projects = db.Projects.ToList();

            foreach (var project in projects)
            {
                if (project.Description.Length > 20)
                {
                    project.Description = project.Description.Remove(19) + "...";
                }

                if (project.VideoUrl != null && project.VideoUrl.Length > 20)
                {
                    project.VideoUrl = project.VideoUrl.Remove(19) + "...";
                }
            }

            return View(projects);
        }

        // GET: ManageProjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: ManageProjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,DateCreated,ImageFile,VideoUrl")] EnterProject projectViewModel)
        {
            if (ModelState.IsValid)
            {
                var project = new Project
                {
                    Name = projectViewModel.Name,
                    Description = projectViewModel.Description,
                    DateCreated = projectViewModel.DateCreated,
                    VideoUrl = projectViewModel.VideoUrl
                };

                if (projectViewModel.ImageFile != null && projectViewModel.ImageFile.ContentLength > 0)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(projectViewModel.ImageFile.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(projectViewModel.ImageFile.ContentLength);
                    }

                    project.ImageBytes = imageData;
                }

                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        }

        // GET: ManageProjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }

            var projectViewModel = new EnterProject
            {
                ID = project.ID,
                DateCreated = project.DateCreated,
                Description = project.Description,
                Name = project.Name,
                VideoUrl = project.VideoUrl,
                ExistingImageBytes = project.ImageBytes
            };

            return View(projectViewModel);
        }

        // POST: ManageProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,DateCreated,ImageFile,VideoUrl")] EnterProject projectViewModel)
        {
            var project = db.Projects.SingleOrDefault(p => p.ID == projectViewModel.ID);

            if (project == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            project.Name = projectViewModel.Name;
            project.Description = projectViewModel.Description;
            project.VideoUrl = projectViewModel.VideoUrl;

            if (projectViewModel.ImageFile != null && projectViewModel.ImageFile.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(projectViewModel.ImageFile.InputStream))
                {
                    imageData = binaryReader.ReadBytes(projectViewModel.ImageFile.ContentLength);
                }

                project.ImageBytes = imageData;
            }

            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: ManageProjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: ManageProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
