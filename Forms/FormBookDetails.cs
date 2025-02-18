using StudentLibrary.Classes;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentLibrary
{
    public partial class FormBookDetails : Form
    {

        public Book b;

        private string dbConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\C#\\StudLib\\Database\\Database.mdf;Integrated Security=True";
        private string queryNew = "INSERT INTO Books (ISBN, Author, Title, YearOfRelease, QuantityNumber) VALUES (@ISBN, @Author, @Title, @YearOfRelease, @QuantityNumber)";
        private string queryUpdate = "UPDATE Books SET ISBN = @ISBN, Author = @Author, Title = @Title, YearOfRelease = @YearOfRelease, QuantityNumber = @QuantityNumber WHERE Id = @Id";

        bool edit;

        public FormBookDetails()
        {
            InitializeComponent();
        }

        private void FormBookDetails_Load(object sender, EventArgs e)
        {

            edit = false;

            if (b != null)
            {
                txtISBN.Text = b.ISBN;
                txtAuthor.Text = b.Author;
                txtTitle.Text = b.Title;
                txtYearOfRelease.Text = b.YearOfRelease;
                txtQuantityNumber.Text = b.QuantityNumber.ToString();

                edit = true;

            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (txtISBN.Text == "" || txtAuthor.Text == "" || txtTitle.Text == "" || txtYearOfRelease.Text == "" || txtQuantityNumber.Text == "")
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

                            command.Parameters.AddWithValue("@ISBN", txtISBN.Text);
                            command.Parameters.AddWithValue("@Author", txtAuthor.Text);
                            command.Parameters.AddWithValue("@Title", txtTitle.Text);
                            command.Parameters.AddWithValue("@YearOfRelease", txtYearOfRelease.Text);
                            command.Parameters.AddWithValue("@QuantityNumber", txtQuantityNumber.Text);

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

                            command.Parameters.AddWithValue("@Id", int.Parse(b.Id));
                            command.Parameters.AddWithValue("@ISBN", txtISBN.Text);
                            command.Parameters.AddWithValue("@Author", txtAuthor.Text);
                            command.Parameters.AddWithValue("@Title", txtTitle.Text);
                            command.Parameters.AddWithValue("@YearOfRelease", txtYearOfRelease.Text);
                            command.Parameters.AddWithValue("@QuantityNumber", txtQuantityNumber.Text);

                            command.ExecuteNonQuery();

                        }
                    }
                }

                DialogResult = DialogResult.OK;

            }

        }
    }
}
