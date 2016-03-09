using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Numerics;


namespace Calcapplication
{
    public partial class MainForm : Form
    {
        private TextBox tb = null;

        struct kompleksie
        {
            public int real;
            public int imaginary;

            public kompleksie(int real, int imaginary)
            {
                this.real = real;
                this.imaginary = imaginary;
            }

            public override string ToString()
            {
                return real + imaginary + "i";
            }

            public static kompleksie operator +(kompleksie k1, kompleksie k2)
            {
                return new kompleksie(k1.real + k2.real, k1.imaginary + k2.imaginary);
            }

            public static kompleksie operator /(kompleksie k1, kompleksie k2)
            {
                kompleksie temp;
                temp.real = (k1.real * k2.real + k1.imaginary * k2.imaginary) / (k2.real * k2.real + k2.imaginary * k2.imaginary);
                temp.imaginary = (k1.imaginary * k2.real - k1.real * k2.imaginary) / (k2.real * k2.real + k2.imaginary * k2.imaginary);
                return temp;
            }

            public static kompleksie operator -(kompleksie k1, kompleksie k2)
            {
                return new kompleksie(k1.real - k2.real, k1.imaginary - k2.imaginary);
            }

            public static kompleksie operator *(kompleksie k1, kompleksie k2)
            {
                kompleksie temp;
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
    //visām pogām spiešanas
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
        //Otrais mēģinājums
        {
            if (izvele.SelectedIndex == 0)
            {
                string[] skaitList;
                List<char> zimlist = new List<char>();
                List<char> tempzimlist = new List<char>();
                //List<int> zimjuIndeksi = new List<int>();
                int skaititajs = 0;
                char[] dalitaji = { '+', '*', '/', '-' };
                //char parbaude;

                //izlasa zīmes no ievades un skaitļus
                foreach (char zime in textBox1.Text)
                {
                    if (zime == '*' || zime == '+' || zime == '-' || zime == '/')
                    {
                        zimlist.Add(zime);
                        //zimjuIndeksi.Add(skaititajs);
                    }
                    skaititajs++;
                }

                skaititajs = 0;

                //skaitļu ieguve masīvā

                skaitList = textBox1.Text.Split(dalitaji);
                //rēķināšanas funkcija
                double temp1;
                double temp2;
                bool izpilde = true;
                //string[] iznemamaisSkaitlis;
                //while (izpilde == true)
                //{
                for (int i = 0; i < zimlist.Count; i++)
                {
                    if (zimlist[i] == '*')
                    {
                        temp1 = Convert.ToDouble(skaitList[i]);
                        temp2 = Convert.ToDouble(skaitList[i + 1]);
                        temp1 = temp1 * temp2;
                        skaitList[i] = temp1.ToString();
                        //iznemamaisSkaitlis[0] = skaitList[i+1];
                        skaitList[i + 1] = null;
                        string[] tempSkait = skaitList.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                        skaitList = tempSkait;
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
                        /*for (int j = 0; j < skaitList.Length - 1; j++)
                        {
                            
                            if (i == j)
                            {
                                tempSkait[j] = temp1.ToString();
                            }
                            else if (skaitList[j] == null)
                            {
                                continue;
                            }
                            else
                            {
                                tempSkait[j] = skaitList[j];
                            }
                            MessageBox.Show(tempSkait[j]);
                        }*/
                    }
                    else if (zimlist[i] == '/')
                    {
                        temp1 = Convert.ToDouble(skaitList[i]);
                        temp2 = Convert.ToDouble(skaitList[i + 1]);
                        temp1 = temp1 / temp2;
                        skaitList[i] = temp1.ToString();
                        //iznemamaisSkaitlis[0] = skaitList[i+1];
                        skaitList[i + 1] = null;
                        string[] tempSkait = skaitList.Where(s => !string.IsNullOrEmpty(s)).ToArray();//nesanāk izņemt
                        skaitList = tempSkait;
                        i = 0;
                        textBox1.Text = tempSkait[0];
                    }
                    else if (zimlist[i] == '+')
                    {
                        temp1 = Convert.ToDouble(skaitList[i]);
                        temp2 = Convert.ToDouble(skaitList[i + 1]);
                        temp1 = temp1 + temp2;
                        skaitList[i] = temp1.ToString();
                        //iznemamaisSkaitlis[0] = skaitList[i+1];
                        skaitList[i + 1] = null;
                        string[] tempSkait = skaitList.Where(s => !string.IsNullOrEmpty(s)).ToArray();//nesanāk izņemt
                        skaitList = tempSkait;
                        i = 0;
                        textBox1.Text = tempSkait[0];
                    }
                    else if (zimlist[i] == '-')
                    {
                        temp1 = Convert.ToDouble(skaitList[i]);
                        temp2 = Convert.ToDouble(skaitList[i + 1]);
                        temp1 = temp1 - temp2;
                        skaitList[i] = temp1.ToString();
                        //iznemamaisSkaitlis[0] = skaitList[i+1];
                        skaitList[i + 1] = null;
                        string[] tempSkait = skaitList.Where(s => !string.IsNullOrEmpty(s)).ToArray();//nesanāk izņemt
                        skaitList = tempSkait;
                        i = 0;
                        textBox1.Text = tempSkait[0];
                    }
                    else
                    {
                        izpilde = false;
                    }
                }
                //}



                /*for (int i = 0; i < textBox1.Text.Length; i++)
                {
                    char[] skaitlis;
                    parbaude = textBox1.Text[i];
                    if (parbaude == '*' || parbaude == '+' || parbaude == '-' || parbaude == '/')
                    {
                        skaitList.Add(skaitlis);
                        skaititajs = 0;
                        continue;
                    }
                    else
                    {
                        skaitlis[skaititajs] = parbaude;
                        skaititajs++;
                    }
                }*/

                /*for (int i = 0; i < skaitList.Count(); i++)
                {
                    MessageBox.Show(skaitList[i]);
                }*/

                //Pārbaudes cikls, lai redzētu zīmju indeksus
                /*foreach (int i in zimjuIndeksi)
                {
                    MessageBox.Show(i.ToString());
                }*/
            }
            else if (izvele.SelectedIndex == 1)
            {
                int temp = Convert.ToInt32(textBox2.Text);
                int temp2 = Convert.ToInt32(textBox3.Text);
                kompleksie c1 = new kompleksie(temp, temp2);
                temp = Convert.ToInt32(textBox4.Text);
                temp2 = Convert.ToInt32(textBox5.Text);
                kompleksie c2 = new kompleksie(temp, temp2);
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
            double sakne = Math.Sqrt(Convert.ToDouble(textBox1.Text));
            textBox1.Text = sakne.ToString();
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
            /*if (textBox3.Focused)
            {
                textBox3.Text += "i";
            }*/
            /*int irI = 0;
            for (int i = 0; i < textBox3.Text.Length; i++)
            {
                if (textBox3.Text[i].Equals("i"))
                {
                    irI = 1;
                }
            }
            if (irI == 0)
            {
                textBox3.Text += "i";
            }
            irI = 0;
            for (int i = 0; i < textBox5.Text.Length; i++)
            {
                if (textBox5.Text[i].Equals("i"))
                {
                    irI = 1;
                }
            }
            if (irI == 0)
            {
                textBox5.Text += "i";
            }*/
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox1.Text += "r";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        

        /*pirmais mēģinājums
        {
            bool cipars = false;
            bool zime = false;
            bool reizdal = false;
            int indekss = 0;
            int skaititajs = 0;
            bool ciklabeigas = false;
            double pirmais = 0;
            double otrais = 0;
            string pirmaisStr;
            string otraisStr;

            //kaut kāda pārbaude vai ir kaut cik adekvāta ievade
            foreach (char x in textBox1.Text)
            {
                if (x == '1' || x == '2' || x == '3' || x == '4' || x == '5' || x == '6' || x == '7' || x == '8' || x == '9' || x == '0')
                {
                    cipars = true;
                }
                if (x == '*' || x == '+' || x == '-' || x == '/')
                {
                    zime = true;
                }
            }
            if (cipars == true && zime == true)//ja virkne ir reizinašanas vai dališanas zīme
            {
                foreach (char x in textBox1.Text)
                {
                    if (x == '*' || x == '/')
                    {
                        reizdal = true;
                        indekss = skaititajs;
                        break;
                    }
                    skaititajs++;
                }
                if (reizdal == true)
                {
                    for (int i = skaititajs; ciklabeigas == true; i--)//mekle pa kreisi no zimes skaitli
                    {
                        if (textBox1.Text[i] == '+' || textBox1.Text[i] == '-' || textBox1.Text[i] == '*' || textBox1.Text[i] == '/' || textBox1.Text[i] == '0')
                        {
                          //  pirmais textBox1.Text[i];
                        }
                    }
                }
            }
        }*/
        


    }
}
