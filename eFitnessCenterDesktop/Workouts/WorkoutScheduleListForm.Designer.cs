namespace eFitnessCenterDesktop.Workouts
{
    partial class WorkoutScheduleListForm
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
            this.dgvSchedules = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workoutIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workoutNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayOfTheWeekDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeOfTheDayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workoutScheduleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbWorkoutDays = new System.Windows.Forms.ComboBox();
            this.cbWorkout = new System.Windows.Forms.ComboBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timePickerStart = new System.Windows.Forms.DateTimePicker();
            this.timePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workoutScheduleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSchedules
            // 
            this.dgvSchedules.AutoGenerateColumns = false;
            this.dgvSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.workoutIdDataGridViewTextBoxColumn,
            this.workoutNameDataGridViewTextBoxColumn,
            this.dayOfTheWeekDataGridViewTextBoxColumn,
            this.timeOfTheDayDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.dgvSchedules.DataSource = this.workoutScheduleBindingSource;
            this.dgvSchedules.Location = new System.Drawing.Point(0, 85);
            this.dgvSchedules.Name = "dgvSchedules";
            this.dgvSchedules.Size = new System.Drawing.Size(799, 367);
            this.dgvSchedules.TabIndex = 0;
            this.dgvSchedules.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSchedules_CellContentDoubleClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // workoutIdDataGridViewTextBoxColumn
            // 
            this.workoutIdDataGridViewTextBoxColumn.DataPropertyName = "WorkoutId";
            this.workoutIdDataGridViewTextBoxColumn.HeaderText = "WorkoutId";
            this.workoutIdDataGridViewTextBoxColumn.Name = "workoutIdDataGridViewTextBoxColumn";
            // 
            // workoutNameDataGridViewTextBoxColumn
            // 
            this.workoutNameDataGridViewTextBoxColumn.DataPropertyName = "WorkoutName";
            this.workoutNameDataGridViewTextBoxColumn.HeaderText = "WorkoutName";
            this.workoutNameDataGridViewTextBoxColumn.Name = "workoutNameDataGridViewTextBoxColumn";
            // 
            // dayOfTheWeekDataGridViewTextBoxColumn
            // 
            this.dayOfTheWeekDataGridViewTextBoxColumn.DataPropertyName = "DayOfTheWeek";
            this.dayOfTheWeekDataGridViewTextBoxColumn.HeaderText = "DayOfTheWeek";
            this.dayOfTheWeekDataGridViewTextBoxColumn.Name = "dayOfTheWeekDataGridViewTextBoxColumn";
            // 
            // timeOfTheDayDataGridViewTextBoxColumn
            // 
            this.timeOfTheDayDataGridViewTextBoxColumn.DataPropertyName = "TimeOfTheDay";
            this.timeOfTheDayDataGridViewTextBoxColumn.HeaderText = "TimeOfTheDay";
            this.timeOfTheDayDataGridViewTextBoxColumn.Name = "timeOfTheDayDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // workoutScheduleBindingSource
            // 
            this.workoutScheduleBindingSource.DataSource = typeof(Models.Workout.WorkoutSchedule);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dan u Sedmici";
            // 
            // cbWorkoutDays
            // 
            this.cbWorkoutDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorkoutDays.FormattingEnabled = true;
            this.cbWorkoutDays.Location = new System.Drawing.Point(16, 38);
            this.cbWorkoutDays.Name = "cbWorkoutDays";
            this.cbWorkoutDays.Size = new System.Drawing.Size(121, 21);
            this.cbWorkoutDays.TabIndex = 2;
            // 
            // cbWorkout
            // 
            this.cbWorkout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorkout.FormattingEnabled = true;
            this.cbWorkout.Location = new System.Drawing.Point(159, 38);
            this.cbWorkout.Name = "cbWorkout";
            this.cbWorkout.Size = new System.Drawing.Size(121, 21);
            this.cbWorkout.TabIndex = 4;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(156, 13);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(43, 13);
            this.lbl2.TabIndex = 3;
            this.lbl2.Text = "Trening";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pocetak";
            // 
            // timePickerStart
            // 
            this.timePickerStart.Location = new System.Drawing.Point(298, 39);
            this.timePickerStart.Name = "timePickerStart";
            this.timePickerStart.Size = new System.Drawing.Size(121, 20);
            this.timePickerStart.TabIndex = 6;
            // 
            // timePickerEnd
            // 
            this.timePickerEnd.Location = new System.Drawing.Point(440, 39);
            this.timePickerEnd.Name = "timePickerEnd";
            this.timePickerEnd.Size = new System.Drawing.Size(121, 20);
            this.timePickerEnd.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(437, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Kraj";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(682, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Pretraga";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(682, 56);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Obrisi";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // WorkoutScheduleListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.timePickerEnd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timePickerStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbWorkout);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.cbWorkoutDays);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSchedules);
            this.Name = "WorkoutScheduleListForm";
            this.Text = "WorkoutScheduleListForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workoutScheduleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSchedules;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workoutIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workoutNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayOfTheWeekDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeOfTheDayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource workoutScheduleBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbWorkoutDays;
        private System.Windows.Forms.ComboBox cbWorkout;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker timePickerStart;
        private System.Windows.Forms.DateTimePicker timePickerEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDelete;
    }
}