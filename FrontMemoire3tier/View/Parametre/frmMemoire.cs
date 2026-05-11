using FrontMemoire3tier.ServiceMemoire;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontMemoire3tier.View.Parametre
{
    public partial class frmMemoire : Form
    {
        ServiceMemoire.Service1Client service = new ServiceMemoire.Service1Client();
        
        public frmMemoire()
        {
            InitializeComponent();
        }

        private void Effacer()
        {
            txtAnnee.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtSujet.Text = string.Empty;
            dgMemoire.DataSource = service.GetAllMemoire();
            txtSujet.Focus();
        }
        private void frmMemoire_Load(object sender, EventArgs e)
        {
            Effacer();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            ServiceMemoire.Memoire memoire = new ServiceMemoire.Memoire();
            memoire.AnneeMemoire = int.Parse(txtAnnee.Text);
            memoire.SujetMemoire = txtSujet.Text;
            memoire.DescriptionMemoire = txtDescription.Text;
            service.AddMemoire(memoire);
            Effacer();

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgMemoire.CurrentRow.Cells[2].Value.ToString());
            ServiceMemoire.Memoire memoire = new ServiceMemoire.Memoire();
            memoire.IdMemoire = id; memoire.AnneeMemoire = int.Parse(txtAnnee.Text);
            memoire.SujetMemoire = txtSujet.Text;
            memoire.DescriptionMemoire = txtDescription.Text;
            service.DeleteMemoire(memoire);
            Effacer();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgMemoire.CurrentRow.Cells[2].Value.ToString());
            ServiceMemoire.Memoire memoire = new ServiceMemoire.Memoire();
            memoire.IdMemoire = id;
            memoire.AnneeMemoire = int.Parse(txtAnnee.Text);
            memoire.SujetMemoire = txtSujet.Text;
            memoire.DescriptionMemoire = txtDescription.Text;
            service.EditMemoire(memoire);
            Effacer();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ServiceMemoire.MemoireModel memoire = new ServiceMemoire.MemoireModel();
            memoire.AnneeMemoire = int.Parse(txtAnnee.Text);
            memoire.SujetMemoire = txtSujet.Text;
            service.GetMemoireList(memoire);
            Effacer();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            txtAnnee.Text = dgMemoire.CurrentRow.Cells[0].Value.ToString();
            txtDescription.Text = dgMemoire.CurrentRow.Cells[1].Value.ToString();
            txtSujet.Text = dgMemoire.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
