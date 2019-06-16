namespace eFitnessCenterDesktop.Suplements
{
    partial class numAmount
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
            System.Windows.Forms.Label label4;
            this.label1 = new System.Windows.Forms.Label();
            this.tbNaziv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMessure = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbVrsta = new System.Windows.Forms.ComboBox();
            this.Opis = new System.Windows.Forms.Label();
            this.tbOpis = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.numKolicina = new System.Windows.Forms.NumericUpDown();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKolicina)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(26, 159);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(44, 13);
            label4.TabIndex = 6;
            label4.Text = "Kolicina";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv";
            // 
            // tbNaziv
            // 
            this.tbNaziv.Location = new System.Drawing.Point(29, 23);
            this.tbNaziv.Name = "tbNaziv";
            this.tbNaziv.Size = new System.Drawing.Size(121, 20);
            this.tbNaziv.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cijena";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mjerna Jedinica";
            // 
            // cbMessure
            // 
            this.cbMessure.FormattingEnabled = true;
            this.cbMessure.Items.AddRange(new object[] {
            "kg",
            "l"});
            this.cbMessure.Location = new System.Drawing.Point(29, 131);
            this.cbMessure.Name = "cbMessure";
            this.cbMessure.Size = new System.Drawing.Size(121, 21);
            this.cbMessure.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Vrsta";
            // 
            // cbVrsta
            // 
            this.cbVrsta.FormattingEnabled = true;
            this.cbVrsta.Location = new System.Drawing.Point(30, 225);
            this.cbVrsta.Name = "cbVrsta";
            this.cbVrsta.Size = new System.Drawing.Size(121, 21);
            this.cbVrsta.TabIndex = 9;
            // 
            // Opis
            // 
            this.Opis.AutoSize = true;
            this.Opis.Location = new System.Drawing.Point(27, 260);
            this.Opis.Name = "Opis";
            this.Opis.Size = new System.Drawing.Size(28, 13);
            this.Opis.TabIndex = 10;
            this.Opis.Text = "Opis";
            // 
            // tbOpis
            // 
            this.tbOpis.Location = new System.Drawing.Point(29, 288);
            this.tbOpis.Name = "tbOpis";
            this.tbOpis.Size = new System.Drawing.Size(196, 79);
            this.tbOpis.TabIndex = 11;
            this.tbOpis.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(30, 401);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Spasi";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // numPrice
            // 
            this.numPrice.Location = new System.Drawing.Point(29, 79);
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(120, 20);
            this.numPrice.TabIndex = 14;
            // 
            // numKolicina
            // 
            this.numKolicina.Location = new System.Drawing.Point(29, 175);
            this.numKolicina.Name = "numKolicina";
            this.numKolicina.Size = new System.Drawing.Size(120, 20);
            this.numKolicina.TabIndex = 15;
            this.numKolicina.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numAmount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 522);
            this.Controls.Add(this.numKolicina);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbOpis);
            this.Controls.Add(this.Opis);
            this.Controls.Add(this.cbVrsta);
            this.Controls.Add(this.label5);
            this.Controls.Add(label4);
            this.Controls.Add(this.cbMessure);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNaziv);
            this.Controls.Add(this.label1);
            this.Name = "numAmount";
            this.Text = "SuplementAddForm";
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKolicina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNaziv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMessure;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbVrsta;
        private System.Windows.Forms.Label Opis;
        private System.Windows.Forms.RichTextBox tbOpis;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.NumericUpDown numKolicina;
    }
}