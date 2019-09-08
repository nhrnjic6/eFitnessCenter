using eFitnessCenterDesktop.Services;
using eFitnessCenterDesktop.Suplements;
using Models.Requests;
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

namespace eFitnessCenterDesktop
{
    public partial class SuplementsListForm : Form
    {
        private string _accessToken;
        private readonly ApiService _suplementApiService;
        private readonly ApiService _suplementTypeApiService;
        private List<Suplement> _suplements;

        public SuplementsListForm(string accessToken)
        {
            InitializeComponent();
            _accessToken = accessToken;
            _suplementApiService = new ApiService("suplements", _accessToken);
            _suplementTypeApiService = new ApiService("suplementType", _accessToken);
            _ = loadSuplements();
        }

        private async Task loadSuplements()
        {
            await initComboBoxData();
            await initGridData();
        }

        private async Task initGridData()
        {
            SuplementSearchParams searchParams = new SuplementSearchParams
            {
                Name = tbName.Text,
                Type = cbVrsta.SelectedValue.ToString()
            };

            _suplements = await _suplementApiService.GetAll<List<Suplement>>(searchParams);
            dgvSuplements.DataSource = _suplements;
        }

        private async Task initComboBoxData()
        {
            List<SuplementType> types = await _suplementTypeApiService.GetAll<List<SuplementType>>(null);
            cbVrsta.DataSource = types;
            cbVrsta.DisplayMember = "Type";
            cbVrsta.ValueMember = "Type";
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            await initGridData();
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvSuplements.SelectedRows.Count;

            if (selectedRowsCount == 1)
            {
                int selectedRowIndex = dgvSuplements.CurrentCell.RowIndex;
                int id = int.Parse(dgvSuplements.Rows[selectedRowIndex].Cells[0].Value.ToString());
                await _suplementApiService.Delete(id);
                await initGridData();
            }
            else
            {
                MessageBox.Show("Only one row can be selected for delete operation");
            }
        }

        private void DgvSuplements_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = dgvSuplements.CurrentCell.RowIndex;
            int id = int.Parse(dgvSuplements.Rows[selectedRowIndex].Cells[0].Value.ToString());

            Suplement suplementForEdit = _suplements.Where(x => x.Id == id).FirstOrDefault();

            numAmount suplementAddForm = new numAmount(_accessToken, suplementForEdit);
            suplementAddForm.MdiParent = this.MdiParent;
            suplementAddForm.WindowState = FormWindowState.Maximized;
            suplementAddForm.ControlBox = false;
            suplementAddForm.MaximizeBox = false;
            suplementAddForm.MinimizeBox = false;
            suplementAddForm.ShowIcon = false;

            suplementAddForm.Show();
        }

        private void SuplementBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
