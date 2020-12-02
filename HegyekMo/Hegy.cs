using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HegyekMo
{
    class Hegy
    {
        private string csucs;

        public string Csucs
        {
            get { return csucs; }
        }

        private string hegyseg;

        public string Hegyseg
        {
            get { return hegyseg; }
        }

        private int magassag;

        public int Magassag
        {
            get { return magassag; }
        }

        public double labban;

        public Hegy(string csucs, string hegyseg, int magassag)
        {
            this.csucs = csucs;
            this.hegyseg = hegyseg;
            this.magassag = magassag;
            this.labban = magassag * 3.280839895;
        }

    }
}
