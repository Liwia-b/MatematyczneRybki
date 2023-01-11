namespace Matematyczne_Rybki
{
    partial class Gra
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gra));
            this.startprzycisk = new System.Windows.Forms.Button();
            this.tytul = new System.Windows.Forms.Label();
            this.wyjdzzgry = new System.Windows.Forms.Button();
            this.rozpocznijodnowa = new System.Windows.Forms.Button();
            this.kontynuuj = new System.Windows.Forms.Button();
            this.nazwagracza = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // startprzycisk
            // 
            this.startprzycisk.AutoSize = true;
            this.startprzycisk.BackColor = System.Drawing.Color.Pink;
            this.startprzycisk.Font = new System.Drawing.Font("Cooper Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startprzycisk.Location = new System.Drawing.Point(169, 652);
            this.startprzycisk.Name = "startprzycisk";
            this.startprzycisk.Size = new System.Drawing.Size(708, 82);
            this.startprzycisk.TabIndex = 2;
            this.startprzycisk.Text = "rozpocznij gre";
            this.startprzycisk.UseVisualStyleBackColor = false;
            this.startprzycisk.Click += new System.EventHandler(this.start_Click);
            // 
            // tytul
            // 
            this.tytul.BackColor = System.Drawing.Color.Pink;
            this.tytul.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tytul.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tytul.Font = new System.Drawing.Font("Cooper Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tytul.ForeColor = System.Drawing.Color.Black;
            this.tytul.Location = new System.Drawing.Point(169, 65);
            this.tytul.Name = "tytul";
            this.tytul.Size = new System.Drawing.Size(708, 117);
            this.tytul.TabIndex = 3;
            this.tytul.Text = "matematyczne rybki";
            this.tytul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tytul.Click += new System.EventHandler(this.label1_Click);
            // 
            // wyjdzzgry
            // 
            this.wyjdzzgry.AutoSize = true;
            this.wyjdzzgry.BackColor = System.Drawing.Color.Pink;
            this.wyjdzzgry.Font = new System.Drawing.Font("Cooper Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.wyjdzzgry.Location = new System.Drawing.Point(169, 469);
            this.wyjdzzgry.Name = "wyjdzzgry";
            this.wyjdzzgry.Size = new System.Drawing.Size(708, 82);
            this.wyjdzzgry.TabIndex = 4;
            this.wyjdzzgry.Text = "wyjdz z gry";
            this.wyjdzzgry.UseVisualStyleBackColor = false;
            this.wyjdzzgry.Visible = false;
            this.wyjdzzgry.Click += new System.EventHandler(this.wyjdzzgry_Click);
            // 
            // rozpocznijodnowa
            // 
            this.rozpocznijodnowa.AutoSize = true;
            this.rozpocznijodnowa.BackColor = System.Drawing.Color.Pink;
            this.rozpocznijodnowa.Font = new System.Drawing.Font("Cooper Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rozpocznijodnowa.Location = new System.Drawing.Point(169, 381);
            this.rozpocznijodnowa.Name = "rozpocznijodnowa";
            this.rozpocznijodnowa.Size = new System.Drawing.Size(708, 82);
            this.rozpocznijodnowa.TabIndex = 5;
            this.rozpocznijodnowa.Text = "rozpocznij od nowa";
            this.rozpocznijodnowa.UseVisualStyleBackColor = false;
            this.rozpocznijodnowa.Visible = false;
            this.rozpocznijodnowa.Click += new System.EventHandler(this.rozpocznijodnowa_Click);
            // 
            // kontynuuj
            // 
            this.kontynuuj.AutoSize = true;
            this.kontynuuj.BackColor = System.Drawing.Color.Pink;
            this.kontynuuj.Font = new System.Drawing.Font("Cooper Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.kontynuuj.Location = new System.Drawing.Point(169, 293);
            this.kontynuuj.Name = "kontynuuj";
            this.kontynuuj.Size = new System.Drawing.Size(708, 82);
            this.kontynuuj.TabIndex = 6;
            this.kontynuuj.Text = "kontynuuj";
            this.kontynuuj.UseVisualStyleBackColor = false;
            this.kontynuuj.Visible = false;
            this.kontynuuj.Click += new System.EventHandler(this.kontynuuj_Click);
            // 
            // nazwagracza
            // 
            this.nazwagracza.Location = new System.Drawing.Point(169, 623);
            this.nazwagracza.Name = "nazwagracza";
            this.nazwagracza.Size = new System.Drawing.Size(708, 23);
            this.nazwagracza.TabIndex = 7;
            this.nazwagracza.Text = "Podaj nazwe gracza!";
            this.nazwagracza.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nazwagracza.TextChanged += new System.EventHandler(this.nazwagracza_TextChanged);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.Pink;
            this.button1.Font = new System.Drawing.Font("Cooper Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(169, 652);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(708, 82);
            this.button1.TabIndex = 8;
            this.button1.Text = "kup rybke za 500";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.Pink;
            this.button2.Font = new System.Drawing.Font("Cooper Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(883, 652);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 82);
            this.button2.TabIndex = 9;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.BackColor = System.Drawing.Color.Pink;
            this.button3.Font = new System.Drawing.Font("Cooper Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(73, 652);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 82);
            this.button3.TabIndex = 10;
            this.button3.Text = "<";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Pink;
            this.pictureBox1.Location = new System.Drawing.Point(169, 182);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(708, 464);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // Gra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nazwagracza);
            this.Controls.Add(this.kontynuuj);
            this.Controls.Add(this.rozpocznijodnowa);
            this.Controls.Add(this.wyjdzzgry);
            this.Controls.Add(this.tytul);
            this.Controls.Add(this.startprzycisk);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Gra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Gra_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Gra_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button startprzycisk;
        private Label tytul;
        private Button wyjdzzgry;
        private Button rozpocznijodnowa;
        private Button kontynuuj;
        private TextBox nazwagracza;
        private Button button1;
        private Button button2;
        private Button button3;
        private PictureBox pictureBox1;
    }
}
