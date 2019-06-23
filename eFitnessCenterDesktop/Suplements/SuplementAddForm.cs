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
    public partial class numAmount : Form
    {
        private string _accessToken;
        private Suplement _suplement;
        private readonly ApiService _suplementApiService;
        private readonly ApiService _suplementTypeApiService;

        public numAmount(string accessToken, Suplement suplement)
        {
            InitializeComponent();
            _accessToken = accessToken;
            _suplement = suplement;
            _suplementApiService = new ApiService("suplements", _accessToken);
            _suplementTypeApiService = new ApiService("suplementType", _accessToken);
            setEditFields();
        }

        private async Task initComboBoxData()
        {
            List<SuplementType> types = await _suplementTypeApiService.GetAll<List<SuplementType>>(null);
            cbVrsta.DataSource = types;
            cbVrsta.DisplayMember = "Name";
            cbVrsta.ValueMember = "Id";
        }

        private async void setEditFields()
        {
            await initComboBoxData();

            if (_suplement != null) {

                tbNaziv.Text = _suplement.Name;
                numPrice.Value = (decimal) _suplement.Price;
                tbOpis.Text = _suplement.Description;
                numKolicina.Value = (decimal) _suplement.Amount;
                cbMessure.Text = _suplement.MessureUnit;
                cbVrsta.SelectedValue = _suplement.SuplementTypeId;
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            SuplementCreateRequest createRequest = new SuplementCreateRequest
            {
                Name = tbNaziv.Text,
                Price = (double) numPrice.Value,
                Description = tbOpis.Text,
                Amount = (double) numKolicina.Value,
                MessureUnit = cbMessure.Text,
                SuplementTypeId = int.Parse(cbVrsta.SelectedValue.ToString())
            };

            if(_suplement == null)
            {
                await _suplementApiService.Create<Suplement>(createRequest);
            }
            else
            {
                await _suplementApiService.Update<Suplement>(_suplement.Id ,createRequest);
            }

            SuplementsListForm suplementListForm = new SuplementsListForm(_accessToken);
            suplementListForm.MdiParent = this.MdiParent;
            suplementListForm.WindowState = FormWindowState.Maximized;
            suplementListForm.ControlBox = false;
            suplementListForm.MaximizeBox = false;
            suplementListForm.MinimizeBox = false;
            suplementListForm.ShowIcon = false;

            suplementListForm.Show();
        }
    }
}
