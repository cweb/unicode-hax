namespace TestUniMap
{
    partial class FormUniMapTest
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonGetBestfit = new System.Windows.Forms.Button();
            this.buttonGetUnicode = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.dataGridViewBestFit = new System.Windows.Forms.DataGridView();
            this.comboBoxCharsets = new System.Windows.Forms.ComboBox();
            this.labelCharsetCombo = new System.Windows.Forms.Label();
            this.labelInput = new System.Windows.Forms.Label();
            this.comboBoxTransformations = new System.Windows.Forms.ComboBox();
            this.textBoxUnicharProps = new System.Windows.Forms.TextBox();
            this.labelTransformCombo = new System.Windows.Forms.Label();
            this.labelResultsAsString = new System.Windows.Forms.Label();
            this.labelResultsAsGrid = new System.Windows.Forms.Label();
            this.labelSpecialCharacters = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBestFit)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxInput
            // 
            this.textBoxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInput.Location = new System.Drawing.Point(7, 52);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(100, 38);
            this.textBoxInput.TabIndex = 0;
            this.textBoxInput.TextChanged += new System.EventHandler(this.textBoxInput_TextChanged);
            // 
            // buttonGetBestfit
            // 
            this.buttonGetBestfit.Location = new System.Drawing.Point(7, 160);
            this.buttonGetBestfit.Name = "buttonGetBestfit";
            this.buttonGetBestfit.Size = new System.Drawing.Size(75, 43);
            this.buttonGetBestfit.TabIndex = 1;
            this.buttonGetBestfit.Text = "Get Bestfit Equivalents";
            this.buttonGetBestfit.UseVisualStyleBackColor = true;
            this.buttonGetBestfit.Click += new System.EventHandler(this.buttonGetBestfit_Click);
            // 
            // buttonGetUnicode
            // 
            this.buttonGetUnicode.Location = new System.Drawing.Point(7, 268);
            this.buttonGetUnicode.Name = "buttonGetUnicode";
            this.buttonGetUnicode.Size = new System.Drawing.Size(75, 39);
            this.buttonGetUnicode.TabIndex = 2;
            this.buttonGetUnicode.Text = "Get Unicode Transforms";
            this.buttonGetUnicode.UseVisualStyleBackColor = true;
            this.buttonGetUnicode.Click += new System.EventHandler(this.buttonGetUnicode_Click);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(332, 32);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(154, 368);
            this.textBoxOutput.TabIndex = 3;
            this.textBoxOutput.TextChanged += new System.EventHandler(this.textBoxOutput_TextChanged);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStatus.ForeColor = System.Drawing.SystemColors.Highlight;
            this.textBoxStatus.Location = new System.Drawing.Point(144, 12);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(155, 118);
            this.textBoxStatus.TabIndex = 5;
            this.textBoxStatus.TextChanged += new System.EventHandler(this.textBoxStatus_TextChanged);
            // 
            // dataGridViewBestFit
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBestFit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewBestFit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBestFit.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewBestFit.Location = new System.Drawing.Point(492, 32);
            this.dataGridViewBestFit.Name = "dataGridViewBestFit";
            this.dataGridViewBestFit.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBestFit.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewBestFit.Size = new System.Drawing.Size(570, 368);
            this.dataGridViewBestFit.TabIndex = 6;
            this.dataGridViewBestFit.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBestFit_CellContentClick);
            // 
            // comboBoxCharsets
            // 
            this.comboBoxCharsets.FormattingEnabled = true;
            this.comboBoxCharsets.Location = new System.Drawing.Point(7, 133);
            this.comboBoxCharsets.Name = "comboBoxCharsets";
            this.comboBoxCharsets.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCharsets.TabIndex = 7;
            this.comboBoxCharsets.SelectedIndexChanged += new System.EventHandler(this.comboBoxCharsets_SelectedIndexChanged);
            // 
            // labelCharsetCombo
            // 
            this.labelCharsetCombo.AutoSize = true;
            this.labelCharsetCombo.Location = new System.Drawing.Point(6, 117);
            this.labelCharsetCombo.Name = "labelCharsetCombo";
            this.labelCharsetCombo.Size = new System.Drawing.Size(117, 13);
            this.labelCharsetCombo.TabIndex = 8;
            this.labelCharsetCombo.Text = "Filter results by charset:";
            this.labelCharsetCombo.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(6, 13);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(85, 26);
            this.labelInput.TabIndex = 9;
            this.labelInput.Text = "Enter a single \r\nASCII character:";
            this.labelInput.Click += new System.EventHandler(this.labelInput_Click);
            // 
            // comboBoxTransformations
            // 
            this.comboBoxTransformations.FormattingEnabled = true;
            this.comboBoxTransformations.Location = new System.Drawing.Point(7, 237);
            this.comboBoxTransformations.Name = "comboBoxTransformations";
            this.comboBoxTransformations.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTransformations.TabIndex = 10;
            this.comboBoxTransformations.SelectedIndexChanged += new System.EventHandler(this.comboBoxTransformations_SelectedIndexChanged);
            // 
            // textBoxUnicharProps
            // 
            this.textBoxUnicharProps.Location = new System.Drawing.Point(182, 172);
            this.textBoxUnicharProps.Multiline = true;
            this.textBoxUnicharProps.Name = "textBoxUnicharProps";
            this.textBoxUnicharProps.ReadOnly = true;
            this.textBoxUnicharProps.Size = new System.Drawing.Size(100, 130);
            this.textBoxUnicharProps.TabIndex = 11;
            this.textBoxUnicharProps.TextChanged += new System.EventHandler(this.textBoxUnicharProps_TextChanged);
            // 
            // labelTransformCombo
            // 
            this.labelTransformCombo.AutoSize = true;
            this.labelTransformCombo.Location = new System.Drawing.Point(4, 221);
            this.labelTransformCombo.Name = "labelTransformCombo";
            this.labelTransformCombo.Size = new System.Drawing.Size(148, 13);
            this.labelTransformCombo.TabIndex = 12;
            this.labelTransformCombo.Text = "Filter results by transformation:";
            // 
            // labelResultsAsString
            // 
            this.labelResultsAsString.AutoSize = true;
            this.labelResultsAsString.Location = new System.Drawing.Point(333, 13);
            this.labelResultsAsString.Name = "labelResultsAsString";
            this.labelResultsAsString.Size = new System.Drawing.Size(96, 13);
            this.labelResultsAsString.TabIndex = 13;
            this.labelResultsAsString.Text = "Results as a string:";
            // 
            // labelResultsAsGrid
            // 
            this.labelResultsAsGrid.AutoSize = true;
            this.labelResultsAsGrid.Location = new System.Drawing.Point(492, 12);
            this.labelResultsAsGrid.Name = "labelResultsAsGrid";
            this.labelResultsAsGrid.Size = new System.Drawing.Size(116, 13);
            this.labelResultsAsGrid.TabIndex = 14;
            this.labelResultsAsGrid.Text = "Results as a Data Grid:";
            // 
            // labelSpecialCharacters
            // 
            this.labelSpecialCharacters.AutoSize = true;
            this.labelSpecialCharacters.Location = new System.Drawing.Point(182, 153);
            this.labelSpecialCharacters.Name = "labelSpecialCharacters";
            this.labelSpecialCharacters.Size = new System.Drawing.Size(99, 13);
            this.labelSpecialCharacters.TabIndex = 15;
            this.labelSpecialCharacters.Text = "Special Characters:";
            // 
            // FormUniMapTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 623);
            this.Controls.Add(this.labelSpecialCharacters);
            this.Controls.Add(this.labelResultsAsGrid);
            this.Controls.Add(this.labelResultsAsString);
            this.Controls.Add(this.labelTransformCombo);
            this.Controls.Add(this.textBoxUnicharProps);
            this.Controls.Add(this.comboBoxTransformations);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.labelCharsetCombo);
            this.Controls.Add(this.comboBoxCharsets);
            this.Controls.Add(this.dataGridViewBestFit);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.buttonGetUnicode);
            this.Controls.Add(this.buttonGetBestfit);
            this.Controls.Add(this.textBoxInput);
            this.Name = "FormUniMapTest";
            this.Text = "Get Unicode and Bestfit Mappings";
            this.Load += new System.EventHandler(this.FormUniMapTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBestFit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonGetBestfit;
        private System.Windows.Forms.Button buttonGetUnicode;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.DataGridView dataGridViewBestFit;
        private System.Windows.Forms.ComboBox comboBoxCharsets;
        private System.Windows.Forms.Label labelCharsetCombo;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.ComboBox comboBoxTransformations;
        private System.Windows.Forms.TextBox textBoxUnicharProps;
        private System.Windows.Forms.Label labelTransformCombo;
        private System.Windows.Forms.Label labelResultsAsString;
        private System.Windows.Forms.Label labelResultsAsGrid;
        private System.Windows.Forms.Label labelSpecialCharacters;
    }
}

