using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalCalcLibrary
{
    public class Element
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double AreaPerTon { get; set; }
        public double MassOneMeter { get; set; }
        public int SortID { get; set; }
    }
}
