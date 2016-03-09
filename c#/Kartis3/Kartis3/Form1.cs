using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;



namespace Kartis3
{
    

    public partial class Form1 : Form
    {
        public static List<Kartis> kava = new List<Kartis>(52);
        public static List<Speletajs> speletaji = new List<Speletajs>(4);
        public static List<SpeletajsVisual> speletajivisual = new List<SpeletajsVisual>(4);
        public static List<string> sp_names = new List<string>();
        
        
        public Form1()
        {
            InitializeComponent();;
            Move.Enabled = false;
            button1.Enabled = false;
        }
        public void izveidotKavu()
        {
            kava.Clear();
            foreach (Masts m in Enum.GetValues(typeof(Masts)))
            {
                foreach (Vertiba v in Enum.GetValues(typeof(Vertiba)))

                    kava.Add(new Kartis(m, v));
                
            }

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            //pictureBox1.Image = tempKartis.Attels1;
            //label1.Text = tempKartis.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void maisitKavu()
        {
            for (int i = 0; i < 6000; i++)
            {
                Random r = new Random();
                int nr = r.Next(52);
                Kartis temp = new Kartis(kava[nr].Masts, kava[nr].Vertiba);
                kava.RemoveAt(nr);
                kava.Add(temp);
            }

        }

        

        public Speletajs dalitKartisSpeletajam(string name)
        {
            List<Kartis> kartissp = new List<Kartis>();
            for (int i = 0; i < 6; i++)
            {
                Kartis temp = new Kartis(kava[0].Masts, kava[0].Vertiba);
                kava.RemoveAt(0);
                kartissp.Add(temp);
            }
            Speletajs sp = new Speletajs(name, kartissp);
            return sp;
        }

        public void inicializeSp()
        {
            speletaji.Clear();
            bool aktivs = true;
            while (sp_names.Count > 0)
            {
                Speletajs sp1 = dalitKartisSpeletajam(sp_names.First());
                sp1.VaiAktivs = aktivs;
                speletaji.Add(sp1);
                sp_names.Remove(sp_names.First());
                aktivs = false;
            }

        }

        public void setActiveSpeletajs(bool vaiAktivs, int index)
            
        {
            speletajivisual[index].Sp.VaiAktivs = vaiAktivs;
            speletajivisual[index].Enabled = vaiAktivs;
            if (vaiAktivs == false)
            {
                speletajivisual[index].BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                speletajivisual[index].BorderStyle = BorderStyle.Fixed3D;
            }
        }
        public int getAktivo()
        {   
            int aktivais = 0;
            for(int i = 0; i < speletajivisual.Count;i++){
                if(speletajivisual[i].Sp.VaiAktivs){
                    aktivais = i;
                    break;
                }
            }
            return aktivais;
        }

        public void mainitAktivo()
        {   
            int aktivs = getAktivo();
            setActiveSpeletajs(false, aktivs);
            aktivs++;
            if (aktivs > speletajivisual.Count - 1)
            {
                aktivs = 0;
            }
            setActiveSpeletajs(true, aktivs);

        }


        private void Got_focus(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            speletajivisual[getAktivo()].paceltKarti();
            mainitAktivo();
        }

        private void izietToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void jaunaSpeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            Form2 form2 = new Form2();
            form2.Show();
           

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label1.Text = "Maisa kavu ...";
            this.Refresh();
            this.izveidotKavu();
            this.maisitKavu();
            this.inicializeSp();
            label1.Text = "Dala kartis ...";
            this.Refresh();
            while (speletajivisual.Count > 0)
            {
                this.Controls.Remove(speletajivisual.First());
                speletajivisual.Remove(speletajivisual.First());
            }
            for (int j = 0; j < speletaji.Count; j++)
            {

                SpeletajsVisual vssp = new SpeletajsVisual(speletaji[j]);
                vssp.Location = new Point(0, j * 170 + 30);
                vssp.Size = new Size(700, 150);
                if (j == 0) 
                { 
                    vssp.BorderStyle = BorderStyle.Fixed3D; 
                }
                else
                {
                    vssp.BorderStyle = BorderStyle.FixedSingle;   
                }
                
                speletajivisual.Add(vssp);
                this.Controls.Add(vssp);
            }
            if (speletaji.Count >0)
            {
                Move.Enabled = true;
            }
            label1.Text = "Done";
        }
    }
    public partial class SpeletajsVisual : UserControl
    {

