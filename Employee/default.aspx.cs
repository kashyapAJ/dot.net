using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employee
{
    public partial class _default : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9PML351\SQLEXPRESS; Initial Catalog=EMPL; Integrated Security=True");
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FillGrid();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmpDes.Text == null || txtEmpName.Text == null ||
                txtEmpDes.Text.ToString().Trim().Equals("") || txtEmpName.Text.ToString().Trim().Equals(""))
                    lblInfo.Text = "Please enter all fields";
                else
                {
                   
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "sp_EMPL";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Emp_Name", txtEmpName.Text.ToString());
                    cmd.Parameters.AddWithValue("@Emp_des", txtEmpDes.Text.ToString());
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand("Select Emp_Name,Emp_Des,OnDate from Employees_DB", con));
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    proDataGrid.DataSource = dt;
                    proDataGrid.DataBind();
                    adapter.Dispose();
                    cmd.Dispose();
                    con.Close();

                    lblInfo.Text = "Added Successfully";
                    txtEmpDes.Text = "";
                    txtEmpName.Text = "";
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
                SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand("Select Emp_Name,Emp_Des,OnDate from Employees_DB", con));
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