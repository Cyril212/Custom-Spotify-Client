namespace SpotifyExp
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Play = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.username = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.Label();
            this.Country = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.PlaySong = new System.Windows.Forms.DataGridViewButtonColumn();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Album = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Band = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Release = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.trackNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uRLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trackInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(103, 215);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(75, 23);
            this.Play.TabIndex = 0;
            this.Play.Text = "Sign In";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Visible = false;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(-1, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(287, 263);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(486, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Saved Albums";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(87, 42);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(125, 125);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.Visible = false;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(100, 179);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(10, 13);
            this.username.TabIndex = 4;
            this.username.Text = " ";
            this.username.Visible = false;
            this.username.Click += new System.EventHandler(this.label2_Click);
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Location = new System.Drawing.Point(100, 204);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(10, 13);
            this.Email.TabIndex = 5;
            this.Email.Text = " ";
            this.Email.Visible = false;
            // 
            // Country
            // 
            this.Country.AutoSize = true;
            this.Country.Location = new System.Drawing.Point(100, 229);
            this.Country.Name = "Country";
            this.Country.Size = new System.Drawing.Size(10, 13);
            this.Country.TabIndex = 6;
            this.Country.Text = " ";
            this.Country.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(505, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Songs";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.trackNameDataGridViewTextBoxColumn,
            this.uRLDataGridViewTextBoxColumn,
            this.PlaySong});
            this.dataGridView2.DataSource = this.trackInfoBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(307, 273);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(425, 210);
            this.dataGridView2.TabIndex = 10;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // PlaySong
            // 
            this.PlaySong.HeaderText = "Play";
            this.PlaySong.Name = "PlaySong";
            this.PlaySong.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PlaySong.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PlaySong.Text = "Play";
            this.PlaySong.ToolTipText = "Play";
            this.PlaySong.UseColumnTextForButtonValue = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Album,
            this.Band,
            this.Release});
            this.listView1.Location = new System.Drawing.Point(307, 40);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(425, 198);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Album
            // 
            this.Album.Text = "Album";
            this.Album.Width = 142;
            // 
            // Band
            // 
            this.Band.Text = "Band";
            this.Band.Width = 165;
            // 
            // Release
            // 
            this.Release.Text = "Release";
            this.Release.Width = 113;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(87, 273);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(125, 125);
            this.flowLayoutPanel2.TabIndex = 4;
            this.flowLayoutPanel2.Visible = false;
            // 
            // trackNameDataGridViewTextBoxColumn
            // 
            this.trackNameDataGridViewTextBoxColumn.DataPropertyName = "TrackName";
            this.trackNameDataGridViewTextBoxColumn.HeaderText = "TrackName";
            this.trackNameDataGridViewTextBoxColumn.Name = "trackNameDataGridViewTextBoxColumn";
            // 
            // uRLDataGridViewTextBoxColumn
            // 
            this.uRLDataGridViewTextBoxColumn.DataPropertyName = "URL";
            this.uRLDataGridViewTextBoxColumn.HeaderText = "URL";
            this.uRLDataGridViewTextBoxColumn.Name = "uRLDataGridViewTextBoxColumn";
            // 
            // trackInfoBindingSource
            // 
            this.trackInfoBindingSource.DataSource = typeof(SpotifyExp.TrackInfo);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 254);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Country);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.username);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.Play);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Custom Spotify";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.Label Country;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Album;
        private System.Windows.Forms.ColumnHeader Band;
        private System.Windows.Forms.ColumnHeader Release;
        private System.Windows.Forms.BindingSource trackInfoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn trackNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uRLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn PlaySong;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}

