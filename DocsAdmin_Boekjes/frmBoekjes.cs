using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocsAdmin_Boekjes.Data;
using DocsAdmin_Boekjes.Helper;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace DocsAdmin_Boekjes
{
    public partial class frmBoekjes : Form
    {
        //Private fields
        private string _tempPrintFilePath;
        private double _currentSelectedInputPrice;
        private BookInput _currentSelectedBookInput;
        private List<double> _controlePriceList;
        private List<int> _controleQuantityList;
        private int _currentControleIndex = -1;
        private XmlExportHelper _xmlHelper;
        private List<int> _allBookNrs;


        //Ctor
        public frmBoekjes()
        {
            InitializeComponent();
        }

        #region Form LoadEvent and LoadFunctions

        private void frmBoekjes_Load(object sender, EventArgs e)
        {
            //Generate field values
            _controlePriceList = new List<double>();
            _controleQuantityList = new List<int>();
            _tempPrintFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\TempPrintFile.txt";

            //Generate the remaining controls
            GeneratePricingButtons();

            //Set eventhandlers for the quantityButtons
            SetQuantityButtonsEventHandlers();

            
            //Init xml
            InitXmlHelper();

            //Populate cboBookNrs
            PopulateCboBookNumbers();

            //Init inputscreen
            InitialiseInputScreen(false);

            //Search xml
            InitBookNrValueAccordingToXml();

            //Get total by date
            GetTotalValueByDate();

            //Enable and disable controls
            EnableDisableControls();

            //Focus on the bookNr
            txtBookNr.Focus();
        }

        private void InitXmlHelper()
        {
            //Prepare for saving
            var xmlPath = PrepareForSavingToXml(false);

            //If the xmlPath is still null --> exception
            if (string.IsNullOrEmpty(xmlPath))
                throw new Exception("The provided xmlFileLocation to save was null/empty.");

            //Get xmlHelper, create new when necessary
            if (_xmlHelper == null)
                _xmlHelper = new XmlExportHelper(xmlPath);

            //Get number of books in xml
            sslStatusLabelNumberOfBooks.Text = string.Format("Aantal boekjes in xml: {0} | ", _xmlHelper.NumberOfBooks);

            //Set xmlFilepath in statusbar
            sslXmlFilePath.Text = string.Format("Locatie XML file: {0}", xmlPath);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Check for ctrl + S --> Save_Action
            if (keyData == (Keys.Control | Keys.S))
            {
                SaveToXml(false);
                return true;
            }

            //Check for ctrl + N --> New book
            if (keyData == (Keys.Control | Keys.N))
            {
                InitialiseInputScreen();
                return true;
            }

            //Check for ctrl + P --> Print current book
            if (keyData == (Keys.Control | Keys.P))
            {
                PrintCurrentBook();
                return true;
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void EnableDisableControls()
        {
            //Logic to enable/disable controls
            //Add customPrice button
            btnAddCustomPrice.Enabled = !string.IsNullOrEmpty(txtCustomPrice.Text);

            //Edit Sheet details buttons
            var sheetDetailControlsEnabled = (lbSheets.SelectedIndex != -1);
            txtSheetDetail.Enabled = sheetDetailControlsEnabled;
            dtpSheetDate.Enabled = sheetDetailControlsEnabled;
            btnEdit.Enabled = sheetDetailControlsEnabled;
            btnDelete.Enabled = sheetDetailControlsEnabled;
            btnInsert.Enabled = sheetDetailControlsEnabled;

            //Controle button disabled when no inputs are given..
            btnControleNext.Enabled = lbSheets.Items.Count != 0 && _currentControleIndex + 1 < _controlePriceList.Count;
            btnControleVorige.Enabled = lbSheets.Items.Count != 0 && _currentControleIndex - 1 >= 0;

            //Set focus on custom txt
            txtCustomPrice.Focus();

            //Set bookNr text readonly if there's already an input
            txtBookNr.ReadOnly = lbSheets.Items.Count > 0;

            //Export to excel must be disabled if no bookNrs are detected
            btnExportToExcelToolStripMenuItem.Enabled = _allBookNrs.Count > 0;
        }

        
        #endregion

        #region Init logic

        private void InitialiseInputScreen(bool showMsgBoxToConfirmInitialise = true)
        {
            //Unsaved progress will be lost. Continue?
            DialogResult result;

            if (showMsgBoxToConfirmInitialise)
                result = MessageBox.Show("U wilt een nieuw boekje starten. Alle niet opgeslaan gegevens zullen verloren gaan. Wilt u doorgaan?", "Nieuw boekje starten", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            else
                result = DialogResult.Yes;

            if (result == DialogResult.Yes)
            {
                //Get new bookNr
                InitBookNrValueAccordingToXml();

                //Clear current sheets
                lbSheets.Items.Clear();

                //Reset input date
                dtpInputDate.Value = DateTime.Now;

                //Calculate control input
                CalculateControleValues();

                //Clear edit screen
                txtTotalInputs.Text = "";
                txtDetailBookNr.Text = "";
                txtSheetDetail.Text = "";

                //Clear huidig blaadje count
                lblCurrentSheet.Text = "";

                //EnableDisable controls
                EnableDisableControls();

                //Focus on bookNr
                txtBookNr.Focus();
            }


        }

        private void btnNewBook_Click(object sender, EventArgs e)
        {
            //Init input screen
            InitialiseInputScreen();
        }

        #endregion

        #region Booknr Logic

        private void txtBookNr_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Input must be numeric
            if (e.KeyChar == '\r')
            {
                //Logic to execute when enter is pressed
                SearchIfBookAlreadyExistsInXml();
                txtCustomPrice.Focus();
            }
            else if (e.KeyChar != '\b' && !IsTextBoxPressedKeyNumeric(e.KeyChar.ToString()))
            {
                //No numeric value entered!
                MessageBox.Show("Enkel numerieke waarden toegestaan.", "Waarschuwing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void SearchIfBookAlreadyExistsInXml()
        {
            //Get the entered number
            int enteredBooknr = int.Parse(txtBookNr.Text);

            //Get book from XML
            var bookSheets = _xmlHelper.RetrieveBookFromXmlByBookNr(enteredBooknr);

            //If already exists, the count will be > 0
            if (bookSheets.Count > 0)
            {
                //Print the sheets on the form
                foreach (var sheet in bookSheets)
                    lbSheets.Items.Add(sheet);

                //Calculate totals
                CalculateTotalBook();

                //Calculate control values
                CalculateControleValues();

                //EnableDisable
                EnableDisableControls();
            }

        }

        private bool IsTextBoxPressedKeyNumeric(string valueToTest)
        {
            //Vars
            int testValue = 0;

            //Return result
            return int.TryParse(valueToTest, out testValue);
        }

        private void InitBookNrValueAccordingToXml()
        {
            //Retrieve next bookNr
            txtBookNr.Text = _xmlHelper.RetrieveNexToAddBookNr().ToString();
        }

        private void PopulateCboBookNumbers()
        {
            //Get all bookNrs from excel
            _allBookNrs = _xmlHelper.RetrieveAllBookNumbers();

            //Store new sheet input date
            var tempNewSheetDate = dtpInputDate.Value;

            //Set itemssource
            cboBookNrs.DataSource = _allBookNrs;

            //Set autocomplete source
            var autoCompleteSource = new AutoCompleteStringCollection();
            foreach (var bookNr in _allBookNrs)
                autoCompleteSource.Add(bookNr.ToString());
            
            cboBookNrs.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboBookNrs.AutoCompleteMode = AutoCompleteMode.Append;
            cboBookNrs.AutoCompleteCustomSource = autoCompleteSource;

            //Set selectedIndex on the lastitem
            cboBookNrs.SelectedIndex = cboBookNrs.Items.Count - 1;

            //Reset the inputDate
            //Necassary as it gets reset after setting datasource
            dtpInputDate.Value = tempNewSheetDate;
        }

        private void CboBookNrs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Init inputscreen
            InitialiseInputScreen(false);

            //Set txtBookNr to selecteditem 
            txtBookNr.Text = cboBookNrs.SelectedItem.ToString();

            //Retrieve the book with the selected nr from xml
            SearchIfBookAlreadyExistsInXml();
        }

        #endregion

        #region QuantityButtons Region

        private void SetQuantityButtonsEventHandlers()
        {
            //Set eventhandlers for the quantityButtons
            foreach (var control in gbQuantity.Controls)
                if (control.GetType() == typeof(Button))
                    ((Button)control).Click += QuantityButtonClick_EventHandler;

        }

        private void QuantityButtonClick_EventHandler(object sender, EventArgs e)
        {
            //Sender is a button --> Cast
            var btnSender = (Button)sender;

            //The number of times to price needs to be added is in the Tag property
            //Cast to int and pass to the AddPrice method
            AddSheetToLbSheets(int.Parse(btnSender.Tag.ToString()));

        }

        #endregion

        #region lbInputs_SheetDetailsLogic

        private void lbSheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get selected bookInput
            _currentSelectedBookInput = lbSheets.SelectedItem as BookInput;

            //Fill details view
            if (_currentSelectedBookInput != null)
            {
                txtDetailBookNr.Text = _currentSelectedBookInput.BookID.ToString();
                txtSheetDetail.Text = _currentSelectedBookInput.Value.ToString("00.00");
                dtpSheetDate.Value = _currentSelectedBookInput.Date;
            }
            else
            {
                txtDetailBookNr.Text = "";
                txtSheetDetail.Text = "";
                dtpSheetDate.Value = DateTime.Today;
            }

            //Re-calculate total
            CalculateTotalBook();

            //Enable and disable controls
            EnableDisableControls();
        }

        #endregion

        #region PricingButtons Region

        private void GeneratePricingButtons()
        {
            //Settings
            var appSettings = ConfigurationManager.AppSettings;

            //Loop the appSettings
            foreach (var setting in appSettings.Keys)
            {
                //Check if key has tarief in its name
                if (setting.ToString().ToLower().Contains("tarief"))
                {
                    //Get the value of the Tarief
                    var priceValue = appSettings[setting.ToString()];

                    //Create the button
                    var b = new Button();
                    b.Name = string.Format("btn{0}", setting.ToString());
                    b.Height = 35;
                    b.Width = 90;
                    b.Text = "€ " + priceValue;
                    b.Tag = priceValue;

                    //Set button font
                    var f = new Font(b.Font.FontFamily, 11, FontStyle.Regular);
                    b.Font = f;

                    //Add clickHandler
                    b.Click += pricingButton_ClickEventHandler;

                    //Add the button to the groupbox
                    flowLayout.Controls.Add(b);
                }
            }

        }

        private void pricingButton_ClickEventHandler(object sender, EventArgs e)
        {
            //Cast sender to button 
            //Necessary step to read the Text and get the pricing value
            _currentSelectedInputPrice = double.Parse(((Button)sender).Tag.ToString());

            //Add default 1 times the price
            AddSheetToLbSheets();
        }

        #endregion

        #region Custom Price

        private void btnAddCustomPrice_Click(object sender, EventArgs e)
        {
            //Add custom price
            AddCustomPrice();
        }

        private void txtCustomPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Check if + --> Add price
            if (e.KeyChar == '+')
            {
                //Add custom price
                AddCustomPrice();
                e.Handled = true;
            }


        }

        private void txtCustomPrice_TextChanged(object sender, EventArgs e)
        {
            //EnableDisableControls
            EnableDisableControls();
        }

        private void AddCustomPrice()
        {
            //Parse the custom InputPrice
            var input = txtCustomPrice.Text.Replace('.', ',');

            if (double.TryParse(input, out _currentSelectedInputPrice))
            {
                //Add default 1 times the price
                AddSheetToLbSheets();

                //Clear this text
                txtCustomPrice.Text = "";
            }
            else
            {
                MessageBox.Show("Gelieve een numerieke waarde in te vullen.", "Waarschuwing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }



        #endregion

        #region AddSheetLogic

        private void AddSheetToLbSheets(int quantity = 1)
        {
            //get bookNr
            int bookNr = int.Parse(txtBookNr.Text);

            //TODO Should work with BookInputs!!!!!!
            for (int i = 0; i < quantity; i++)
            {
                //Add the current selected price to Book for the provided number of times
                var bi = new BookInput() { BookID = bookNr, Value = _currentSelectedInputPrice, Date = dtpInputDate.Value };
                lbSheets.Items.Add(bi);
            }

            //Calculate the total
            CalculateTotalBook();

            //Calculate controle values
            CalculateControleValues();

            //EnableDisable Controls
            EnableDisableControls();

            //Select the last item in the listbox
            lbSheets.SelectedIndex = lbSheets.Items.Count - 1;

        }

        private void CalculateTotalBook()
        {
            //Create result
            double result = 0;

            foreach (var lbi in lbSheets.Items)
            {
                //Convert item to bookInput
                var bi = lbi as BookInput;

                //Add to results
                result += bi.Value;
            }

            //Set textbox Total
            txtTotalInputs.Text = string.Format("€ {0}", result.ToString("0.00"));

            //Set current sheet number
            lblCurrentSheet.Text = lbSheets.Items.Count.ToString();
        }

        #endregion

        #region SheetDetail logic

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //Update the selected bookInput
            var updatedBookInput = new BookInput();
            updatedBookInput.BookID = int.Parse(txtBookNr.Text);
            updatedBookInput.Value = double.Parse(txtSheetDetail.Text.Replace('.', ','));
            updatedBookInput.Date = dtpSheetDate.Value;

            //update the item in the listbox
            var lbSheetsIndexPosition = lbSheets.SelectedIndex;
            lbSheets.Items.RemoveAt(lbSheetsIndexPosition);
            lbSheets.Items.Insert(lbSheetsIndexPosition, updatedBookInput);
            lbSheets.SelectedIndex = lbSheetsIndexPosition;

            //Recalculate controle values
            CalculateControleValues();

            //EnableDisableControls
            EnableDisableControls();

            //Print Controle values
            //PrintControleValues(ControleValue.EditOccurred);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Delete the currentSelectedBookInput
            if (lbSheets.SelectedIndex != -1)
                lbSheets.Items.RemoveAt(lbSheets.SelectedIndex);

            //Calculate controle values
            CalculateControleValues();

            //EnableDisableControls
            EnableDisableControls();

            //Print Controle values
            // PrintControleValues(ControleValue.DeleteOccurred);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //Create nex bookInput
            var newBI = new BookInput()
            {
                BookID = int.Parse(txtDetailBookNr.Text),
                Value = double.Parse(txtSheetDetail.Text),
                Date = dtpSheetDate.Value
            };

            //Insert the new BI at the current index
            lbSheets.Items.Insert(lbSheets.SelectedIndex, newBI);

            //Recalculate total
            CalculateTotalBook();

            //Calculate controle values
            CalculateControleValues();

            //EnableDisableControls
            EnableDisableControls();

            //Print Controle values
            //PrintControleValues(ControleValue.EditOccurred);
        }


        #endregion

        #region Controle logic

        private void btnControleNext_Click(object sender, EventArgs e)
        {
            PrintControleValues(ControleValue.Next);
        }

        private void btnControleVorige_Click(object sender, EventArgs e)
        {
            PrintControleValues(ControleValue.Previous);
        }

        private void PrintControleValues(ControleValue value)
        {
            //Update controleIndex according to controleValue
            if (value == ControleValue.Next)
                _currentControleIndex++;
            else if (value == ControleValue.Previous)
                _currentControleIndex--;

            //Print the values to frm
            txtControlPrice.Text = "€ " + _controlePriceList[_currentControleIndex].ToString("0.00");
            txtControlQuantity.Text = _controleQuantityList[_currentControleIndex].ToString();

            //EnableDisablecontrols
            EnableDisableControls();

            //Sync lbSheetsSelectedIndex
            SyncLbSheetsSelectedIndexWithCurrentControleIndex();
        }

        private void SyncLbSheetsSelectedIndexWithCurrentControleIndex()
        {
            if (_currentControleIndex != -1)
            {
                //Vars
                int tempSelectedIndex = 0;

                //Iterate quantity list to get the correct selectedIndex for the lbSheets
                for (int i = 0; i <= _currentControleIndex; i++)
                {
                    tempSelectedIndex += _controleQuantityList[i];
                }

                //Perform -1 as the lbSheets collection is null-based
                tempSelectedIndex--;

                //Perform the selectedItem
                lbSheets.SelectedIndex = tempSelectedIndex;
            }

        }

        private void CalculateControleValues()
        {
            //Init the lists
            _controlePriceList = new List<double>();
            _controleQuantityList = new List<int>();
            _currentControleIndex = -1;
            int tempQuantity = 0;

            //Empty textboxes
            txtControlPrice.Text = "";
            txtControlQuantity.Text = "";

            foreach (BookInput bi in lbSheets.Items)
            {
                //first item in the listbox is handled differently..
                if (lbSheets.Items.IndexOf(bi) == 0)
                {
                    _controlePriceList.Add(bi.Value);
                    tempQuantity = 1;
                }
                //Or if it's a new price
                else if (bi.Value != _controlePriceList.LastOrDefault())
                {
                    //Add the quantity to the list
                    _controleQuantityList.Add(tempQuantity);

                    //Init for the new iteration
                    _controlePriceList.Add(bi.Value);
                    tempQuantity = 1;
                }
                else
                {
                    //Still the same price --> update the quantity
                    tempQuantity++;
                }
            }

            //Add tempQuantity for the last iteration item
            _controleQuantityList.Add(tempQuantity);
        }


        #endregion

        #region Save to File logic

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Execute save logic. No Save as
            SaveToXml(false);
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Execute save logic. Save as
            SaveToXml(true);
        }

        private void SaveToXml(bool isSaveAs)
        {
            //Get a xmlFileLocation from the user
            var xmlFileLocation = PrepareForSavingToXml(isSaveAs);

            //Save current book to xml
            SaveBookToXmlDoc(xmlFileLocation, isSaveAs);

            //Get number of books in xml
            sslStatusLabelNumberOfBooks.Text = string.Format("Aantal boekjes in xml: {0} | ", _xmlHelper.NumberOfBooks);

            //Set filepath
            sslXmlFilePath.Text = string.Format("Locatie XML file: {0}", xmlFileLocation);

            //Update totalByDate
            GetTotalValueByDate();

            //Update cboBookNrs
            PopulateCboBookNumbers();
        }

        private string PrepareForSavingToXml(bool isSaveAsAction)
        {
            //Read the appSetting savePath value. 
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string xmlPath = config.AppSettings.Settings["xmlFilePath"].Value;

            //If it's null/Empty --> We need a location..
            if (isSaveAsAction || string.IsNullOrEmpty(xmlPath))
                xmlPath = SetXmlFilePath();

            //Return result
            return xmlPath;
        }

        private string SetXmlFilePath()
        {
            //Result
            string xmlPath = "";

            //SafeFileDialog
            var sfd = new SaveFileDialog();
            sfd.Filter = "XML File | *.xml";
            sfd.FileName = "DocsAdmin.xml";
            sfd.Title = "Save DocsAdmin to XML";
            var result = sfd.ShowDialog();

            //If aborted/canceled/... --> Abort procedure
            if (result == DialogResult.Abort || result == DialogResult.Cancel)
                return xmlPath;

            //User defined a correct path
            xmlPath = sfd.FileName;

            //Save path in configFile for next time
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["xmlFilePath"].Value = xmlPath;
            config.Save(ConfigurationSaveMode.Modified);

            //Return selectedXmlPath
            return xmlPath;
        }

        private void SaveBookToXmlDoc(string xmlPath, bool isSaveAsNewFile)
        {
            //If the xmlPath is still null --> exception
            if (string.IsNullOrEmpty(xmlPath))
                throw new Exception("The provided xmlFileLocation to save was null/empty.");

            //Get xmlHelper, create new when necessary
            if (isSaveAsNewFile || _xmlHelper == null)
                _xmlHelper = new XmlExportHelper(xmlPath);

            //Create sheetList,, retrieve the lbItems
            var sheets = new List<BookInput>();
            foreach (var bi in lbSheets.Items)
                sheets.Add(bi as BookInput);

            //Save current Book
            _xmlHelper.SaveBookToXml(txtBookNr.Text, sheets);
        }

        #endregion

        #region Total By Date Logic

        private void dtpTotalByDateFilter_ValueChanged(object sender, EventArgs e)
        {
            GetTotalValueByDate();
        }

        private void GetTotalValueByDate()
        {
            //Get the totalByDate
            var total = _xmlHelper.CalculateTotalByDate(dtpTotalByDateFilter.Value);

            //Set txtTotal
            txtTotalByDate.Text = "€ " + total.Total.ToString("0.00");

            //Set bookNrs. --> use ToStringmethod for that
            txtDateBooks.Text = total.ToString();
        }

        #endregion

        #region Print Logic

        private void btnPrintCurrentBook_Click(object sender, EventArgs e)
        {
            //Call print method
            PrintCurrentBook();
        }

        private void PrintCurrentBook()
        {
            //Write current book to temp PrintFile
            //Just a normal textfile
            WriteBookToTempPrintFile();

            //Print the TempPrintFile
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(_tempPrintFilePath);
            psi.Verb = "PRINT";

            System.Diagnostics.Process.Start(psi);
        }

        private void WriteBookToTempPrintFile()
        {
            //Create writer
            using (var writer = new StreamWriter(_tempPrintFilePath))
            {
                //Write the bookNr
                writer.WriteLine("Boekje " + txtBookNr.Text);
                writer.WriteLine();

                //Write each sheetValue
                foreach (BookInput sheet in lbSheets.Items)
                    writer.WriteLine(sheet.ToString());

                //Write dashes to seperate total
                writer.WriteLine("----------");

                //Write total
                writer.Write(txtTotalInputs.Text);
            }
        }


        #endregion

        #region Excel logic

        private void ExportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Show the new form
            var frmExcelExport = new frmExcelExport(_allBookNrs, _xmlHelper);
            frmExcelExport.ShowDialog();
        }

        #endregion


    }
}
