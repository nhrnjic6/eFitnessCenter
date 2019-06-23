using eFitnessCenterDesktop.Clients;
using eFitnessCenterDesktop.Suplements;
using Models.Clients;
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
    public partial class MainForm : Form
    {
        private int childFormNumber = 0;
        private string _accessToken;

        public MainForm()
        {
            InitializeComponent();
            ShowLoginForm();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void AllClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowClientList();
        }

        private void ShowClientList()
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }

            ClientListForm clientListForm = new ClientListForm(_accessToken);
            clientListForm.MdiParent = this;
            clientListForm.WindowState = FormWindowState.Maximized;
            clientListForm.ControlBox = false;
            clientListForm.MaximizeBox = false;
            clientListForm.MinimizeBox = false;
            clientListForm.ShowIcon = false;

            clientListForm.Show();
        }

        private void ShowNewClient(Client client)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }

            AddClientForm addClientForm = new AddClientForm(_accessToken, client);
            addClientForm.MdiParent = this;
            addClientForm.WindowState = FormWindowState.Maximized;
            addClientForm.ControlBox = false;
            addClientForm.MaximizeBox = false;
            addClientForm.MinimizeBox = false;
            addClientForm.ShowIcon = false;

            addClientForm.Show();
        }

        private void ShowLoginForm()
        {
            LoginForm loginForm = new LoginForm();
            loginForm.MdiParent = this;
            loginForm.WindowState = FormWindowState.Maximized;
            loginForm.ControlBox = false;
            loginForm.MaximizeBox = false;
            loginForm.MinimizeBox = false;
            loginForm.ShowIcon = false;
            loginForm.Show();

            loginForm.OnTokenFetch((token) =>
            {
                _accessToken = token;
                ShowClientList();
            });
        }

        private void AddClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNewClient(null);
        }

        private void SuplementListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuplementsListForm suplementsListForm = new SuplementsListForm(_accessToken);
            suplementsListForm.MdiParent = this;
            suplementsListForm.WindowState = FormWindowState.Maximized;
            suplementsListForm.ControlBox = false;
            suplementsListForm.MaximizeBox = false;
            suplementsListForm.MinimizeBox = false;
            suplementsListForm.ShowIcon = false;
            suplementsListForm.Show();
        }

        private void NewSuplementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            numAmount suplementsAddForm = new numAmount(_accessToken, null);
            suplementsAddForm.MdiParent = this;
            suplementsAddForm.WindowState = FormWindowState.Maximized;
            suplementsAddForm.ControlBox = false;
            suplementsAddForm.MaximizeBox = false;
            suplementsAddForm.MinimizeBox = false;
            suplementsAddForm.ShowIcon = false;
            suplementsAddForm.Show();
        }

        private void SuplementPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuplementPaymentListForm paymentForm = new SuplementPaymentListForm(_accessToken);
            paymentForm.MdiParent = this;
            paymentForm.WindowState = FormWindowState.Maximized;
            paymentForm.ControlBox = false;
            paymentForm.MaximizeBox = false;
            paymentForm.MinimizeBox = false;
            paymentForm.ShowIcon = false;
            paymentForm.Show();
        }

        private void NewPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuplementPaymentCreate paymentForm = new SuplementPaymentCreate(_accessToken, null);
            paymentForm.MdiParent = this;
            paymentForm.WindowState = FormWindowState.Maximized;
            paymentForm.ControlBox = false;
            paymentForm.MaximizeBox = false;
            paymentForm.MinimizeBox = false;
            paymentForm.ShowIcon = false;
            paymentForm.Show();
        }
    }
}
