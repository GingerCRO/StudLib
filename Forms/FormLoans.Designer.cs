namespace StudentLibrary
{
    partial class FormLoans
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.btnStudents = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBooks = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lbLoans = new System.Windows.Forms.ListBox();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStudents,
            this.btnBooks});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(651, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // btnStudents
            // 
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Size = new System.Drawing.Size(65, 20);
            this.btnStudents.Text = "Students";
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // btnBooks
            // 
            this.btnBooks.Name = "btnBooks";
            this.btnBooks.Size = new System.Drawing.Size(51, 20);
            this.btnBooks.Text = "Books";
            this.btnBooks.Click += new System.EventHandler(this.btnBooks_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Borrowed books";
            // 
            // lbLoans
            // 
            this.lbLoans.FormattingEnabled = true;
            this.lbLoans.Location = new System.Drawing.Point(15, 49);
            this.lbLoans.Name = "lbLoans";
            this.lbLoans.Size = new System.Drawing.Size(534, 290);
            this.lbLoans.TabIndex = 2;
            // 
            // btnBorrow
            // 
            this.btnBorrow.Location = new System.Drawing.Point(555, 49);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(88, 23);
            this.btnBorrow.TabIndex = 3;
            this.btnBorrow.Text = "Borrow a book";
            this.btnBorrow.UseVisualStyleBackColor = true;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(555, 78);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(88, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit a loan";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(555, 107);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(88, 23);
            this.btnReturn.TabIndex = 5;
            this.btnReturn.Text = "Return a book";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // FormLoans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 357);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.lbLoans);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormLoans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Library App v1.0";
            this.Load += new System.EventHandler(this.FormLoans_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem btnStudents;
        private System.Windows.Forms.ToolStripMenuItem btnBooks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbLoans;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnReturn;
    }
}

