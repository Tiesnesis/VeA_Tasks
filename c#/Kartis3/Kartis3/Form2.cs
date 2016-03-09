using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kartis3
{
    public partial class Form2 : Form
    {
        List<Label> l_list = new List<Label>();
        List<TextBox> box_list = new List<TextBox>();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (box_list.Count > 0)
            {
                Form1.sp_names.Add(box_list.First().Text);
                box_list.Remove(box_list.First());
            }
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            while (l_list.Count > 0) 
            { 
                this.Controls.Remove(l_list.Last());
                l_list.Remove(l_list.Last());
            }
            while (box_list.Count > 0)
            {
                this.Controls.Remove(box_list.Last());
                box_list.Remove(box_list.Last());
            }
            for (int i = 0; i < int.Parse(((ComboBox)sender).SelectedItem.ToString()); i++)
            {
                Label temp_l1 = new Label();
                TextBox temp_box = new TextBox();
                temp_l1.Text = "Speletajs Nr." + (i + 1);
                temp_l1.SetBounds(10, 40+(70 * i), 200, 15);
                temp_box.SetBounds(10, 60+(70 * i), 200, 10);
                l_list.Add(temp_l1);
                box_list.Add(temp_box);
                this.Controls.Add(temp_l1);
                this.Controls.Add(temp_box);
            }
        }
    }
}
