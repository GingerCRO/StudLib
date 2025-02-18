using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using StudentLibrary.Classes;

namespace StudentLibrary
{
    public partial class FormStudents : Form
    {

        string dbConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\C#\\StudLib\\Database\\Database.mdf;Integrated Security=True";

        string query = "SELECT Id, StudentId, Name, Surname, UniversityName, Address, Phone FROM Students";
        string queryDelete = "DELETE FROM Students WHERE Id = @Id";

        public FormStudents()
        {
            InitializeComponent();
        }

        private void FormStudents_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void DataRefresh()
        {
            lbStudents.Items.Clear();
            LoadStudents();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            FormStudentDetails fsd = new FormStudentDetails();

            if (fsd.ShowDialog() == DialogResult.OK)
            {
                DataRefresh();
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            FormStudentDetails fsd = new FormStudentDetails();

            if (lbStudents.SelectedIndex < 0)
            {
                MessageBox.Show("You have to select a student!");
            }
            else
            {
                fsd.s = (Student)lbStudents.SelectedItem;

                if (fsd.ShowDialog() == DialogResult.OK)
                {
                    DataRefresh();
                }
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            if (lbStudents.SelectedIndex < 0)
            {
                MessageBox.Show("You have to select a student!");
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(dbConnection))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(queryDelete, connection))
                    {

                        Student studentToDelete = (Student)lbStudents.SelectedItem;

                        command.Parameters.AddWithValue("@Id", studentToDelete.Id);

                        command.ExecuteNonQuery();

                    }
                }
                DataRefresh();
            }

        }

        private void LoadStudents()
        {

            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Student student = new Student();

                            student.Id = reader.GetInt32(0).ToString();
                            student.StudentId = reader[1].ToString();
                            student.Name = reader[2].ToString();
                            student.Surname = reader[3].ToString();
                            student.UniversityName = reader[4].ToString();
                            student.Address = reader[5].ToString();
                            student.Phone = reader[6].ToString();

                            lbStudents.Items.Add(student);

                        }
                    }
                }
            }

        }

    }
}
