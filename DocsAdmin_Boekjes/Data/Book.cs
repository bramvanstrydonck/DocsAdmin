using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocsAdmin_Boekjes.Data
{
    public class Book
    {
        //Properties
        public int bookNumber { get; set; }
        public ICollection<BookInput> BookInputs { get; set; }

        //Total --> calculated property
        public double Total {
            get
            {
                //Create result
                double result = 0;

                //loop bookInputs
                if (BookInputs.Any())
                {
                    foreach (var bi in BookInputs)
                        result += bi.Value;
                }

                //Return result
                return result;
            }

        }
    }
}
