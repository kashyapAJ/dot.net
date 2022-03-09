using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Product_Management
{
    public partial class Default : System.Web.UI.Page
    {//this is used for connection 
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9PML351\SQLEXPRESS; Initial Catalog=Ajay; Integrated Security=True");
        
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)//for output
        {
            if (!IsPostBack)
                FillGrid();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProductDesc.Text == null || txtProductName.Text == null ||
                txtProductDesc.Text.ToString().Trim().Equals("") || txtProductName.Text.ToString().Trim().Equals(""))
                    lblInfo.Text = "Please enter all fields";
                else
                {
                    
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "sp_AddProducts";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProName", txtProductName.Text.ToString());
                    cmd.Parameters.AddWithValue("@Prodesc", txtProductDesc.Text.ToString());
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand("Select ProName,ProDesc,OnDate from Products", con));
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    proDataGrid.DataSource = dt;
                    proDataGrid.DataBind();
                    adapter.Dispose();
                    cmd.Dispose();
                    con.Close();

                    lblInfo.Text = "Added Successfully";
                    txtProductDesc.Text = "";
                    txtProductName.Text = "";
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
                SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand("Select ProName,ProDesc,OnDate from Products", con));
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