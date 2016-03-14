using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace notepadnesalauztais
{
    public partial class help : Form
    {
        public help()
        {
            InitializeComponent();
            LinkLabel.Link contr = new LinkLabel.Link();
            contr.LinkData = "https://notepad-plus-plus.org/contributors/";
            linkLabel1.Links.Add(contr);

            LinkLabel.Link hpage = new LinkLabel.Link();
            hpage.LinkData = "https://notepad-plus-plus.org/";
            linkLabel2.Links.Add(hpage);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }
    }
}
