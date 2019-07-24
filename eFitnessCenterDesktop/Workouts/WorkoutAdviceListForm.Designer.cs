namespace eFitnessCenterDesktop.Workouts
{
    partial class WorkoutAdviceListForm
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
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.cbTrainer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAdvices = new System.Windows.Forms.DataGridView();
            this.workoutAdviceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trainerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdvices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workoutAdviceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Korisnik";
            // 
            // cbClient
            // 
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(12, 34);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(121, 21);
            this.cbClient.TabIndex = 1;
            // 
            // cbTrainer
            // 
            this.cbTrainer.FormattingEnabled = true;
            this.cbTrainer.Location = new System.Drawing.Point(203, 34);
            this.cbTrainer.Name = "cbTrainer";
            this.cbTrainer.Size = new System.Drawing.Size(121, 21);
            this.cbTrainer.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trener";
            // 
            // dgvAdvices
            // 
            this.dgvAdvices.AutoGenerateColumns = false;
            this.dgvAdvices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdvices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.messageDataGridViewTextBoxColumn,
            this.clientNameDataGridViewTextBoxColumn,
            this.trainerNameDataGridViewTextBoxColumn,
            this.createdAtDataGridViewTextBoxColumn});
            this.dgvAdvices.DataSource = this.workoutAdviceBindingSource;
            this.dgvAdvices.Location = new System.Drawing.Point(-1, 78);
            this.dgvAdvices.Name = "dgvAdvices";
            this.dgvAdvices.Size = new System.Drawing.Size(789, 378);
            this.dgvAdvices.TabIndex = 4;
            this.dgvAdvices.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAdvices_CellContentDoubleClick);
            // 
            // workoutAdviceBindingSource
            // 
            this.workoutAdviceBindingSource.DataSource = typeof(Models.Workout.WorkoutAdvice);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // messageDataGridViewTextBoxColumn
            // 
            this.messageDataGridViewTextBoxColumn.DataPropertyName = "Message";
            this.messageDataGridViewTextBoxColumn.HeaderText = "Poruka";
            this.messageDataGridViewTextBoxColumn.Name = "messageDataGridViewTextBoxColumn";
            // 
            // clientNameDataGridViewTextBoxColumn
            // 
            this.clientNameDataGridViewTextBoxColumn.DataPropertyName = "ClientName";
            this.clientNameDataGridViewTextBoxColumn.HeaderText = "Korisnik";
            this.clientNameDataGridViewTextBoxColumn.Name = "clientNameDataGridViewTextBoxColumn";
            // 
            // trainerNameDataGridViewTextBoxColumn
            // 
            this.trainerNameDataGridViewTextBoxColumn.DataPropertyName = "TrainerName";
            this.trainerNameDataGridViewTextBoxColumn.HeaderText = "Trener";
            this.trainerNameDataGridViewTextBoxColumn.Name = "trainerNameDataGridViewTextBoxColumn";
            // 
            // createdAtDataGridViewTextBoxColumn
            // 
            this.createdAtDataGridViewTextBoxColumn.DataPropertyName = "CreatedAt";
            this.createdAtDataGridViewTextBoxColumn.HeaderText = "Kreirano";
            this.createdAtDataGridViewTextBoxColumn.Name = "createdAtDataGridViewTextBoxColumn";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(576, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Pretraga";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(686, 34);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Obrisi";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // WorkoutAdviceListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 450);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvAdvices);
            this.Controls.Add(this.cbTrainer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.label1);
            this.Name = "WorkoutAdviceListForm";
            this.Text = "WorkoutAdviceListForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdvices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workoutAdviceBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.ComboBox cbTrainer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvAdvices;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trainerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource workoutAdviceBindingSource;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDelete;
    }
}