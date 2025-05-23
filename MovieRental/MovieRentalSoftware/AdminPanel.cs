using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MovieRentalSoftware
{
    public partial class AdminPanel : Form
    {
        private int adminId;
        private Movie_Rental_ManagementDataSetTableAdapters.MOVIETableAdapter movieTableAdapter;
        private Movie_Rental_ManagementDataSetTableAdapters.SUPPLIERTableAdapter supplierTableAdapter;
        private Movie_Rental_ManagementDataSetTableAdapters.RENTAL_DETAILTableAdapter rentalDetailTableAdapter;
        private Movie_Rental_ManagementDataSet.MOVIEDataTable movieTable;
        private Movie_Rental_ManagementDataSet.SUPPLIERDataTable supplierTable;
        private Movie_Rental_ManagementDataSet.RENTAL_DETAILDataTable rentalDetailTable;

        public AdminPanel(int adminId)
        {
            InitializeComponent();
            this.adminId = adminId;
            LoadMovies();
        }

        private void LoadMovies()
        {
            movieTableAdapter = new Movie_Rental_ManagementDataSetTableAdapters.MOVIETableAdapter();
            movieTable = new Movie_Rental_ManagementDataSet.MOVIEDataTable();
            movieTableAdapter.Fill(movieTable);
            dataGridViewMovies.DataSource = movieTable;
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            var addMovieForm = new AddEditMovieForm(adminId);
            if (addMovieForm.ShowDialog() == DialogResult.OK)
            {
                LoadMovies();
            }
        }

        private void btnEditMovie_Click(object sender, EventArgs e)
        {
            if (dataGridViewMovies.SelectedRows.Count > 0)
            {
                int movieId = Convert.ToInt32(dataGridViewMovies.SelectedRows[0].Cells["MOVIE_ID"].Value);
                var editMovieForm = new AddEditMovieForm(adminId, movieId);
                if (editMovieForm.ShowDialog() == DialogResult.OK)
                {
                    LoadMovies();
                }
            }
        }

        private void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            if (dataGridViewMovies.SelectedRows.Count > 0)
            {
                int movieId = Convert.ToInt32(dataGridViewMovies.SelectedRows[0].Cells["MOVIE_ID"].Value);
                string movieTitle = dataGridViewMovies.SelectedRows[0].Cells["NAME"].Value.ToString();
                
                rentalDetailTableAdapter = new Movie_Rental_ManagementDataSetTableAdapters.RENTAL_DETAILTableAdapter();
                rentalDetailTable = new Movie_Rental_ManagementDataSet.RENTAL_DETAILDataTable();
                rentalDetailTableAdapter.Fill(rentalDetailTable);
                
                var relatedRentals = rentalDetailTable.Where(rd => rd.MOVIE_ID == movieId).ToList();
                
                if (relatedRentals.Count > 0)
                {
                    DialogResult result = MessageBox.Show(
                        $"The movie '{movieTitle}' has {relatedRentals.Count} associated rental record(s). " +
                        "Deleting this movie will also delete all related rental records. " +
                        "Do you want to continue?",
                        "Delete Movie with Rental Records",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    
                    if (result != DialogResult.Yes)
                    {
                        return;
                    }
                    
                    foreach (var rentalDetail in relatedRentals)
                    {
                        rentalDetail.Delete();
                    }
                    rentalDetailTableAdapter.Update(rentalDetailTable);
                }
                
                var movieRow = movieTable.FindByMOVIE_ID(movieId);
                if (movieRow != null)
                {
                    movieRow.Delete();
                    movieTableAdapter.Update(movieTable);
                    LoadMovies();
                    MessageBox.Show($"Movie '{movieTitle}' has been deleted successfully.", "Movie Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a movie to delete.", "No Movie Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
} 