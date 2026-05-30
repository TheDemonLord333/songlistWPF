namespace Songliste
{
    partial class AddSong
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
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_songtitle = new System.Windows.Forms.Label();
            this.txt_Title = new System.Windows.Forms.TextBox();
            this.lblArtist = new System.Windows.Forms.Label();
            this.txt_artist = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.txt_year = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.showPath = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.Location = new System.Drawing.Point(12, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(189, 25);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Song hinzufügen";
            // 
            // lbl_songtitle
            // 
            this.lbl_songtitle.AutoSize = true;
            this.lbl_songtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_songtitle.Location = new System.Drawing.Point(14, 48);
            this.lbl_songtitle.Name = "lbl_songtitle";
            this.lbl_songtitle.Size = new System.Drawing.Size(30, 15);
            this.lbl_songtitle.TabIndex = 1;
            this.lbl_songtitle.Text = "Titel";
            // 
            // txt_Title
            // 
            this.txt_Title.Location = new System.Drawing.Point(17, 66);
            this.txt_Title.Name = "txt_Title";
            this.txt_Title.Size = new System.Drawing.Size(100, 20);
            this.txt_Title.TabIndex = 2;
            // 
            // lblArtist
            // 
            this.lblArtist.AutoSize = true;
            this.lblArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtist.Location = new System.Drawing.Point(14, 106);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(33, 15);
            this.lblArtist.TabIndex = 3;
            this.lblArtist.Text = "Artist";
            // 
            // txt_artist
            // 
            this.txt_artist.Location = new System.Drawing.Point(17, 124);
            this.txt_artist.Name = "txt_artist";
            this.txt_artist.Size = new System.Drawing.Size(100, 20);
            this.txt_artist.TabIndex = 4;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(14, 179);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(32, 15);
            this.lblYear.TabIndex = 5;
            this.lblYear.Text = "Year";
            // 
            // txt_year
            // 
            this.txt_year.Location = new System.Drawing.Point(17, 195);
            this.txt_year.Name = "txt_year";
            this.txt_year.Size = new System.Drawing.Size(100, 20);
            this.txt_year.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(17, 247);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(184, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Hinzufügen";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // showPath
            // 
            this.showPath.AutoSize = true;
            this.showPath.Location = new System.Drawing.Point(129, 231);
            this.showPath.Name = "showPath";
            this.showPath.Size = new System.Drawing.Size(75, 13);
            this.showPath.TabIndex = 8;
            this.showPath.TabStop = true;
            this.showPath.Text = "Pfad anzeigen";
            this.showPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.showPath_LinkClicked);
            // 
            // AddSong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 281);
            this.Controls.Add(this.showPath);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txt_year);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.txt_artist);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.txt_Title);
            this.Controls.Add(this.lbl_songtitle);
            this.Controls.Add(this.lbl_title);
            this.Name = "AddSong";
            this.Text = "AddSong";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_songtitle;
        private System.Windows.Forms.TextBox txt_Title;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.TextBox txt_artist;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txt_year;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.LinkLabel showPath;
    }
}