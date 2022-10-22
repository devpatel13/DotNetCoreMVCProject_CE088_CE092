using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System
{
    public partial class adminlogin : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button_Click1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                //string query = "select * from admin_login_tb1 where username='"+adminidTextBox.Text.Trim()+"' and password='"+passTextBox.Text.Trim()+"'";
                string query = "select * from admin where username=@username and password=@password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", adminidTextBox.Text);
                cmd.Parameters.AddWithValue("@password", passTextBox.Text);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    //Session["user_sess"] = adminidTextBox.Text;
                    if (dr.Read())
                    {
                        Response.Write("<script>alert('" + dr.GetValue(1).ToString() + "')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('1')</script>");
                    }
                    Session.Add("username", dr.GetValue(0).ToString());
                    Session.Add("fullname", dr.GetValue(1).ToString());
                    Session.Add("role", "admin");
                    //Session["status"] = "active";
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('User Invalid ')</script>");

                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('User Invalid')</script>");
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('" + dr.GetValue(1).ToString() + "')</script>");

                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('User Invalid ')</script>");

                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());

            }
        }
    }
}