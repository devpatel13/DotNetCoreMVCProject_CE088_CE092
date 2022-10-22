using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Library_Management_System
{
    public partial class userlogin : System.Web.UI.Page
    {   
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["usernmae"] = "user";
            Session["role"] = null;
            Session["fullname"] = null;
            Session["status"] = null;
            Response.Redirect("homepage.aspx", false);
            Response.Redirect("usersignup.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from member where member_ID='"+email.Text.Trim() +"' and password='"+password.Text.Trim()+"'" ;
                SqlCommand cmd = new SqlCommand(query, con);
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataReader dr = cmd.ExecuteReader();
                Response.Write(dr.HasRows);
                if (dr.HasRows)
                {
                    Session["user_sess"] = email.Text;
                    while (dr.Read())
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert(logged in successfully)</script>");
                        Session["username"] = email.Text.Trim();
                        Session["full_name"] = dr.GetValue(2).ToString();
                        /*Session["role"] = "user";*/
                        Session["status"] = "active";
                        Session.Add("role", dr["isadmin"].ToString());
                    }
                    Response.Write(Session["full_name"]);
                }
                else
                {
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('" + dr.GetValue(1).ToString() + "')</script>");

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('User Invalid ')</script>");

                }
                con.Close();
                
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                
            }
            Response.Redirect("homepage.aspx");
        }
    }
}