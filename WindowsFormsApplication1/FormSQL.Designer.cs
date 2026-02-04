using System.ComponentModel;
using System.Windows.Forms;

namespace ValToCSV
{
    partial class FormSQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSQL));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtValues = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(250, 1177);
            this.btnClear.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(200, 55);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtValues
            // 
            this.txtValues.Location = new System.Drawing.Point(34, 34);
            this.txtValues.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtValues.MaxLength = 100000000;
            this.txtValues.Multiline = true;
            this.txtValues.Name = "txtValues";
            this.txtValues.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtValues.Size = new System.Drawing.Size(2246, 247);
            this.txtValues.TabIndex = 2;
            this.txtValues.Text = resources.GetString("txtValues.Text");
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(34, 461);
            this.txtResult.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtResult.MaxLength = 100000000;
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(2246, 685);
            this.txtResult.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "Result:";
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(34, 307);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(200, 55);
            this.btnProcess.TabIndex = 7;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(34, 1177);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(200, 55);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(530, 831);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 32);
            this.lblMessage.TabIndex = 9;
            // 
            // FormSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2341, 1295);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtValues);
            this.Controls.Add(this.btnClear);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "FormSQL";
            this.Text = "Excel to SQL";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Button btnClear;
        private TextBox txtValues;
        private TextBox txtResult;
        private Label label1;
        private Button btnProcess;
        private Button btnCopy;
        private Label lblMessage;
    }
}