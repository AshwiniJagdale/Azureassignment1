using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCCrudOprationApp.Models
{
    public class SqlHelper
    {
        public IEnumerable<tbl_Employee> GetAllEmployee()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("usp_GetAllEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<tbl_Employee> Emp = new List<tbl_Employee>();
            while (reader.Read())
            {
                tbl_Employee db = new tbl_Employee();
                db.Id = (int)reader["Id"];
                db.Name = reader["Name"].ToString();
                db.Gender = reader["Gender"].ToString();
                db.City = reader["City"].ToString();
                db.Salary = (int)reader["Salary"];
                Emp.Add(db);
            }

            return Emp;
        }

        public void InsertEmployee(tbl_Employee emps)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("usp_InsertEmp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", emps.Id);
            cmd.Parameters.AddWithValue("@Name", emps.Name);
            cmd.Parameters.AddWithValue("@Gender", emps.Gender);
            cmd.Parameters.AddWithValue("@City", emps.City);
            cmd.Parameters.AddWithValue("@Salary", emps.Salary);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void UpdateEmployee(tbl_Employee emps)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("usp_UpdateEmp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", emps.Id);
            cmd.Parameters.AddWithValue("@Name", emps.Name);
            cmd.Parameters.AddWithValue("@Gender", emps.Gender);
            cmd.Parameters.AddWithValue("@City", emps.City);
            cmd.Parameters.AddWithValue("@Salary", emps.Salary);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void DelateEmployee(tbl_Employee emps)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("usp_DeleteEmp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", emps.Id);
            con.Open();
            cmd.ExecuteNonQuery();
        }

    }
}
    