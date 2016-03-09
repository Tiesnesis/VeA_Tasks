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
            LinkLabel.Link adrese = new LinkLabel.Link();
            adrese.LinkData = "http://www.1188.lv";
            linkLabel1.Links.Add(adrese);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }
    }
}
