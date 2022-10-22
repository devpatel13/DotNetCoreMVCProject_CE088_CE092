using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Library_Management_System
{
    public partial class usersignup : System.Web.UI.Page
    {

        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkid())
            {
                Response.Write("<script>alert('Member id already exist')</script>");
            }
            else
            {
                newuser();
                Session["role"] = "0";
                Response.Write("<script>alert('Member added Suc')</script>");
                Response.Redirect("homepage.aspx",false);
                
            }
             
        }
        bool checkid()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "select * from member where member_ID=@member_id;";
                SqlCommand cmd = new SqlCommand(query, con);
                
                cmd.Parameters.AddWithValue("@member_ID", uid.Text.Trim());
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count>=1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                throw;
            }
        }
        void newuser()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "insert into member(member_ID,dob,full_name,password,contact_no,email,state,city,pincode,address,account_status) values(@member_id,@dob,@full_name,@password,@contact_no,@email,@state,@city,@pincode,@address,@pending)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@member_ID", uid.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", dob.Text.Trim());
                cmd.Parameters.AddWithValue("@full_name", fn.Text.Trim());
                cmd.Parameters.AddWithValue("@password", pass.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", cn.Text.Trim());
                cmd.Parameters.AddWithValue("@email", ma.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", ci.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", pin.Text.Trim());
                cmd.Parameters.AddWithValue("@address", fa.Text.Trim());
                cmd.Parameters.AddWithValue("@pending", "pending");
                Session.Add("username", uid.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('sign in successfull')</script>");
            }
            catch (Exception ex)
            {

                Response.Write(ex.ToString());
            }
        }
        
    }
   
}