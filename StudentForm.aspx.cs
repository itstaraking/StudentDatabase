using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace StudentDatabase
{
    public partial class StudentForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Students(StudentName, StartDate, Program, TransferCredits) VALUES(@StudentName, @StartDate, @Program, @TransferCredits)";
            if(tbStudentName.Text !="" && tbStartDate.Text !="" && tbProgram.Text != "")
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@StudentName", tbStudentName.Text);
                    command.Parameters.AddWithValue("@StartDate", tbStartDate.Text);
                    command.Parameters.AddWithValue("@Program", tbProgram.Text);
                    command.Parameters.AddWithValue("@TransferCredits", tbTransferCredits.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                    ClearFields();
                }
            }
            else
            {
                lblConfirmation.Text = "Please Enter Student Name, Start Date and Program";
            }
            BindGrid();
        }
        private void ClearFields()
        {
            tbStudentName.Text = "";
            tbStartDate.Text = "";
            tbProgram.Text = "";
            tbTransferCredits.Text = "";
            tbStudentName.Focus();
        }

        private void BindGrid()
        {
            string connection = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connection))
            {
                using (SqlCommand command = new SqlCommand("SELECT StudentName, StartDate, Program, TransferCredits FROM Students"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        command.Connection = conn;
                        sda.SelectCommand = command;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if(tbStudentName.Text != "")
            {
                string query = "DELETE FROM Students WHERE StudentName = @StudentName";
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@StudentName", tbStudentName.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                    ClearFields();
                    BindGrid();
                }
            }
            else
            {
                lblConfirmation.Text = "Enter First Name To Be Deleted";
                ClearFields();
            }


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Students SET StudentName = @StudentName, StartDate = @StartDate, Program = @Program, TransferCredits = @TransferCredits WHERE StudentName = @StudentName";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@StudentName", tbStudentName.Text);
                command.Parameters.AddWithValue("@StartDate", tbStartDate.Text);
                command.Parameters.AddWithValue("@Program", tbProgram.Text);
                command.Parameters.AddWithValue("@TransferCredits", tbTransferCredits.Text);
                command.ExecuteNonQuery();
                connection.Close();
                ClearFields();
                BindGrid();
            }
        }
    }
}