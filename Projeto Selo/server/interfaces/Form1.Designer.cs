namespace interfaces;

partial class Form1
{

    private System.ComponentModel.IContainer components = null;


    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.informativoLabel = new System.Windows.Forms.Label();

        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

        //Informações e configurações
        this.Name = "Iseelo";
        this.Text = "Iseelo";
        this.BackColor = Color.FromArgb(30, 30, 30);
        this.components = new System.ComponentModel.Container();
        this.SuspendLayout();
        this.ClientSize = new System.Drawing.Size(225, 120);

        // 
        // informativoLabel
        // 
        this.informativoLabel = new Label();
        this.informativoLabel.Location = new System.Drawing.Point(10, 10);
        this.informativoLabel.Name = "informativoLabel";
        this.informativoLabel.Size = new System.Drawing.Size(230, 70);
        this.informativoLabel.TabIndex = 3;
        this.informativoLabel.Text = "";
        this.informativoLabel.ForeColor = Color.White;
        this.informativoLabel.BackColor = Color.FromArgb(41, 39, 39);
        this.Controls.Add(this.informativoLabel);


        //Tela direita inferior
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        var screenWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
        var screenHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
        this.Left = screenWidth - this.ClientSize.Width;
        this.Top = screenHeight - this.ClientSize.Height;
        this.Icon = new Icon(@"C:\selo_test\images\skyinformatica.ico");
    }

    #endregion
}
