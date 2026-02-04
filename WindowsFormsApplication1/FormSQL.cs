using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityJustWorks.SQL;

namespace ValToCSV
{
    public partial class FormSQL : Form
    {
        public FormSQL()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = string.Empty;

                if (string.IsNullOrWhiteSpace(txtValues.Text))
                {
                    txtResult.Text = string.Empty;
                    lblMessage.Text = "No input provided.";
                    return;
                }

                List<List<string>> rows = TsvParser.Parse(txtValues.Text);
                rows = rows.Where(row => row.Any(cell => !string.IsNullOrWhiteSpace(cell))).ToList();

                if (rows.Count < 2)
                {
                    txtResult.Text = string.Empty;
                    lblMessage.Text = "Input needs a table name row and a header row.";
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

                txtResult.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                txtResult.Text = string.Empty;
                lblMessage.Text = $"Error: {ex.Message}";
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtResult.Text);
            lblMessage.Text = "Copied..";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            lblMessage.Text = "Cleared..";

        }
    }

    public static class SqlHelper
    {
        public static string InsertInto(DataTable Table)
        {
            if (!Helper.IsValidDatatable(Table))
                return string.Empty;
            string columnsString = Helper.TableToColumnsString(Table);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (DataRow row in (InternalDataCollectionBase)Table.Rows)
            {
                if (row != null && row.ItemArray.Length >= 1)
                {
                    string valueString = Helper.RowToValueString(row);

                    if (!string.IsNullOrWhiteSpace(columnsString))
                    //if (!string.IsNullOrWhiteSpace(columnsString) && !string.IsNullOrWhiteSpace(valueString))
                    {
                        if (string.IsNullOrWhiteSpace(valueString))
                        {
                            valueString = "('')";
                        }

                        stringBuilder.AppendFormat("INSERT INTO {0} {1} VALUES {2};\r\n", (object)Table.TableName,
                            (object)columnsString, (object)valueString);

                        //stringBuilder.Append(string.Format(" {0}", (object)columnsString));
                        //stringBuilder.Append("VALUES");
                        //stringBuilder.Append(string.Format("   {0}", (object)valueString));
                    }
                }
            }

            return stringBuilder.ToString();
        }

        public static string CreateTable<T>(params T[] ClassObjects) where T : class
        {
            return SqlHelper.CreateTable(Table.FromClassInstanceCollection<T>(ClassObjects));
        }

        public static string CreateTable(DataTable Table)
        {
            if (!Helper.IsValidDatatable(Table, true))
                return string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format("DECLARE {0} TABLE (", (object)Table.TableName));
            stringBuilder.Append("   ");
            bool flag = true;
            foreach (DataColumn dataColumn in Table.Columns.OfType<DataColumn>())
            {
                if (flag)
                    flag = false;
                else
                    stringBuilder.Append("   ,");
                stringBuilder.AppendLine(string.Format("[{0}] {1} {2}", (object)dataColumn.ColumnName,
                    (object)SqlHelper.GetSQLTypeAsString(dataColumn.DataType),
                    dataColumn.AllowDBNull ? (object)"NULL" : (object)"NOT NULL"));
            }

            stringBuilder.AppendLine("); ");
            //stringBuilder.AppendLine(") ON [PRIMARY]");
            //stringBuilder.AppendLine("GO");
            if (Table.PrimaryKey.Length != 0)
                stringBuilder.Append(SqlHelper.BuildKeysScript(Table));
            return stringBuilder.ToString();
        }

        private static string BuildKeysScript(DataTable Table)
        {
            if (Table.PrimaryKey.Length < 1)
                return string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            if (Table.PrimaryKey.Length == 1)
            {
                stringBuilder.AppendLine(string.Format("ALTER TABLE {0}", (object)Table.TableName));
                stringBuilder.AppendLine(string.Format("ADD PRIMARY KEY ({0})",
                    (object)Table.PrimaryKey[0].ColumnName));
            }
            else
            {
                List<string> list = Table.PrimaryKey.OfType<DataColumn>()
                    .Select<DataColumn, string>((System.Func<DataColumn, string>)(dc => dc.ColumnName))
                    .ToList<string>();
                string str1 = list.Aggregate<string>((Func<string, string, string>)((a, b) => a + b));
                string str2 =
                    list.Aggregate<string>((Func<string, string, string>)((a, b) =>
                        string.Format("{0}, {1}", (object)a, (object)b)));
                stringBuilder.AppendLine(string.Format("ALTER TABLE {0}", (object)Table.TableName));
                stringBuilder.AppendLine(string.Format("ADD CONSTRAINT pk_{0} PRIMARY KEY ({1})", (object)str1,
                    (object)str2));
            }

            stringBuilder.AppendLine("GO");
            return stringBuilder.ToString();
        }

        private static string GetSQLTypeAsString(Type DataType)
        {
            switch (DataType.Name)
            {
                case "Boolean":
                    return "[bit]";
                case "Byte":
                    return "[tinyint] UNSIGNED";
                case "Char":
                    return "[char]";
                case "DateTime":
                    return "[datetime]";
                case "Decimal":
                    return "[decimal]";
                case "Double":
                    return "[double]";
                case "Guid":
                    return "[uniqueidentifier]";
                case "Int16":
                    return "[smallint]";
                case "Int32":
                    return "[int]";
                case "Int64":
                    return "[bigint]";
                case "Object":
                    return "[variant]";
                case "SByte":
                    return "[tinyint]";
                case "Single":
                    return "[float]";
                case "String":
                    return "[nvarchar](250)";
                case "UInt16":
                    return "[smallint] UNSIGNED";
                case "UInt32":
                    return "[int] UNSIGNED";
                case "UInt64":
                    return "[bigint] UNSIGNED";
                default:
                    return "[nvarchar](MAX)";
            }
        }

        public static class StoredProcedure
        {
            public static string Insert(DataTable Table)
            {
                return SqlHelper.StoredProcedure.GenerateStoredProcedure(Table,
                    SqlHelper.StoredProcedure.GenerateInsertInto(Table));
            }

            public static string Update(DataTable Table, string WhereClause)
            {
                return SqlHelper.StoredProcedure.GenerateStoredProcedure(Table,
                    SqlHelper.StoredProcedure.GenerateUpdate(Table, WhereClause));
            }

            private static string GenerateStoredProcedure(DataTable Table, string Body)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("USE [{DatabaseName}]");
                stringBuilder.AppendLine("GO");
                stringBuilder.AppendLine("CREATE PROCEDURE [dbo].[{StoredProcedureName}]");
                stringBuilder.AppendLine("(");
                stringBuilder.AppendLine(SqlHelper.StoredProcedure.GenerateParameterList(Table));
                stringBuilder.AppendLine(")");
                stringBuilder.AppendLine("AS");
                stringBuilder.AppendLine("BEGIN");
                stringBuilder.AppendLine(Body);
                stringBuilder.AppendLine("END");
                return stringBuilder.ToString();
            }

            public static string GenerateParameterList(DataTable Table)
            {
                if (!Helper.IsValidDatatable(Table))
                    return string.Empty;
                StringBuilder stringBuilder = new StringBuilder();
                foreach (DataColumn column in (InternalDataCollectionBase)Table.Columns)
                {
                    if (stringBuilder.Length != 0)
                        stringBuilder.Append("\n\t,");
                    stringBuilder.AppendFormat("@{0} {1}", (object)column.ColumnName,
                        (object)SqlHelper.GetSQLTypeAsString(column.DataType));
                    stringBuilder.AppendLine();
                }

                stringBuilder.Insert(0, '\t');
                return stringBuilder.ToString();
            }

            private static string GenerateInsertInto(DataTable Table)
            {
                IEnumerable<string> source1 = Table.Columns.OfType<DataColumn>()
                    .Select<DataColumn, string>((System.Func<DataColumn, string>)(col => col.ColumnName));
                IEnumerable<object> source2 =
                    ((IEnumerable<object>)source1).Select<object, object>(
                        (System.Func<object, object>)(col => (object)string.Format("@{0}", col)));
                DataTable Table1 = new DataTable(Table.TableName);
                foreach (string columnName in (IEnumerable<object>)source1)
                    Table1.Columns.Add(columnName, typeof(string));
                DataRow row = Table1.NewRow();
                row.ItemArray = source2.ToArray<object>();
                Table1.Rows.Add(row);
                return SqlHelper.InsertInto(Table1).Replace("'", "");
            }

            private static string GenerateUpdate(DataTable Table, string WhereClause)
            {
                if (!Helper.IsValidDatatable(Table))
                    return string.Empty;
                IEnumerable<string> strings = Table.Columns.OfType<DataColumn>()
                    .Select<DataColumn, string>((System.Func<DataColumn, string>)(col => col.ColumnName));
                StringBuilder stringBuilder = new StringBuilder();
                foreach (string str in strings)
                {
                    if (stringBuilder.Length != 0)
                        stringBuilder.Append("\t,");
                    stringBuilder.AppendLine(string.Format("[{0}] = @{1}", (object)str, (object)str));
                }

                stringBuilder.Insert(0, "\t");
                stringBuilder.Insert(0, Environment.NewLine);
                stringBuilder.Insert(0, "SET");
                stringBuilder.Insert(0, Environment.NewLine);
                stringBuilder.Insert(0, string.Format("UPDATE [{0}]", (object)Table.TableName));
                stringBuilder.AppendLine("WHERE");
                stringBuilder.AppendLine(string.Format("\t{0}", (object)WhereClause));
                return stringBuilder.ToString();
            }
        }
    }

    internal static class TsvParser
    {
        public static List<List<string>> Parse(string input)
        {
            var rows = new List<List<string>>();
            var currentRow = new List<string>();
            var currentField = new StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];

                if (ch == '"')
                {
                    if (inQuotes)
                    {
                        if (i + 1 < input.Length && input[i + 1] == '"')
                        {
                            currentField.Append('"');
                            i++;
                        }
                        else
                        {
                            inQuotes = false;
                        }
                    }
                    else
                    {
                        inQuotes = true;
                    }

                    continue;
                }

                if (!inQuotes)
                {
                    if (ch == '\t')
                    {
                        currentRow.Add(currentField.ToString());
                        currentField.Clear();
                        continue;
                    }

                    if (ch == '\r' || ch == '\n')
                    {
                        currentRow.Add(currentField.ToString());
                        currentField.Clear();
                        rows.Add(currentRow);
                        currentRow = new List<string>();

                        if (ch == '\r' && i + 1 < input.Length && input[i + 1] == '\n')
                        {
                            i++;
                        }

                        continue;
                    }
                }

                currentField.Append(ch);
            }

            currentRow.Add(currentField.ToString());

            bool hasContent = currentRow.Any(cell => !string.IsNullOrWhiteSpace(cell));
            if (hasContent || rows.Count > 0)
            {
                rows.Add(currentRow);
            }

            return rows;
        }
    }

    internal static class SqlInputBuilder
    {
        public static string BuildTableName(IReadOnlyList<string> tableNameRow)
        {
            string tableName = string.Join(" ", tableNameRow.Select(cell => cell.Trim()))
                .Replace('\u0009', ' ')
                .Trim();

            return string.IsNullOrWhiteSpace(tableName) ? "Data" : tableName;
        }

        public static List<string> BuildColumnNames(IReadOnlyList<string> headerCells, int totalColumns)
        {
            var names = new List<string>(totalColumns);
            var used = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < totalColumns; i++)
            {
                string raw = i < headerCells.Count ? headerCells[i] : string.Empty;
                string candidate = NormalizeColumnName(raw, i + 1);

                if (used.TryGetValue(candidate, out int count))
                {
                    count++;
                    used[candidate] = count;
                    candidate = $"{candidate}_{count}";
                }
                else
                {
                    used[candidate] = 1;
                }

                names.Add(candidate);
            }

            return names;
        }

        private static string NormalizeColumnName(string rawName, int index)
        {
            string name = (rawName ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                return $"Column{index}";
            }

            return name;
        }

        public static bool RowIsEmpty(IReadOnlyList<string> row)
        {
            for (int i = 0; i < row.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(row[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
