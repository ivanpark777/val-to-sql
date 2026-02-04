using System.ComponentModel;
using System.Windows.Forms;

namespace ValToCSV
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabCsvToSql = new System.Windows.Forms.TabPage();
            this.txtValues = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.cbDelimiter = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabExcelToSql = new System.Windows.Forms.TabPage();
            this.lblExcelMessage = new System.Windows.Forms.Label();
            this.btnExcelCopy = new System.Windows.Forms.Button();
            this.btnExcelProcess = new System.Windows.Forms.Button();
            this.lblExcelResult = new System.Windows.Forms.Label();
            this.txtExcelResult = new System.Windows.Forms.TextBox();
            this.txtExcelValues = new System.Windows.Forms.TextBox();
            this.btnExcelClearInput = new System.Windows.Forms.Button();
            this.btnExcelClearResult = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.tabCsvToSql.SuspendLayout();
            this.tabExcelToSql.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabCsvToSql);
            this.tabMain.Controls.Add(this.tabExcelToSql);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1620, 913);
            this.tabMain.TabIndex = 0;
            // 
            // tabCsvToSql
            // 
            this.tabCsvToSql.Controls.Add(this.txtValues);
            this.tabCsvToSql.Controls.Add(this.txtResult);
            this.tabCsvToSql.Controls.Add(this.btnGenerate);
            this.tabCsvToSql.Controls.Add(this.lblMessage);
            this.tabCsvToSql.Controls.Add(this.btnClear);
            this.tabCsvToSql.Controls.Add(this.cbDelimiter);
            this.tabCsvToSql.Controls.Add(this.linkLabel1);
            this.tabCsvToSql.Controls.Add(this.label1);
            this.tabCsvToSql.Location = new System.Drawing.Point(8, 46);
            this.tabCsvToSql.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabCsvToSql.Name = "tabCsvToSql";
            this.tabCsvToSql.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabCsvToSql.Size = new System.Drawing.Size(1604, 859);
            this.tabCsvToSql.TabIndex = 0;
            this.tabCsvToSql.Text = "CSV TO SQL";
            this.tabCsvToSql.UseVisualStyleBackColor = true;
            // 
            // txtValues
            // 
            this.txtValues.Location = new System.Drawing.Point(27, 126);
            this.txtValues.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtValues.MaxLength = 100000000;
            this.txtValues.Multiline = true;
            this.txtValues.Name = "txtValues";
            this.txtValues.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtValues.Size = new System.Drawing.Size(1525, 247);
            this.txtValues.TabIndex = 1;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(27, 532);
            this.txtResult.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtResult.MaxLength = 100000000;
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(1525, 321);
            this.txtResult.TabIndex = 4;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(24, 393);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(323, 55);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Process";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(29, 823);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 32);
            this.lblMessage.TabIndex = 5;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(403, 393);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(235, 55);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear values";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cbDelimiter
            // 
            this.cbDelimiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDelimiter.FormattingEnabled = true;
            this.cbDelimiter.Items.AddRange(new object[] {
            "String",
            "Integer",
            "StringSharp"});
            this.cbDelimiter.Location = new System.Drawing.Point(338, 36);
            this.cbDelimiter.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cbDelimiter.Name = "cbDelimiter";
            this.cbDelimiter.Size = new System.Drawing.Size(316, 39);
            this.cbDelimiter.TabIndex = 10;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(1524, 54);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(28, 32);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "x";
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 46);
            this.label1.TabIndex = 15;
            this.label1.Text = "CONVERTER";
            // 
            // tabExcelToSql
            // 
            this.tabExcelToSql.Controls.Add(this.lblExcelMessage);
            this.tabExcelToSql.Controls.Add(this.btnExcelCopy);
            this.tabExcelToSql.Controls.Add(this.btnExcelProcess);
            this.tabExcelToSql.Controls.Add(this.lblExcelResult);
            this.tabExcelToSql.Controls.Add(this.txtExcelResult);
            this.tabExcelToSql.Controls.Add(this.txtExcelValues);
            this.tabExcelToSql.Controls.Add(this.btnExcelClearResult);
            this.tabExcelToSql.Controls.Add(this.btnExcelClearInput);
            this.tabExcelToSql.Location = new System.Drawing.Point(8, 46);
            this.tabExcelToSql.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabExcelToSql.Name = "tabExcelToSql";
            this.tabExcelToSql.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabExcelToSql.Size = new System.Drawing.Size(1604, 859);
            this.tabExcelToSql.TabIndex = 1;
            this.tabExcelToSql.Text = "EXCEL TO SQL";
            this.tabExcelToSql.UseVisualStyleBackColor = true;
            // 
            // lblExcelMessage
            // 
            this.lblExcelMessage.AutoSize = true;
            this.lblExcelMessage.ForeColor = System.Drawing.Color.Red;
            this.lblExcelMessage.Location = new System.Drawing.Point(530, 831);
            this.lblExcelMessage.Name = "lblExcelMessage";
            this.lblExcelMessage.Size = new System.Drawing.Size(0, 32);
            this.lblExcelMessage.TabIndex = 16;
            // 
            // btnExcelCopy
            // 
            this.btnExcelCopy.Location = new System.Drawing.Point(34, 789);
            this.btnExcelCopy.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnExcelCopy.Name = "btnExcelCopy";
            this.btnExcelCopy.Size = new System.Drawing.Size(200, 55);
            this.btnExcelCopy.TabIndex = 15;
            this.btnExcelCopy.Text = "Copy";
            this.btnExcelCopy.UseVisualStyleBackColor = true;
            this.btnExcelCopy.Click += new System.EventHandler(this.btnExcelCopy_Click);
            // 
            // btnExcelProcess
            // 
            this.btnExcelProcess.Location = new System.Drawing.Point(34, 307);
            this.btnExcelProcess.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnExcelProcess.Name = "btnExcelProcess";
            this.btnExcelProcess.Size = new System.Drawing.Size(200, 55);
            this.btnExcelProcess.TabIndex = 14;
            this.btnExcelProcess.Text = "Process";
            this.btnExcelProcess.UseVisualStyleBackColor = true;
            this.btnExcelProcess.Click += new System.EventHandler(this.btnExcelProcess_Click);
            // 
            // lblExcelResult
            // 
            this.lblExcelResult.AutoSize = true;
            this.lblExcelResult.Location = new System.Drawing.Point(38, 422);
            this.lblExcelResult.Name = "lblExcelResult";
            this.lblExcelResult.Size = new System.Drawing.Size(103, 32);
            this.lblExcelResult.TabIndex = 13;
            this.lblExcelResult.Text = "Result:";
            // 
            // txtExcelResult
            // 
            this.txtExcelResult.Location = new System.Drawing.Point(34, 461);
            this.txtExcelResult.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtExcelResult.MaxLength = 100000000;
            this.txtExcelResult.Multiline = true;
            this.txtExcelResult.Name = "txtExcelResult";
            this.txtExcelResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtExcelResult.Size = new System.Drawing.Size(1525, 306);
            this.txtExcelResult.TabIndex = 12;
            // 
            // txtExcelValues
            // 
            this.txtExcelValues.Location = new System.Drawing.Point(34, 34);
            this.txtExcelValues.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtExcelValues.MaxLength = 100000000;
            this.txtExcelValues.Multiline = true;
            this.txtExcelValues.Name = "txtExcelValues";
            this.txtExcelValues.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExcelValues.Size = new System.Drawing.Size(1525, 247);
            this.txtExcelValues.TabIndex = 11;
            this.txtExcelValues.Text = resources.GetString("txtExcelValues.Text");
            // 
            // btnExcelClearInput
            // 
            this.btnExcelClearInput.Location = new System.Drawing.Point(250, 789);
            this.btnExcelClearInput.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnExcelClearInput.Name = "btnExcelClearInput";
            this.btnExcelClearInput.Size = new System.Drawing.Size(200, 55);
            this.btnExcelClearInput.TabIndex = 10;
            this.btnExcelClearInput.Text = "Clear Input";
            this.btnExcelClearInput.UseVisualStyleBackColor = true;
            this.btnExcelClearInput.Click += new System.EventHandler(this.btnExcelClearInput_Click);
            // 
            // btnExcelClearResult
            // 
            this.btnExcelClearResult.Location = new System.Drawing.Point(466, 789);
            this.btnExcelClearResult.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnExcelClearResult.Name = "btnExcelClearResult";
            this.btnExcelClearResult.Size = new System.Drawing.Size(200, 55);
            this.btnExcelClearResult.TabIndex = 17;
            this.btnExcelClearResult.Text = "Clear Result";
            this.btnExcelClearResult.UseVisualStyleBackColor = true;
            this.btnExcelClearResult.Click += new System.EventHandler(this.btnExcelClearResult_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1620, 913);
            this.Controls.Add(this.tabMain);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "FormMain";
            this.Text = "Text to CSV for SQL";
            this.tabMain.ResumeLayout(false);
            this.tabCsvToSql.ResumeLayout(false);
            this.tabCsvToSql.PerformLayout();
            this.tabExcelToSql.ResumeLayout(false);
            this.tabExcelToSql.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabMain;
        private TabPage tabCsvToSql;
        private TabPage tabExcelToSql;
        private TextBox txtValues;
        private TextBox txtResult;
        private Button btnGenerate;
        private Label lblMessage;
        private Button btnClear;
        private ComboBox cbDelimiter;
        private LinkLabel linkLabel1;
        private Label label1;
        private Label lblExcelMessage;
        private Button btnExcelCopy;
        private Button btnExcelProcess;
        private Label lblExcelResult;
        private TextBox txtExcelResult;
        private TextBox txtExcelValues;
        private Button btnExcelClearInput;
        private Button btnExcelClearResult;
    }
}
