using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocsAdmin_Boekjes.Data
{
    public enum ControleValue
    {
        Previous, Next, EditOccurred, DeleteOccurred, InsertOccurred
    }

    public class BookInput
    {
        //Properties
        public int BookID { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }

        //ToString method
        public override string ToString()
        {
            //Return nice text layout
            return string.Format("€ {0}", Value.ToString("0.00"));
        }

    }
}
