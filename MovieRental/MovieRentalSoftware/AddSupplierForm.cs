using System;
using System.Windows.Forms;

namespace MovieRentalSoftware
{
    public partial class AddSupplierForm : Form
    {
        private int adminId;
        private Movie_Rental_ManagementDataSetTableAdapters.SUPPLIERTableAdapter supplierTableAdapter;
        private Movie_Rental_ManagementDataSet.SUPPLIERDataTable supplierTable;

        public AddSupplierForm(int adminId)
        {
            InitializeComponent();
            this.adminId = adminId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string contactInfo = txtContactInfo.Text.Trim();
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(contactInfo))
            {
                MessageBox.Show("Please enter supplier name and contact info.");
                return;
            }
            supplierTableAdapter = new Movie_Rental_ManagementDataSetTableAdapters.SUPPLIERTableAdapter();
            supplierTable = new Movie_Rental_ManagementDataSet.SUPPLIERDataTable();
            supplierTableAdapter.Fill(supplierTable);
            int maxId = 0;
            foreach (System.Data.DataRow row in supplierTable.Rows)
            {
                int id = Convert.ToInt32(row["SUPPLIER_ID"]);
                if (id > maxId) maxId = id;
            }
            int nextSupplierId = maxId + 1;
            supplierTableAdapter.Insert(nextSupplierId, adminId, name, contactInfo);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
} 