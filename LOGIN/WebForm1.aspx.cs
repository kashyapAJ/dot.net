using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            SqlConnection SQLConn = new SqlConnection(@"Data Source=DESKTOP-9PML351\SQLEXPRESS; Initial Catalog=Ajay; Integrated Security=True");
            lblmsg.Text = "";
            SqlDataAdapter SQLAdapter = new SqlDataAdapter("Select * from Login where username='" + txtusername.Text + "' and password='" + txtpassword.Text + "'", SQLConn);
            DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);

            if (DT.Rows.Count > 0)
            {
                lblmsg.Text = "Welcome to System";
                lblmsg.ForeColor = System.Drawing.Color.Green;
            }

            else
            {
                lblmsg.Text = "Invalid username or password";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}