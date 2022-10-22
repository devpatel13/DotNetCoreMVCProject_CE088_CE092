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
using System.IO;

namespace Library_Management_System
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
        static bool isAuthorSet = false;
        static bool ispubSet = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
            if(!isAuthorSet)
                author();
            /*if (!ispubSet)*/
               /* publisher();*/

        }
        //add
        protected void Button1_Click(object sender, EventArgs e)
        {
            addbook();
            //Response.Write("<script>alert('" + DropDownList3.SelectedIndex + "')</script>");
        }
        //upadte
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateBookByID();
        }
        //delete
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteBookByID();   
        }
        void deleteBookByID()
        {
            if (checkbookid())
            {
                try
                {
                    SqlConnection con = new SqlConnection(cs);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from book WHERE book_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book Deleted Successfully');</script>");

                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
        }

        void updateBookByID()
        {
            int global_actual_stock = 0, global_issued_books=0;
            if (checkbookid())
            {
                try
                {

                    int actual_stock = Convert.ToInt32(TextBox4.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBox5.Text.Trim());

                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                            return;


                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            TextBox5.Text = "" + current_stock;
                        }
                    }

                    string genres = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres = genres + ListBox1.Items[i] + ",";
                    }
                    genres = genres.Remove(genres.Length - 1);

                  

                    SqlConnection con = new SqlConnection(cs);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE book set book_name=@book_name, genre=@genre, author_name=@author_name, publisher_name=@publisher_name, publish_date=@publish_date, language=@language, edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link where book_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());                           
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());



                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Book Updated Successfully');</script>");


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");
            }
        }

        void addbook() {
            if (checkbookid())
            {
                Response.Write("<script>alert('book id already taken')</script>");
            }
            else
            {
                try
                {
                    string genres = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres = genres + ListBox1.Items[i] + ",";
                    }
                    
                    genres = genres.Remove(genres.Length - 1);
                    SqlConnection con = new SqlConnection(cs);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string query = "insert into book(book_id,book_name,genre,author_name,publish_date," +
                      "language,edition,book_cost,no_of_pages,book_descrpition,actual_stock,current_stock) " +
                      "values(@book_id,@book_name,@genre,@author_name,@publish_date,@language,@edition," +
                      "@book_cost,@no_of_pages,@book_descrpition,@actual_stock,@current_stock)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());

                    cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedValue);

                    cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_descrpition", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@current_stock", TextBox4.Text.Trim());
                    cmd.ExecuteNonQuery();
                    //cmd.Parameters.AddWithValue("@book_img_link", filepath);
                    Response.Write("<script>alert('book added scuccesfully')</script>");



                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                    Response.Write(ex.StackTrace);
                }
            }
        }

        bool checkbookid()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "select * from book where book_id=@book_id;";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());

                /*SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }*/
                SqlDataReader reader = cmd.ExecuteReader();
                return reader.HasRows;

            }
            catch (Exception ex)
            {
                Response.Write(ex);
                throw;
            }
        }
        void getBookByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book WHERE book_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                    TextBox3.Text = dt.Rows[0]["publish_date"].ToString();
                    TextBox9.Text = dt.Rows[0]["edition"].ToString();
                    TextBox10.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    TextBox11.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    TextBox4.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox5.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["book_description"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();

                    ListBox1.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                            {
                                ListBox1.Items[j].Selected = true;

                            }
                        }
                    }

                   /* global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();*/

                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }

            }
            catch (Exception ex)
            {

            }
        }
        void author()
        {
            try
            {
                SqlConnection con=new SqlConnection(cs);
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "select author_name from author;";
                SqlCommand cmd = new SqlCommand(query,con);
                /*SqlDataAdapter da=new SqlDataAdapter(cmd);
                DataTable dt=new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource=dt;
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();*/
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListItem listItem = new ListItem(reader["author_name"].ToString());
                    DropDownList3.Items.Add(listItem);
                }
                
                isAuthorSet = true;
            }
            catch (Exception exe)
            {
                Response.Write(exe);
                throw;
            }
        }
        void publisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "select publisher_name from publisher;";
                SqlCommand cmd = new SqlCommand(query, con);
                /*SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();*/
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListItem listItem = new ListItem(reader["publisher_name"].ToString());
                    DropDownList2.Items.Add(listItem);
                }

                ispubSet = true;
            }
            catch (Exception exe)
            {
                Response.Write(exe);
                throw;
            }
        }
        //go button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getBookByID();
        }
    }
}