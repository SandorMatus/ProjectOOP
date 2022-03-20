using System.Threading;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt
{
    public partial class Form1 : Form
    {
    public TextBox textBox1;
    public TextBox textBox2;
            int i = 0;

    public Form1()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
        {
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.textBox2 = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        //
        // textBox1
        //
        this.textBox1.AcceptsTab = true;
        this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.textBox2.Size = new Size(1,400);
        this.textBox2.Multiline = true;
        this.textBox2.Text = "Enter your name";
        this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.textBox1.KeyDown += new KeyEventHandler(keypressed);
        this.textBox2.Enabled = false;
        //
        // Form1
        //
        this.ClientSize = new System.Drawing.Size(500, 500);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.textBox2);
        this.Text = "The game";
        this.ResumeLayout(false);
        this.PerformLayout();
        }
        private void keypressed(object sender, System.Windows.Forms.KeyEventArgs e)
{
    if (e.KeyCode == Keys.Enter)
    {
        if(i == 0){
        this.textBox2.Text = "Your name is : " + this.textBox1.Text + "\r\n Press Enter to continue...";
        this.textBox1.Text = "";
        i = 1;
        }else{
        this.textBox2.Text = "Choose your path : \r\n 1. Gay route \r\n 2. Cave \r\n 3. Death \n";
        }
        }
    }
}
    }

