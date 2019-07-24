using eFitnessCenterDesktop.Services;
using Models.Clients;
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
    public partial class WorkoutAdviceListForm : Form
    {
        private string _accessToken;
        private readonly ApiService _trainerApiService;
        private readonly ApiService _clientApiService;
        private readonly ApiService _workoutAdviceApiService;

        private List<WorkoutAdvice> _workoutAdvices;

        public WorkoutAdviceListForm(string accessToken)
        {
            InitializeComponent();
            _accessToken = accessToken;
            _trainerApiService = new ApiService("trainers", _accessToken);
            _clientApiService = new ApiService("clients", _accessToken);
            _workoutAdviceApiService = new ApiService("workoutAdvice", _accessToken);
            _ = initFormData();
            _ = loadGridData();
        }

        public async Task initFormData()
        {
            List<Trainer> trainers = await _trainerApiService.GetAll<List<Trainer>>(null);
            List<Client> clients = await _clientApiService.GetAll<List<Client>>(null);

            cbClient.DataSource = clients;
            cbClient.ValueMember = "Id";
            cbClient.DisplayMember = "Name";

            cbTrainer.DataSource = trainers;
            cbTrainer.ValueMember = "Id";
            cbTrainer.DisplayMember = "Name";
        }

        public async Task loadGridData()
        {
            _workoutAdvices = await _workoutAdviceApiService.GetAll<List<WorkoutAdvice>>(null);
            dgvAdvices.DataSource = _workoutAdvices;
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            await loadGridData();
        }

        private void DgvAdvices_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = dgvAdvices.CurrentCell.RowIndex;
            int id = int.Parse(dgvAdvices.Rows[selectedRowIndex].Cells[0].Value.ToString());

            WorkoutAdvice workoutAdvice = _workoutAdvices.Where(x => x.Id == id).FirstOrDefault();

            WorkoutAdviceCreateForm workoutForm = new WorkoutAdviceCreateForm(_accessToken, workoutAdvice);
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
            int selectedRowsCount = dgvAdvices.SelectedRows.Count;

            if (selectedRowsCount == 1)
            {
                int selectedRowIndex = dgvAdvices.CurrentCell.RowIndex;
                int id = int.Parse(dgvAdvices.Rows[selectedRowIndex].Cells[0].Value.ToString());
                await _workoutAdviceApiService.Delete(id);
                await loadGridData();
            }
            else
            {
                MessageBox.Show("Only one row can be selected for delete operation");
            }
        }
    }
}
