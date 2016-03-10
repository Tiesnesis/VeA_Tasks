using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace Calcapplication
{
    public partial class MainForm : Form
    {
        private TextBox tb = null;

        struct complex
        {
            public int real;
            public int imaginary;

            public complex(int real, int imaginary)
            {
                this.real = real;
                this.imaginary = imaginary;
            }

            public override string ToString()
            {
                return real + imaginary + "i";
            }

            public static complex operator +(complex k1, complex k2)
            {
                return new complex(k1.real + k2.real, k1.imaginary + k2.imaginary);
            }

            public static complex operator /(complex k1, complex k2)
            {
                complex temp;
                temp.real = (k1.real * k2.real + k1.imaginary * k2.imaginary) / (k2.real * k2.real + k2.imaginary * k2.imaginary);
                temp.imaginary = (k1.imaginary * k2.real - k1.real * k2.imaginary) / (k2.real * k2.real + k2.imaginary * k2.imaginary);
                return temp;
            }

            public static complex operator -(complex k1, complex k2)
            {
                return new complex(k1.real - k2.real, k1.imaginary - k2.imaginary);
            }

            public static complex operator *(complex k1, complex k2)
            {
                complex temp;
                temp.real = k1.real * k2.real - k1.imaginary * k2.imaginary;
                temp.imaginary = k1.real * k2.imaginary + k1.imaginary * k2.real;
                return temp;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            izvele.SelectedIndex = 0;
            this.textBox2.GotFocus += new EventHandler(GetF);
            this.textBox3.GotFocus += new EventHandler(GetF);
            this.textBox4.GotFocus += new EventHandler(GetF);
            this.textBox5.GotFocus += new EventHandler(GetF);
        }
    //Button Click listeners
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += button1.Text;
            if (tb != null && izvele.SelectedIndex == 1)
            {
                tb.SelectedText += button1.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += button2.Text;
            if (tb != null && izvele.SelectedIndex == 1)
            {
                tb.SelectedText += button2.Text;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += button3.Text;
            if (tb != null && izvele.SelectedIndex == 1)
            {
                tb.SelectedText += button3.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += button4.Text;
            if (tb != null && izvele.SelectedIndex == 1)
            {
                tb.SelectedText += button4.Text;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += button5.Text;
            if (tb != null && izvele.SelectedIndex == 1)
            {
                tb.SelectedText += button5.Text;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += button6.Text;
            if (tb != null && izvele.SelectedIndex == 1)
            {
                tb.SelectedText += button6.Text;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += button7.Text;
            if (tb != null && izvele.SelectedIndex == 1)
            {
                tb.SelectedText += button7.Text;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += button8.Text;
            if (tb != null && izvele.SelectedIndex == 1)
            {
                tb.SelectedText += button8.Text;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += button9.Text;
            if (tb != null && izvele.SelectedIndex == 1)
            {
                tb.SelectedText += button9.Text;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += button10.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
                textBox1.Text += button11.Text;
                if (tb != null && izvele.SelectedIndex == 1)
                {
                    tb.SelectedText += button11.Text;
                }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += button12.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += button13.Text;
            if (izvele.SelectedIndex == 1)
            {
                textBox6.Text = button13.Text;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += button14.Text;
                if (tb != null && izvele.SelectedIndex == 1)
                {
                    textBox6.Text = button14.Text;
                }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += button15.Text;
            if (izvele.SelectedIndex == 1)
            {
                textBox6.Text = button15.Text;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text += button16.Text;
            if (izvele.SelectedIndex == 1)
            {
                textBox6.Text = button16.Text;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 1)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 1)
            {
                textBox1.Text = null;
            }
        }
    
        private void izvele_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (izvele.SelectedIndex == 0)
            {
                panel1.Show();
                panel2.Hide();
                panel3.Hide();
            }
            else if (izvele.SelectedIndex == 1)
            {
                panel2.Show();
                panel1.Hide();
                panel3.Show();
                button23.Hide();
                button22.Hide();
            }
        }

        private void GetF(object sender, EventArgs e)
        {
            // Keeps you selecting textbox object reference.
            tb = sender as TextBox;

        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (izvele.SelectedIndex == 0)
            {
                string[] numberList;
                List<char> zimlist = new List<char>();
                List<char> tempzimlist = new List<char>();
                int skaititajs = 0;
                char[] dalitaji = { '+', '*', '/', '-' };
                //char templates;

                //Capture action chars from input
                foreach (char zime in textBox1.Text)
                {
                    if (zime == '*' || zime == '+' || zime == '-' || zime == '/')
                    {
                        zimlist.Add(zime);
                    }
                    skaititajs++;
                }

                skaititajs = 0;

                //Capture number list from input

                numberList = textBox1.Text.Split(dalitaji);
                //Calculation
                double temp1;
                double temp2;

                for (int i = 0; i < zimlist.Count; i++)
                {
                    if (zimlist[i] == '*')
                    {
                        temp1 = Convert.ToDouble(numberList[i]);
                        temp2 = Convert.ToDouble(numberList[i + 1]);
                        temp1 = temp1 * temp2;
                        numberList[i] = temp1.ToString();
                        numberList[i + 1] = null;
                        string[] tempSkait = numberList.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                        numberList = tempSkait;
                        for (int x = 0; x < zimlist.Count; x++)
                        {
                            if (x != i)
                            {
                                tempzimlist.Add(zimlist[x]);
                            }
                            else if (x == i)
                            {
                                continue;
                            }
                        }
                        zimlist = tempzimlist;
                        i = 0;
                        textBox1.Text = tempSkait[0];
                    }
                    else if (zimlist[i] == '/')
                    {
                        temp1 = Convert.ToDouble(numberList[i]);
                        temp2 = Convert.ToDouble(numberList[i + 1]);
                        temp1 = temp1 / temp2;
                        numberList[i] = temp1.ToString();
                        numberList[i + 1] = null;
                        string[] tempSkait = numberList.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                        numberList = tempSkait;
                        i = 0;
                        textBox1.Text = tempSkait[0];
                    }
                    else if (zimlist[i] == '+')
                    {
                        temp1 = Convert.ToDouble(numberList[i]);
                        temp2 = Convert.ToDouble(numberList[i + 1]);
                        temp1 = temp1 + temp2;
                        numberList[i] = temp1.ToString();
                        numberList[i + 1] = null;
                        string[] tempSkait = numberList.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                        numberList = tempSkait;
                        i = 0;
                        textBox1.Text = tempSkait[0];
                    }
                    else if (zimlist[i] == '-')
                    {
                        temp1 = Convert.ToDouble(numberList[i]);
                        temp2 = Convert.ToDouble(numberList[i + 1]);
                        temp1 = temp1 - temp2;
                        numberList[i] = temp1.ToString();
                        numberList[i + 1] = null;
                        string[] tempSkait = numberList.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                        i = 0;
                        textBox1.Text = tempSkait[0];
                    }
                }
            }
            else if (izvele.SelectedIndex == 1)
            {
                int temp = Convert.ToInt32(textBox2.Text);
                int temp2 = Convert.ToInt32(textBox3.Text);
                complex c1 = new complex(temp, temp2);
                temp = Convert.ToInt32(textBox4.Text);
                temp2 = Convert.ToInt32(textBox5.Text);
                complex c2 = new complex(temp, temp2);
                switch (textBox6.Text)
                {
                    case("+"):
                        c1 = c1 + c2;
                        MessageBox.Show(c1.real + "+" + c1.imaginary + "i");
                        break;
                    case ("-"):
                        c1 = c1 - c2;
                        MessageBox.Show(c1.real + "+" + c1.imaginary + "i");
                        break;
                    case ("/"):
                        c1 = c1 / c2;
                        MessageBox.Show(c1.real + "+" + c1.imaginary + "i");
                        break;
                    case ("*"):
                        c1 = c1 * c2;
                        MessageBox.Show(c1.real + "+" + c1.imaginary + "i");
                        break;
                    default:
                        break;
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            double sqrt = Math.Sqrt(Convert.ToDouble(textBox1.Text));
            textBox1.Text = sqrt.ToString();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            double kapinat = Convert.ToDouble(textBox1.Text);
            textBox1.Text = null;
            string input = Microsoft.VisualBasic.Interaction.InputBox("Ievadiet kapinataju", "Kapinasana", "2", -1, -1);
            double kapinatajs = Convert.ToDouble(input);
            kapinat = Math.Pow(kapinat, kapinatajs);
            textBox1.Text = kapinat.ToString();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (tb != null) tb.SelectedText += "i";
         
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox1.Text += "r";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
