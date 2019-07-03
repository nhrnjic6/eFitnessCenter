namespace eFitnessCenterDesktop.Workouts
{
    partial class WorkoutListForm
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
            this.dgvWorkouts = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workoutTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trainerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.difficultyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workoutBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbTrainer = new System.Windows.Forms.ComboBox();
            this.Trener = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.Tezina = new System.Windows.Forms.Label();
            this.cbDifficulty = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDuration = new System.Windows.Forms.ComboBox();
            this.btnSeach = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkouts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workoutBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvWorkouts
            // 
            this.dgvWorkouts.AutoGenerateColumns = false;
            this.dgvWorkouts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkouts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.createdAtDataGridViewTextBoxColumn,
            this.workoutTypeDataGridViewTextBoxColumn,
            this.trainerDataGridViewTextBoxColumn,
            this.durationDataGridViewTextBoxColumn,
            this.difficultyDataGridViewTextBoxColumn});
            this.dgvWorkouts.DataSource = this.workoutBindingSource;
            this.dgvWorkouts.Location = new System.Drawing.Point(1, 136);
            this.dgvWorkouts.Name = "dgvWorkouts";
            this.dgvWorkouts.Size = new System.Drawing.Size(798, 313);
            this.dgvWorkouts.TabIndex = 0;
            this.dgvWorkouts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvWorkouts_CellContentClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Naziv";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // createdAtDataGridViewTextBoxColumn
            // 
            this.createdAtDataGridViewTextBoxColumn.DataPropertyName = "CreatedAt";
            this.createdAtDataGridViewTextBoxColumn.HeaderText = "Kreiran";
            this.createdAtDataGridViewTextBoxColumn.Name = "createdAtDataGridViewTextBoxColumn";
            // 
            // workoutTypeDataGridViewTextBoxColumn
            // 
            this.workoutTypeDataGridViewTextBoxColumn.DataPropertyName = "WorkoutType";
            this.workoutTypeDataGridViewTextBoxColumn.HeaderText = "Vrsta ";
            this.workoutTypeDataGridViewTextBoxColumn.Name = "workoutTypeDataGridViewTextBoxColumn";
            // 
            // trainerDataGridViewTextBoxColumn
            // 
            this.trainerDataGridViewTextBoxColumn.DataPropertyName = "Trainer";
            this.trainerDataGridViewTextBoxColumn.HeaderText = "Trener";
            this.trainerDataGridViewTextBoxColumn.Name = "trainerDataGridViewTextBoxColumn";
            // 
            // durationDataGridViewTextBoxColumn
            // 
            this.durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
            this.durationDataGridViewTextBoxColumn.HeaderText = "Trajanje";
            this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            // 
            // difficultyDataGridViewTextBoxColumn
            // 
            this.difficultyDataGridViewTextBoxColumn.DataPropertyName = "Difficulty";
            this.difficultyDataGridViewTextBoxColumn.HeaderText = "Tezina";
            this.difficultyDataGridViewTextBoxColumn.Name = "difficultyDataGridViewTextBoxColumn";
            // 
            // workoutBindingSource
            // 
            this.workoutBindingSource.DataSource = typeof(Models.Workout.Workout);
            // 
            // cbTrainer
            // 
            this.cbTrainer.FormattingEnabled = true;
            this.cbTrainer.Location = new System.Drawing.Point(15, 31);
            this.cbTrainer.Name = "cbTrainer";
            this.cbTrainer.Size = new System.Drawing.Size(121, 21);
            this.cbTrainer.TabIndex = 1;
            // 
            // Trener
            // 
            this.Trener.AutoSize = true;
            this.Trener.Location = new System.Drawing.Point(12, 9);
            this.Trener.Name = "Trener";
            this.Trener.Size = new System.Drawing.Size(38, 13);
            this.Trener.TabIndex = 2;
            this.Trener.Text = "Trener";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vrsta";
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(194, 31);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(121, 21);
            this.cbType.TabIndex = 3;
            // 
            // Tezina
            // 
            this.Tezina.AutoSize = true;
            this.Tezina.Location = new System.Drawing.Point(12, 69);
            this.Tezina.Name = "Tezina";
            this.Tezina.Size = new System.Drawing.Size(39, 13);
            this.Tezina.TabIndex = 6;
            this.Tezina.Text = "Tezina";
            // 
            // cbDifficulty
            // 
            this.cbDifficulty.FormattingEnabled = true;
            this.cbDifficulty.Items.AddRange(new object[] {
            "Begginer",
            "Intermidiate",
            "Hard",
            "Expert",
            "Master"});
            this.cbDifficulty.Location = new System.Drawing.Point(15, 91);
            this.cbDifficulty.Name = "cbDifficulty";
            this.cbDifficulty.Size = new System.Drawing.Size(121, 21);
            this.cbDifficulty.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Trajanje";
            // 
            // cbDuration
            // 
            this.cbDuration.FormattingEnabled = true;
            this.cbDuration.Items.AddRange(new object[] {
            "15",
            "25",
            "30",
            "45",
            "60",
            "90"});
            this.cbDuration.Location = new System.Drawing.Point(194, 91);
            this.cbDuration.Name = "cbDuration";
            this.cbDuration.Size = new System.Drawing.Size(121, 21);
            this.cbDuration.TabIndex = 7;
            // 
            // btnSeach
            // 
            this.btnSeach.Location = new System.Drawing.Point(552, 29);
            this.btnSeach.Name = "btnSeach";
            this.btnSeach.Size = new System.Drawing.Size(75, 23);
            this.btnSeach.TabIndex = 9;
            this.btnSeach.Text = "Pretraga";
            this.btnSeach.UseVisualStyleBackColor = true;
            this.btnSeach.Click += new System.EventHandler(this.BtnSeach_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(667, 29);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Obrisi";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // WorkoutListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSeach);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDuration);
            this.Controls.Add(this.Tezina);
            this.Controls.Add(this.cbDifficulty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.Trener);
            this.Controls.Add(this.cbTrainer);
            this.Controls.Add(this.dgvWorkouts);
            this.Name = "WorkoutListForm";
            this.Text = "WorkoutListForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkouts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workoutBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWorkouts;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workoutTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trainerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn difficultyDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource workoutBindingSource;
        private System.Windows.Forms.ComboBox cbTrainer;
        private System.Windows.Forms.Label Trener;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label Tezina;
        private System.Windows.Forms.ComboBox cbDifficulty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDuration;
        private System.Windows.Forms.Button btnSeach;
        private System.Windows.Forms.Button btnDelete;
    }
}