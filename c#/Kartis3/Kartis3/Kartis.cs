using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ClassLibrary1;

namespace Kartis3
{
    public enum Masts {Pikis, Kreicis, Ercens, Karavs};
    public enum Vertiba {Divi, Tris, Cetri, Pieci, Sesi, Septini, Astoni, Devini, Desmit, Kalps, Dama, Kungs, Duzis};
    public class Kartis
    {
        Masts masts;
        Vertiba vertiba;
        Image Attels;

        public Image Attels1
        {
            get { return Attels; }
            set { Attels = value; }
        }
        bool vaiApgriests;
        public Vertiba Vertiba
        {
            get { return vertiba; }
            set { vertiba = value; }
        }
        public Masts Masts
        {
            get { return masts; }
            set { masts = value; }
        }
        public Kartis(Masts m, Vertiba v)
        {
            this.masts = m;
            this.vertiba = v;
            this.vaiApgriests = true;
            this.Attels = ClassLibrary1.Class1.getBildi(this.Masts + "_" + this.Vertiba);
            this.Attels.Tag = (this.Masts + " " + this.Vertiba);
        }
        public override string ToString()
        {
            return this.masts + "_" + this.vertiba;
        }
    }
}
