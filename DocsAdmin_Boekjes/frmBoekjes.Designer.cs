namespace DocsAdmin_Boekjes
{
    partial class frmBoekjes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBookNumber = new System.Windows.Forms.Label();
            this.txtBookNr = new System.Windows.Forms.TextBox();
            this.lbSheets = new System.Windows.Forms.ListBox();
            this.txtTotalInputs = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewBook = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrintCurrentBook = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbBook = new System.Windows.Forms.GroupBox();
            this.gbSheetDetails = new System.Windows.Forms.GroupBox();
            this.lblDetailsTarief = new System.Windows.Forms.Label();
            this.lblDetailBoekjesNummer = new System.Windows.Forms.Label();
            this.txtDetailBookNr = new System.Windows.Forms.TextBox();
            this.dtpSheetDate = new System.Windows.Forms.DateTimePicker();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtSheetDetail = new System.Windows.Forms.TextBox();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.gbQuantity = new System.Windows.Forms.GroupBox();
            this.btnSeven = new System.Windows.Forms.Button();
            this.btnThree = new System.Windows.Forms.Button();
            this.btnSix = new System.Windows.Forms.Button();
            this.btnEight = new System.Windows.Forms.Button();
            this.btnTen = new System.Windows.Forms.Button();
            this.btnFour = new System.Windows.Forms.Button();
            this.btnFive = new System.Windows.Forms.Button();
            this.btnNine = new System.Windows.Forms.Button();
            this.btnTwo = new System.Windows.Forms.Button();
            this.gbPrices = new System.Windows.Forms.GroupBox();
            this.btnAddCustomPrice = new System.Windows.Forms.Button();
            this.txtCustomPrice = new System.Windows.Forms.TextBox();
            this.flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.dtpInputDate = new System.Windows.Forms.DateTimePicker();
            this.gbControle = new System.Windows.Forms.GroupBox();
            this.btnControleVorige = new System.Windows.Forms.Button();
            this.btnControleNext = new System.Windows.Forms.Button();
            this.txtControlPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtControlQuantity = new System.Windows.Forms.TextBox();
            this.lblHuidigBlaadje = new System.Windows.Forms.Label();
            this.lblCurrentSheet = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTotalByDate = new System.Windows.Forms.TextBox();
            this.dtpTotalByDateFilter = new System.Windows.Forms.DateTimePicker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sslXmlFilePath = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslStatusLabelNumberOfBooks = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.cboBookNrs = new System.Windows.Forms.ComboBox();
            this.gbNavigation = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.gbBook.SuspendLayout();
            this.gbSheetDetails.SuspendLayout();
            this.gbInput.SuspendLayout();
            this.gbQuantity.SuspendLayout();
            this.gbPrices.SuspendLayout();
            this.gbControle.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.gbNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBookNumber
            // 
            this.lblBookNumber.AutoSize = true;
            this.lblBookNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookNumber.Location = new System.Drawing.Point(12, 33);
            this.lblBookNumber.Name = "lblBookNumber";
            this.lblBookNumber.Size = new System.Drawing.Size(159, 25);
            this.lblBookNumber.TabIndex = 0;
            this.lblBookNumber.Text = "Boekjesnummer:";
            // 
            // txtBookNr
            // 
            this.txtBookNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookNr.Location = new System.Drawing.Point(167, 30);
            this.txtBookNr.Name = "txtBookNr";
            this.txtBookNr.Size = new System.Drawing.Size(114, 30);
            this.txtBookNr.TabIndex = 1;
            this.txtBookNr.Text = "1";
            this.txtBookNr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBookNr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBookNr_KeyPress);
            // 
            // lbSheets
            // 
            this.lbSheets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSheets.FormattingEnabled = true;
            this.lbSheets.ItemHeight = 25;
            this.lbSheets.Location = new System.Drawing.Point(6, 21);
            this.lbSheets.Name = "lbSheets";
            this.lbSheets.Size = new System.Drawing.Size(268, 304);
            this.lbSheets.TabIndex = 2;
            this.lbSheets.SelectedIndexChanged += new System.EventHandler(this.lbSheets_SelectedIndexChanged);
            // 
            // txtTotalInputs
            // 
            this.txtTotalInputs.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalInputs.Location = new System.Drawing.Point(6, 331);
            this.txtTotalInputs.Multiline = true;
            this.txtTotalInputs.Name = "txtTotalInputs";
            this.txtTotalInputs.ReadOnly = true;
            this.txtTotalInputs.Size = new System.Drawing.Size(268, 40);
            this.txtTotalInputs.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(956, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "msMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewBook,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.btnPrintCurrentBook,
            this.btnExportToExcelToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // btnNewBook
            // 
            this.btnNewBook.Name = "btnNewBook";
            this.btnNewBook.Size = new System.Drawing.Size(271, 26);
            this.btnNewBook.Text = "Nieuw boekje (ctrl + n)";
            this.btnNewBook.Click += new System.EventHandler(this.btnNewBook_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.SaveToolStripMenuItem.Text = "Save (ctrl + s)";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.SaveAsToolStripMenuItem.Text = "Save as..";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // btnPrintCurrentBook
            // 
            this.btnPrintCurrentBook.Name = "btnPrintCurrentBook";
            this.btnPrintCurrentBook.Size = new System.Drawing.Size(271, 26);
            this.btnPrintCurrentBook.Text = "Print huidig boekje (ctrl + p)";
            this.btnPrintCurrentBook.Click += new System.EventHandler(this.btnPrintCurrentBook_Click);
            // 
            // btnExportToExcelToolStripMenuItem
            // 
            this.btnExportToExcelToolStripMenuItem.Name = "btnExportToExcelToolStripMenuItem";
            this.btnExportToExcelToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.btnExportToExcelToolStripMenuItem.Text = "Export to excel..";
            this.btnExportToExcelToolStripMenuItem.Click += new System.EventHandler(this.ExportToExcelToolStripMenuItem_Click);
            // 
            // gbBook
            // 
            this.gbBook.Controls.Add(this.lbSheets);
            this.gbBook.Controls.Add(this.txtTotalInputs);
            this.gbBook.Location = new System.Drawing.Point(17, 67);
            this.gbBook.Name = "gbBook";
            this.gbBook.Size = new System.Drawing.Size(285, 383);
            this.gbBook.TabIndex = 5;
            this.gbBook.TabStop = false;
            this.gbBook.Text = "Digitaal boekje";
            // 
            // gbSheetDetails
            // 
            this.gbSheetDetails.Controls.Add(this.lblDetailsTarief);
            this.gbSheetDetails.Controls.Add(this.lblDetailBoekjesNummer);
            this.gbSheetDetails.Controls.Add(this.txtDetailBookNr);
            this.gbSheetDetails.Controls.Add(this.dtpSheetDate);
            this.gbSheetDetails.Controls.Add(this.btnInsert);
            this.gbSheetDetails.Controls.Add(this.btnDelete);
            this.gbSheetDetails.Controls.Add(this.btnEdit);
            this.gbSheetDetails.Controls.Add(this.txtSheetDetail);
            this.gbSheetDetails.Location = new System.Drawing.Point(17, 456);
            this.gbSheetDetails.Name = "gbSheetDetails";
            this.gbSheetDetails.Size = new System.Drawing.Size(285, 174);
            this.gbSheetDetails.TabIndex = 6;
            this.gbSheetDetails.TabStop = false;
            this.gbSheetDetails.Text = "Blaadje(s) details";
            // 
            // lblDetailsTarief
            // 
            this.lblDetailsTarief.AutoSize = true;
            this.lblDetailsTarief.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailsTarief.Location = new System.Drawing.Point(15, 67);
            this.lblDetailsTarief.Name = "lblDetailsTarief";
            this.lblDetailsTarief.Size = new System.Drawing.Size(57, 20);
            this.lblDetailsTarief.TabIndex = 11;
            this.lblDetailsTarief.Text = "Tarief:";
            // 
            // lblDetailBoekjesNummer
            // 
            this.lblDetailBoekjesNummer.AutoSize = true;
            this.lblDetailBoekjesNummer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailBoekjesNummer.Location = new System.Drawing.Point(15, 31);
            this.lblDetailBoekjesNummer.Name = "lblDetailBoekjesNummer";
            this.lblDetailBoekjesNummer.Size = new System.Drawing.Size(65, 20);
            this.lblDetailBoekjesNummer.TabIndex = 8;
            this.lblDetailBoekjesNummer.Text = "Boekje:";
            // 
            // txtDetailBookNr
            // 
            this.txtDetailBookNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetailBookNr.Location = new System.Drawing.Point(97, 24);
            this.txtDetailBookNr.Name = "txtDetailBookNr";
            this.txtDetailBookNr.ReadOnly = true;
            this.txtDetailBookNr.Size = new System.Drawing.Size(177, 30);
            this.txtDetailBookNr.TabIndex = 10;
            // 
            // dtpSheetDate
            // 
            this.dtpSheetDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSheetDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSheetDate.Location = new System.Drawing.Point(6, 96);
            this.dtpSheetDate.Name = "dtpSheetDate";
            this.dtpSheetDate.Size = new System.Drawing.Size(268, 30);
            this.dtpSheetDate.TabIndex = 7;
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(188, 129);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(85, 35);
            this.btnInsert.TabIndex = 9;
            this.btnInsert.Text = "Invoegen";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(95, 129);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 35);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Verwijder";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(6, 129);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(85, 35);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Wijzig";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtSheetDetail
            // 
            this.txtSheetDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSheetDetail.Location = new System.Drawing.Point(97, 60);
            this.txtSheetDetail.Name = "txtSheetDetail";
            this.txtSheetDetail.Size = new System.Drawing.Size(177, 30);
            this.txtSheetDetail.TabIndex = 7;
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.gbQuantity);
            this.gbInput.Controls.Add(this.gbPrices);
            this.gbInput.Location = new System.Drawing.Point(318, 67);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(626, 383);
            this.gbInput.TabIndex = 7;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "Input";
            // 
            // gbQuantity
            // 
            this.gbQuantity.Controls.Add(this.btnSeven);
            this.gbQuantity.Controls.Add(this.btnThree);
            this.gbQuantity.Controls.Add(this.btnSix);
            this.gbQuantity.Controls.Add(this.btnEight);
            this.gbQuantity.Controls.Add(this.btnTen);
            this.gbQuantity.Controls.Add(this.btnFour);
            this.gbQuantity.Controls.Add(this.btnFive);
            this.gbQuantity.Controls.Add(this.btnNine);
            this.gbQuantity.Controls.Add(this.btnTwo);
            this.gbQuantity.Location = new System.Drawing.Point(316, 21);
            this.gbQuantity.Name = "gbQuantity";
            this.gbQuantity.Size = new System.Drawing.Size(304, 356);
            this.gbQuantity.TabIndex = 1;
            this.gbQuantity.TabStop = false;
            this.gbQuantity.Text = "Aantal";
            // 
            // btnSeven
            // 
            this.btnSeven.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeven.Location = new System.Drawing.Point(17, 76);
            this.btnSeven.Name = "btnSeven";
            this.btnSeven.Size = new System.Drawing.Size(50, 50);
            this.btnSeven.TabIndex = 8;
            this.btnSeven.Tag = "6";
            this.btnSeven.Text = "7";
            this.btnSeven.UseVisualStyleBackColor = true;
            // 
            // btnThree
            // 
            this.btnThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThree.Location = new System.Drawing.Point(73, 20);
            this.btnThree.Name = "btnThree";
            this.btnThree.Size = new System.Drawing.Size(50, 50);
            this.btnThree.TabIndex = 7;
            this.btnThree.Tag = "2";
            this.btnThree.Text = "3";
            this.btnThree.UseVisualStyleBackColor = true;
            // 
            // btnSix
            // 
            this.btnSix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSix.Location = new System.Drawing.Point(245, 21);
            this.btnSix.Name = "btnSix";
            this.btnSix.Size = new System.Drawing.Size(50, 50);
            this.btnSix.TabIndex = 4;
            this.btnSix.Tag = "5";
            this.btnSix.Text = "6";
            this.btnSix.UseVisualStyleBackColor = true;
            // 
            // btnEight
            // 
            this.btnEight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEight.Location = new System.Drawing.Point(73, 76);
            this.btnEight.Name = "btnEight";
            this.btnEight.Size = new System.Drawing.Size(50, 50);
            this.btnEight.TabIndex = 6;
            this.btnEight.Tag = "7";
            this.btnEight.Text = "8";
            this.btnEight.UseVisualStyleBackColor = true;
            // 
            // btnTen
            // 
            this.btnTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTen.Location = new System.Drawing.Point(189, 77);
            this.btnTen.Name = "btnTen";
            this.btnTen.Size = new System.Drawing.Size(50, 50);
            this.btnTen.TabIndex = 3;
            this.btnTen.Tag = "9";
            this.btnTen.Text = "10";
            this.btnTen.UseVisualStyleBackColor = true;
            // 
            // btnFour
            // 
            this.btnFour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFour.Location = new System.Drawing.Point(133, 21);
            this.btnFour.Name = "btnFour";
            this.btnFour.Size = new System.Drawing.Size(50, 50);
            this.btnFour.TabIndex = 5;
            this.btnFour.Tag = "3";
            this.btnFour.Text = "4";
            this.btnFour.UseVisualStyleBackColor = true;
            // 
            // btnFive
            // 
            this.btnFive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFive.Location = new System.Drawing.Point(189, 21);
            this.btnFive.Name = "btnFive";
            this.btnFive.Size = new System.Drawing.Size(50, 50);
            this.btnFive.TabIndex = 2;
            this.btnFive.Tag = "4";
            this.btnFive.Text = "5";
            this.btnFive.UseVisualStyleBackColor = true;
            // 
            // btnNine
            // 
            this.btnNine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNine.Location = new System.Drawing.Point(133, 77);
            this.btnNine.Name = "btnNine";
            this.btnNine.Size = new System.Drawing.Size(50, 50);
            this.btnNine.TabIndex = 1;
            this.btnNine.Tag = "8";
            this.btnNine.Text = "9";
            this.btnNine.UseVisualStyleBackColor = true;
            // 
            // btnTwo
            // 
            this.btnTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTwo.Location = new System.Drawing.Point(17, 20);
            this.btnTwo.Name = "btnTwo";
            this.btnTwo.Size = new System.Drawing.Size(50, 50);
            this.btnTwo.TabIndex = 0;
            this.btnTwo.Tag = "1";
            this.btnTwo.Text = "2";
            this.btnTwo.UseVisualStyleBackColor = true;
            // 
            // gbPrices
            // 
            this.gbPrices.Controls.Add(this.btnAddCustomPrice);
            this.gbPrices.Controls.Add(this.txtCustomPrice);
            this.gbPrices.Controls.Add(this.flowLayout);
            this.gbPrices.Location = new System.Drawing.Point(6, 21);
            this.gbPrices.Name = "gbPrices";
            this.gbPrices.Size = new System.Drawing.Size(304, 356);
            this.gbPrices.TabIndex = 0;
            this.gbPrices.TabStop = false;
            this.gbPrices.Text = "Tarieven";
            // 
            // btnAddCustomPrice
            // 
            this.btnAddCustomPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomPrice.Location = new System.Drawing.Point(166, 310);
            this.btnAddCustomPrice.Name = "btnAddCustomPrice";
            this.btnAddCustomPrice.Size = new System.Drawing.Size(132, 37);
            this.btnAddCustomPrice.TabIndex = 10;
            this.btnAddCustomPrice.Text = "Voeg toe";
            this.btnAddCustomPrice.UseVisualStyleBackColor = true;
            this.btnAddCustomPrice.Click += new System.EventHandler(this.btnAddCustomPrice_Click);
            // 
            // txtCustomPrice
            // 
            this.txtCustomPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomPrice.Location = new System.Drawing.Point(6, 310);
            this.txtCustomPrice.Name = "txtCustomPrice";
            this.txtCustomPrice.Size = new System.Drawing.Size(154, 34);
            this.txtCustomPrice.TabIndex = 1;
            this.txtCustomPrice.TextChanged += new System.EventHandler(this.txtCustomPrice_TextChanged);
            this.txtCustomPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomPrice_KeyPress);
            // 
            // flowLayout
            // 
            this.flowLayout.Location = new System.Drawing.Point(6, 21);
            this.flowLayout.Name = "flowLayout";
            this.flowLayout.Size = new System.Drawing.Size(292, 283);
            this.flowLayout.TabIndex = 0;
            // 
            // dtpInputDate
            // 
            this.dtpInputDate.CustomFormat = "";
            this.dtpInputDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInputDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInputDate.Location = new System.Drawing.Point(522, 28);
            this.dtpInputDate.Name = "dtpInputDate";
            this.dtpInputDate.Size = new System.Drawing.Size(191, 30);
            this.dtpInputDate.TabIndex = 10;
            // 
            // gbControle
            // 
            this.gbControle.Controls.Add(this.btnControleVorige);
            this.gbControle.Controls.Add(this.btnControleNext);
            this.gbControle.Controls.Add(this.txtControlPrice);
            this.gbControle.Controls.Add(this.label1);
            this.gbControle.Controls.Add(this.txtControlQuantity);
            this.gbControle.Location = new System.Drawing.Point(318, 456);
            this.gbControle.Name = "gbControle";
            this.gbControle.Size = new System.Drawing.Size(310, 118);
            this.gbControle.TabIndex = 8;
            this.gbControle.TabStop = false;
            this.gbControle.Text = "Controle";
            // 
            // btnControleVorige
            // 
            this.btnControleVorige.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnControleVorige.Location = new System.Drawing.Point(12, 72);
            this.btnControleVorige.Name = "btnControleVorige";
            this.btnControleVorige.Size = new System.Drawing.Size(124, 35);
            this.btnControleVorige.TabIndex = 14;
            this.btnControleVorige.Text = "Vorige";
            this.btnControleVorige.UseVisualStyleBackColor = true;
            this.btnControleVorige.Click += new System.EventHandler(this.btnControleVorige_Click);
            // 
            // btnControleNext
            // 
            this.btnControleNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnControleNext.Location = new System.Drawing.Point(164, 72);
            this.btnControleNext.Name = "btnControleNext";
            this.btnControleNext.Size = new System.Drawing.Size(140, 35);
            this.btnControleNext.TabIndex = 12;
            this.btnControleNext.Text = "Volgende";
            this.btnControleNext.UseVisualStyleBackColor = true;
            this.btnControleNext.Click += new System.EventHandler(this.btnControleNext_Click);
            // 
            // txtControlPrice
            // 
            this.txtControlPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtControlPrice.Location = new System.Drawing.Point(164, 36);
            this.txtControlPrice.Name = "txtControlPrice";
            this.txtControlPrice.ReadOnly = true;
            this.txtControlPrice.Size = new System.Drawing.Size(140, 30);
            this.txtControlPrice.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "keer";
            // 
            // txtControlQuantity
            // 
            this.txtControlQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtControlQuantity.Location = new System.Drawing.Point(12, 36);
            this.txtControlQuantity.Name = "txtControlQuantity";
            this.txtControlQuantity.ReadOnly = true;
            this.txtControlQuantity.Size = new System.Drawing.Size(68, 30);
            this.txtControlQuantity.TabIndex = 12;
            // 
            // lblHuidigBlaadje
            // 
            this.lblHuidigBlaadje.AutoSize = true;
            this.lblHuidigBlaadje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHuidigBlaadje.Location = new System.Drawing.Point(758, 33);
            this.lblHuidigBlaadje.Name = "lblHuidigBlaadje";
            this.lblHuidigBlaadje.Size = new System.Drawing.Size(141, 25);
            this.lblHuidigBlaadje.TabIndex = 9;
            this.lblHuidigBlaadje.Text = "Huidig blaadje:";
            // 
            // lblCurrentSheet
            // 
            this.lblCurrentSheet.AutoSize = true;
            this.lblCurrentSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentSheet.Location = new System.Drawing.Point(894, 33);
            this.lblCurrentSheet.Name = "lblCurrentSheet";
            this.lblCurrentSheet.Size = new System.Drawing.Size(0, 25);
            this.lblCurrentSheet.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTotalByDate);
            this.groupBox1.Controls.Add(this.dtpTotalByDateFilter);
            this.groupBox1.Location = new System.Drawing.Point(634, 456);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 118);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Totaal per datum";
            // 
            // txtTotalByDate
            // 
            this.txtTotalByDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalByDate.Location = new System.Drawing.Point(6, 67);
            this.txtTotalByDate.Multiline = true;
            this.txtTotalByDate.Name = "txtTotalByDate";
            this.txtTotalByDate.ReadOnly = true;
            this.txtTotalByDate.Size = new System.Drawing.Size(298, 40);
            this.txtTotalByDate.TabIndex = 4;
            // 
            // dtpTotalByDateFilter
            // 
            this.dtpTotalByDateFilter.CustomFormat = "";
            this.dtpTotalByDateFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTotalByDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTotalByDateFilter.Location = new System.Drawing.Point(6, 31);
            this.dtpTotalByDateFilter.Name = "dtpTotalByDateFilter";
            this.dtpTotalByDateFilter.Size = new System.Drawing.Size(298, 30);
            this.dtpTotalByDateFilter.TabIndex = 11;
            this.dtpTotalByDateFilter.ValueChanged += new System.EventHandler(this.dtpTotalByDateFilter_ValueChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslXmlFilePath,
            this.sslStatusLabelNumberOfBooks});
            this.statusStrip1.Location = new System.Drawing.Point(0, 634);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(956, 25);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sslXmlFilePath
            // 
            this.sslXmlFilePath.Name = "sslXmlFilePath";
            this.sslXmlFilePath.Size = new System.Drawing.Size(143, 20);
            this.sslXmlFilePath.Text = "toolStripStatusLabel";
            // 
            // sslStatusLabelNumberOfBooks
            // 
            this.sslStatusLabelNumberOfBooks.Name = "sslStatusLabelNumberOfBooks";
            this.sslStatusLabelNumberOfBooks.Size = new System.Drawing.Size(798, 20);
            this.sslStatusLabelNumberOfBooks.Spring = true;
            this.sslStatusLabelNumberOfBooks.Text = "statusLabel";
            this.sslStatusLabelNumberOfBooks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(319, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Datum nieuw blaadje:";
            // 
            // cboBookNrs
            // 
            this.cboBookNrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBookNrs.FormattingEnabled = true;
            this.cboBookNrs.Location = new System.Drawing.Point(191, 16);
            this.cboBookNrs.Name = "cboBookNrs";
            this.cboBookNrs.Size = new System.Drawing.Size(113, 30);
            this.cboBookNrs.TabIndex = 14;
            this.cboBookNrs.SelectedIndexChanged += new System.EventHandler(this.CboBookNrs_SelectedIndexChanged);
            // 
            // gbNavigation
            // 
            this.gbNavigation.Controls.Add(this.label3);
            this.gbNavigation.Controls.Add(this.cboBookNrs);
            this.gbNavigation.Location = new System.Drawing.Point(634, 580);
            this.gbNavigation.Name = "gbNavigation";
            this.gbNavigation.Size = new System.Drawing.Size(310, 50);
            this.gbNavigation.TabIndex = 15;
            this.gbNavigation.TabStop = false;
            this.gbNavigation.Text = "Navigatie";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Ga naar boekje nr:";
            // 
            // frmBoekjes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 659);
            this.Controls.Add(this.gbNavigation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpInputDate);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCurrentSheet);
            this.Controls.Add(this.lblHuidigBlaadje);
            this.Controls.Add(this.gbControle);
            this.Controls.Add(this.gbInput);
            this.Controls.Add(this.gbSheetDetails);
            this.Controls.Add(this.gbBook);
            this.Controls.Add(this.txtBookNr);
            this.Controls.Add(this.lblBookNumber);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmBoekjes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boekjes :D";
            this.Load += new System.EventHandler(this.frmBoekjes_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbBook.ResumeLayout(false);
            this.gbBook.PerformLayout();
            this.gbSheetDetails.ResumeLayout(false);
            this.gbSheetDetails.PerformLayout();
            this.gbInput.ResumeLayout(false);
            this.gbQuantity.ResumeLayout(false);
            this.gbPrices.ResumeLayout(false);
            this.gbPrices.PerformLayout();
            this.gbControle.ResumeLayout(false);
            this.gbControle.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gbNavigation.ResumeLayout(false);
            this.gbNavigation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBookNumber;
        private System.Windows.Forms.TextBox txtBookNr;
        private System.Windows.Forms.ListBox lbSheets;
        private System.Windows.Forms.TextBox txtTotalInputs;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbBook;
        private System.Windows.Forms.GroupBox gbSheetDetails;
        private System.Windows.Forms.DateTimePicker dtpSheetDate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtSheetDetail;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.DateTimePicker dtpInputDate;
        private System.Windows.Forms.GroupBox gbQuantity;
        private System.Windows.Forms.Button btnSeven;
        private System.Windows.Forms.Button btnThree;
        private System.Windows.Forms.Button btnSix;
        private System.Windows.Forms.Button btnEight;
        private System.Windows.Forms.Button btnTen;
        private System.Windows.Forms.Button btnFour;
        private System.Windows.Forms.Button btnFive;
        private System.Windows.Forms.Button btnNine;
        private System.Windows.Forms.Button btnTwo;
        private System.Windows.Forms.GroupBox gbPrices;
        private System.Windows.Forms.FlowLayoutPanel flowLayout;
        private System.Windows.Forms.TextBox txtCustomPrice;
        private System.Windows.Forms.Button btnAddCustomPrice;
        private System.Windows.Forms.Label lblDetailsTarief;
        private System.Windows.Forms.Label lblDetailBoekjesNummer;
        private System.Windows.Forms.TextBox txtDetailBookNr;
        private System.Windows.Forms.GroupBox gbControle;
        private System.Windows.Forms.Button btnControleNext;
        private System.Windows.Forms.TextBox txtControlPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtControlQuantity;
        private System.Windows.Forms.Button btnControleVorige;
        private System.Windows.Forms.Label lblHuidigBlaadje;
        private System.Windows.Forms.Label lblCurrentSheet;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTotalByDate;
        private System.Windows.Forms.DateTimePicker dtpTotalByDateFilter;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sslXmlFilePath;
        private System.Windows.Forms.ToolStripStatusLabel sslStatusLabelNumberOfBooks;
        private System.Windows.Forms.ToolStripMenuItem btnNewBook;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem btnPrintCurrentBook;
        private System.Windows.Forms.ComboBox cboBookNrs;
        private System.Windows.Forms.GroupBox gbNavigation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem btnExportToExcelToolStripMenuItem;
    }
}

