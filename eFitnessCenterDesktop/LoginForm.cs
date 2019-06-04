using eFitnessCenterDesktop.Services;
using Models.Requests.Token;
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
    public partial class LoginForm : Form
    {
        private readonly TokenService tokenService;

        public LoginForm()
        {
            InitializeComponent();
            tokenService = new TokenService();
        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            string email = inputEmail.Text;
            string password = inputPassword.Text;
            TokenResponse result = await tokenService.GetToken(
            new GetTokenPost{
                Email = email,
                Password = password});

            if(result == null)
            {
                MessageBox.Show("Invalid username or password");
            }
            else
            {
                MessageBox.Show(result.AccessToken);
            }
        }
    }
}
