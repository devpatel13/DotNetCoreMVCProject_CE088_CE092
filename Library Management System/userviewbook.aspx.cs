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
    public partial class userviewbook : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
            
        }
     /*   void getdata()
        {
            SqlConnection con=new SqlConnection(cs);
            try
            {
                SqlCommand cmd = new SqlCommand;
            }
            catch (Exception)
            {

                throw;
            }
        }*/
    }
}