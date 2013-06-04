using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AngleValueConverter
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Enter && textBox1.Enabled != textBox2.Enabled)
      {
        double d_input = 0;
        if (textBox1.Enabled)
        {
          if (Double.TryParse(textBox1.Text, out d_input) || 
            DotDevidedDouble.TryParse(textBox1.Text, out d_input))
          {
            textBox2.Text = (d_input * Math.PI / 180).ToString();
          }
          else
          {
            textBox1.Text = (0.0).ToString();
          }
        }
        else
        {
          if (Double.TryParse(textBox2.Text, out d_input) ||
            DotDevidedDouble.TryParse(textBox2.Text, out d_input))
          {
            textBox1.Text = (d_input * 180 / Math.PI).ToString();
          }
          else
          {
            textBox2.Text = (0.0).ToString();
          }
        }

        return true;    // indicate that you handled this keystroke
      }

      // Call the base class
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      DisableTextBox(textBox1, "Degrees");
      DisableTextBox(textBox2, "Radians");
    }

    private void DisableTextBox(
      System.Windows.Forms.TextBox a_text_box,
      String a_str
    )
    {
      a_text_box.Enabled = false;
      a_text_box.Text = a_str;
    }

    private void Form1_Click(object sender, MouseEventArgs e)
    {
      if (e.Y > this.Height / 2)
      {
        this.textBox2.Enabled = true;
        this.textBox2.Text = (0.0).ToString();
        this.textBox2.SelectAll();
        DisableTextBox(textBox1, "Degrees");
      }
      else
      {
        this.textBox1.Enabled = true;
        this.textBox1.Text = (0.0).ToString();
        this.textBox1.SelectAll();
        DisableTextBox(textBox2, "Radians");
      }
    }

  }
}
