using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace client
{
    partial class teste
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel painelVerificar;
        private System.Windows.Forms.Panel painelVerificarBorda;
        private System.Windows.Forms.Button botaoVerificar;
        private System.Windows.Forms.Button botaoExecutar;
        private System.Windows.Forms.Button botaoProcurar;
        private System.Windows.Forms.Label informativoLabel;
        private System.Windows.Forms.Label desaAtivado;
        private System.Windows.Forms.Panel painel;
        private System.Windows.Forms.Label painelSelo;
        private System.Windows.Forms.Panel painel2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.components = new System.ComponentModel.Container();
            this.botaoVerificar = new System.Windows.Forms.Button();
            this.botaoProcurar = new System.Windows.Forms.Button();
            this.informativoLabel = new System.Windows.Forms.Label();
            this.desaAtivado = new System.Windows.Forms.Label();
            this.painelSelo = new System.Windows.Forms.Label();
            this.painel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();

            //Texto: Desativado / Ativado
            desaAtivado.Text = "Desativado"; // Defina o texto que deseja exibir
            desaAtivado.Location = new Point(80, 150); // Defina a localização do Label no formulário
            desaAtivado.AutoSize = true; // Define o Label para ajustar automaticamente o tamanho ao texto
            desaAtivado.ForeColor = Color.White;
            desaAtivado.BackColor = Color.Red;
            desaAtivado.BringToFront();
            this.Controls.Add(desaAtivado); // Adicionar o Label ao formulário

            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.ImageLocation = @"C:\selo_test\images\selofinal.png"; // Defina o caminho da imagem que deseja exibir
            pictureBox1.Location = new Point(67, 90); // Defina a localização do PictureBox no formulário
            pictureBox1.Size = new Size(100, 80); // Defina o tamanho do PictureBox
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Define o modo de exibição da imagem
            pictureBox1.SendToBack();
            this.Controls.Add(pictureBox1); // Adicionar o PictureBox ao formulário


            //Texto: Selo digital
            painelSelo.Text = "Selo digital"; // Defina o texto que deseja exibir
            painelSelo.Location = new Point(65, 60); // Defina a localização do Label no formulário
            painelSelo.AutoSize = true; // Define o Label para ajustar automaticamente o tamanho ao texto
            painelSelo.ForeColor = Color.White;
            painelSelo.Font = new Font(painelSelo.Font.FontFamily, 12, FontStyle.Bold);
            painelSelo.BackColor = Color.Red;
            this.Controls.Add(painelSelo); // Adicionar o Label ao formulário


            // 
            // botaoVerificar
            // 
            this.botaoVerificar.Location = new System.Drawing.Point(400, 60);
            this.botaoVerificar.Name = "botaoVerificar";
            this.botaoVerificar.Size = new System.Drawing.Size(80, 35);
            this.botaoVerificar.TabIndex = 0;
            this.botaoVerificar.Text = "Verificar";
            this.botaoVerificar.UseVisualStyleBackColor = true;
            this.botaoVerificar.Click += new System.EventHandler(this.botaoVerificar_Click);

            // 
            // botaoExecutar
            // 
            botaoExecutar = new Button();
            botaoExecutar.Text = "Executar";
            botaoExecutar.Location = new Point(400, 150);
            botaoExecutar.Size = new Size(80, 35);
            botaoExecutar.BackColor = Color.White;
            botaoExecutar.Click += new EventHandler(botaoExecutar_Click); // Evento de clique do botão
            this.Controls.Add(botaoExecutar); // Adicionar o botão ao formulário


            // 
            // informativoLabel
            // 
            this.informativoLabel.Location = new System.Drawing.Point(10, 10);
            this.informativoLabel.Name = "informativoLabel";
            this.informativoLabel.Size = new System.Drawing.Size(250, 30);
            this.informativoLabel.TabIndex = 3;
            this.informativoLabel.Text = "";
            this.informativoLabel.ForeColor = Color.White;
            this.informativoLabel.BackColor = Color.FromArgb(41, 39, 39);


            //Painel
            this.painel = new Panel();
            this.painel.BackColor = System.Drawing.SystemColors.Control;
            this.painel.Location = new System.Drawing.Point(10, 90);
            this.painel.Name = "painel";
            this.painel.Size = new System.Drawing.Size(220, 110);
            this.painel.TabIndex = 4;
            this.painel.BackColor = Color.FromArgb(41, 39, 39); // Defina a cor de fundo como Transparente

            //Painel2
            this.painel2.BackColor = System.Drawing.SystemColors.Control;
            this.painel2.Location = new System.Drawing.Point(8, 50);
            this.painel2.Name = "painel2";
            this.painel2.Size = new System.Drawing.Size(225, 150);
            this.painel2.TabIndex = 4;
            this.painel2.BackColor = Color.Red; // Defina a cor de fundo como Transparente
            this.painel2.Paint += new PaintEventHandler(PaintPanel); // Registre o evento Paint para desenhar as bordas arredondadas
            this.Controls.Add(painel2);


            // Input Execute
            enderecoIPTextBox = new TextBox();
            enderecoIPTextBox.Location = new Point(250, 65);
            enderecoIPTextBox.Size = new Size(120, 20);
            this.Controls.Add(enderecoIPTextBox);

            // Input IP
            this.caminhoExecutar = new System.Windows.Forms.TextBox();
            this.caminhoExecutar.Location = new System.Drawing.Point(250, 155); // Posição do TextBox no formulário
            this.caminhoExecutar.Name = "caminho Executar";
            this.caminhoExecutar.Size = new System.Drawing.Size(120, 20); // Tamanho do TextBox
            this.Controls.Add(this.caminhoExecutar);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 250);
            this.Controls.Add(this.painel);
            this.Controls.Add(this.painel2);
            this.Controls.Add(this.botaoVerificar);
            this.Controls.Add(this.informativoLabel);
            this.Name = "Iseelo";
            this.Text = "Iseelo";
            this.ResumeLayout(false);

            // verificar painel
            this.painelVerificar = new System.Windows.Forms.Panel();
            this.painelVerificar.BackColor = System.Drawing.SystemColors.Control;
            this.painelVerificar.Location = new System.Drawing.Point(210, 50);
            this.painelVerificar.Name = "painelVerificar";
            this.painelVerificar.Size = new System.Drawing.Size(240, 130);
            this.painelVerificar.TabIndex = 4;
            this.painelVerificar.Paint += new PaintEventHandler(PaintPanel); // Registrando o evento Paint para desenhar as bordas arredondadas
            this.painelVerificar.BackColor = Color.FromArgb(41, 39, 39);
            this.painelVerificar.Paint += new PaintEventHandler(this.PaintPanelWithBorder); // Aqui você está definindo a cor de fundo como vermelho, não como Transparente
            this.Controls.Add(painelVerificar);


            //Painel Log
            this.painelVerificar = new System.Windows.Forms.Panel();
            this.painelVerificar.BackColor = System.Drawing.SystemColors.Control;
            this.painelVerificar.Location = new System.Drawing.Point(0, 2);
            this.painelVerificar.Name = "painelLog";
            this.painelVerificar.Size = new System.Drawing.Size(240, 40);
            this.painelVerificar.TabIndex = 4;
            this.painelVerificar.Paint += new PaintEventHandler(PaintPanel); // Registrando o evento Paint para desenhar as bordas arredondadas
            this.painelVerificar.BackColor = Color.FromArgb(41, 39, 39);
            this.painelVerificar.Paint += new PaintEventHandler(this.PaintPanelWithBorder); // Aqui você está definindo a cor de fundo como vermelho, não como Transparente
            this.Controls.Add(painelVerificar);


            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            var screenWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            var screenHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            this.Left = screenWidth - this.ClientSize.Width;
            this.Top = screenHeight - this.ClientSize.Height;
            this.Icon = new Icon(@"C:\selo_test\images\skyinformatica.ico");
        }

        private void PaintPanel(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;

            // Define as bordas arredondadas
            GraphicsPath path = new GraphicsPath();
            int borderRadius = 5; // Ajuste o valor conforme desejado
            path.AddArc(0, 0, borderRadius * 2, borderRadius * 2, 180, 90);
            path.AddArc(panel.Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2, 270, 90);
            path.AddArc(panel.Width - borderRadius * 2, panel.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
            path.AddArc(0, panel.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
            path.CloseFigure();
            panel.Region = new Region(path);
            path.Dispose();
        }

        private void PaintPanelWithBorder(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            int borderWidth = 3; // Largura da borda em pixels
            Color borderColor = Color.Black; // Cor da borda

            // Desenha a borda ao redor do painel
            ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle,
                                    borderColor, borderWidth, ButtonBorderStyle.Solid,
                                    borderColor, borderWidth, ButtonBorderStyle.Solid,
                                    borderColor, borderWidth, ButtonBorderStyle.Solid,
                                    borderColor, borderWidth, ButtonBorderStyle.Solid);
        }

        #endregion
    }
}
