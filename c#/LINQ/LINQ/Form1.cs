using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace LINQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //konekcija un datu izvilkšana no access datubāzes
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;" + "data source = D:/veikals.mdb";
            OleDbConnection connection = new OleDbConnection(connectionString);
            DataSet ds = new DataSet();
            OleDbDataAdapter daTable1 = new OleDbDataAdapter("SELECT * FROM Pircejs", connection);
            daTable1.Fill(ds, "Pircejs");
            DataTable table1 = ds.Tables["Pircejs"];
            OleDbDataAdapter daTable2 = new OleDbDataAdapter("SELECT * FROM Prece", connection);
            daTable2.Fill(ds, "Prece");
            DataTable table2 = ds.Tables["Prece"];
            OleDbDataAdapter daTable3 = new OleDbDataAdapter("SELECT * FROM Pirkums", connection);
            daTable3.Fill(ds, "Pirkums");
            DataTable table3 = ds.Tables["Pirkums"];
            OleDbDataAdapter daTable4 = new OleDbDataAdapter("SELECT * FROM Nop_preces", connection);
            daTable4.Fill(ds, "Nop_preces");
            DataTable table4 = ds.Tables["Nop_preces"];
            //Pirmais vaicājums
            /*
            var result = from temp in table1.AsEnumerable()
                         select new
                         {
                             Vards = temp.Field<String>("Vards_Uzvards"),
                             Vecums = temp.Field<Int32>("Vecums")
                         };
            foreach (var item in result)
            {
                listBox1.Items.Add(item.Vards + "  " + item.Vecums);
            }
            //Otrais vaicājums
            var result2 = from temp1 in table1.AsEnumerable()
                          join temp2 in table3.AsEnumerable()
                          on temp1.Field<Int32>("ID_pircejs") equals temp2.Field<Int32>("ID_pircejs")
                          select new
                          {
                              vards = temp1.Field<String>("Vards_Uzvards"),
                              ID_pirkums = temp2.Field<Int32>("ID_pirkums")
                          };

            foreach (var item in result2)
            {
                Console.WriteLine(item.vards + "  " + item.ID_pirkums);
            }
            */
            var result = from temp in table1.AsEnumerable()
                         select new
                         {
                             Vards = temp.Field<String>("Vards_Uzvards")
                         };
            foreach (var item in result)
            {
                comboBox1.Items.Add(item.Vards);
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string izvele = comboBox1.SelectedItem.ToString();
            /*var result = from temp in table1.AsEnumerable()
                         select new
                         {
                             Vards = temp.Field<String>("Vards_Uzvards")
                         };
            foreach (var item in result)
            {
                comboBox1.Items.Add(item.Vards);
            }*/
            //jāuztaisa viss globāls un tad ar where visu izbliež
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
