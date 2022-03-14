using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace userinfo
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9PML351\SQLEXPRESS; Initial Catalog=User; Integrated Security=True");
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                    FillGrid();
            }
        }


        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == null || txtNumber.Text == null || City.SelectedValue == null || Gender.Text == null ||
                    txtemail.Text == null || txtpassword.Text == null ||// add more coloum
                txtName.Text.ToString().Trim().Equals("") || txtNumber.Text.ToString().Trim().Equals("") || Gender.Text.ToString().Trim().Equals("") || City.Text.ToString().Trim().Equals("") || txtpassword.Text.ToString().Trim().Equals("") || txtemail.Text.ToString().Trim().Equals(""))
                    lblInfo.Text = "Please enter all fields";
                else
                {

                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "sp_user";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UName", txtName.Text.ToString());
                    cmd.Parameters.AddWithValue("@Contact_Number", txtNumber.Text.ToString());
                    cmd.Parameters.AddWithValue("@Gender", Gender.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@City", City.SelectedValue);
                    cmd.Parameters.AddWithValue("@Email_ID", txtemail.Text.ToString());
                    cmd.Parameters.AddWithValue("@C_Password", txtpassword.Text.ToString());// add more parameter for coloum
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand("Select UName, Contact_Number,Gender,City,Email_ID,C_Password from User_Data", con));
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    proDataGrid.DataSource = dt;
                    proDataGrid.DataBind();
                    adapter.Dispose();
                    cmd.Dispose();
                    con.Close();

                    lblInfo.Text = "Added Successfully";
                    txtName.Text = "";
                    txtNumber.Text = "";
                    txtpassword.Text = "";
                    txtemail.Text = "";
                    City.Text = "";
                    Gender.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = "Error:" + ex.Message.ToString();
            }
        }


        public void FillGrid()
        {
            try
            {

                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand("Select UName, Contact_Number,Gender,City,Email_ID,C_Password from User_Data", con)); ///
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                proDataGrid.DataSource = dt;
                proDataGrid.DataBind();
                adapter.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}