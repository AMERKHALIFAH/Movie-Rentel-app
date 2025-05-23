namespace MovieRentalSoftware
{
    partial class AdminPanel
    {
        private Guna.UI2.WinForms.Guna2DataGridView dataGridViewMovies;
        private Guna.UI2.WinForms.Guna2Button btnAddMovie;
        private Guna.UI2.WinForms.Guna2Button btnEditMovie;
        private Guna.UI2.WinForms.Guna2Button btnDeleteMovie;

        private void InitializeComponent()
        {
            this.dataGridViewMovies = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnAddMovie = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditMovie = new Guna.UI2.WinForms.Guna2Button();
            this.btnDeleteMovie = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovies)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMovies
            // 
            this.dataGridViewMovies.AllowUserToAddRows = false;
            this.dataGridViewMovies.AllowUserToDeleteRows = false;
            this.dataGridViewMovies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMovies.Location = new System.Drawing.Point(30, 30);
            this.dataGridViewMovies.Name = "dataGridViewMovies";
            this.dataGridViewMovies.ReadOnly = true;
            this.dataGridViewMovies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMovies.Size = new System.Drawing.Size(740, 350);
            this.dataGridViewMovies.TabIndex = 0;
            // 
            // btnAddMovie
            // 
            this.btnAddMovie.Animated = true;
            this.btnAddMovie.BorderRadius = 8;
            this.btnAddMovie.FillColor = System.Drawing.Color.FromArgb(0, 192, 0);
            this.btnAddMovie.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAddMovie.ForeColor = System.Drawing.Color.White;
            this.btnAddMovie.Location = new System.Drawing.Point(30, 400);
            this.btnAddMovie.Name = "btnAddMovie";
            this.btnAddMovie.Size = new System.Drawing.Size(220, 45);
            this.btnAddMovie.TabIndex = 1;
            this.btnAddMovie.Text = "Add Movie";
            this.btnAddMovie.Click += new System.EventHandler(this.btnAddMovie_Click);
            // 
            // btnEditMovie
            // 
            this.btnEditMovie.Animated = true;
            this.btnEditMovie.BorderRadius = 8;
            this.btnEditMovie.FillColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnEditMovie.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnEditMovie.ForeColor = System.Drawing.Color.White;
            this.btnEditMovie.Location = new System.Drawing.Point(290, 400);
            this.btnEditMovie.Name = "btnEditMovie";
            this.btnEditMovie.Size = new System.Drawing.Size(220, 45);
            this.btnEditMovie.TabIndex = 2;
            this.btnEditMovie.Text = "Edit Movie";
            this.btnEditMovie.Click += new System.EventHandler(this.btnEditMovie_Click);
            // 
            // btnDeleteMovie
            // 
            this.btnDeleteMovie.Animated = true;
            this.btnDeleteMovie.BorderRadius = 8;
            this.btnDeleteMovie.FillColor = System.Drawing.Color.FromArgb(192, 0, 0);
            this.btnDeleteMovie.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnDeleteMovie.ForeColor = System.Drawing.Color.White;
            this.btnDeleteMovie.Location = new System.Drawing.Point(550, 400);
            this.btnDeleteMovie.Name = "btnDeleteMovie";
            this.btnDeleteMovie.Size = new System.Drawing.Size(220, 45);
            this.btnDeleteMovie.TabIndex = 3;
            this.btnDeleteMovie.Text = "Delete Movie";
            this.btnDeleteMovie.Click += new System.EventHandler(this.btnDeleteMovie_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.dataGridViewMovies);
            this.Controls.Add(this.btnAddMovie);
            this.Controls.Add(this.btnEditMovie);
            this.Controls.Add(this.btnDeleteMovie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Panel";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovies)).EndInit();
            this.ResumeLayout(false);
        }
    }
} 