using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS_Test_12.Models;
using Microsoft.AspNet.Identity;

namespace CMS_Test_12.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.StudentToFacultyCoordinator);
            return View(posts.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.StudentToFacultyCoordinatorId = new SelectList(db.StudentToFacultyCoordinators, "Id", "Description");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Description,Status,StudentToFacultyCoordinatorId")] Post post, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                post.Image = new byte[image.ContentLength]; // image stored in binary formate
                image.InputStream.Read(post.Image, 0, image.ContentLength);
                string fileName = System.IO.Path.GetFileName(image.FileName);
                string urlImage = Server.MapPath("~/Image/" + fileName);
                image.SaveAs(urlImage);
                post.UrlImage = "Image/" + fileName;

                //Get User ID
                var CurrentId = User.Identity.GetUserId();
                //Get student
                var manastudent = db.ManageStudents.SingleOrDefault(c => c.StudentId == CurrentId);
                /*var studenfacultycoordinator = db.StudentToFacultyCoordinators.SingleOrDefault(c => c.ManageStudentId )*/;
                var stfaco = (from st in db.StudentToFacultyCoordinators where st.ManageStudentId == manastudent.Id select st.Id).ToList();
                /*var IdGod = from id in db.StudentToFacultyCoordinators 
                            where id == 
                            select new
							{
                                ID = id.Id,
							}*/
                post.StudentToFacultyCoordinatorId = stfaco[0];



                /*var ManaSt = db.ManageStudents.SingleOrDefault(c => c.StudentId == CurrentId); //1row

                var Sub = GetId(ManaSt.Id); //ID bac3*/

                /*var GetstudentId = db.StudentToFacultyCoordinators.Where(c => c.Id == Sub);*/
                /*post.StudentToFacultyCoordinatorId = */
            }

            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentToFacultyCoordinatorId = new SelectList(db.StudentToFacultyCoordinators, "Id", "Description", post.StudentToFacultyCoordinatorId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,PostName,Description,Status,Image,UrlImage,StudentToFacultyCoordinatorId")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentToFacultyCoordinatorId = new SelectList(db.StudentToFacultyCoordinators, "Id", "Description", post.StudentToFacultyCoordinatorId);
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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

        //Support function
        public ManageStudents GetId(int id)
        {
            return db.ManageStudents.SingleOrDefault(p => p.Id == id);
        }

    }
}
