using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocsAdmin_Boekjes.Data
{
    public class TotalByDateObject
    {
        public double Total { get; set; }
        public List<string> BookNrs { get; set; }

        public TotalByDateObject()
        {
            Total = 0;
            BookNrs = new List<string>();
        }

        public override string ToString()
        {
            var result = "";
            var firstRun = true;

            foreach (var nr in BookNrs)
            {
                if (firstRun)
                {
                    result += nr;
                    firstRun = false;
                }
                else
                {
                    result += ";" + nr;
                }
            }

            return result;
            
        }
    }
}
