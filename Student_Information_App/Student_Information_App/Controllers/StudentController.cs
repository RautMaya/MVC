using Student_Information_App.Models;
using Student_Information_App.QueryFunction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Information_App.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
           

            StudentQuery student = new StudentQuery();
            DataTable dt = student.GetStudentDetails();
            List<StudentModel> listModel = new List<StudentModel>();
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    StudentModel studentModel = new StudentModel();

                    studentModel.Roll_No = Convert.ToInt32(dr["Roll_No"]);
                    studentModel.Stud_Name = Convert.ToString(dr["Stud_Name"]);
                    studentModel.Mob_No = Convert.ToInt32(dr["Mob_No"]);
                    studentModel.Address = Convert.ToString(dr["Address"]);

                    listModel.Add(studentModel);
                }
            }
            return View(listModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            StudentModel studentModel = new StudentModel();


            studentModel.Stud_Name = Convert.ToString(collection["Stud_Name"]);

            if (!string.IsNullOrWhiteSpace(collection["Mob_No"]))
            {
                studentModel.Mob_No = Convert.ToInt32(collection["Mob_No"]);
            }
            studentModel.Address = Convert.ToString(collection["Address"]);

            if (string.IsNullOrWhiteSpace(studentModel.Stud_Name))
            {
                ModelState.AddModelError("Stud_Name", "Plese Enter Name");
            }
            StudentQuery Student = new StudentQuery();

            if (ModelState.IsValid)
            {
                int Res = Student.InsertData(studentModel);

                if (Res > 0)
                {
                    TempData["Message"] = "Data Inserted Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(studentModel);
                }
            }
            return View(studentModel);
        }

        public ActionResult Edit(int Id = 0)
        {
            StudentModel model = FillstudentDetails(Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            StudentModel studentModel = new StudentModel();
            studentModel.Stud_Name = Convert.ToString(collection["Stud_Name"]);
            studentModel.Roll_No = Convert.ToInt32(collection["Roll_No"]);
            if (!string.IsNullOrWhiteSpace(collection["Mob_No"]))
            {
                studentModel.Mob_No = Convert.ToInt32(collection["Mob_No"]);
            }
            studentModel.Address = Convert.ToString(collection["Address"]);

            if (string.IsNullOrWhiteSpace(studentModel.Stud_Name))
            {
                ModelState.AddModelError("Stud_Name", "Please Enter Company");
            }
            StudentQuery student = new StudentQuery();
            if (ModelState.IsValid)
            {
                int Res = student.UpdateData(studentModel);
                if (Res > 0)
                {
                    TempData["Message"] = "Data Update Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(studentModel);
                }
            }
            return View(studentModel);
        }

        public ActionResult Delete(int Id = 0)
        {
            StudentModel model = FillstudentDetails(Id);
            return View(model);
        }
        [HttpPost]

        public ActionResult Delete(FormCollection collection)
        {
            int RollNo = Convert.ToInt32(collection["Roll_No"]);
            StudentQuery student = new StudentQuery();
            int Res = student.DeleteData(RollNo);

            if(Res > 0)
            {
                TempData["Message"] = "Data Delete Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                StudentModel studentModel = FillstudentDetails(RollNo);
                return View(studentModel);
            }
        }
        public ActionResult Details(int Id = 0)
        {
            StudentModel model = FillstudentDetails(Id);
            return View(model);
        }

        public static StudentModel FillstudentDetails(int Id)
        {
            StudentModel studentModel = new StudentModel();

            StudentQuery student = new StudentQuery();
            DataTable dt = student.GetStudentDetails(Id);

            if(dt.Rows.Count> 0)
            {
                studentModel.Roll_No = Convert.ToInt32(dt.Rows[0]["Roll_No"]);
                studentModel.Stud_Name = Convert.ToString(dt.Rows[0]["Stud_Name"]);
                studentModel.Mob_No = Convert.ToInt32(dt.Rows[0]["Mob_No"]);
                studentModel.Address = Convert.ToString(dt.Rows[0]["Address"]);
            }
            return studentModel;
        }
    }
}