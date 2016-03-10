using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace notepadnesalauztais
{
    public partial class LogIn : Form
    {
        public static List<lietotajs> ldb = new List<lietotajs>();
        public LogIn(ParentForm izsaucejs)
        {
            InitializeComponent();
            lietotajs pirmais = new lietotajs("user1@mailinator", "pswd1");
            lietotajs otrais = new lietotajs("user2@mailinator", "pswd2");
            lietotajs tresais = new lietotajs("user3@mailinator", "pswd3");
            ldb.Add(pirmais);
            ldb.Add(otrais);
            ldb.Add(tresais);
            ParentForm izsauc = izsaucejs;
            
            
        }
        public static bool g = false;
        private void button1_Click(object sender, EventArgs e)
        {
            lietotajs temp = new lietotajs(textBox1.Text, textBox2.Text);
            foreach (lietotajs x in ldb)
            {
                if (x.Equals(temp))
                {
                    MessageBox.Show("Pareiza ievade");
                    this.Hide();
                    g = true;
                    break;
                }
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            Regex re = new Regex(@"^user[0-9]{1}@npad$");
            if (re.IsMatch(textBox1.Text)) 
            {
                label3.Text = "Pareiza ievade";
            }
            else
            {
                label3.Text = "Nepareiza ievade";
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            Regex reg = new Regex(@"^[a-z]{6}[0-9]{1}$");
            if (reg.IsMatch(textBox2.Text))
            {
                label4.Text = "Pareiza ievade";
            }
            else
            {
                label4.Text = "Nepareiza ievade";
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
