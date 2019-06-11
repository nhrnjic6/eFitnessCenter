using eFitnessCenterDesktop.Services;
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
        private readonly ApiService _apiService;
        private List<Suplement> _clients;

        public SuplementsListForm(string accessToken)
        {
            _accessToken = accessToken;
            _apiService = new ApiService("suplements", _accessToken);
        }


    }
}
