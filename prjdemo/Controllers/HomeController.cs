using prjdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace prjdemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult List()
        {
            STUDBEntities db = new STUDBEntities();
            var table = from t in db.學生學籍資料
                        from o in db.系所資料
                        where t.DEPT_CODE == o.DEPT_CODE
                        select new HomeListViewModel
                        {
                            DEPT_NAME = o.DEPT_NAME,
                            STUD_NAME = t.STUD_NAME,
                            STUD_NO = t.STUD_NO
                        };

            return View(table);
        }

        public ActionResult Create()
        {
            STUDBEntities db = new STUDBEntities();

            List<SelectListItem> gender = new List<SelectListItem>()
            {
                new SelectListItem(){ Text = "男", Value="男"},
                new SelectListItem(){ Text = "女", Value="女"}
            };
            ViewBag.Gender = gender;

            List < SelectListItem > dept = db.系所資料.Select(d => new SelectListItem { Text = d.DEPT_NAME, Value = d.DEPT_CODE }).ToList();
            dept.Insert(0, new SelectListItem { Text = "選擇科系", Value = "" });
            ViewBag.SelectList = dept;
            return View();
        }

        [HttpPost]
        public ActionResult Create(學生學籍資料 s)
        {
            STUDBEntities db = new STUDBEntities();
            db.學生學籍資料.Add(s);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                STUDBEntities db = new STUDBEntities();
                學生學籍資料 t = db.學生學籍資料.FirstOrDefault(p => p.STUD_NO == id.ToString());
                if (t != null)
                {
                    db.學生學籍資料.Remove(t);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            STUDBEntities db = new STUDBEntities();
            學生學籍資料 t = db.學生學籍資料.FirstOrDefault(s => s.STUD_NO == id.ToString());
            if (t == null)
                return RedirectToAction("List");


            List<SelectListItem> gender = new List<SelectListItem>()
            {
                new SelectListItem(){ Text = "男", Value="男"},
                new SelectListItem(){ Text = "女", Value="女"}
            };
            ViewBag.Gender = gender;

            List<SelectListItem> dept = db.系所資料.Select(d => new SelectListItem { Text = d.DEPT_NAME, Value = d.DEPT_CODE }).ToList();
            dept.Insert(0, new SelectListItem { Text = "選擇科系", Value = "" });
            
            ViewBag.SelectList = dept;

            return View(t);
        }

        [HttpPost]
        public ActionResult Edit(學生學籍資料 prod)
        {

            STUDBEntities db = new STUDBEntities();
            學生學籍資料 sEdit = db.學生學籍資料.FirstOrDefault(s => s.STUD_NO == prod.STUD_NO);
            if (sEdit != null)
            {
                sEdit.STUD_NAME = prod.STUD_NAME;
                sEdit.SEX = prod.SEX;
                sEdit.DEPT_CODE = prod.DEPT_CODE;
                sEdit.TEL = prod.TEL;
                sEdit.ADDRESS = prod.ADDRESS;

                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult Select(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            STUDBEntities db = new STUDBEntities();
            var table =
               from x in db.學生選課資料
               from o in db.學期課程資料
               from y in db.課程資料
               from a in db.系所資料
               where x.STUD_NO == id.ToString() && x.COURSE_NO == o.COURSE_NO && o.SUBJ_NO == y.SUBJ_NO && o.DEPT_CODE == a.DEPT_CODE
               select new HomeSelectViewModel
                {
                    STUD_NO = x.STUD_NO,
                    ACAD_YEAR = x.ACAD_YEAR,
                    COURSE_NO = x.COURSE_NO,
                    SUBJ_NAME = y.SUBJ_NAME,
                    DEPT_NAME = a.DEPT_NAME
                };
            return View(table);
        }
    }
}