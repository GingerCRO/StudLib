using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using StudentLibrary.Classes;

namespace StudentLibrary
{
    public partial class FormStudentDetails : Form
    {

        public Student s;

        private string dbConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\C#\\StudLib\\Database\\Database.mdf;Integrated Security=True";
        private string queryNew = "INSERT INTO Students (StudentId, Name, Surname, UniversityName, Address, Phone) VALUES (@StudentId, @Name, @Surname, @UniversityName, @Address, @Phone)";
        private string queryUpdate = "UPDATE Students SET StudentId = @StudentId, Name = @Name, Surname = @Surname, UniversityName = @UniversityName, Address = @Address, Phone = @Phone WHERE Id = @Id";

        bool edit;

        public FormStudentDetails()
        {
            InitializeComponent();
        }

        private void FormStudentDetails_Load(object sender, EventArgs e)
        {

            edit = false;

            if (s != null)
            {
                txtID.Text = s.StudentId;
                txtName.Text = s.Name;
                txtSurname.Text = s.Surname;
                txtUniversityName.Text = s.UniversityName;
                txtAddress.Text = s.Address;
                txtPhone.Text = s.Phone;

                edit = true;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (txtID.Text == "" || txtName.Text == "" || txtSurname.Text == "" || txtUniversityName.Text == "" || txtAddress.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("All fields are required!");
            }
            else
            {
                if (!edit)
                {
                    using (SqlConnection connection = new SqlConnection(dbConnection))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(queryNew, connection))
                        {

                            command.Parameters.AddWithValue("@StudentId", txtID.Text);
                            command.Parameters.AddWithValue("@Name", txtName.Text);
                            command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                            command.Parameters.AddWithValue("@UniversityName", txtUniversityName.Text);
                            command.Parameters.AddWithValue("@Address", txtAddress.Text);
                            command.Parameters.AddWithValue("@Phone", txtPhone.Text);

                            command.ExecuteNonQuery();

                        }
                    }
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(dbConnection))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(queryUpdate, connection))
                        {

                            command.Parameters.AddWithValue("@Id", s.Id);
                            command.Parameters.AddWithValue("@StudentId", txtID.Text);
                            command.Parameters.AddWithValue("@Name", txtName.Text);
                            command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                            command.Parameters.AddWithValue("@UniversityName", txtUniversityName.Text);
                            command.Parameters.AddWithValue("@Address", txtAddress.Text);
                            command.Parameters.AddWithValue("@Phone", txtPhone.Text);

                            command.ExecuteNonQuery();

                        }
                    }
                }

                DialogResult = DialogResult.OK;
            
            }
        }
    }
}
