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

            cbVrsta.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMessure.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async Task initComboBoxData()
        {
            List<SuplementType> types = await _suplementTypeApiService.GetAll<List<SuplementType>>(null);
            cbVrsta.DataSource = types;
            cbVrsta.DisplayMember = "Type";
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
            if (this.ValidateChildren())
            {
                SuplementCreateRequest createRequest = new SuplementCreateRequest
                {
                    Name = tbNaziv.Text,
                    Price = (double)numPrice.Value,
                    Description = tbOpis.Text,
                    Amount = (double)numKolicina.Value,
                    MessureUnit = cbMessure.Text,
                    SuplementTypeId = int.Parse(cbVrsta.SelectedValue.ToString())
                };

                if (_suplement == null)
                {
                    await _suplementApiService.Create<Suplement>(createRequest);
                }
                else
                {
                    await _suplementApiService.Update<Suplement>(_suplement.Id, createRequest);
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

        private void TbNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNaziv.Text))
            {
                errorProvider.SetError(tbNaziv, "Ovo polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(tbNaziv, null);
            }
        }

        private void NumPrice_Validating(object sender, CancelEventArgs e)
        {
            if (numPrice.Value <= 0)
            {
                errorProvider.SetError(numPrice, "Ovo polje je mora imati vrijednost iznad 0");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(numPrice, null);
            }
        }

        private void CbMessure_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbMessure.Text))
            {
                errorProvider.SetError(cbMessure, "Ovo polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cbMessure, null);
            }
        }

        private void NumKolicina_Validating(object sender, CancelEventArgs e)
        {
            if (numKolicina.Value <= 0)
            {
                errorProvider.SetError(numKolicina, "Ovo polje je mora imati vrijednost iznad 0");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(numKolicina, null);
            }
        }

        private void CbVrsta_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbVrsta.Text))
            {
                errorProvider.SetError(cbVrsta, "Ovo polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cbVrsta, null);
            }
        }

        private void TbOpis_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbOpis.Text))
            {
                errorProvider.SetError(tbOpis, "Ovo polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(tbOpis, null);
            }
        }
    }
}
