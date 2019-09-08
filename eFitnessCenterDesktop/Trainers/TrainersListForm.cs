using eFitnessCenterDesktop.Services;
using Models.Requests;
using Models.Requests.Trainers;
using Models.Trainers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFitnessCenterDesktop.Trainers
{
    public partial class TrainersListForm : Form
    {
        private string _accessToken;
        private readonly ApiService _apiService;
        private List<Trainer> _trainers;

        public TrainersListForm(string accessToken)
        {
            InitializeComponent();
            cbUserStatus.Text = "Active";
            _accessToken = accessToken;
            _apiService = new ApiService("trainers", _accessToken);

            _= loadDataGrid();
        }

        public async Task loadDataGrid()
        {
            var userStatus = cbUserStatus.Text;
            UserStatus? status = fromString(userStatus);

            SearchTrainerParams searchTrainerParams = new SearchTrainerParams
            {
                UserStatus = status,
                FirstName = tbIme.Text,
                LastName = tbPrezime.Text
            };

            _trainers = await _apiService.GetAll<List<Trainer>>(searchTrainerParams);
            dgvTrainers.DataSource = _trainers;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           // new AddTrainerForm(_accessToken, null).Show();
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvTrainers.SelectedRows.Count;

            if (selectedRowsCount == 1)
            {
                int selectedRowIndex = dgvTrainers.CurrentCell.RowIndex;
                int id = int.Parse(dgvTrainers.Rows[selectedRowIndex].Cells[0].Value.ToString());
                await _apiService.Delete(id);
                await loadDataGrid();
            }
            else
            {
                MessageBox.Show("Only one row can be selected for delete operation");
            }
        }

        private UserStatus? fromString(string userStatus)
        {
            switch (userStatus)
            {
                case "Active": return UserStatus.ACTIVE;
                case "Inactive": return UserStatus.INACTIVE;
                case "Deleted": return UserStatus.DELETED;
                default: return null;
            }
        }

        private void DgvTrainers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = dgvTrainers.CurrentCell.RowIndex;
            int id = int.Parse(dgvTrainers.Rows[selectedRowIndex].Cells[0].Value.ToString());
            Trainer trainerForEdit = _trainers.Where(x => x.Id == id).FirstOrDefault();

            AddTrainerForm addTrainerForm = new AddTrainerForm(_accessToken, trainerForEdit);
            addTrainerForm.MdiParent = this.MdiParent;
            addTrainerForm.WindowState = FormWindowState.Maximized;
            addTrainerForm.ControlBox = false;
            addTrainerForm.MaximizeBox = false;
            addTrainerForm.MinimizeBox = false;
            addTrainerForm.ShowIcon = false;

            addTrainerForm.Show();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            _ = loadDataGrid();
        }
    }
}
