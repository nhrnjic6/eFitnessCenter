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
                int dayOfWeekInt = (int)dayOfWeek;

                tbDescription.Text = _workoutSchedule.Description;
                cbDayOfWeek.SelectedValue = dayOfWeekInt.ToString();
                cbWorkout.SelectedValue = _workoutSchedule.WorkoutId;
                timePicker.Value = Convert.ToDateTime(_workoutSchedule.TimeOfTheDay);
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                WorkoutScheduleCreate scheduleCreate = new WorkoutScheduleCreate
                {
                    DayOfTheWeek = (DayOfWeek)int.Parse(cbDayOfWeek.SelectedValue.ToString()),
                    Description = tbDescription.Text,
                    TimeOfTheDay = new TimeSpan(timePicker.Value.Hour, timePicker.Value.Minute, 0),
                    WorkoutId = int.Parse(cbWorkout.SelectedValue.ToString())
                };

                if (_workoutSchedule == null)
                {
                    await _workoutScheduleApiService.Create<Workout>(scheduleCreate);
                }
                else
                {
                    await _workoutScheduleApiService.Update<Workout>(_workoutSchedule.Id, scheduleCreate);
                }

                WorkoutScheduleListForm workoutForm = new WorkoutScheduleListForm(_accessToken);
                workoutForm.MdiParent = this.MdiParent;
                workoutForm.WindowState = FormWindowState.Maximized;
                workoutForm.ControlBox = false;
                workoutForm.MaximizeBox = false;
                workoutForm.MinimizeBox = false;
                workoutForm.ShowIcon = false;
                workoutForm.Show();
            }   
        }

        private void CbWorkout_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbWorkout.Text))
            {
                errorProvider.SetError(cbWorkout, "Ovo polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cbWorkout, null);
            }
        }

        private void CbDayOfWeek_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbDayOfWeek.Text))
            {
                errorProvider.SetError(cbDayOfWeek, "Ovo polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cbDayOfWeek, null);
            }
        }

        private void TimePicker_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(timePicker.Text))
            {
                errorProvider.SetError(timePicker, "Ovo polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(timePicker, null);
            }
        }

        private void TbDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbDescription.Text))
            {
                errorProvider.SetError(tbDescription, "Ovo polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(tbDescription, null);
            }
        }
    }
}
