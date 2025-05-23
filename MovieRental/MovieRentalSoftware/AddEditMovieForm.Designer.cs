namespace MovieRentalSoftware
{
    partial class AddEditMovieForm
    {
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private Guna.UI2.WinForms.Guna2TextBox txtType;
        private Guna.UI2.WinForms.Guna2TextBox txtPrice;
        private Guna.UI2.WinForms.Guna2TextBox txtLeadActor;
        private Guna.UI2.WinForms.Guna2TextBox txtYear;
        private Guna.UI2.WinForms.Guna2TextBox txtAgeRestriction;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpAddingYear;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSupplier;
        private Guna.UI2.WinForms.Guna2Button btnAddSupplier;
        private Guna.UI2.WinForms.Guna2Button btnSave;

        private void InitializeComponent()
        {
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtType = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLeadActor = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtYear = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAgeRestriction = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpAddingYear = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cmbSupplier = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAddSupplier = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // txtName
            this.txtName.PlaceholderText = "Movie Name";
            this.txtName.Location = new System.Drawing.Point(30, 30);
            this.txtName.Size = new System.Drawing.Size(300, 36);
            // txtType
            this.txtType.PlaceholderText = "Type/Genre";
            this.txtType.Location = new System.Drawing.Point(30, 80);
            this.txtType.Size = new System.Drawing.Size(300, 36);
            // txtPrice
            this.txtPrice.PlaceholderText = "Price";
            this.txtPrice.Location = new System.Drawing.Point(30, 130);
            this.txtPrice.Size = new System.Drawing.Size(300, 36);
            // txtLeadActor
            this.txtLeadActor.PlaceholderText = "Lead Actor";
            this.txtLeadActor.Location = new System.Drawing.Point(30, 180);
            this.txtLeadActor.Size = new System.Drawing.Size(300, 36);
            // txtYear
            this.txtYear.PlaceholderText = "Year";
            this.txtYear.Location = new System.Drawing.Point(30, 230);
            this.txtYear.Size = new System.Drawing.Size(300, 36);
            // txtAgeRestriction
            this.txtAgeRestriction.PlaceholderText = "Age Restriction";
            this.txtAgeRestriction.Location = new System.Drawing.Point(30, 280);
            this.txtAgeRestriction.Size = new System.Drawing.Size(300, 36);
            // dtpAddingYear
            this.dtpAddingYear.Location = new System.Drawing.Point(30, 330);
            this.dtpAddingYear.Size = new System.Drawing.Size(300, 36);
            // cmbSupplier
            this.cmbSupplier.Location = new System.Drawing.Point(30, 380);
            this.cmbSupplier.Size = new System.Drawing.Size(220, 36);
            // btnAddSupplier
            this.btnAddSupplier.Text = "Add Supplier";
            this.btnAddSupplier.Location = new System.Drawing.Point(260, 380);
            this.btnAddSupplier.Size = new System.Drawing.Size(120, 36);
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // btnSave
            this.btnSave.Text = "Save";
            this.btnSave.Location = new System.Drawing.Point(30, 430);
            this.btnSave.Size = new System.Drawing.Size(350, 45);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // AddEditMovieForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 500);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtLeadActor);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtAgeRestriction);
            this.Controls.Add(this.dtpAddingYear);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.btnAddSupplier);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddEditMovieForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Movie";
            this.ResumeLayout(false);
        }
    }
} 