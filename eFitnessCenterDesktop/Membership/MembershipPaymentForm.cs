using eFitnessCenterDesktop.Services;
using Models.Clients;
using Models.Membership;
using Models.Requests.Membership;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFitnessCenterDesktop.Membership
{
    public partial class MembershipPaymentForm : Form
    {
        private readonly ApiService _apiService;
        private readonly string _accessToken;
        private readonly Client _client;
        private List<MembershipPayment> _payments;

        public MembershipPaymentForm(string token, Client client)
        {
            InitializeComponent();
            _accessToken = token;
            _client = client;
            _apiService = new ApiService("membershipPayments", token);
            _= initDataGrid();
        }

        private async Task initDataGrid()
        {
            MembershipPaymentSearchParams searchParams = new MembershipPaymentSearchParams
            {
                ClientId = _client.Id
            };

            _payments = await _apiService.GetAll<List<MembershipPayment>>(searchParams);

            dgvPayments.DataSource = _payments;
            dgvPayments.Visible = true;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            MembershipPaymentCreateForm paymentForm = new MembershipPaymentCreateForm(_accessToken, _client ,null);
            paymentForm.MdiParent = this.MdiParent;
            paymentForm.WindowState = FormWindowState.Maximized;
            paymentForm.ControlBox = false;
            paymentForm.MaximizeBox = false;
            paymentForm.MinimizeBox = false;
            paymentForm.ShowIcon = false;

            paymentForm.Show();
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvPayments.SelectedRows.Count;

            if (selectedRowsCount == 1)
            {
                int selectedRowIndex = dgvPayments.CurrentCell.RowIndex;
                int id = int.Parse(dgvPayments.Rows[selectedRowIndex].Cells[0].Value.ToString());
                await _apiService.Delete(id);
                await initDataGrid();
            }
            else
            {
                MessageBox.Show("Only one row can be selected for delete operation");
            }
        }

        private void DgvPayments_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = dgvPayments.CurrentCell.RowIndex;
            int id = int.Parse(dgvPayments.Rows[selectedRowIndex].Cells[0].Value.ToString());

            MembershipPayment payment = _payments.Where(x => x.Id == id).FirstOrDefault();
            MembershipPaymentCreateForm paymentForm = new MembershipPaymentCreateForm(_accessToken, _client, payment);
            paymentForm.MdiParent = this.MdiParent;
            paymentForm.WindowState = FormWindowState.Maximized;
            paymentForm.ControlBox = false;
            paymentForm.MaximizeBox = false;
            paymentForm.MinimizeBox = false;
            paymentForm.ShowIcon = false;

            paymentForm.Show();
        }
    }
}
