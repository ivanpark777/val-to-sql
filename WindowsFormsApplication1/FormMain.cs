using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ValToCSV
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtValues.Text))
            {
                string[] lines = txtValues.Text.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);
                StringType stringType = StringType.String;

                if (cbDelimiter.SelectedItem != null)
                {
                    var selected = cbDelimiter.SelectedItem.ToString();
                    if (selected == "Integer")
                        stringType = StringType.Number;
                    if (selected == "StringSharp")
                        stringType = StringType.StringSharp;
                }

                int n = 0;
                var sb = new StringBuilder();
                bool first = true;

                foreach (string val in lines)
                {
                    string trimmed = val.Trim();
                    if (trimmed.Length == 0)
                    {
                        continue;
                    }

                    if (!first)
                    {
                        sb.Append(',');
                    }

                    if (stringType == StringType.String)
                        sb.Append('\'').Append(trimmed).Append('\'');
                    else if (stringType == StringType.Number)
                        sb.Append(trimmed);
                    else if (stringType == StringType.StringSharp)
                        sb.Append('\"').Append(trimmed).Append('\"');

                    n++;
                    first = false;
                }

                lblMessage.Text = n.ToString();
                txtResult.Text = sb.ToString();
                txtResult.SelectAll();
                txtResult.Copy();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtValues.Text = string.Empty;
            txtResult.Text = string.Empty;
            lblMessage.Text = string.Empty;
        }

        private void btnCopyResult_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResult.Text))
            {
                lblMessage.Text = "Nothing to copy..";
            }
            else
            {
                Clipboard.SetText(txtResult.Text);
                lblMessage.Text = "Copied..";
            }
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            FormTest f = new FormTest();
            f.Show();
        }

        private void btnExcelProcess_Click(object sender, EventArgs e)
        {
            try
            {
                lblExcelMessage.Text = string.Empty;

                if (string.IsNullOrWhiteSpace(txtExcelValues.Text))
                {
                    txtExcelResult.Text = string.Empty;
                    lblExcelMessage.Text = "No input provided.";
                    return;
                }

                List<List<string>> rows = TsvParser.Parse(txtExcelValues.Text);
                rows = rows.Where(row => row.Any(cell => !string.IsNullOrWhiteSpace(cell))).ToList();

                if (rows.Count < 2)
                {
                    txtExcelResult.Text = string.Empty;
                    lblExcelMessage.Text = "Input needs a table name row and a header row.";
                    return;
                }

                string tableName = SqlInputBuilder.BuildTableName(rows[0]);
                List<string> headerCells = rows[1];

                int maxColumns = rows.Skip(1).Select(row => row.Count).DefaultIfEmpty(0).Max();
                List<string> columnNames = SqlInputBuilder.BuildColumnNames(headerCells, maxColumns);

                DataTable table = new DataTable(tableName);
                foreach (string name in columnNames)
                {
                    table.Columns.Add(new DataColumn(name, typeof(string)));
                }

                for (int i = 2; i < rows.Count; i++)
                {
                    if (SqlInputBuilder.RowIsEmpty(rows[i]))
                    {
                        continue;
                    }

                    DataRow dataRow = table.NewRow();
                    List<string> row = rows[i];

                    for (int colIndex = 0; colIndex < table.Columns.Count; colIndex++)
                    {
                        string value = colIndex < row.Count ? row[colIndex] : string.Empty;
                        dataRow[colIndex] = value ?? string.Empty;
                    }

                    table.Rows.Add(dataRow);
                }

                StringBuilder sb = new StringBuilder();
                sb.Append(SqlHelper.CreateTable(table));
                sb.AppendLine(SqlHelper.InsertInto(table));

                txtExcelResult.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                txtExcelResult.Text = string.Empty;
                lblExcelMessage.Text = $"Error: {ex.Message}";
            }
        }

        private void btnExcelCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtExcelResult.Text);
            lblExcelMessage.Text = "Copied..";
        }

        private void btnExcelClearInput_Click(object sender, EventArgs e)
        {
            txtExcelValues.Text = string.Empty;
            lblExcelMessage.Text = "Input cleared..";
        }

        private void btnExcelClearResult_Click(object sender, EventArgs e)
        {
            txtExcelResult.Text = "";
            lblExcelMessage.Text = "Result cleared..";
        }
    }

    public enum StringType
    {
        String,
        Number, StringSharp
    }
}
