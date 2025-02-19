using StudentLibrary.Classes;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentLibrary
{
    public partial class FormBooks : Form
    {

        string dbConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\C#\\StudLib\\Database\\Database.mdf;Integrated Security=True";
        
        string query = "SELECT Id, ISBN, Author, Title, YearOfRelease, QuantityNumber FROM Books";
        string queryDelete = "DELETE FROM Books WHERE Id = @Id";

        public FormBooks()
        {
            InitializeComponent();
        }

        private void FormBooks_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void DataRefresh()
        {

            lbBooks.Items.Clear();
            LoadBooks();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            FormBookDetails fbd = new FormBookDetails();
            
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                DataRefresh();
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            FormBookDetails fbd = new FormBookDetails();

            if (lbBooks.SelectedIndex < 0)
            {
                MessageBox.Show("You have to select a book!");
            }
            else
            {
                fbd.b = (Book)lbBooks.SelectedItem;

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    DataRefresh();
                }
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            if (lbBooks.SelectedIndex < 0)
            {
                MessageBox.Show("You have to select a book!");
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(dbConnection))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(queryDelete, connection))
                    {

                        Book bookToDelete = (Book)lbBooks.SelectedItem;

                        command.Parameters.AddWithValue("@Id", bookToDelete.Id);

                        command.ExecuteNonQuery();

                    }
                }
                DataRefresh();
            }

        }

        private void LoadBooks()
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

                            Book book = new Book();

                            book.Id = reader.GetInt32(0).ToString();
                            book.ISBN = reader[1].ToString();
                            book.Author = reader[2].ToString();
                            book.Title = reader[3].ToString();
                            book.YearOfRelease = reader[4].ToString();
                            book.QuantityNumber = reader.GetInt32(5);

                            lbBooks.Items.Add(book);

                        }
                    }
                }
            }

        }

    }
}
