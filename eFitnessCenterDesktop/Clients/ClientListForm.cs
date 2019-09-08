using eFitnessCenterDesktop.Services;
using Models.Clients;
using Models.Requests;
using Models.Requests.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFitnessCenterDesktop.Clients
{
    public partial class ClientListForm : Form
    {
        private string _accessToken;
        private readonly ApiService _apiService;
        private List<Client> _clients;

        public ClientListForm(string accessToken)
        {
            InitializeComponent();
            cbUserStatus.Text = "Active";
            _accessToken = accessToken;
            _apiService = new ApiService("clients", _accessToken);

            _= loadDataGrid(); 
        }

        public async Task loadDataGrid()
        {
            var userStatus = cbUserStatus.Text;
            UserStatus? status = fromString(userStatus);

            SearchClientParams searchClientParams = new SearchClientParams
            {
                UserStatus = status,
                FirstName = tbIme.Text,
                LastName = tbPrezime.Text
            };

            _clients = await _apiService.GetAll<List<Client>>(searchClientParams);
            dgvClients.DataSource = _clients;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new AddClientForm(_accessToken, null).Show();
        }

        private void DgvClients_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = dgvClients.CurrentCell.RowIndex;
            int id = int.Parse(dgvClients.Rows[selectedRowIndex].Cells[0].Value.ToString());
            Client clientForEdit = _clients.Where(x => x.Id == id).FirstOrDefault();

            AddClientForm addClientForm = new AddClientForm(_accessToken, clientForEdit);
            addClientForm.MdiParent = this.MdiParent;
            addClientForm.WindowState = FormWindowState.Maximized;
            addClientForm.ControlBox = false;
            addClientForm.MaximizeBox = false;
            addClientForm.MinimizeBox = false;
            addClientForm.ShowIcon = false;

            addClientForm.Show();
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            await loadDataGrid();
        }   

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvClients.SelectedRows.Count;

            if(selectedRowsCount == 1)
            {
                int selectedRowIndex = dgvClients.CurrentCell.RowIndex;
                int id = int.Parse(dgvClients.Rows[selectedRowIndex].Cells[0].Value.ToString());
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
    }
}
