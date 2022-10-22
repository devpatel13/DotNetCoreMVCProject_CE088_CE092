using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Library_Management_System
{
    public partial class login : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //log in    
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from member where member_ID='" + email.Text.Trim() + "' and password='" + password.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataReader dr = cmd.ExecuteReader();
     
                if (dr.HasRows)
                {
                    
                    while (dr.Read())
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert(logged in successfully)</script>");
                        Session["username"] = email.Text.Trim();
                        Session["full_name"] = dr.GetValue(2).ToString();
                        /*Session["role"] = "user";*/
                        Session["status"] = "active";
                        Session.Add("role", dr["isadmin"].ToString().Trim());
                    }
                    Response.Write("<scrpit>alert('alerrvdfb')</script>");
                    Response.Redirect("homepage.aspx",false);

                }
                else
                {
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('" + dr.GetValue(1).ToString() + "')</script>");

                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('User Invalid ')</script>");
                    Response.Write("<scrpit>alert('user id invalid')</script>");

                }
                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());

            }
            
        }
        //sign up
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }
    }
}