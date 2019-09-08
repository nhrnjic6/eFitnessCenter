namespace eFitnessCenterDesktop
{
    partial class MainForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suplementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suplementListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSuplementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suplementPaymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workoutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewWorkoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workoutListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workoutAdviceListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createWorkoutAdviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allTrainersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTranerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientsToolStripMenuItem,
            this.suplementsToolStripMenuItem,
            this.workoutsToolStripMenuItem,
            this.trainersToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(820, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            this.menuStrip.Visible = false;
            // 
            // clientsToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allClientsToolStripMenuItem,
            this.addClientToolStripMenuItem});
            this.clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            this.clientsToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.clientsToolStripMenuItem.Text = "Clients";
            // 
            // allClientsToolStripMenuItem
            // 
            this.allClientsToolStripMenuItem.Name = "allClientsToolStripMenuItem";
            this.allClientsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.allClientsToolStripMenuItem.Text = "All Clients";
            this.allClientsToolStripMenuItem.Click += new System.EventHandler(this.AllClientsToolStripMenuItem_Click);
            // 
            // addClientToolStripMenuItem
            // 
            this.addClientToolStripMenuItem.Name = "addClientToolStripMenuItem";
            this.addClientToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.addClientToolStripMenuItem.Text = "Add Client";
            this.addClientToolStripMenuItem.Click += new System.EventHandler(this.AddClientToolStripMenuItem_Click);
            // 
            // suplementsToolStripMenuItem
            // 
            this.suplementsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.suplementListToolStripMenuItem,
            this.newSuplementToolStripMenuItem,
            this.suplementPaymentsToolStripMenuItem,
            this.newPaymentToolStripMenuItem});
            this.suplementsToolStripMenuItem.Name = "suplementsToolStripMenuItem";
            this.suplementsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.suplementsToolStripMenuItem.Text = "Suplements";
            // 
            // suplementListToolStripMenuItem
            // 
            this.suplementListToolStripMenuItem.Name = "suplementListToolStripMenuItem";
            this.suplementListToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.suplementListToolStripMenuItem.Text = "Suplement List";
            this.suplementListToolStripMenuItem.Click += new System.EventHandler(this.SuplementListToolStripMenuItem_Click);
            // 
            // newSuplementToolStripMenuItem
            // 
            this.newSuplementToolStripMenuItem.Name = "newSuplementToolStripMenuItem";
            this.newSuplementToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.newSuplementToolStripMenuItem.Text = "New Suplement";
            this.newSuplementToolStripMenuItem.Click += new System.EventHandler(this.NewSuplementToolStripMenuItem_Click);
            // 
            // suplementPaymentsToolStripMenuItem
            // 
            this.suplementPaymentsToolStripMenuItem.Name = "suplementPaymentsToolStripMenuItem";
            this.suplementPaymentsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.suplementPaymentsToolStripMenuItem.Text = "Suplement Payments";
            this.suplementPaymentsToolStripMenuItem.Click += new System.EventHandler(this.SuplementPaymentsToolStripMenuItem_Click);
            // 
            // newPaymentToolStripMenuItem
            // 
            this.newPaymentToolStripMenuItem.Name = "newPaymentToolStripMenuItem";
            this.newPaymentToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.newPaymentToolStripMenuItem.Text = "New Payment";
            this.newPaymentToolStripMenuItem.Click += new System.EventHandler(this.NewPaymentToolStripMenuItem_Click);
            // 
            // workoutsToolStripMenuItem
            // 
            this.workoutsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewWorkoutToolStripMenuItem,
            this.workoutListToolStripMenuItem,
            this.createScheduleToolStripMenuItem,
            this.scheduleListToolStripMenuItem,
            this.workoutAdviceListToolStripMenuItem,
            this.createWorkoutAdviceToolStripMenuItem});
            this.workoutsToolStripMenuItem.Name = "workoutsToolStripMenuItem";
            this.workoutsToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.workoutsToolStripMenuItem.Text = "Workouts";
            // 
            // createNewWorkoutToolStripMenuItem
            // 
            this.createNewWorkoutToolStripMenuItem.Name = "createNewWorkoutToolStripMenuItem";
            this.createNewWorkoutToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.createNewWorkoutToolStripMenuItem.Text = "Create New Workout";
            this.createNewWorkoutToolStripMenuItem.Click += new System.EventHandler(this.CreateNewWorkoutToolStripMenuItem_Click);
            // 
            // workoutListToolStripMenuItem
            // 
            this.workoutListToolStripMenuItem.Name = "workoutListToolStripMenuItem";
            this.workoutListToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.workoutListToolStripMenuItem.Text = "Workout List";
            this.workoutListToolStripMenuItem.Click += new System.EventHandler(this.WorkoutListToolStripMenuItem_Click);
            // 
            // createScheduleToolStripMenuItem
            // 
            this.createScheduleToolStripMenuItem.Name = "createScheduleToolStripMenuItem";
            this.createScheduleToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.createScheduleToolStripMenuItem.Text = "Create Schedule";
            this.createScheduleToolStripMenuItem.Click += new System.EventHandler(this.CreateScheduleToolStripMenuItem_Click);
            // 
            // scheduleListToolStripMenuItem
            // 
            this.scheduleListToolStripMenuItem.Name = "scheduleListToolStripMenuItem";
            this.scheduleListToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.scheduleListToolStripMenuItem.Text = "Schedule List";
            this.scheduleListToolStripMenuItem.Click += new System.EventHandler(this.ScheduleListToolStripMenuItem_Click);
            // 
            // workoutAdviceListToolStripMenuItem
            // 
            this.workoutAdviceListToolStripMenuItem.Name = "workoutAdviceListToolStripMenuItem";
            this.workoutAdviceListToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.workoutAdviceListToolStripMenuItem.Text = "Workout Advice List";
            this.workoutAdviceListToolStripMenuItem.Click += new System.EventHandler(this.WorkoutAdviceListToolStripMenuItem_Click);
            // 
            // createWorkoutAdviceToolStripMenuItem
            // 
            this.createWorkoutAdviceToolStripMenuItem.Name = "createWorkoutAdviceToolStripMenuItem";
            this.createWorkoutAdviceToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.createWorkoutAdviceToolStripMenuItem.Text = "Create Workout Advice";
            this.createWorkoutAdviceToolStripMenuItem.Click += new System.EventHandler(this.CreateWorkoutAdviceToolStripMenuItem_Click);
            // 
            // trainersToolStripMenuItem
            // 
            this.trainersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allTrainersToolStripMenuItem,
            this.newTranerToolStripMenuItem});
            this.trainersToolStripMenuItem.Name = "trainersToolStripMenuItem";
            this.trainersToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.trainersToolStripMenuItem.Text = "Trainers";
            // 
            // allTrainersToolStripMenuItem
            // 
            this.allTrainersToolStripMenuItem.Name = "allTrainersToolStripMenuItem";
            this.allTrainersToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.allTrainersToolStripMenuItem.Text = "All Trainers";
            this.allTrainersToolStripMenuItem.Click += new System.EventHandler(this.AllTrainersToolStripMenuItem_Click);
            // 
            // newTranerToolStripMenuItem
            // 
            this.newTranerToolStripMenuItem.Name = "newTranerToolStripMenuItem";
            this.newTranerToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.newTranerToolStripMenuItem.Text = "New Traner";
            this.newTranerToolStripMenuItem.Click += new System.EventHandler(this.NewTranerToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 459);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(820, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 481);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suplementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suplementListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSuplementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suplementPaymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workoutsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewWorkoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workoutListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workoutAdviceListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createWorkoutAdviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allTrainersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTranerToolStripMenuItem;
    }
}



