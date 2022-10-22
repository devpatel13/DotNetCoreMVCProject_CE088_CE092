using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Library_Management_System
{
    public partial class adminpublisher : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
        bool checkpublisherid()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "select * from publisher where publisher_Id=@member_id;";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@member_ID", TextBox3.Text.Trim());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
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
        void updatepublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "update publisher set publisher_name=@publisher_name where publisher_Id=@Id;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('publisher updated successfully')</script>");
                GridView2.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write(ex.ToString());
            }
        }
        void addpublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "insert into publisher(publisher_name) values(@name)";
                SqlCommand cmd = new SqlCommand(query, con);
                /*cmd.Parameters.AddWithValue("@Id", TextBox3.Text.Trim());*/
                cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('publisher added successfully')</script>");
                GridView2.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write(ex.ToString());
            }
        }
        void deletepublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "delete from publisher where publisher_id=@Id;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", TextBox3.Text.Trim());



                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('publisher deleted successfully')</script>");
                GridView2.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write(ex.ToString());
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //add
        protected void Button3_Click(object sender, EventArgs e)
        {
            /*if (checkpublisherid())
            {
                Response.Write("<script>alert('publisher already exists')</script>");

            }
            else
            {
                addpublisher();
            }*/
            addpublisher();
        }
        //update
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (checkpublisherid())
            {

                updatepublisher();
            }
            else
            {

                Response.Write("<script>alert('Author does not exist')</script>");
            }
        }
        //delete
        protected void Button6_Click(object sender, EventArgs e)
        {
            if (checkpublisherid())
            {

                deletepublisher();
            }
            else
            {

                Response.Write("<script>alert('Author does not exist')</script>");
            }
        }
    }
}