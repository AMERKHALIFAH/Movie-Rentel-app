using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MovieRentalSoftware
{
    public partial class LoginForm : Form
    {
        private Movie_Rental_ManagementDataSetTableAdapters.CLIENTTableAdapter clientTableAdapter;
        private Movie_Rental_ManagementDataSet.CLIENTDataTable clientDataTable;
        private Movie_Rental_ManagementDataSetTableAdapters.ADMINTableAdapter adminTableAdapter;
        private Movie_Rental_ManagementDataSet.ADMINDataTable adminDataTable;
        public static int LoggedInClientId { get; set; } // To store Client_ID

        public LoginForm()
        {
            InitializeComponent();
            // Ensure password characters are used for the password textbox
            if (this.txtLoginPassword != null) 
            {
                 this.txtLoginPassword.PasswordChar = '*';
            }
        }

        private void btnLoginSubmit_Click(object sender, EventArgs e)
        {
            string name = txtLoginName.Text.Trim();
            string password = txtLoginPassword.Text;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both name and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                // Check admin first
                adminTableAdapter = new Movie_Rental_ManagementDataSetTableAdapters.ADMINTableAdapter();
                adminDataTable = new Movie_Rental_ManagementDataSet.ADMINDataTable();
                adminTableAdapter.Fill(adminDataTable);
                var adminRow = adminDataTable.FirstOrDefault(row => row.NAME == name && row.PASSWORD == password);
                if (adminRow != null)
                {
                    MessageBox.Show($"Welcome, Admin {name}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdminPanel adminPanel = new AdminPanel(adminRow.ADMIN_ID);
                    adminPanel.Show();
                    this.Hide();
                    return;
                }
                // Check client
                clientTableAdapter = new Movie_Rental_ManagementDataSetTableAdapters.CLIENTTableAdapter();
                clientDataTable = new Movie_Rental_ManagementDataSet.CLIENTDataTable();
                clientTableAdapter.Fill(clientDataTable);
                var clientRow = clientDataTable.FirstOrDefault(row => row.NAME == name && row.PASSWORD == password);
                if (clientRow != null)
                {
                    LoggedInClientId = clientRow.CLIENT_ID;
                    MessageBox.Show($"Welcome, {name}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid name or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error during login: " + ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignInForm signInForm = new SignInForm();
            signInForm.Show();
            this.Hide(); // Hide the login form
        }
    }
}
