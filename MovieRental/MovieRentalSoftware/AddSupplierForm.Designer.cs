namespace MovieRentalSoftware
{
    partial class AddSupplierForm
    {
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private Guna.UI2.WinForms.Guna2TextBox txtContactInfo;
        private Guna.UI2.WinForms.Guna2Button btnSave;

        private void InitializeComponent()
        {
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtContactInfo = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // txtName
            this.txtName.PlaceholderText = "Supplier Name";
            this.txtName.Location = new System.Drawing.Point(30, 30);
            this.txtName.Size = new System.Drawing.Size(300, 36);
            // txtContactInfo
            this.txtContactInfo.PlaceholderText = "Contact Info";
            this.txtContactInfo.Location = new System.Drawing.Point(30, 80);
            this.txtContactInfo.Size = new System.Drawing.Size(300, 36);
            // btnSave
            this.btnSave.Text = "Save";
            this.btnSave.Location = new System.Drawing.Point(30, 130);
            this.btnSave.Size = new System.Drawing.Size(300, 45);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // AddSupplierForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 200);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtContactInfo);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddSupplierForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Supplier";
            this.ResumeLayout(false);
        }
    }
} 