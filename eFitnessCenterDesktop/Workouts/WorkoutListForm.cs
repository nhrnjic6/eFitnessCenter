using eFitnessCenterDesktop.Services;
using Models.Requests.Workout;
using Models.Trainers;
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
    public partial class WorkoutListForm : Form
    {
        private string _accessToken;
        private readonly ApiService _trainerApiService;
        private readonly ApiService _workoutTypeApiService;
        private readonly ApiService _workoutApiService;
        private List<Workout> _workouts;

        public WorkoutListForm(string accessToken)
        {
            InitializeComponent();
            _accessToken = accessToken;
            _trainerApiService = new ApiService("trainers", _accessToken);
            _workoutTypeApiService = new ApiService("workoutType", _accessToken);
            _workoutApiService = new ApiService("workout", _accessToken);
            _ = loadWorkouts();
        }

        public async Task loadWorkouts()
        {
            await initFormData();
            await loadDataGrid();
        }

        public async Task initFormData()
        {
            List<Trainer> trainers = await _trainerApiService.GetAll<List<Trainer>>(null);
            cbTrainer.DataSource = trainers;
            cbTrainer.ValueMember = "Id";
            cbTrainer.DisplayMember = "Name";

            List<WorkoutType> workoutTypes = await _workoutTypeApiService.GetAll<List<WorkoutType>>(null);
            cbType.DataSource = workoutTypes;
            cbType.ValueMember = "Name";
            cbType.DisplayMember = "Name";
        }

        public async Task loadDataGrid()
        {
            WorkoutSearchParams searchParams = new WorkoutSearchParams
            {
                Difficulty = cbDifficulty.Text,
                Duration = string.IsNullOrEmpty(cbDuration.Text) ? null : (int?)int.Parse(cbDuration.Text),
                TrainerId = string.IsNullOrEmpty(cbTrainer.SelectedValue.ToString()) ? null : (int?) int.Parse(cbTrainer.SelectedValue.ToString()),
                WorkoutType = cbType.SelectedValue.ToString()
            };

            _workouts = await _workoutApiService.GetAll<List<Workout>>(searchParams);
            dgvWorkouts.DataSource = _workouts;
        }

        private async void BtnSeach_Click(object sender, EventArgs e)
        {
            await loadDataGrid();
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvWorkouts.SelectedRows.Count;

            if (selectedRowsCount == 1)
            {
                int selectedRowIndex = dgvWorkouts.CurrentCell.RowIndex;
                int id = int.Parse(dgvWorkouts.Rows[selectedRowIndex].Cells[0].Value.ToString());
                await _workoutApiService.Delete(id);
                await loadDataGrid();
            }
            else
            {
                MessageBox.Show("Only one row can be selected for delete operation");
            }
        }

        private void DgvWorkouts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = dgvWorkouts.CurrentCell.RowIndex;
            int id = int.Parse(dgvWorkouts.Rows[selectedRowIndex].Cells[0].Value.ToString());

            Workout workout = _workouts.Where(x => x.Id == id).FirstOrDefault();

            WorkoutCreateForm workoutForm = new WorkoutCreateForm(_accessToken, workout);
            workoutForm.MdiParent = this.MdiParent;
            workoutForm.WindowState = FormWindowState.Maximized;
            workoutForm.ControlBox = false;
            workoutForm.MaximizeBox = false;
            workoutForm.MinimizeBox = false;
            workoutForm.ShowIcon = false;
            workoutForm.Show();
        }
    }
}
