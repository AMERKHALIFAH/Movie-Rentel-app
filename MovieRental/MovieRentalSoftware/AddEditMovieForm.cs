using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MovieRentalSoftware
{
    public partial class AddEditMovieForm : Form
    {
        private int adminId;
        private int? movieId;
        private Movie_Rental_ManagementDataSetTableAdapters.MOVIETableAdapter movieTableAdapter;
        private Movie_Rental_ManagementDataSetTableAdapters.SUPPLIERTableAdapter supplierTableAdapter;
        private Movie_Rental_ManagementDataSet.MOVIEDataTable movieTable;
        private Movie_Rental_ManagementDataSet.SUPPLIERDataTable supplierTable;

        public AddEditMovieForm(int adminId, int? movieId = null)
        {
            InitializeComponent();
            this.adminId = adminId;
            this.movieId = movieId;
            LoadSuppliers();
            if (movieId.HasValue)
                LoadMovie(movieId.Value);
        }

        private void LoadSuppliers()
        {
            supplierTableAdapter = new Movie_Rental_ManagementDataSetTableAdapters.SUPPLIERTableAdapter();
            supplierTable = new Movie_Rental_ManagementDataSet.SUPPLIERDataTable();
            supplierTableAdapter.Fill(supplierTable);
            cmbSupplier.DataSource = supplierTable;
            cmbSupplier.DisplayMember = "NAME";
            cmbSupplier.ValueMember = "SUPPLIER_ID";
        }

        private void LoadMovie(int movieId)
        {
            movieTableAdapter = new Movie_Rental_ManagementDataSetTableAdapters.MOVIETableAdapter();
            movieTable = new Movie_Rental_ManagementDataSet.MOVIEDataTable();
            movieTableAdapter.Fill(movieTable);
            var row = movieTable.FindByMOVIE_ID(movieId);
            if (row != null)
            {
                txtName.Text = row.NAME;
                txtType.Text = row.IsTYPENull() ? "" : row.TYPE;
                txtPrice.Text = row.PRICE.ToString();
                txtLeadActor.Text = row.IsLEAD_ACTORNull() ? "" : row.LEAD_ACTOR;
                txtYear.Text = row.IsYEARNull() ? "" : row.YEAR.ToString();
                txtAgeRestriction.Text = row.IsAGE_RESTRIECTIONNull() ? "" : row.AGE_RESTRIECTION.ToString();
                dtpAddingYear.Value = row.ADDING_YEAR;
                cmbSupplier.SelectedValue = row.SUPPLIER_ID;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string type = txtType.Text.Trim();
            double price;
            string leadActor = txtLeadActor.Text.Trim();
            int year, ageRestriction;
            DateTime addingYear = dtpAddingYear.Value;
            int supplierId = (int)cmbSupplier.SelectedValue;
            if (string.IsNullOrWhiteSpace(name) || !double.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Please enter valid movie name and price.");
                return;
            }
            int.TryParse(txtYear.Text, out year);
            int.TryParse(txtAgeRestriction.Text, out ageRestriction);
            movieTableAdapter = new Movie_Rental_ManagementDataSetTableAdapters.MOVIETableAdapter();
            movieTable = new Movie_Rental_ManagementDataSet.MOVIEDataTable();
            movieTableAdapter.Fill(movieTable);
            if (movieId.HasValue)
            {
                var row = movieTable.FindByMOVIE_ID(movieId.Value);
                if (row != null)
                {
                    row.NAME = name;
                    row.TYPE = type;
                    row.PRICE = price;
                    row.LEAD_ACTOR = leadActor;
                    row.YEAR = year;
                    row.AGE_RESTRIECTION = ageRestriction;
                    row.ADDING_YEAR = addingYear;
                    row.SUPPLIER_ID = supplierId;
                    movieTableAdapter.Update(movieTable);
                }
            }
            else
            {
                int maxMovieId = 0;
                foreach (System.Data.DataRow row in movieTable.Rows)
                {
                    int id = Convert.ToInt32(row["MOVIE_ID"]);
                    if (id > maxMovieId) maxMovieId = id;
                }
                int nextMovieId = maxMovieId + 1;
                movieTableAdapter.Insert(nextMovieId, adminId, supplierId, name, type, price, leadActor, year, ageRestriction, addingYear);
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            var addSupplierForm = new AddSupplierForm(adminId);
            if (addSupplierForm.ShowDialog() == DialogResult.OK)
            {
                LoadSuppliers();
            }
        }
    }
} 