using DocsAdmin_Boekjes.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DocsAdmin_Boekjes.Helper
{
    public class XmlExportHelper
    {
        //private fields
        private XDocument _xmlDoc;

        //Props
        public string XmlFilePath { get; set; }

        //Readonly Properties
        public int NumberOfBooks
        {
            get { return _xmlDoc.Root.Descendants("Book").Count(); }
        }


        //Ctor
        public XmlExportHelper(string filePath)
        {
            //Set filepath
            XmlFilePath = filePath;

            //Init XDoc and check if the file already exists or not..
            GearEngine();
        }

        private void GearEngine()
        {
            //Check if file exists
            if (File.Exists(XmlFilePath))
            {
                //Load xDocument
                _xmlDoc = XDocument.Load(XmlFilePath);
            }
            else
            {
                //Create new xDoc
                _xmlDoc = new XDocument();

                //Generate the correct tree
                var root = new XElement("DocsAdmin");
                _xmlDoc.Add(root);

                //Save the file
                _xmlDoc.Save(XmlFilePath);
            }

        }

        #region Save to XML Logic

        public void SaveBookToXml(string bookNr, ICollection<BookInput> sheets)
        {
            //Get a bookElement
            //isOverride is later on used to determine if we need to update or add an alement
            bool isOverride;
            var bookElement = GetBookElement(bookNr, out isOverride);

            //Check if it's null. If it is, break --> User wants no override
            if (bookElement == null)
                return;

            //Create the sheets
            foreach (var sheet in sheets)
            {
                //Create sheet elements
                var sheetDate = new XElement("Date", sheet.Date.Date);
                var sheetValue = new XElement("Value", sheet.Value);

                //Create sheet
                var sheetElement = new XElement("Sheet");
                sheetElement.Add(sheetDate);
                sheetElement.Add(sheetValue);

                //Add sheetElement to the bookElement
                bookElement.Add(sheetElement);
            }

            //Add the constructed book to the rootElement of our doc
            //Only if it's not an override/update
            if (!isOverride)
                _xmlDoc.Root.Add(bookElement);

            //Save xmlFile
            _xmlDoc.Save(XmlFilePath);

            //Show messagebox to user
            MessageBox.Show("Huidige sessie werd succesvol opgeslaan.", "Succesvol opgeslaan", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //This method creates a new bookElement or returns the already existing one
        private XElement GetBookElement(string bookNr, out bool isOverride)
        {
            //Check if the document already has a book with the current number
            isOverride = false;
            var bookElement = _xmlDoc.Root.Elements().FirstOrDefault(el => el.Attribute(XName.Get("number")).Value == bookNr);

            if (bookElement != null)
            {
                //There is an existing bookElement. Ask for override
                if (MessageBox.Show(string.Format("Er bestaat al een boekje met nummer: '{0}' in het document. Wenst u te overschrijven?", bookNr), "Informatie overschrijven?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Override so clear current nodes
                    bookElement.Elements().Remove();
                    isOverride = true;
                }
                else
                {
                    //No override so set element to null so calling Action can handle it
                    bookElement = null;
                }

            }
            else
            {
                //There's no bookElement with the provided bookNr
                //So we just create one..
                bookElement = new XElement("Book");

                //Set bookNr Attribute
                bookElement.SetAttributeValue("number", bookNr);
            }

            //Return the bookElement
            return bookElement;
        }



        #endregion

        #region Total by Date Logic

        public double CalculateTotalByDate(DateTime filterDate)
        {
            //Init var
            double total = 0;

            //Search all dateTags who correspond the filter
            //var dateElements = _xmlDoc.Root.Elements().Where(e => e.Name.Equals("Date") && filterDate.Date.Equals(DateTime.Parse(e.Value).Date));
            var dateElements = _xmlDoc.Root.Descendants(XName.Get("Date")).Where(e => filterDate.Date.Equals(DateTime.Parse(e.Value).Date));

            //For each date element,, retrieve it's parent (Sheet)
            //From Sheet, retrieve the 'Value' element --> Contains the value
            foreach (var dateElement in dateElements)
            {
                //Get valueElement
                var valueElement = dateElement.Parent.Elements(XName.Get("Value")).FirstOrDefault();

                //Retrieve the priceValue
                total += double.Parse(valueElement.Value, CultureInfo.InvariantCulture);
            }

            //Return result
            return total;
        }

        #endregion

        #region BookNr Logic

        public int RetrieveNexToAddBookNr()
        {
            //vars
            int result = 0;

            //Search for all bookElements
            var bookElements = _xmlDoc.Root.Descendants("Book");

            //check the bookNr attribute
            foreach (var book in bookElements)
            {
                //Try parse the attributeValue as int
                int bookNr = 0;
                int.TryParse(book.Attribute(XName.Get("number")).Value, out bookNr);

                //Check if the bookNr > current result. 
                //True --> replace
                if (bookNr > result)
                    result = bookNr;
            }
            //Result has now the greatest value in the xmlDoc
            //Next to add = greatest value in xml + 1
            result++;
            return result;
        }

        public ICollection<BookInput> RetrieveBookFromXmlByBookNr(int bookNr)
        {
            //Vars
            var result = new List<BookInput>();

            //Search the book
            var bookElement = _xmlDoc.Root.Descendants("Book").FirstOrDefault(b => b.Attribute(XName.Get("number")).Value.Trim().Equals(bookNr.ToString()));

            //Possible that it's null
            // != Null --> Already exists and return the inputs
            if (bookElement != null)
            {
                //Get the sheet elements from the bookElement
                var sheets = bookElement.Elements();

                //Create bookInput foreach sheet
                foreach (var sheetElement in sheets)
                {
                    //Get tempDate and value
                    //Use tryParse. We neve know what happened with the data
                    bool dateOk, valueOk;
                    DateTime tempDate = DateTime.MinValue;
                    double tempValue = -1;

                    dateOk = DateTime.TryParse(sheetElement.Element(XName.Get("Date")).Value, out tempDate);
                    valueOk = double.TryParse(sheetElement.Element(XName.Get("Value")).Value.Replace('.', ','), out tempValue);

                    //Only if both Date and Value are ok --> add to list
                    if (dateOk && valueOk)
                    {
                        result.Add(new BookInput()
                        {
                            BookID = bookNr,
                            Date = tempDate,
                            Value = tempValue
                        });
                    }
                }
            }

            //Return result
            return result;
        }

        #endregion


    }
}
