using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;

namespace MovieRentalSoftware
{
    public partial class SignInForm : Form
    {
        private Movie_Rental_ManagementDataSetTableAdapters.CLIENTTableAdapter clientTableAdapter;
        private Movie_Rental_ManagementDataSetTableAdapters.ADDRESSTableAdapter addressTableAdapter;
        private Movie_Rental_ManagementDataSetTableAdapters.ADMINTableAdapter adminTableAdapter;

        public SignInForm()
        {
            InitializeComponent();
            if (cmbUserType.Items.Count > 0)
                cmbUserType.SelectedIndex = 0;
            if (this.txtPassword != null) this.txtPassword.PasswordChar = '*';
            if (this.txtConfirmPassword != null) this.txtConfirmPassword.PasswordChar = '*';
        }

        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isAdmin = cmbUserType.SelectedItem != null && cmbUserType.SelectedItem.ToString() == "Admin";
            txtAdminEmail.Visible = isAdmin;
            txtAdminRole.Visible = isAdmin;
            txtCreditCard.Visible = !isAdmin;
            txtResidAddress.Visible = !isAdmin;
            txtBussAddress.Visible = !isAdmin;
            txtBillingAddress.Visible = !isAdmin;
            txtPhone.Visible = !isAdmin;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string userType = cmbUserType.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword) || string.IsNullOrWhiteSpace(userType))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (userType == "Admin")
            {
                string email = txtAdminEmail.Text.Trim();
                string role = txtAdminRole.Text.Trim();
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(role))
                {
                    MessageBox.Show("Please fill in all admin fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    adminTableAdapter = new Movie_Rental_ManagementDataSetTableAdapters.ADMINTableAdapter();
                    var adminTable = new Movie_Rental_ManagementDataSet.ADMINDataTable();
                    adminTableAdapter.Fill(adminTable);
                    int nextAdminId = adminTable.Rows.Count > 0 ? adminTable.AsEnumerable().Max(r => r.Field<int>("ADMIN_ID")) + 1 : 1;
                    var newAdminRow = adminTable.NewADMINRow();
                    newAdminRow.ADMIN_ID = nextAdminId;
                    newAdminRow.NAME = name;
                    newAdminRow.PASSWORD = password;
                    newAdminRow.ROLE = role;
                    newAdminRow.EMAIL = email;
                    newAdminRow.SetADM_ADMIN_IDNull();
                    adminTable.AddADMINRow(newAdminRow);
                    adminTableAdapter.Update(adminTable);
                    MessageBox.Show("Admin registration successful! You can now log in.", "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdminPanel adminPanel = new AdminPanel(newAdminRow.ADMIN_ID);
                    adminPanel.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred during admin registration: " + ex.Message, "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            else
            {
                string phone = txtPhone.Text.Trim();
                string creditCard = txtCreditCard.Text.Trim();
                string residAddress = txtResidAddress.Text.Trim();
                string bussAddress = txtBussAddress.Text.Trim();
                string billingAddress = txtBillingAddress.Text.Trim();
                if (string.IsNullOrWhiteSpace(creditCard) || string.IsNullOrWhiteSpace(residAddress) || string.IsNullOrWhiteSpace(billingAddress))
                {
                    MessageBox.Show("Please fill in all required client fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    clientTableAdapter = new Movie_Rental_ManagementDataSetTableAdapters.CLIENTTableAdapter();
                    addressTableAdapter = new Movie_Rental_ManagementDataSetTableAdapters.ADDRESSTableAdapter();
                    Movie_Rental_ManagementDataSet.CLIENTDataTable clientTableForCount = new Movie_Rental_ManagementDataSet.CLIENTDataTable();
                    clientTableAdapter.Fill(clientTableForCount);
                    int currentClientCount = clientTableForCount.Rows.Count;
                    int nextClientId = currentClientCount + 1;
                    Movie_Rental_ManagementDataSet.CLIENTDataTable clientTable = new Movie_Rental_ManagementDataSet.CLIENTDataTable();
                    Movie_Rental_ManagementDataSet.CLIENTRow newClientRow = clientTable.NewCLIENTRow();
                    newClientRow.CLIENT_ID = nextClientId;
                    newClientRow.NAME = name;
                    newClientRow.PASSWORD = password;
                    if (!string.IsNullOrWhiteSpace(phone)) newClientRow.PHONE = phone;
                    else newClientRow.SetPHONENull();
                    newClientRow.CREDIT_CARD = creditCard;
                    clientTable.AddCLIENTRow(newClientRow);
                    clientTableAdapter.Update(clientTable);
                    int newClientIdFromRow = newClientRow.CLIENT_ID;
                    Movie_Rental_ManagementDataSet.ADDRESSDataTable addressTable = new Movie_Rental_ManagementDataSet.ADDRESSDataTable();
                    Movie_Rental_ManagementDataSet.ADDRESSRow newAddressRow = addressTable.NewADDRESSRow();
                    newAddressRow.CLIENT_ID = newClientIdFromRow;
                    newAddressRow.RESID_ADRS = residAddress;
                    if (!string.IsNullOrWhiteSpace(bussAddress)) newAddressRow.BUSS_ADRS = bussAddress;
                    else newAddressRow.BUSS_ADRS = "";
                    newAddressRow.BILLING_ADRS = billingAddress;
                    addressTable.AddADDRESSRow(newAddressRow);
                    addressTableAdapter.Update(addressTable);
                    MessageBox.Show("Registration successful! You can now log in.", "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Close();
                }
                catch (System.Data.ConstraintException ex)
                {
                    MessageBox.Show("Error during registration: A client with this information might already exist or there was a data conflict. \nDetails: " + ex.Message, "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred during registration: " + ex.Message, "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        // Remove unused guna2TextBox7_TextChanged if it's still present from the old design
        // private void guna2TextBox7_TextChanged(object sender, EventArgs e) { /* ... */ }
    }
}
