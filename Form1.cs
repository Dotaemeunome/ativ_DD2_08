using System;
using System.Drawing;
using System.Windows.Forms;

namespace CentralAtendimento
{
    public class Form1 : Form
    {
        private readonly Senhas senhas;
        private readonly Guiches guiches;

        private NumericUpDown quantidadeGuiches;
        private Button btnAdicionarGuiche;
        private Button btnGerar;
        private ComboBox comboGuiche;
        private Button btnChamar;
        private ListBox listaSenhas;
        private ListBox listaAtendimentos;
        private Label lblStatus;

        public Form1()
        {
            senhas = new Senhas();
            guiches = new Guiches();
            InicializarComponentes();
            AtualizarTela();
        }

        private void InicializarComponentes()
        {
            Text = "Central de Atendimento";
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(820, 520);
            Size = new Size(980, 620);
            Font = new Font("Segoe UI", 10F);

            TableLayoutPanel principal = new TableLayoutPanel();
            principal.Dock = DockStyle.Fill;
            principal.Padding = new Padding(12);
            principal.ColumnCount = 2;
            principal.RowCount = 5;
            principal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            principal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            principal.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            principal.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            principal.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            principal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            principal.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            Controls.Add(principal);

            Label titulo = new Label();
            titulo.Text = "Central de Atendimento";
            titulo.Font = new Font(Font, FontStyle.Bold);
            titulo.Font = new Font(titulo.Font.FontFamily, 18F, FontStyle.Bold);
            titulo.AutoSize = true;
            titulo.Margin = new Padding(0, 0, 0, 12);
            principal.Controls.Add(titulo, 0, 0);
            principal.SetColumnSpan(titulo, 2);

            GroupBox grupoGeracao = new GroupBox();
            grupoGeracao.Text = "Senhas";
            grupoGeracao.Dock = DockStyle.Fill;
            FlowLayoutPanel painelGeracao = new FlowLayoutPanel();
            painelGeracao.Dock = DockStyle.Fill;
            painelGeracao.Padding = new Padding(8);
            painelGeracao.AutoSize = true;
            btnGerar = new Button();
            btnGerar.Text = "Gerar senha";
            btnGerar.AutoSize = true;
            btnGerar.Click += GerarSenha;
            painelGeracao.Controls.Add(btnGerar);
            grupoGeracao.Controls.Add(painelGeracao);
            principal.Controls.Add(grupoGeracao, 0, 1);

            GroupBox grupoGuiches = new GroupBox();
            grupoGuiches.Text = "Guichês";
            grupoGuiches.Dock = DockStyle.Fill;
            TableLayoutPanel painelGuiches = new TableLayoutPanel();
            painelGuiches.Dock = DockStyle.Fill;
            painelGuiches.Padding = new Padding(8);
            painelGuiches.ColumnCount = 4;
            painelGuiches.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            painelGuiches.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            painelGuiches.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            painelGuiches.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            painelGuiches.Controls.Add(new Label { Text = "Quantidade:", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 0);
            quantidadeGuiches = new NumericUpDown();
            quantidadeGuiches.Minimum = 1;
            quantidadeGuiches.Maximum = 50;
            quantidadeGuiches.Value = 1;
            quantidadeGuiches.Width = 55;
            painelGuiches.Controls.Add(quantidadeGuiches, 1, 0);
            btnAdicionarGuiche = new Button();
            btnAdicionarGuiche.Text = "Adicionar";
            btnAdicionarGuiche.AutoSize = true;
            btnAdicionarGuiche.Click += AdicionarGuiches;
            painelGuiches.Controls.Add(btnAdicionarGuiche, 2, 0);
            grupoGuiches.Controls.Add(painelGuiches);
            principal.Controls.Add(grupoGuiches, 1, 1);

            GroupBox grupoChamada = new GroupBox();
            grupoChamada.Text = "Chamar próxima senha";
            grupoChamada.Dock = DockStyle.Fill;
            FlowLayoutPanel painelChamada = new FlowLayoutPanel();
            painelChamada.Dock = DockStyle.Fill;
            painelChamada.Padding = new Padding(8);
            painelChamada.WrapContents = false;
            painelChamada.Controls.Add(new Label { Text = "Guichê:", AutoSize = true, Anchor = AnchorStyles.Left, Margin = new Padding(3, 7, 3, 3) });
            comboGuiche = new ComboBox();
            comboGuiche.DropDownStyle = ComboBoxStyle.DropDownList;
            comboGuiche.Width = 100;
            painelChamada.Controls.Add(comboGuiche);
            btnChamar = new Button();
            btnChamar.Text = "Chamar";
            btnChamar.AutoSize = true;
            btnChamar.Click += ChamarSenha;
            painelChamada.Controls.Add(btnChamar);
            grupoChamada.Controls.Add(painelChamada);
            principal.Controls.Add(grupoChamada, 0, 2);
            principal.SetColumnSpan(grupoChamada, 2);

            TableLayoutPanel listas = new TableLayoutPanel();
            listas.Dock = DockStyle.Fill;
            listas.ColumnCount = 2;
            listas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            listas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            principal.Controls.Add(listas, 0, 3);
            principal.SetColumnSpan(listas, 2);

            GroupBox grupoSenhas = new GroupBox();
            grupoSenhas.Text = "Senhas aguardando atendimento";
            grupoSenhas.Dock = DockStyle.Fill;
            listaSenhas = new ListBox();
            listaSenhas.Dock = DockStyle.Fill;
            grupoSenhas.Controls.Add(listaSenhas);
            listas.Controls.Add(grupoSenhas, 0, 0);

            GroupBox grupoAtendimentos = new GroupBox();
            grupoAtendimentos.Text = "Atendimentos realizados por guichê";
            grupoAtendimentos.Dock = DockStyle.Fill;
            listaAtendimentos = new ListBox();
            listaAtendimentos.Dock = DockStyle.Fill;
            grupoAtendimentos.Controls.Add(listaAtendimentos);
            listas.Controls.Add(grupoAtendimentos, 1, 0);

            lblStatus = new Label();
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.DarkGreen;
            lblStatus.Margin = new Padding(0, 8, 0, 0);
            principal.Controls.Add(lblStatus, 0, 4);
            principal.SetColumnSpan(lblStatus, 2);
        }

        private void GerarSenha(object sender, EventArgs e)
        {
            Senha senha = senhas.GerarSenha();
            lblStatus.Text = "Senha " + senha.Id + " gerada com sucesso.";
            AtualizarTela();
        }

        private void AdicionarGuiches(object sender, EventArgs e)
        {
            int quantidade = (int)quantidadeGuiches.Value;
            int primeiroId = guiches.ListaGuiches.Count + 1;
            for (int i = 0; i < quantidade; i++)
                guiches.adicionar(new Guiche(primeiroId + i));

            lblStatus.Text = quantidade + " guichê(s) adicionado(s).";
            AtualizarTela();
        }

        private void ChamarSenha(object sender, EventArgs e)
        {
            if (comboGuiche.SelectedItem == null)
            {
                lblStatus.Text = "Cadastre e selecione um guichê antes de chamar.";
                return;
            }

            Guiche guiche = (Guiche)comboGuiche.SelectedItem;
            Senha senha = guiche.Chamar(senhas.FilaSenhas);
            if (senha == null)
                lblStatus.Text = "Não há senhas aguardando atendimento.";
            else
                lblStatus.Text = "Senha " + senha.Id + " chamada no guichê " + guiche.Id + ".";
            AtualizarTela();
        }

        private void AtualizarTela()
        {
            int guicheSelecionado = comboGuiche != null && comboGuiche.SelectedItem != null
                ? ((Guiche)comboGuiche.SelectedItem).Id : -1;

            if (listaSenhas != null)
            {
                listaSenhas.Items.Clear();
                foreach (Senha senha in senhas.Listar())
                    listaSenhas.Items.Add(senha.dadosParciais());
            }

            if (comboGuiche != null)
            {
                comboGuiche.Items.Clear();
                foreach (Guiche guiche in guiches.ListaGuiches)
                    comboGuiche.Items.Add(guiche);
                comboGuiche.DisplayMember = "Id";
                if (comboGuiche.Items.Count > 0)
                {
                    int indice = 0;
                    for (int i = 0; i < comboGuiche.Items.Count; i++)
                        if (((Guiche)comboGuiche.Items[i]).Id == guicheSelecionado) indice = i;
                    comboGuiche.SelectedIndex = indice;
                }
            }

            if (listaAtendimentos != null)
            {
                listaAtendimentos.Items.Clear();
                foreach (Guiche guiche in guiches.ListaGuiches)
                {
                    foreach (Senha senha in guiche.Atendimentos)
                        listaAtendimentos.Items.Add("Guichê " + guiche.Id + ": " + senha.dadosCompletos());
                }
            }
        }
    }
}
