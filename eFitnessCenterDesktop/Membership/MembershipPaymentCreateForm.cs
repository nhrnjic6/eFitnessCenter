using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eFitnessCenterDesktop.Services;
using Models.Clients;
using Models.Membership;
using Models.Requests.Membership;

namespace eFitnessCenterDesktop.Membership
{
    public partial class MembershipPaymentCreateForm : Form
    {
        private readonly ApiService _apiService;
        private readonly ApiService _membershipTypeApiService;
        private readonly string _token;
        private readonly MembershipPayment _payment;
        private List<MembershipType> _membershipTypes;
        private readonly Client _client;

        public MembershipPaymentCreateForm(string token, Client client, MembershipPayment payment)
        {
            InitializeComponent();
            _token = token;
            _payment = payment;
            _client = client;
            _apiService = new ApiService("membershipPayments", token);
            _membershipTypeApiService = new ApiService("membershipTypes", token);
            initData();
        }

        private async void initData()
        {
            _membershipTypes = await _membershipTypeApiService.GetAll<List<MembershipType>>(null);
            cbClanarinaType.DataSource = _membershipTypes;
            cbClanarinaType.ValueMember = "Id";
            cbClanarinaType.DisplayMember = "Name";

            lblDescription.Text += $"{_client.FirstName} {_client.LastName}";

            if(_payment != null)
            {
                int id = _membershipTypes.Where(x => x.Name == _payment.MembershipTypeName).FirstOrDefault().Id;
                cbClanarinaType.SelectedValue = id;
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if(_payment == null)
            {
                MembershipPaymentCreate membershipPayment = new MembershipPaymentCreate
                {
                    ClientId = _client.Id,
                    MembershipTypeId = int.Parse(cbClanarinaType.SelectedValue.ToString())
                };

                await _apiService.Create<MembershipType>(membershipPayment);
            }
            else
            {
                MembershipPaymentUpdate membershipUpdate = new MembershipPaymentUpdate
                {
                    MembershipTypeId = int.Parse(cbClanarinaType.SelectedValue.ToString())
                };

                await _apiService.Update<MembershipType>(_payment.Id, membershipUpdate);
            }

            MembershipPaymentForm paymentForm = new MembershipPaymentForm(_token, _client);
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
