using eFitnessCenterDesktop.Services;
using Models.Clients;
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
    public partial class SuplementPaymentCreate : Form
    {
        private string _accessToken;
        private readonly ApiService _suplementPaymentApiService;
        private readonly ApiService _suplementApiService;
        private readonly ApiService _clientsApiService;
        private readonly SuplementPayment _paymentForEdit;

        public SuplementPaymentCreate(string accessToken, SuplementPayment paymentForEdit)
        {
            InitializeComponent();
            _accessToken = accessToken;
            _paymentForEdit = paymentForEdit;
            _suplementApiService = new ApiService("suplements", _accessToken);
            _suplementPaymentApiService = new ApiService("suplementPayments", _accessToken);
            _clientsApiService = new ApiService("clients", _accessToken);

            initFormData();
        }

        private async void initFormData()
        {
            List<Client> clients = await _clientsApiService.GetAll<List<Client>>(null);
            cbKorisnik.DataSource = clients;
            cbKorisnik.ValueMember = "Id";
            cbKorisnik.DisplayMember = "Name";

            List<Suplement> suplements = await _suplementApiService.GetAll<List<Suplement>>(null);
            cbSuplement.DataSource = suplements;
            cbSuplement.DisplayMember = "Name";
            cbSuplement.ValueMember = "Id";

            if(_paymentForEdit != null)
            {
                int clientId = clients
                    .Where(x => _paymentForEdit.ClientName.Contains(x.FirstName))
                    .Where(x => _paymentForEdit.ClientName.Contains(x.LastName))
                    .FirstOrDefault().Id;

                int suplementId = suplements
                    .Where(x => x.Name.Equals(_paymentForEdit.SuplementName))
                    .FirstOrDefault().Id;

                cbKorisnik.SelectedValue = clientId;
                cbSuplement.SelectedValue = suplementId;

                nupKolicina.Value = _paymentForEdit.Amount;
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                SuplementPaymentRequest paymentRequest = new SuplementPaymentRequest
                {
                    ClientId = int.Parse(cbKorisnik.SelectedValue.ToString()),
                    SuplementId = int.Parse(cbSuplement.SelectedValue.ToString()),
                    Amount = (int)nupKolicina.Value
                };

                if (_paymentForEdit == null)
                {
                    await _suplementPaymentApiService.Create<SuplementPayment>(paymentRequest);
                }
                else
                {
                    await _suplementPaymentApiService.Update<SuplementPayment>(_paymentForEdit.Id, paymentRequest);
                }

                SuplementPaymentListForm paymentForm = new SuplementPaymentListForm(_accessToken);
                paymentForm.MdiParent = this.MdiParent;
                paymentForm.WindowState = FormWindowState.Maximized;
                paymentForm.ControlBox = false;
                paymentForm.MaximizeBox = false;
                paymentForm.MinimizeBox = false;
                paymentForm.ShowIcon = false;
                paymentForm.Show();
            }
        }

        private void CbKorisnik_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbKorisnik.Text))
            {
                errorProvider.SetError(cbKorisnik, "Ovo polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cbKorisnik, null);
            }
        }

        private void CbSuplement_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbSuplement.Text))
            {
                errorProvider.SetError(cbSuplement, "Ovo polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cbSuplement, null);
            }
        }

        private void NupKolicina_Validating(object sender, CancelEventArgs e)
        {
            if (nupKolicina.Value <= 0)
            {
                errorProvider.SetError(nupKolicina, "Ovo polje mora imati vrijednost iznad 0");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(nupKolicina, null);
            }
        }
    }
}
