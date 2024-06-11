using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente.Forms
{
    public partial class Form_Main : Form_Borderless
    {
        private Point initialPosLoading = new Point();
        private string BaseAppName = "ChatterBox | ";
        private string appName;
        private string currentLoadedFormName;
        private int utilizadorAtualId;
        private Dictionary<string, Form> formCache = new Dictionary<string, Form>(); // Cache de forms, para evitar fazer dispose e criar novas instâncias

        public Form_Main(int id)
        {
            InitializeComponent();
            criarEventosPanel(this.panel_topBar);
            criarEventosBtns(this.pictureBox_fechar, this.pictureBox_minimizar);
            this.Text = BaseAppName + "Home Page";
            initialPosLoading = panelLoadingArea.Location;
            this.utilizadorAtualId = id;
        }

        private void loadForm(Form form)
        {
            foreach (Control ctrl in panelLoadingArea.Controls)
            {
                if (ctrl == form)
                {
                    return;
                }

                if (ctrl is Form_Chat formChat)
                {
                    formChat.Hide();
                }
                else
                {
                    ctrl.Hide();
                }
            }

            panelLoadingArea.Controls.Clear();
            form.TopLevel = false;
            panelLoadingArea.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            currentLoadedFormName = form.Name;
            form.Show();
            this.Text = appName;
        }

        // Método que obtém um form da cache ou cria um novo form
        private Form GetOrCreateForm(string formName, Func<Form> formCreator)
        {
            if (formCache.TryGetValue(formName, out Form cachedForm)) // Se o form já foi criado, retorna o form da cache
            {
                return cachedForm;
            }
            else // Se o form ainda não foi criado, cria um novo form e adiciona à cache
            {
                Form newForm = formCreator();
                formCache[formName] = newForm;
                return newForm;
            }
        }

        public static void Center(Control control)
        {
            float larguraControl = control.Width;
            float larguraParent = control.Parent.Width;
            float centrado = (larguraParent / 2) - (larguraControl / 2);

            control.Left = Convert.ToInt32(centrado);
        }

        private void btnMensagem_Click(object sender, EventArgs e)
        {
            if (currentLoadedFormName == "FormChat" || RegisterHelper.NumeroUtilizadoresOnline() >2) // Certificar que existe apenas 2 utilizadores online para a troca de mensagens
            {
                return;
            }
            RegisterHelper.AlterarEstado(utilizadorAtualId, true); // Altera o estado do utilizador para online
            appName = BaseAppName + "Mensagens";

            Form form = GetOrCreateForm("FormChat", () => new Form_Chat(utilizadorAtualId)); // Obtém o form da cache ou cria um novo form
            form.Name = "FormChat";
            loadForm(form);
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnConta_Click(object sender, EventArgs e)
        {
            appName = BaseAppName + "Conta";

            Form form = GetOrCreateForm("FormConta", () => new Form_Conta(utilizadorAtualId));
            form.Name = "FormConta";
            ((Form_Conta)form).Logout_Invoked += Logout;
            loadForm(form);
        }

        // Quando o form é fechado, fecha o cliente e altera o estado do utilizador para offline
        private void Form_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form = GetForm("FormChat");
            if (form != null && form is Form_Chat formChat)
            {
                formChat.fecharCliente();
            }
            RegisterHelper.AlterarEstado(utilizadorAtualId, false);
        }

        // Método que faz logout do utilizador, e fecha o form atual e abre o form de login
        private void Logout(object sender, bool close)
        {
            if (close)
            {
                Form formCliente = GetForm("FormChat");
                if (formCliente != null && formCliente is Form_Chat formChat)
                {
                    formChat.fecharCliente();
                }
                this.Close();
                Form form = new Form_Login();
                form.Show();
            }
        }

        private Form GetForm(string formName)
        {
            formCache.TryGetValue(formName, out Form cachedForm);
            return cachedForm;
        }
    }
}
