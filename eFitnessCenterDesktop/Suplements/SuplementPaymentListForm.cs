using eFitnessCenterDesktop.Services;
using Models.Requests.Suplements;
using Models.Suplements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFitnessCenterDesktop.Suplements
{
    public partial class SuplementPaymentListForm : Form
    {
        private string _accessToken;
        private readonly ApiService _suplementApiService;
        private readonly ApiService _suplementTypeApiService;
        private readonly ApiService _suplementPaymentApiService;
        private List<SuplementPayment> _suplementPayments;

        public SuplementPaymentListForm(string accessToken)
        {
            InitializeComponent();
            _accessToken = accessToken;
            _suplementApiService = new ApiService("suplements", accessToken);
            _suplementTypeApiService = new ApiService("suplementType", accessToken);
            _suplementPaymentApiService = new ApiService("suplementPayments", accessToken);

            initSuplementList();
            initSuplementTypeList();
        }

        private async Task initDataGrid()
        {
            SuplementPaymentSearchParams searchParams = new SuplementPaymentSearchParams
            {
                ClientFirstName = tbFirstName.Text,
                ClientLastName = tbLastName.Text,
                SuplementName = cbSuplement.SelectedValue.ToString(),
                SuplementType = cbSuplementType.SelectedValue.ToString()
            };

            _suplementPayments = await _suplementPaymentApiService.GetAll<List<SuplementPayment>>(searchParams);
            dgvSuplementPayments.DataSource = _suplementPayments;
        }

        private async void initSuplementList()
        {   
            List<Suplement> suplements = await _suplementApiService.GetAll<List<Suplement>>(null);
            cbSuplement.DataSource = suplements;
            cbSuplement.ValueMember = "Name";
            cbSuplement.DisplayMember = "Name";
        }

        private async void initSuplementTypeList()
        {
            List<SuplementType> suplementType = await _suplementTypeApiService.GetAll<List<SuplementType>>(null);
            cbSuplementType.DataSource = suplementType;
            cbSuplementType.ValueMember = "Type";
            cbSuplementType.DisplayMember = "Type";
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            await initDataGrid();
        }

        private void DgvSuplementPayments_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = dgvSuplementPayments.CurrentCell.RowIndex;
            int id = int.Parse(dgvSuplementPayments.Rows[selectedRowIndex].Cells[0].Value.ToString());

            SuplementPayment paymentForEdit = _suplementPayments.Where(x => x.Id == id).FirstOrDefault();

            SuplementPaymentCreate form = new SuplementPaymentCreate(_accessToken, paymentForEdit);
            form.MdiParent = this.MdiParent;
            form.WindowState = FormWindowState.Maximized;
            form.ControlBox = false;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ShowIcon = false;

            form.Show();
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvSuplementPayments.SelectedRows.Count;

            if (selectedRowsCount == 1)
            {
                int selectedRowIndex = dgvSuplementPayments.CurrentCell.RowIndex;
                int id = int.Parse(dgvSuplementPayments.Rows[selectedRowIndex].Cells[0].Value.ToString());
                await _suplementPaymentApiService.Delete(id);
                await initDataGrid();
            }
            else
            {
                MessageBox.Show("Only one row can be selected for delete operation");
            }
        }
    }
}
