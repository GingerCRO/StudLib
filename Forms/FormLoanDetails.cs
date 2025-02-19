using StudentLibrary.Classes;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentLibrary
{
    public partial class FormLoanDetails : Form
    {

        public Loan l;

        bool edit;
        int index;

        string dbConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\C#\\StudLib\\Database\\Database.mdf;Integrated Security=True";
        string queryNew = "INSERT INTO Loans (StudentId, BookId, LoanDate, NumberOfDays) VALUES (@StudentId, @BookId, @LoanDate, @NumberOfDays)";
        string queryUpdate = "UPDATE Loans SET StudentId = @StudentId, BookId = @BookId, LoanDate = @LoanDate, NumberOfDays = @NumberOfDays WHERE Id = @Id";
        string queryLoadStudents = "SELECT Id, StudentId, Name, Surname, UniversityName, Address, Phone FROM Students";
        string queryLoadBooks = "SELECT Id, ISBN, Author, Title, YearOfRelease, QuantityNumber FROM Books";

        public FormLoanDetails()
        {
            InitializeComponent();
        }

        private void FormLoanDetails_Load(object sender, EventArgs e)
        {

            dtpLoanDate.Value = DateTime.Now;
            txtNumberOfDays.Text = "25";

            DataRefresh();

            edit = false;
            
            if (l != null)
            {
                edit = true;

                index = 0;
                foreach (Student student in lbStudents.Items)
                {
                    if (student.Id == l.Student.Id)
                    {
                        break;
                    }
                    ++index;
                }

                lbStudents.SetSelected(index, true);

                index = 0;
                foreach (Book book in lbBooks.Items)
                {
                    if (book.Id == l.Book.Id)
                    {
                        break;
                    }
                    ++index;
                }

                txtNumberOfDays.Text = l.NumberOfDays.ToString();
                lbBooks.SetSelected(index, true);

            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (lbStudents.SelectedIndex < 0 || lbBooks.SelectedIndex < 0 || txtNumberOfDays.Text == "")
            {
                MessageBox.Show("All fields are required!");
            }
            else
            {

                Student tempStudent = (Student)lbStudents.SelectedItem;
                Book tempBook = (Book)lbBooks.SelectedItem;

                if (!edit)
                {
                    using (SqlConnection connection = new SqlConnection(dbConnection))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(queryNew, connection))
                        {

                            command.Parameters.AddWithValue("@StudentId", int.Parse(tempStudent.Id));
                            command.Parameters.AddWithValue("@BookId", int.Parse(tempBook.Id));
                            command.Parameters.AddWithValue("@LoanDate", DateTime.Parse(dtpLoanDate.Value.ToString()));
                            command.Parameters.AddWithValue("@NumberOfDays", int.Parse(txtNumberOfDays.Text));

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

                            command.Parameters.AddWithValue("@Id", l.Id);
                            command.Parameters.AddWithValue("@StudentId", int.Parse(tempStudent.Id));
                            command.Parameters.AddWithValue("@BookId", int.Parse(tempBook.Id));
                            command.Parameters.AddWithValue("@LoanDate", DateTime.Parse(dtpLoanDate.Value.ToString()));
                            command.Parameters.AddWithValue("@NumberOfDays", int.Parse(txtNumberOfDays.Text));

                            command.ExecuteNonQuery();

                        }
                    }
                }

                DialogResult = DialogResult.OK;

            }

        }

        private void DataRefresh()
        {
            lbStudents.Items.Clear();
            lbBooks.Items.Clear();
            LoadData();
        }

        private void LoadData()
        {

            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryLoadStudents, connection))
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

            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryLoadBooks, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Book book = new Book();

                            book.Id = reader.GetInt32(0).ToString();
                            book.ISBN = reader[1].ToString();
                            book.Author = reader[2].ToString();
                            book.Title = reader[3].ToString();
                            book.YearOfRelease = reader[4].ToString();
                            book.QuantityNumber = int.Parse(reader.GetInt32(5).ToString());

                            lbBooks.Items.Add(book);

                        }
                    }
                }
            }

        }

    }
}
