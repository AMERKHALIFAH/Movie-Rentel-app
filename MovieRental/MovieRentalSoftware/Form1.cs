using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MovieRentalSoftware
{
    public partial class Form1 : Form
    {
        private Movie_Rental_ManagementDataSetTableAdapters.MOVIETableAdapter movieTableAdapter;
        private Movie_Rental_ManagementDataSet.MOVIEDataTable movieDataTable;
        private Movie_Rental_ManagementDataSetTableAdapters.RENTAL_DETAILTableAdapter rentalDetailTableAdapter;
        private Movie_Rental_ManagementDataSet.RENTAL_DETAILDataTable rentalDetailDataTable;

        public Form1()
        {
            InitializeComponent();
            CustomizeDataGridView();
            LoadMoviesData();
        }

        private void CustomizeDataGridView()
        {
            if (moviesDataGridView != null)
            {
                // Style the DataGridView if it's a Guna2DataGridView
                if (moviesDataGridView is Guna.UI2.WinForms.Guna2DataGridView gdgv)
                {
                    gdgv.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    gdgv.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
                    gdgv.ThemeStyle.HeaderStyle.ForeColor = Color.White;
                    
                    gdgv.ThemeStyle.RowsStyle.BackColor = Color.White;
                    gdgv.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(240, 240, 240);
                    
                    gdgv.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
                    gdgv.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
                    
                    gdgv.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
                    gdgv.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
                    
                    gdgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    gdgv.GridColor = Color.FromArgb(231, 229, 255);
                }
            }
        }

        private void LoadMoviesData()
        {
            try
            {
                movieTableAdapter = new Movie_Rental_ManagementDataSetTableAdapters.MOVIETableAdapter();
                movieDataTable = new Movie_Rental_ManagementDataSet.MOVIEDataTable();
                movieTableAdapter.Fill(movieDataTable);
                moviesDataGridView.DataSource = movieDataTable;

                // Set column headers and formatting
                if (moviesDataGridView.Columns.Count > 0)
                {
                    if (moviesDataGridView.Columns.Contains("MOVIE_ID")) 
                        moviesDataGridView.Columns["MOVIE_ID"].HeaderText = "Movie ID";
                    
                    if (moviesDataGridView.Columns.Contains("ADMIN_ID")) 
                        moviesDataGridView.Columns["ADMIN_ID"].HeaderText = "Admin ID";
                    
                    if (moviesDataGridView.Columns.Contains("SUPPLIER_ID")) 
                        moviesDataGridView.Columns["SUPPLIER_ID"].HeaderText = "Supplier ID";
                    
                    if (moviesDataGridView.Columns.Contains("NAME")) 
                        moviesDataGridView.Columns["NAME"].HeaderText = "Movie Title";
                    
                    if (moviesDataGridView.Columns.Contains("TYPE")) 
                        moviesDataGridView.Columns["TYPE"].HeaderText = "Genre";
                    
                    if (moviesDataGridView.Columns.Contains("PRICE")) 
                        moviesDataGridView.Columns["PRICE"].HeaderText = "Price";
                    
                    if (moviesDataGridView.Columns.Contains("LEAD_ACTOR")) 
                        moviesDataGridView.Columns["LEAD_ACTOR"].HeaderText = "Lead Actor";
                    
                    if (moviesDataGridView.Columns.Contains("YEAR")) 
                        moviesDataGridView.Columns["YEAR"].HeaderText = "Release Year";
                    
                    if (moviesDataGridView.Columns.Contains("AGE_RESTRIECTION")) 
                        moviesDataGridView.Columns["AGE_RESTRIECTION"].HeaderText = "Age Restriction";
                    
                    if (moviesDataGridView.Columns.Contains("ADDING_YEAR")) 
                        moviesDataGridView.Columns["ADDING_YEAR"].HeaderText = "Date Added";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading movies: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackToMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void btnRentMovie_Click(object sender, EventArgs e)
        {
            if (moviesDataGridView.SelectedRows.Count > 0)
            {
                int movieId = Convert.ToInt32(moviesDataGridView.SelectedRows[0].Cells["MOVIE_ID"].Value);
                string movieName = moviesDataGridView.SelectedRows[0].Cells["NAME"].Value.ToString();
                double price = Convert.ToDouble(moviesDataGridView.SelectedRows[0].Cells["PRICE"].Value);
                int clientId = LoginForm.LoggedInClientId;
                if (clientId == 0)
                {
                    MessageBox.Show("You must be logged in as a client to rent a movie.", "Not Logged In", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DateTime returnDate = dtpReturnDate.Value;
                if (returnDate <= DateTime.Now)
                {
                    MessageBox.Show("Please select a valid return date in the future.", "Invalid Return Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var result = MessageBox.Show($"Do you want to rent '{movieName}' for ${price} and return it by {returnDate:d}?", "Rent Movie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    rentalDetailTableAdapter = new Movie_Rental_ManagementDataSetTableAdapters.RENTAL_DETAILTableAdapter();
                    rentalDetailDataTable = new Movie_Rental_ManagementDataSet.RENTAL_DETAILDataTable();
                    rentalDetailTableAdapter.Fill(rentalDetailDataTable);
                    int maxRentalId = 0;
                    foreach (System.Data.DataRow row in rentalDetailDataTable.Rows)
                    {
                        int id = Convert.ToInt32(row["RENTAL_ID"]);
                        if (id > maxRentalId) maxRentalId = id;
                    }
                    int nextRentalId = maxRentalId + 1;
                    DateTime rentalDate = DateTime.Now;
                    rentalDetailTableAdapter.Insert(nextRentalId, movieId, clientId, rentalDate, price, returnDate);
                    MessageBox.Show("Movie rented successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a movie to rent.", "Rent Movie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
