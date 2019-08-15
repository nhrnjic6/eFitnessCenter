using eFitnessCenterDesktop.Services;
using Models.Clients;
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
    public partial class WorkoutAdviceCreateForm : Form
    {
        private string _accessToken;
        private readonly ApiService _trainerApiService;
        private readonly ApiService _clientApiService;
        private readonly ApiService _workoutAdviceApiService;

        private readonly WorkoutAdvice _workoutAdvice;

        public WorkoutAdviceCreateForm(string accessToken, WorkoutAdvice workoutAdvice)
        {
            InitializeComponent();
            _accessToken = accessToken;
            _workoutAdvice = workoutAdvice;
            _trainerApiService = new ApiService("trainers", _accessToken);
            _clientApiService = new ApiService("clients", _accessToken);
            _workoutAdviceApiService = new ApiService("workoutAdvice", _accessToken);
            _ = initFormData();
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

            if(_workoutAdvice != null)
            {
                tbMessage.Text = _workoutAdvice.Message;
                cbClient.SelectedValue = _workoutAdvice.ClientId;
                cbTrainer.SelectedValue = _workoutAdvice.TrainerId;
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                WorkoutAdviceCreate adviceCreate = new WorkoutAdviceCreate
                {
                    ClientId = int.Parse(cbClient.SelectedValue.ToString()),
                    TrainerId = int.Parse(cbTrainer.SelectedValue.ToString()),
                    Message = tbMessage.Text
                };

                if (_workoutAdvice == null)
                {
                    await _workoutAdviceApiService.Create<WorkoutAdvice>(adviceCreate);
                }
                else
                {
                    await _workoutAdviceApiService.Update<WorkoutAdvice>(_workoutAdvice.Id, adviceCreate);
                }

                WorkoutAdviceListForm workoutForm = new WorkoutAdviceListForm(_accessToken);
                workoutForm.MdiParent = this.MdiParent;
                workoutForm.WindowState = FormWindowState.Maximized;
                workoutForm.ControlBox = false;
                workoutForm.MaximizeBox = false;
                workoutForm.MinimizeBox = false;
                workoutForm.ShowIcon = false;
                workoutForm.Show();
            }
        }

        private void CbClient_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbClient.Text))
            {
                errorProvider.SetError(cbClient, "Ovo polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cbClient, null);
            }
        }

        private void CbTrainer_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbTrainer.Text))
            {
                errorProvider.SetError(cbTrainer, "Ovo polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cbTrainer, null);
            }
        }

        private void TbMessage_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbMessage.Text))
            {
                errorProvider.SetError(tbMessage, "Ovo polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(tbMessage, null);
            }
        }
    }
}
