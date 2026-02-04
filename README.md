# Data-to-SQL Utility

A lightweight Windows desktop tool that bridges the gap between spreadsheets and SQL queries. It is a life-saver for anyone who spends too much time manually massaging data between Excel and a database. Use it to quickly format `WHERE IN` lists or generate bulk `INSERT` statements without dealing with ODBC drivers or heavyweight database GUIs.

## Core Features

1. SQL List Formatter
   Transform a column of raw data into a database-ready string. Copy a column from Excel or a SQL result set and convert it into a comma-separated list.

   Input: A raw column of values.

   Output: `('value1', 'value2', 'value3')`

   Use Case: Perfect for quickly building `SELECT * FROM table WHERE id IN (...)` queries.

1. Excel-to-SQL Insert Wizard
   Convert spreadsheet data directly into valid `INSERT` commands. The tool generates raw SQL that works in any environment (optimized for MySQL).

## How to Use the Insert Wizard

To ensure the wizard generates your queries correctly, your pasted data must follow this 3-part structure:

1. Line 1: The table name only
1. Line 2: A tab-separated list of field names (copy directly from your Excel header row)
1. Line 3+: Your tab-separated data rows

Example Input:

```plaintext
apple
types	color	size
golden	yellow's my favorite colour	large
mac	reddish	medium
```

Generated Output:

```sql
INSERT INTO apple (types, color, size) VALUES ('golden', 'yellow\'s my favorite colour', 'large');
INSERT INTO apple (types, color, size) VALUES ('mac', 'reddish', 'medium');
```

## Important Limitations

- Universal Quoting: Every field value is wrapped in quotes for compatibility. You may need to adjust numeric or boolean columns depending on your database.
- Date Handling: Native date formatting is not currently supported.
- Escaping: Basic escaping is handled (such as single quotes), but always review generated SQL before running it against production data.
