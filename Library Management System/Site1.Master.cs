using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace Library_Management_System
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["username"]==null)
            {
                
                    LinkButton1.Visible = true;
                    LinkButton2.Visible = true;
                    LinkButton3.Visible = false;
                    LinkButton7.Visible = false;
                  

                    LinkButton9.Visible = false;
                    LinkButton8.Visible = false;
                    LinkButton10.Visible = false;
                    LinkButton11.Visible = false;
                    LinkButton12.Visible = false;
                    LinkButton6.Visible = false;

                
            }

            

            else if (Session["username"].ToString() == "admin")
            {
                LinkButton1.Visible = false;
                LinkButton2.Visible = true;
                LinkButton3.Visible = true;
                LinkButton7.Visible = true;
                LinkButton7.Text = "hello there Admin";
                LinkButton9.Visible = true;
                LinkButton8.Visible = true;
                LinkButton10.Visible = false;
                LinkButton11.Visible = false;
                LinkButton12.Visible = false;
                LinkButton6.Visible = false;
            }

            else if (Session["username"].ToString() == "user")
            {
                LinkButton1.Visible = false;
                LinkButton2.Visible = true;
                LinkButton3.Visible = false;
                LinkButton7.Visible = true;

                LinkButton7.Text = "hello " + Session["username"].ToString();

                LinkButton9.Visible = false;
                LinkButton8.Visible = false;
                LinkButton10.Visible = false;
                LinkButton11.Visible = true;
                LinkButton12.Visible = false;
                LinkButton6.Visible = false;
            }

        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("userlogin.aspx");
        }
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //LinkButton1.Visible = true;
            //LinkButton2.Visible = true;
            //LinkButton3.Visible = false;
            //LinkButton7.Visible = false;


            //LinkButton9.Visible = false;
            //LinkButton8.Visible = false;
            //LinkButton10.Visible = false;
            //LinkButton11.Visible = true;
            //LinkButton12.Visible = false;
            //LinkButton6.Visible = true;
            Response.Redirect("userlogin.aspx");
        }

        protected void viewbook(object sender, EventArgs e)
        {
            Response.Redirect("userviewbook.aspx");
        }
    }
}