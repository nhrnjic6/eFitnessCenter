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
    public partial class AddTrainerForm : Form
    {
        private string _accessToken;
        private readonly ApiService _apiService;
        private readonly Trainer _trainerForEdit;

        public AddTrainerForm(string accessToken, Trainer trainer)
        {
            InitializeComponent();
            _accessToken = accessToken;
            _trainerForEdit = trainer;
            _apiService = new ApiService("trainers", _accessToken);
            SetTrainerForEdit();
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void SetTrainerForEdit()
        {
            if (_trainerForEdit != null)
            {
                lblStatus.Visible = true;
                cbStatus.Visible = true;

                cbStatus.Text = toStringStatus(_trainerForEdit.Status);

                tbPassword.Visible = false;
                tbIme.Text = _trainerForEdit.FirstName;
                tbPrezime.Text = _trainerForEdit.LastName;
                tbEmail.Text = _trainerForEdit.Email;
                tbTelefon.Text = _trainerForEdit.PhoneNumber;
                tbAdresa.Text = _trainerForEdit.Address;
            }
        }

        private async void CreateNewClient()
        {
            CreateTrainerRequest createTrainerRequest = new CreateTrainerRequest
            {
                FirstName = tbIme.Text,
                LastName = tbPrezime.Text,
                Email = tbEmail.Text,
                Password = tbPassword.Text,
                Address = tbAdresa.Text,
                PhoneNumber = tbTelefon.Text
            };

            await _apiService.Create<Trainer>(createTrainerRequest);
        }

        private async void UpdateClient()
        {
            UpdateTrainerRequest updateTrainerRequest = new UpdateTrainerRequest
            {
                FirstName = tbIme.Text,
                LastName = tbPrezime.Text,
                Email = tbEmail.Text,
                Address = tbAdresa.Text,
                PhoneNumber = tbTelefon.Text,
                Status = fromString(cbStatus.Text)
            };

            await _apiService.Update<Trainer>(_trainerForEdit.Id, updateTrainerRequest);
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

        private string toStringStatus(UserStatus userStatus)
        {
            switch (userStatus)
            {
                case UserStatus.ACTIVE: return "Active";
                case UserStatus.INACTIVE: return "Inactive";
                case UserStatus.DELETED: return "Deleted";
                default: return "Inactive";
            }
        }

        private void LblStatus_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click_1(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (_trainerForEdit == null)
                {
                    CreateNewClient();
                }
                else
                {
                    UpdateClient();
                }

                TrainersListForm clientListForm = new TrainersListForm(_accessToken);
                clientListForm.MdiParent = this.MdiParent;
                clientListForm.WindowState = FormWindowState.Maximized;
                clientListForm.ControlBox = false;
                clientListForm.MaximizeBox = false;
                clientListForm.MinimizeBox = false;
                clientListForm.ShowIcon = false;

                clientListForm.Show();
            }
        }

        private void TbIme_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbIme.Text))
            {
                errorProvider.SetError(tbIme, "Ovo polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(tbIme, null);
            }
        }

        private void TbPrezime_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbPrezime.Text))
            {
                errorProvider.SetError(tbPrezime, "Ovo polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(tbPrezime, null);
            }
        }

        private void TbEmail_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                errorProvider.SetError(tbEmail, "Ovo polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(tbEmail, null);
            }
        }

        private void TbPassword_Validating_1(object sender, CancelEventArgs e)
        {
            if (_trainerForEdit == null && string.IsNullOrEmpty(tbPassword.Text))
            {
                errorProvider.SetError(tbPassword, "Ovo polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(tbPassword, null);
            }
        }

        private void TbAdresa_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbAdresa.Text))
            {
                errorProvider.SetError(tbAdresa, "Ovo polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(tbAdresa, null);
            }
        }

        private void TbTelefon_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbTelefon.Text))
            {
                errorProvider.SetError(tbTelefon, "Ovo polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(tbTelefon, null);
            }
        }

        private void CbStatus_Validating_1(object sender, CancelEventArgs e)
        {
            if (cbStatus.Visible && string.IsNullOrEmpty(cbStatus.Text))
            {
                errorProvider.SetError(cbStatus, "Ovo polje je obavezno");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cbStatus, null);
            }
        }
    }
}
