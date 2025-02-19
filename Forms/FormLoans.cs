using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using StudentLibrary.Classes;


namespace StudentLibrary
{
    public partial class FormLoans : Form
    {

        string dbConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\C#\\StudLib\\Database\\Database.mdf;Integrated Security=True";
        string queryDelete = "DELETE FROM Loans WHERE Id = @Id";
        string queryLoad = "SELECT Loans.Id, Loans.StudentId, Students.Name, Students.Surname, Loans.BookId, Books.Title, Loans.LoanDate, Loans.NumberOfDays FROM Loans JOIN Students ON Loans.StudentId = Students.Id JOIN Books ON Loans.BookId = Books.Id";

        public FormLoans()
        {
            InitializeComponent();
        }

        private void FormLoans_Load(object sender, EventArgs e)
        {
            DataRefresh();
        }

        private void DataRefresh()
        {

            lbLoans.Items.Clear();
            LoadData();

        }

        private void btnStudents_Click(object sender, EventArgs e)
        {

            FormStudents formStudents = new FormStudents();
            formStudents.ShowDialog();

        }

        private void btnBooks_Click(object sender, EventArgs e)
        {

            FormBooks formBooks = new FormBooks();
            formBooks.ShowDialog();

        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {

            FormLoanDetails fld = new FormLoanDetails();

            if (fld.ShowDialog() == DialogResult.OK)
            {
                DataRefresh();
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            FormLoanDetails fld = new FormLoanDetails();

            if (lbLoans.SelectedIndex < 0)
            {
                MessageBox.Show("You have to select a loan!");
            }
            else
            {
                fld.l = (Loan)lbLoans.SelectedItem;

                if (fld.ShowDialog() == DialogResult.OK)
                {
                    DataRefresh();
                }
            }

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {

            if (lbLoans.SelectedIndex < 0)
            {
                MessageBox.Show("You have to select a loan!");
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(dbConnection))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(queryDelete, connection))
                    {

                        Loan loanToDelete = (Loan)lbLoans.SelectedItem;

                        command.Parameters.AddWithValue("@Id", loanToDelete.Id);

                        command.ExecuteNonQuery();

                    }
                }
                DataRefresh();
            }

        }

        private void LoadData()
        {

            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryLoad, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Loan loan = new Loan();
                            loan.Id = reader.GetInt32(0).ToString();

                            Student student = new Student();
                            student.Id = reader.GetInt32(1).ToString();
                            student.Name = reader.GetString(2);
                            student.Surname = reader.GetString(3);

                            Book book = new Book();
                            book.Id = reader.GetInt32(4).ToString();
                            book.Title = reader.GetString(5);

                            loan.LoanDate = reader.GetDateTime(6);
                            loan.NumberOfDays = reader.GetInt32(7);

                            loan.Student = student;
                            loan.Book = book;

                            lbLoans.Items.Add(loan);

                        }
                    }
                }
            }             
        }

    }
}
