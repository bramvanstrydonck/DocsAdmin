using DocsAdmin_Boekjes.Helper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocsAdmin_Boekjes
{
    public partial class frmExcelExport : Form
    {
        //Private fields
        private string _errorMessage;
        private XmlExportHelper _xmlHelper;

        //Property
        public List<int> BookNrs { get; set; }
        public int BeginBook { get; set; }
        public int EndBook { get; set; }


        //Ctor
        public frmExcelExport(List<int> bookNrs, XmlExportHelper xmlHelper)
        {
            //Init component
            InitializeComponent();

            //Set private vars and props
            BookNrs = bookNrs;
            _xmlHelper = xmlHelper;

            //Init comboboxes
            foreach (var bookNr in BookNrs)
            {
                cboStart.Items.Add(bookNr);
                cboEnd.Items.Add(bookNr);
            }

        }

        #region Button logic

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //SafeFileDialog
            var sfd = new SaveFileDialog();
            sfd.Filter = "Excel File | *.xlsx";
            sfd.Title = "Export books to excel file";
            var result = sfd.ShowDialog();

            //Show output file
            txtExcelFilePath.Text = sfd.FileName;
        }

        private async void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (InputValuesOk())
            {
                //Set progressbar visible
                btnExportToExcel.Enabled = false;
                pbProgressBar.Visible = true;

                //Export to excel
                var bookStart = (int)cboStart.SelectedItem;
                var bookEnd = (int)cboEnd.SelectedItem;
                await Task.Factory.StartNew(() => Export2Excel(bookStart, bookEnd));

                //Set progressbar invisible
                pbProgressBar.Visible = false;

                //Show user that operation was succesfull and close this form
                MessageBox.Show("Data werd succesvol geëxporteerd naar het opgegeven excel bestand.", "Mission accomplished :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            else
                MessageBox.Show("Unable to export to excel. Error message: " + _errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }


        #endregion

        #region Validation

        private bool InputValuesOk()
        {
            //Init vars
            bool result = false;
            _errorMessage = "";

            //Textbox may not be empty 
            if (string.IsNullOrEmpty(txtExcelFilePath.Text))
                _errorMessage = "Geen geldig excel output path gespecifieerd.";

            //Check the start value
            if (!string.IsNullOrEmpty(_errorMessage) || cboStart.SelectedItem == null)
                _errorMessage = "Gelieve een startwaarde te selecteren.";

            //Check the start value
            if (!string.IsNullOrEmpty(_errorMessage) || cboEnd.SelectedItem == null)
                _errorMessage = "Gelieve een startwaarde te selecteren.";

            if (!string.IsNullOrEmpty(_errorMessage) || (int)cboEnd.SelectedItem < (int)cboStart.SelectedItem)
                _errorMessage = "De eindwaarde moet groter zijn dan of gelijk aan de startwaarde.";

            //If errormessage is empty --> OK
            if (string.IsNullOrEmpty(_errorMessage))
                result = true;

            //Return result
            return result;
        }

        #endregion

        #region Excel logic

        private void Export2Excel(int bookStart, int bookEnd)
        {
            //Check if excel is installed on the system
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("Unable to detect Microsoft Excel on your system. Make sure that Microsoft Excel is properly installed and try again later.", "Excel not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Create new excelWorkbook
            var excelWorkbook = excelApp.Workbooks.Add();

            //Get the first worksheet
            Microsoft.Office.Interop.Excel.Worksheet worksheet = excelWorkbook.Worksheets.get_Item(1);

            //Loop vars
            int currentColumnIndex = 1;

            //Init loop bookNrs
            for (int currentLoopBookNr = bookStart; currentLoopBookNr <= bookEnd; currentLoopBookNr++)
            {
                //Retrieve the book from the excel
                var book = _xmlHelper.RetrieveBookFromXmlByBookNr(currentLoopBookNr);

                //Write bookNr // Second row is whitespace
                worksheet.Cells[1, currentColumnIndex] = "Boekje " + currentLoopBookNr;

                //Loop the bookInputs 
                int bookInputRowIndex = 3;
                double total = 0;
                foreach (var bookInput in book)
                {
                    //Retrieve bookInput value
                    worksheet.Cells[bookInputRowIndex, currentColumnIndex] = bookInput.ToString();

                    //Increment total
                    total += bookInput.Value;

                    //Increment rowIndex
                    bookInputRowIndex++;
                }

                //Write total
                bookInputRowIndex++;
                worksheet.Cells[bookInputRowIndex, currentColumnIndex] = "€ " + total.ToString("0.00");

                //Increment current column index
                currentColumnIndex++;
            }

            //Save the excel file
            excelWorkbook.SaveAs(txtExcelFilePath.Text);

            //Close the workbook
            excelWorkbook.Close(true);
            excelApp.Quit();

            //Release comm objects
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

        }

        #endregion

        private void frmExcelExport_Load(object sender, EventArgs e)
        {

        }
    }
}
