namespace eFitnessCenterDesktop.Suplements
{
    partial class SuplementPaymentCreate
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbKorisnik = new System.Windows.Forms.ComboBox();
            this.cbSuplement = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nupKolicina = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nupKolicina)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Korisnik:";
            // 
            // cbKorisnik
            // 
            this.cbKorisnik.FormattingEnabled = true;
            this.cbKorisnik.Location = new System.Drawing.Point(26, 54);
            this.cbKorisnik.Name = "cbKorisnik";
            this.cbKorisnik.Size = new System.Drawing.Size(121, 21);
            this.cbKorisnik.TabIndex = 1;
            // 
            // cbSuplement
            // 
            this.cbSuplement.FormattingEnabled = true;
            this.cbSuplement.Location = new System.Drawing.Point(26, 132);
            this.cbSuplement.Name = "cbSuplement";
            this.cbSuplement.Size = new System.Drawing.Size(121, 21);
            this.cbSuplement.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Suplement:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kolicina:";
            // 
            // nupKolicina
            // 
            this.nupKolicina.Location = new System.Drawing.Point(26, 207);
            this.nupKolicina.Name = "nupKolicina";
            this.nupKolicina.Size = new System.Drawing.Size(121, 20);
            this.nupKolicina.TabIndex = 6;
            this.nupKolicina.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(26, 260);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Spasi";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // SuplementPaymentCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.nupKolicina);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbSuplement);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbKorisnik);
            this.Controls.Add(this.label1);
            this.Name = "SuplementPaymentCreate";
            this.Text = "SuplementPaymentCreate";
            ((System.ComponentModel.ISupportInitialize)(this.nupKolicina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbKorisnik;
        private System.Windows.Forms.ComboBox cbSuplement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nupKolicina;
        private System.Windows.Forms.Button btnSave;
    }
}