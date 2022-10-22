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
using System.Security.Cryptography;

namespace Library_Management_System
{
    public partial class adminauthormanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["user"].ConnectionString;



        bool checkauthorid()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "select * from author where author_Id=@member_id;";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@member_ID",  TextBox3.Text.Trim());

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
        void updateauthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "update author set author_name=@author_name where author_id=@Id;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", name.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author updated successfully')</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write(ex.ToString());
            }
        }
        void deleteauthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "delete from author where author_id=@Id;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", TextBox3.Text.Trim());
                


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author deleted successfully')</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write(ex.ToString());
            }
        }
        void addauthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "insert into author(author_name) values(@name)";
                SqlCommand cmd = new SqlCommand(query, con);
                //cmd.Parameters.AddWithValue("@Id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@name", name.Text.Trim());
                

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author added successfully')</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write(ex.ToString());
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //add
        protected void Button3_Click(object sender, EventArgs e)
        {
            //if (checkauthorid())
            //{
            //    Response.Write("<script>alert('Author already exists')</script>");
                
            //}
            //else
            {
                addauthor();
            }
        }
        //update
        protected void Button5_Click(object sender, EventArgs e)
        {
            
            if (checkauthorid())
            {

                updateauthor();
            }
            else
            {
               
                Response.Write("<script>alert('Author does not exist')</script>");
            }
        }
        //delete
        protected void Button6_Click(object sender, EventArgs e)
        {
            if (checkauthorid())
            {

                deleteauthor();
            }
            else
            {

                Response.Write("<script>alert('Author does not exist')</script>");
            }
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        /* bool author_exist() { return true; }*/


    }
}