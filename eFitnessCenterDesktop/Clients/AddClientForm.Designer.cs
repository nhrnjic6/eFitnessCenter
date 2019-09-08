namespace eFitnessCenterDesktop.Clients
{
    partial class AddClientForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbIme = new System.Windows.Forms.TextBox();
            this.tbPrezime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAdresa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbTelefon = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.btnClanarine = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ime";
            // 
            // tbIme
            // 
            this.tbIme.Location = new System.Drawing.Point(29, 39);
            this.tbIme.Name = "tbIme";
            this.tbIme.Size = new System.Drawing.Size(239, 20);
            this.tbIme.TabIndex = 1;
            this.tbIme.Validating += new System.ComponentModel.CancelEventHandler(this.TbIme_Validating);
            // 
            // tbPrezime
            // 
            this.tbPrezime.Location = new System.Drawing.Point(29, 92);
            this.tbPrezime.Name = "tbPrezime";
            this.tbPrezime.Size = new System.Drawing.Size(239, 20);
            this.tbPrezime.TabIndex = 3;
            this.tbPrezime.Validating += new System.ComponentModel.CancelEventHandler(this.TbPrezime_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Prezime";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(29, 147);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(239, 20);
            this.tbEmail.TabIndex = 5;
            this.tbEmail.Validating += new System.ComponentModel.CancelEventHandler(this.TbEmail_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password";
            // 
            // tbAdresa
            // 
            this.tbAdresa.Location = new System.Drawing.Point(29, 261);
            this.tbAdresa.Name = "tbAdresa";
            this.tbAdresa.Size = new System.Drawing.Size(239, 20);
            this.tbAdresa.TabIndex = 9;
            this.tbAdresa.Validating += new System.ComponentModel.CancelEventHandler(this.TbAdresa_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Adresa";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(29, 422);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Spasi";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // tbTelefon
            // 
            this.tbTelefon.Location = new System.Drawing.Point(29, 320);
            this.tbTelefon.Name = "tbTelefon";
            this.tbTelefon.Size = new System.Drawing.Size(239, 20);
            this.tbTelefon.TabIndex = 12;
            this.tbTelefon.Validating += new System.ComponentModel.CancelEventHandler(this.TbTelefon_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Telefon";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(29, 204);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(239, 20);
            this.tbPassword.TabIndex = 7;
            this.tbPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TbPassword_Validating);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(29, 357);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "Status";
            this.lblStatus.Visible = false;
            this.lblStatus.Click += new System.EventHandler(this.LblStatus_Click);
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive",
            "Deleted"});
            this.cbStatus.Location = new System.Drawing.Point(29, 378);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(239, 21);
            this.cbStatus.TabIndex = 14;
            this.cbStatus.Visible = false;
            this.cbStatus.Validating += new System.ComponentModel.CancelEventHandler(this.CbStatus_Validating);
            // 
            // btnClanarine
            // 
            this.btnClanarine.Location = new System.Drawing.Point(339, 15);
            this.btnClanarine.Name = "btnClanarine";
            this.btnClanarine.Size = new System.Drawing.Size(75, 23);
            this.btnClanarine.TabIndex = 15;
            this.btnClanarine.Text = "Clanarine";
            this.btnClanarine.UseVisualStyleBackColor = true;
            this.btnClanarine.Click += new System.EventHandler(this.BtnClanarine_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AddClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 526);
            this.Controls.Add(this.btnClanarine);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.tbTelefon);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbAdresa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPrezime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbIme);
            this.Controls.Add(this.label1);
            this.Name = "AddClientForm";
            this.Text = "AddClientForm";
            this.Load += new System.EventHandler(this.AddClientForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIme;
        private System.Windows.Forms.TextBox tbPrezime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAdresa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbTelefon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Button btnClanarine;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}