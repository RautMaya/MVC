﻿using Student_Information_App.Models;
using Student_Information_App.QueryFunction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Information_App.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            List<LocationModel> ListModel = new List<LocationModel>();
            return View(ListModel);
        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            
            ViewBag.student = LoadStudent();

            return View();
        }

        // POST: Location/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            LocationModel model = new LocationModel();
            try
            {
                // TODO: Add insert logic here

                
                model.RollNo = Convert.ToInt32(collection["RollNo"]);
                model.LocName = Convert.ToString(collection["LocName"]);
                model.Address = Convert.ToString(collection["Address"]);

                LocationQuery Location = new LocationQuery();
                int Res = Location.InsertData(model);

                if(Res > 0)
                {
                    return RedirectToAction("Index");
                }
              
            }
            catch
            {
                return View();
            }

            return View(model);
        }

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Location/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Location/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public List<SelectListItem> LoadStudent(int RollNo = 0)
        {
            List<SelectListItem> ListStudent = new List<SelectListItem>();

            StudentQuery student = new StudentQuery();
            DataTable dt = student.GetStudentDetails();

            if(dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    ListStudent.Add(new SelectListItem()
                    {
                        Text = Convert.ToString(dr["Stud_Name"]),
                        Value = Convert.ToString(dr["Roll_No"]),
                        Selected = RollNo == Convert.ToInt32(dr["Roll_No"])
                    });
                       
                }
            }
            return ListStudent;
        }
    }
}
