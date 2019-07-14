using eFitnessCenterDesktop.Services;
using Models.Requests.Workout;
using Models.Workout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFitnessCenterDesktop.Workouts
{
    public partial class WorkoutScheduleCreateForm : Form
    {
        private string _accessToken;
        private readonly ApiService _workoutApiService;
        private readonly ApiService _workoutScheduleApiService;
        private readonly WorkoutSchedule _workoutSchedule;
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


        public WorkoutScheduleCreateForm(string accessToken, WorkoutSchedule workoutSchedule)
        {
            InitializeComponent();

            timePicker.Format = DateTimePickerFormat.Custom;
            timePicker.CustomFormat = "HH:mm";
            timePicker.ShowUpDown = true;

            _accessToken = accessToken;
            _workoutSchedule = workoutSchedule;
            _workoutApiService = new ApiService("workout", _accessToken);
            _workoutScheduleApiService = new ApiService("workoutSchedule", _accessToken);

            _ = initFormData();
        }

        public async Task initFormData()
        {
            List<Workout> workouts = await _workoutApiService.GetAll<List<Workout>>(null);
            cbWorkout.DataSource = workouts;
            cbWorkout.DisplayMember = "Name";
            cbWorkout.ValueMember = "Id";

            cbDayOfWeek.DataSource = DateTimeList;
            cbDayOfWeek.DisplayMember = "Name";
            cbDayOfWeek.ValueMember = "Value";

            if (_workoutSchedule != null)
            {
                Enum.TryParse(_workoutSchedule.DayOfTheWeek, out DayOfWeek dayOfWeek);

                tbDescription.Text = _workoutSchedule.Description;
                cbDayOfWeek.SelectedValue = (int) dayOfWeek;
                cbWorkout.SelectedValue = _workoutSchedule.WorkoutId;
                timePicker.Value = Convert.ToDateTime(_workoutSchedule.TimeOfTheDay);
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            WorkoutScheduleCreate scheduleCreate = new WorkoutScheduleCreate
            {
                DayOfTheWeek = (DayOfWeek)int.Parse(cbDayOfWeek.SelectedValue.ToString()),
                Description = tbDescription.Text,
                TimeOfTheDay = new TimeSpan(timePicker.Value.Hour, timePicker.Value.Minute, 0),
                WorkoutId = int.Parse(cbWorkout.SelectedValue.ToString())
            };

            await _workoutScheduleApiService.Create<Workout>(scheduleCreate);
        }
    }
}