        Speletajs sp;
        public List<PictureBox> selectedValues = new List<PictureBox>();
        public int gCount = 0;

        public void dalitKartis(Speletajs s)
        {
            if (Form1.kava.Count != 0)
            {
                Kartis temp = new Kartis(Form1.kava[0].Masts, Form1.kava[0].Vertiba);
                Form1.kava.RemoveAt(0);
                s.S_kartis.Add(temp);
            }
        }
        public int getAktivo()
        {
            int aktivais = 0;
            for (int i = 0; i < Form1.speletajivisual.Count; i++)
            {
                if (Form1.speletajivisual[i].Sp.VaiAktivs)
                {
                    aktivais = i;
                    break;
                }
            }
            return aktivais;
        }
        public void setActiveSpeletajs(bool vaiAktivs, int index)
        {
            Form1.speletajivisual[index].Sp.VaiAktivs = vaiAktivs;
            Form1.speletajivisual[index].Enabled = vaiAktivs;
            if (vaiAktivs == false)
            {
                Form1.speletajivisual[index].BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                Form1.speletajivisual[index].BorderStyle = BorderStyle.Fixed3D;
            }
        }
        public void mainitAktivo()
        {
            int aktivs = getAktivo();
            setActiveSpeletajs(false, aktivs);
            aktivs++;
            if (aktivs > Form1.speletajivisual.Count - 1)
            {
                aktivs = 0;
            }
            setActiveSpeletajs(true, aktivs);

        }
        public void paceltKarti()
        {   
            dalitKartis(Sp);
            PictureBox box = new PictureBox();
            box.Location = new Point((Sp.S_kartis.Count - 1) * 50, 50);
            box.Image = Sp.S_kartis[Sp.S_kartis.Count - 1].Attels1;
            box.SizeMode = PictureBoxSizeMode.AutoSize;
            box.Click += new EventHandler(box_Click);
            this.Controls.Add(box);
        }
        public void box_Click(object sender, EventArgs e)
        {
            PictureBox bTemp = (PictureBox)sender;

            if (bTemp.BorderStyle.Equals(BorderStyle.Fixed3D))
            {
                bTemp.BorderStyle = BorderStyle.FixedSingle;
                selectedValues.Remove(bTemp);
            }
            else
            {
                if (selectedValues.Count < 2)
                {
                    bTemp.BorderStyle = BorderStyle.Fixed3D;
                    selectedValues.Add(bTemp);
                    if (selectedValues.Count == 2)
                    {
                        //MessageBox.Show(sp.S_kartis.Count().ToString());
                        if (Regex.Match(selectedValues[0].Image.Tag.ToString(), @"\s(\w+)", RegexOptions.IgnoreCase).ToString() == Regex.Match(selectedValues[1].Image.Tag.ToString(), @"\s(\w+)", RegexOptions.IgnoreCase).ToString())
                        {

                            selectedValues[0].Image = ClassLibrary1.Class1.getBildi("aizmugure");
                            selectedValues[1].Image = ClassLibrary1.Class1.getBildi("aizmugure");
                            selectedValues[0].Enabled = false;
                            selectedValues[1].Enabled = false;
                            gCount += 2;
                            selectedValues.Clear();
                            if (sp.S_kartis.Count == gCount)
                            {
                                MessageBox.Show("Atzimejot visas vienadas kartis uzvarejis ir: "+ sp.Vards.ToString()+"!");
                            }
                            mainitAktivo();
                        }
                        else
                        {
                            selectedValues[0].BorderStyle = BorderStyle.FixedSingle;
                            selectedValues[1].BorderStyle = BorderStyle.FixedSingle;
                            selectedValues.Clear();
                        }
                    }
                }
            }
        }

        public Speletajs Sp
        {
            get { return sp; }
            set { sp = value; }
        }
        
        public SpeletajsVisual(Speletajs sp)
        {
            Label label1 = new Label();
            this.sp = sp;
            
            label1.Text = sp.Vards;
            int i = 0;
            foreach (Kartis item in this.sp.S_kartis)
            {
                PictureBox box = new PictureBox();
                box.Location = new Point(i * 50, 50);
                box.Image = item.Attels1;
                box.SizeMode = PictureBoxSizeMode.AutoSize;
                box.Click += new EventHandler(box_Click);
                this.Controls.Add(box);

                i++;
            }
            this.Controls.Add(label1);
            this.Enabled = this.sp.VaiAktivs;
        }


    }
}
