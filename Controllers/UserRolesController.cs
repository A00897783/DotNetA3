using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using a2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace a2.Controllers.lookup
{
    public class UserRolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       
        public ActionResult Index()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users =
                 from c in db.Users
                 select new { c.Email, c.Id, c.LockoutEnabled };
            string currentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            
            List<string> usersList = new List<string>();
            List<bool> usersEnable = new List<bool>();
            foreach (var user in users)
            {
                usersList.Add(user.Email);
                usersEnable.Add(user.LockoutEnabled);
            }
            ViewBag.Users = usersList;
            ViewBag.Enable = usersEnable;
            //list<string> usersrole = new list<string>();
            //foreach (var id in usersid)
            //{
            //    ilist<string> roles = usermanager.getroles(id);
            //    usersrole.add(roles[0]);
            //}
            //viewbag.roles = usersrole;
            return View() ;
        }
        public ActionResult EditUserRoles(string name)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             var user = userManager.FindByName(name);
            if (user == null)
            {
                return HttpNotFound();
            }
        
            var userRoleIds = (from r in user.Roles select r.RoleId);
            List<string> userRoles = (from id in userRoleIds
                        let r = roleManager.FindById(id)
                        select r.Name).ToList();
            ViewBag.Role = userRoles;
            ViewBag.UserName = name;
            var roles =
                  from c in db.Roles
                  select new { c.Name };
            ViewBag.UserRoles = roles;

            return View();
        }
        /*
        public string getRoleByUserId(string id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IList<string> roles = userManager.GetRoles(id);
            return roles[0];
        }*/

        public ActionResult Roles()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            

            List<SelectListItem> roleList = new List<SelectListItem>();
            List<string> roles = (from r in roleManager.Roles select r.Name).ToList();
            ViewBag.Roles = new SelectList(roles);
            return View();
        }

        public ActionResult DisableUsers(string name)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = userManager.FindByName(name);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserName = name;
            if (user.LockoutEndDateUtc > DateTime.Now)
            {
                
            ViewBag.Status = "Disabled";
            ViewBag.NextStatus = "Enabled";
            }
            else
            {
                ViewBag.Status = "Enabled";
                ViewBag.NextStatus = "Disabled";
            }
            return View();
        }

        public ActionResult Disable(string name)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = userManager.FindByName(name);
            if (user == null)
            {
                return HttpNotFound();
            }

            if (user.LockoutEndDateUtc > DateTime.Now)//if disabled
            {
                DateTime dt = new DateTime(2000, 01, 01);
                DateTimeOffset dto = new DateTimeOffset(dt);
                userManager.SetLockoutEndDate(user.Id, dto);
            }
            else if ((user.LockoutEndDateUtc <= DateTime.Now) || (user.LockoutEndDateUtc == null))//if enabled
            {
                DateTime dt = new DateTime(5000, 01, 01);
                DateTimeOffset dto = new DateTimeOffset(dt);
                userManager.SetLockoutEndDate(user.Id, dto);
            }


            return RedirectToAction("Index");
        }

        // POST: AbuserRelationships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string role)
        {
        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
        if (!roleManager.RoleExists(role)) {
            var result = roleManager.Create(new IdentityRole(role));
            /*if (result.Succeeded) {
                role added
            } else {
                string err = string.Format("Could not add role: '{0}'.", tbRole.Text);
                foreach (var item in result.Errors) {
                    err += "<br />" + item.ToString();
                }
                lblMsg.Text = err;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

        } else {
            lblMsg.Text = string.Format("User '{0}' not found.", tbRole.Text);
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
        BindRoles();
    }
    protected void BindRoles()
    {
        gvRoles.DataSource = db.Roles.OrderBy(r => r.Name).ToList();
        gvRoles.DataBind();
    }*/

     
        // POST: AbuserRelationships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationUser abuserRelationship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abuserRelationship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(abuserRelationship);
        }

        /*
        // GET: AbuserRelationships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           // AbuserRelationship abuserRelationship = db.AbuserRelationships.Find(id);
            if (abuserRelationship == null)
            {
                return HttpNotFound();
            }
            return View(abuserRelationship);
        }

        // POST: AbuserRelationships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           // AbuserRelationship abuserRelationship = db.AbuserRelationships.Find(id);
           // db.AbuserRelationships.Remove(abuserRelationship);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

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
