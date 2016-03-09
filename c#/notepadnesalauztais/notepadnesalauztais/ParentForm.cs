using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace notepadnesalauztais
{
    public struct lietotajs
    {
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public lietotajs(string usern, string pass)
        {
            username = usern;
            password = pass;
        }
    }

    public partial class ParentForm : Form
    {
        public static bool ielogojies = false;

        public static int g = 0;
        string temp = "";
        public ParentForm()
        {
            InitializeComponent();
            dissableControls();
            ielogojies = false;


        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            ChildForm newChild = new ChildForm();
            newChild.MdiParent = this;
            newChild.Show();
            //this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm newChild = new ChildForm();
            newChild.MdiParent = this;
            newChild.Show();
            //this.LayoutMdi(MdiLayout.TileVertical);
        }

        public void dissableControls()
        {
            toolStrip1.Enabled = false;
            fileToolStripMenuItem.Enabled = false;
            editToolStripMenuItem.Enabled = false;
            formatToolStripMenuItem.Enabled = false;
            windowsToolStripMenuItem.Enabled = false;
            helpToolStripMenuItem.Enabled = false;
        }

        public void enableControls()
        {
            toolStrip1.Enabled = true;
            fileToolStripMenuItem.Enabled = true;
            editToolStripMenuItem.Enabled = true;
            formatToolStripMenuItem.Enabled = true;
            windowsToolStripMenuItem.Enabled = true;
            helpToolStripMenuItem.Enabled = true;
        }

        private void authorizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogIn autorizacija = new LogIn(this);
            autorizacija.ShowDialog();
            MessageBox.Show(LogIn.g.ToString());
            if (LogIn.g)
            {
                enableControls();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //Izveido Dialogresult objektu, kas sev satur atverto dialoga formu;
            DialogResult result = saveFileDialog1.ShowDialog();
            //Izveidojam raksttaju
            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
            //Nosakam, kura ir aktva bernu forma
            ChildForm tempChild = (ChildForm)this.ActiveMdiChild;
            //aktvas bernu formas richtextbox komponenti nosakam
            RichTextBox theBox = (RichTextBox)tempChild.ActiveControl;
            //Visu tekstu, kas ir uz richtextbox komponenti, ierakstam faila
            sw.WriteLine(theBox.Text);
            //aizveram straumi
            sw.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            StreamReader sr = new StreamReader(openFileDialog1.FileName);
            ChildForm newChild = new ChildForm();
            newChild.MdiParent = this;
            newChild.Show();
            newChild.ActiveControl.Text = sr.ReadToEnd();
            sr.Close();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //Izveido Dialogresult objektu, kas sev satur atverto dialoga formu;
            DialogResult result = saveFileDialog1.ShowDialog();
            //Izveidojam raksttaju
            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
            //Nosakam, kura ir aktva bernu forma
            ChildForm tempChild = (ChildForm)this.ActiveMdiChild;
            //aktvas bernu formas richtextbox komponenti nosakam
            RichTextBox theBox = (RichTextBox)tempChild.ActiveControl;
            //Visu tekstu, kas ir uz richtextbox komponenti, ierakstam faila
            sw.WriteLine(theBox.Text);
            //aizveram straumi
            sw.Close();
        }

        private void arangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();
            // Show the dialog.
            DialogResult result = fontDialog1.ShowDialog();
                // Get Font.
            Font font = fontDialog1.Font;
                // Set TextBox properties.
            ChildForm tempChild = (ChildForm)this.ActiveMdiChild;
            RichTextBox theBox = (RichTextBox)tempChild.ActiveControl;
            theBox.SelectionFont = font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            DialogResult result = colorDialog1.ShowDialog();
            Color color = colorDialog1.Color;
            ChildForm tempChild = (ChildForm)this.ActiveMdiChild;
            RichTextBox theBox = (RichTextBox)tempChild.ActiveControl;
            theBox.SelectionColor = color;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm tempChild = (ChildForm)this.ActiveMdiChild;
            RichTextBox theBox = (RichTextBox)tempChild.ActiveControl;
            temp = theBox.SelectedText;
            theBox.SelectedText = "";
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm tempChild = (ChildForm)this.ActiveMdiChild;
            RichTextBox theBox = (RichTextBox)tempChild.ActiveControl;
            int selectionIndex = theBox.SelectionStart;
            theBox.Text = theBox.Text.Insert(selectionIndex, temp);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm tempChild = (ChildForm)this.ActiveMdiChild;
            RichTextBox theBox = (RichTextBox)tempChild.ActiveControl;
            temp = theBox.SelectedText;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm tempChild = (ChildForm)this.ActiveMdiChild;
            RichTextBox theBox = (RichTextBox)tempChild.ActiveControl;
            theBox.SelectedText = "";
        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm tempChild = (ChildForm)this.ActiveMdiChild;
            RichTextBox theBox = (RichTextBox)tempChild.ActiveControl;
            theBox.Text = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            StreamReader sr = new StreamReader(openFileDialog1.FileName);
            ChildForm newChild = new ChildForm();
            newChild.MdiParent = this;
            newChild.Show();
            newChild.ActiveControl.Text = sr.ReadToEnd();
            sr.Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            help jaunsLogs = new help();
            jaunsLogs.Show();
        }

    }
}
