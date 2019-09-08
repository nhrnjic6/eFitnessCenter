using eFitnessCenterDesktop.Services;
using Models.Requests.Workout;
using Models.Workout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFitnessCenterDesktop.Workouts
{
    public partial class WorkoutScheduleListForm : Form
    {
        private string _accessToken;
        private readonly ApiService _workoutApiService;
        private readonly ApiService _workoutScheduleApiService;
        private List<WorkoutSchedule> _workoutScheduleList;
        private readonly List<object> DateTimeList = new List<object>
        {
           new { Name = "Monday", Value = "1" },
           new { Name = "Tuesday", Value = "2" },
           new { Name = "Wednesday", Value = "3" },
           new { Name = "Thursday", Value = "4" },
           new { Name = "Friday", Value = "5" },
           new { Name = "Saturday", Value = "6" },
           new { Name = "Sunday", Value = "0" }
        };

        public WorkoutScheduleListForm(string accessToken)
        {
            InitializeComponent();

            _accessToken = accessToken;
            _workoutApiService = new ApiService("workout", _accessToken);
            _workoutScheduleApiService = new ApiService("workoutSchedule", _accessToken);

            _ = loadSchedules();
        }

        public async Task loadSchedules()
        {
            await initFormData();
            await loadGridData();
            dgvSchedules.Visible = true;
        }

        public async Task initFormData()
        {
            cbWorkoutDays.DataSource = DateTimeList;
            cbWorkoutDays.DisplayMember = "Name";
            cbWorkoutDays.ValueMember = "Value";

            timePickerStart.Format = DateTimePickerFormat.Custom;
            timePickerStart.CustomFormat = "HH:mm";
            timePickerStart.ShowUpDown = true;
            timePickerStart.Value = DateTime.ParseExact("00:00:00", "HH:mm:ss", CultureInfo.InvariantCulture);

            timePickerEnd.Format = DateTimePickerFormat.Custom;
            timePickerEnd.CustomFormat = "HH:mm";
            timePickerEnd.ShowUpDown = true;
            timePickerEnd.Value = DateTime.ParseExact("23:59:59", "HH:mm:ss", CultureInfo.InvariantCulture);

            List<Workout> workouts = await _workoutApiService.GetAll<List<Workout>>(null);
            cbWorkout.DataSource = workouts;
            cbWorkout.DisplayMember = "Name";
            cbWorkout.ValueMember = "Id";
        }

        public async Task loadGridData()
        {
            WorkoutScheduleSearchParams searchParams = new WorkoutScheduleSearchParams
            {
                DayOfWeek = (DayOfWeek)int.Parse(cbWorkoutDays.SelectedValue.ToString()),
                TimeFrom = new TimeSpan(timePickerStart.Value.Hour, timePickerStart.Value.Minute, 0),
                TimeTo = new TimeSpan(timePickerEnd.Value.Hour, timePickerEnd.Value.Minute, 0),
                WorkoutId = cbWorkout.SelectedValue.ToString()
            };

            _workoutScheduleList = await _workoutScheduleApiService.GetAll<List<WorkoutSchedule>>(searchParams);
            dgvSchedules.DataSource = _workoutScheduleList;
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            await loadGridData();
        }

        private void DgvSchedules_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = dgvSchedules.CurrentCell.RowIndex;
            int id = int.Parse(dgvSchedules.Rows[selectedRowIndex].Cells[0].Value.ToString());

            WorkoutSchedule workoutSchedule = _workoutScheduleList.Where(x => x.Id == id).FirstOrDefault();

            WorkoutScheduleCreateForm workoutForm = new WorkoutScheduleCreateForm(_accessToken, workoutSchedule);
            workoutForm.MdiParent = this.MdiParent;
            workoutForm.WindowState = FormWindowState.Maximized;
            workoutForm.ControlBox = false;
            workoutForm.MaximizeBox = false;
            workoutForm.MinimizeBox = false;
            workoutForm.ShowIcon = false;
            workoutForm.Show();
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvSchedules.SelectedRows.Count;

            if (selectedRowsCount == 1)
            {
                int selectedRowIndex = dgvSchedules.CurrentCell.RowIndex;
                int id = int.Parse(dgvSchedules.Rows[selectedRowIndex].Cells[0].Value.ToString());
                await _workoutScheduleApiService.Delete(id);
                await loadGridData();
            }
            else
            {
                MessageBox.Show("Only one row can be selected for delete operation");
            }
        }
    }
}
