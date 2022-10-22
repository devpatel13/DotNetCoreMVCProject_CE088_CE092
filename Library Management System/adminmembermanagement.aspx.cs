using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System
{
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();

        }
        //user deatails go
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getdetais();
        }
        //active
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            changstatus("active");
        }
        //[ending
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
             changstatus("pending");
        }
        //disable
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
             changstatus("disable");
        }
        bool checkmemberid()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "select * from member where member_ID=@member_id;";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@member_ID", TextBox1.Text.Trim());

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
        void getdetais()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                //string query = "select * from admin_login_tb1 where username='"+adminidTextBox.Text.Trim()+"' and password='"+passTextBox.Text.Trim()+"'";
                string query = "select * from member where member_ID=@username";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", TextBox1.Text.Trim());

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
                        TextBox2.Text = dr.GetValue(1).ToString();
                        TextBox7.Text = dr.GetValue(10).ToString();
                        TextBox8.Text = dr.GetValue(2).ToString();
                        TextBox3.Text = dr.GetValue(3).ToString();
                        TextBox4.Text = dr.GetValue(4).ToString();
                        TextBox10.Text = dr.GetValue(6).ToString();
                        TextBox9.Text = dr.GetValue(5).ToString();
                        TextBox11.Text = dr.GetValue(7).ToString();
                        TextBox6.Text = dr.GetValue(8).ToString();
                    }
                    else
                    {
                        Response.Write("<script>alert('1')</script>");
                    }


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
        void delete_user()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                //string query = "select * from admin_login_tb1 where username='"+adminidTextBox.Text.Trim()+"' and password='"+passTextBox.Text.Trim()+"'";
                string query = "delete from member where  member_ID=@id";



                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", TextBox1.Text.Trim());
                cmd.ExecuteNonQuery();
                /*else
                {
                    Response.Write("<script>alert('User Invalid')</script>");
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('" + dr.GetValue(1).ToString() + "')</script>");

                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('User Invalid ')</script>");

                }*/
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());

            }
        }
        void changstatus(string status)
        {
            if (checkmemberid())
            {
                try
                {
                    SqlConnection con = new SqlConnection(cs);
                    //string query = "select * from admin_login_tb1 where username='"+adminidTextBox.Text.Trim()+"' and password='"+passTextBox.Text.Trim()+"'";
                    string query = "update member set account_status='" + status + "' where member_ID=@id";



                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", TextBox1.Text.Trim());
                    cmd.ExecuteNonQuery();
                    /*else
                    {
                        Response.Write("<script>alert('User Invalid')</script>");
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('" + dr.GetValue(1).ToString() + "')</script>");

                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('User Invalid ')</script>");

                    }*/
                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());

                }
            }
            else
            {
                Response.Write("<script>alert('user not found')</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)    
        {
            if (checkmemberid())
            {
                delete_user();
            }
            else
            {
                Response.Write("<script>alert('user not found')</script>");
            }
        }
    }
       
    }
