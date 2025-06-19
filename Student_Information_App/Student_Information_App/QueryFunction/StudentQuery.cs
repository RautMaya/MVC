using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Student_Information_App.ExecuteFunction;
using Student_Information_App.Models;

namespace Student_Information_App.QueryFunction
{
    public class StudentQuery
    {
       
         Execute execute = new Execute();
public DataTable GetStudentDetails(int Id = 0)
{
    DataTable dt = new DataTable();
    string Query = "Select * from Student";

    if (Id > 0)
    {
        Query += " where Roll_No=" + Id;
    }
    dt = execute.ExcuteDatatble(Query);

    return dt;
}

           public int InsertData(StudentModel Model)
              {
                      string query = "Insert Into Student(Stud_Name,Mob_No,Address) values('" + Model.Stud_Name + "'," + Model.Mob_No + ",";
                      query += "'" + Model.Address + "') If(@@Error=0) Select 1 else Select 0";
                      int Res = execute.Excuteint(query);
                         return Res;
              }

                  public int UpdateData(StudentModel Model)
            {
                   string query = "Update Student Set Mob_No= " + Model.Mob_No + ", Address='" + Model.Address + "' where Roll_No=" + Model.Roll_No + "";
                   query += " If(@@Error=0) Select 1 else Select 0";

                  int Res = execute.Excuteint(query);

                 return Res;
              }

        public int DeleteData(int Id)
        {
            string query = "Delete From Student Where Roll_No" + Id;

            query += " If(@@Error=0) Select 1 else Select 0";

            int Res = execute.Excuteint(query);

            return Res;
        }

    }
}