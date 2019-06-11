namespace eFitnessCenterDesktop
{
    partial class SuplementsListForm
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
            this.dgvSuplements = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuplements)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSuplements
            // 
            this.dgvSuplements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuplements.Location = new System.Drawing.Point(0, 78);
            this.dgvSuplements.Name = "dgvSuplements";
            this.dgvSuplements.Size = new System.Drawing.Size(800, 373);
            this.dgvSuplements.TabIndex = 0;
            // 
            // SuplementsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvSuplements);
            this.Name = "SuplementsListForm";
            this.Text = "SuplementsListForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuplements)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSuplements;
    }
}