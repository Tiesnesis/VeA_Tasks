using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kartis3
{

    public class Speletajs
    {
        List<Kartis> s_kartis;
        bool vaiAktivs;

        public bool VaiAktivs
        {
            get { return vaiAktivs; }
            set { vaiAktivs = value; }
        }

        internal List<Kartis> S_kartis
        {
            get { return s_kartis; }
            set { s_kartis = value; }
        }
        string vards;

        public string Vards
        {
            get { return vards; }
            set { vards = value; }
        }
        public Speletajs(string name, List<Kartis> t_kartis)
        {
            this.vards = name;
            this.s_kartis = t_kartis;
            this.vaiAktivs = false;
        }
        public override string ToString()
        {
            return this.vards;
        }
    }
}
