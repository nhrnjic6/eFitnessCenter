namespace eFitnessCenterDesktop.Workouts
{
    partial class WorkoutScheduleCreateForm
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
            this.cbWorkout = new System.Windows.Forms.ComboBox();
            this.cbDayOfWeek = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trening";
            // 
            // cbWorkout
            // 
            this.cbWorkout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorkout.FormattingEnabled = true;
            this.cbWorkout.Location = new System.Drawing.Point(32, 44);
            this.cbWorkout.Name = "cbWorkout";
            this.cbWorkout.Size = new System.Drawing.Size(169, 21);
            this.cbWorkout.TabIndex = 1;
            this.cbWorkout.Validating += new System.ComponentModel.CancelEventHandler(this.CbWorkout_Validating);
            // 
            // cbDayOfWeek
            // 
            this.cbDayOfWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDayOfWeek.FormattingEnabled = true;
            this.cbDayOfWeek.Location = new System.Drawing.Point(32, 115);
            this.cbDayOfWeek.Name = "cbDayOfWeek";
            this.cbDayOfWeek.Size = new System.Drawing.Size(169, 21);
            this.cbDayOfWeek.TabIndex = 3;
            this.cbDayOfWeek.Validating += new System.ComponentModel.CancelEventHandler(this.CbDayOfWeek_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dan u Sedmici";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Vrijeme";
            // 
            // timePicker
            // 
            this.timePicker.CustomFormat = "\"HH:mm\"";
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker.Location = new System.Drawing.Point(32, 190);
            this.timePicker.Name = "timePicker";
            this.timePicker.Size = new System.Drawing.Size(169, 20);
            this.timePicker.TabIndex = 5;
            this.timePicker.Validating += new System.ComponentModel.CancelEventHandler(this.TimePicker_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Opis";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(32, 272);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(173, 96);
            this.tbDescription.TabIndex = 7;
            this.tbDescription.Text = "";
            this.tbDescription.Validating += new System.ComponentModel.CancelEventHandler(this.TbDescription_Validating);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(32, 406);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Spasi";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // WorkoutScheduleCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 475);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbDayOfWeek);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbWorkout);
            this.Controls.Add(this.label1);
            this.Name = "WorkoutScheduleCreateForm";
            this.Text = "WorkoutScheduleCreateForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbWorkout;
        private System.Windows.Forms.ComboBox cbDayOfWeek;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker timePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox tbDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}