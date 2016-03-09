using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ClassLibrary1
{
    public class Class1
    {
        public static Image getBildi(string nosaukums)
        {
            return (Image) Atteli.ResourceManager.GetObject(nosaukums);
        }
    }
}
