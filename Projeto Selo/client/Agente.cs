using System;
using System.Drawing; // Para a classe Icon
using System.Windows.Forms;

public class Agente : Form
{
    private NotifyIcon notifyIcon;
    private ContextMenuStrip contextMenu;
    private Form mainForm;

    public Agente(Form form)
    {
        mainForm = form;
        Iniciar();
    }

    private void Iniciar()
    {
        notifyIcon = new NotifyIcon();
        notifyIcon.Icon = new Icon(@"C:\selo_test\images\skyinformatica.ico"); // Certifique-se de que o caminho está correto
        notifyIcon.Text = "Meu Aplicativo";
        notifyIcon.Visible = true;

        contextMenu = new ContextMenuStrip();
        contextMenu.Items.Add("Abrir", null, MostrarFormulario);
        contextMenu.Items.Add("Sair", null, Sair);

        notifyIcon.ContextMenuStrip = contextMenu;

        notifyIcon.DoubleClick += (sender, args) => MostrarFormulario(sender, args);
    }

    private void MostrarFormulario(object sender, EventArgs e)
    {
        mainForm.Show();
        mainForm.WindowState = FormWindowState.Normal;
    }

    private void Sair(object sender, EventArgs e)
    {
        notifyIcon.Visible = false;
        Application.Exit();
    }

    public void Minimizar()
    {
        mainForm.WindowState = FormWindowState.Minimized;
        mainForm.Hide();
    }

    public void Remover()
    {
        notifyIcon.Visible = false;
    }
}
