using Bunifu.Framework.UI;
using ModernDesignUI_GlassForm.Forms_Principal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernDesignUI_GlassForm.Forms_Auxiliares
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            Elipse();
        }

        void Elipse()
        {
            BunifuDragControl c = new BunifuDragControl();
            c.TargetControl = panelLateral;

            BunifuDragControl c1 = new BunifuDragControl();
            c1.TargetControl = panelCentral;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Length == 0 || txtSenha.Text.Length == 0)
            {
                if (txtSenha.Text.Length == 0)
                {
                    erError.SetError(txtSenha, "");
                    erError.SetError(txtSenha,"Deve preencher a sua senha");
                }
                if (txtNome.Text.Length == 0)
                {
                    erError.SetError(txtNome, "");
                    erError.SetError(txtNome,"Deve preencher o seu nome");
                }
                return;
            }
            DashboardPrincipal frm = new DashboardPrincipal();
            frm.Show();
            this.Hide();
            Reset();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            SairApp();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        void SairApp()
        {
            if (MessageBox.Show("Deseja sair da aplicação?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public void Reset()
        {
            txtNome.Focus();
            txtSenha.Text = "";
            txtNome.Text = "";
            txtSenha.Tag = "";
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Se for Backspace
            if (e.KeyChar == (char)Keys.Back)
            {
                if (txtSenha.Tag != null && txtSenha.Tag.ToString().Length > 0)
                {
                    txtSenha.Tag = txtSenha.Tag.ToString().Substring(0, txtSenha.Tag.ToString().Length - 1);
                }
                if (txtSenha.Text.Length > 0)
                {
                    txtSenha.Text = txtSenha.Text.Substring(0, txtSenha.Text.Length - 1);
                }
            }
            else
            {
                // Qualquer outro caractere
                txtSenha.Tag += e.KeyChar.ToString();
                txtSenha.Text += "*";
            }
            txtSenha.SelectionStart = txtSenha.Text.Length;
            e.Handled = true;
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtSenha.SelectionStart = txtSenha.Text.Length;
                txtSenha.Focus();
                e.Handled = true;
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up)
            {
                txtNome.SelectionStart = txtNome.Text.Length;
                txtNome.Focus();
                e.Handled = true;
            }
        }

        private void FormLogin_Shown(object sender, EventArgs e)
        {
            txtNome.Focus();
            txtNome.SelectionStart = txtNome.Text.Length;
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            if (txtSenha.Text.Length > 0)
            {
                erError.SetError(txtSenha, "");
            }
            else
            {
                erError.SetError(txtSenha, "Deve preencher a sua senha");
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (txtNome.Text.Length > 0)
            {
                erError.SetError(txtNome, "");
            }
            else
            {
                erError.SetError(txtNome, "Deve preencher a sua senha");
            }
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.Size = new Size(188, 44);
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.Size = new Size(195, 47);
        }
    }
}
