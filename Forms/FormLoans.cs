using System;
using System.Windows.Forms;
using StudentLibrary.Classes;


namespace StudentLibrary
{
    public partial class FormLoans : Form
    {

        string dbConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\C#\\StudLib\\Database\\Database.mdf;Integrated Security=True";

        public FormLoans()
        {
            InitializeComponent();
        }

        private void FormLoans_Load(object sender, EventArgs e)
        {



        }

        private void DataRefresh()
        {

            

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

            

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {

            

        }

    }
}
