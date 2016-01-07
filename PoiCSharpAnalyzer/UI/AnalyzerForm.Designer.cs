namespace PoiCSharpAnalyzer.UI
{
    partial class AnalyzerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalyzerForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.parseButton = new System.Windows.Forms.Button();
            this.parseTreeOutput = new System.Windows.Forms.TreeView();
            this.label4 = new System.Windows.Forms.Label();
            this.codeOutput = new System.Windows.Forms.TextBox();
            this.variableTypeListView = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.analyzerLog = new System.Windows.Forms.TextBox();
            this.buttonExpandCollapse = new System.Windows.Forms.Button();
            this.codeInput = new System.Windows.Forms.RichTextBox();
            this.codeInputLineNumbers = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.options = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 14F);
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(461, 45);
            this.label1.TabIndex = 2;
            this.label1.Text = "Poi Language Analyzer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F);
            this.label2.Location = new System.Drawing.Point(7, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Poi Source Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F);
            this.label3.Location = new System.Drawing.Point(388, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Parse Tree";
            // 
            // parseButton
            // 
            this.parseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.parseButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.parseButton.FlatAppearance.BorderSize = 2;
            this.parseButton.Font = new System.Drawing.Font("Consolas", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parseButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.parseButton.Location = new System.Drawing.Point(1059, 17);
            this.parseButton.Name = "parseButton";
            this.parseButton.Size = new System.Drawing.Size(210, 53);
            this.parseButton.TabIndex = 5;
            this.parseButton.Text = "Analyze Code";
            this.parseButton.UseVisualStyleBackColor = true;
            this.parseButton.Click += new System.EventHandler(this.parseButton_Click);
            // 
            // parseTreeOutput
            // 
            this.parseTreeOutput.Location = new System.Drawing.Point(393, 109);
            this.parseTreeOutput.Name = "parseTreeOutput";
            this.parseTreeOutput.Size = new System.Drawing.Size(445, 468);
            this.parseTreeOutput.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F);
            this.label4.Location = new System.Drawing.Point(7, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "JavaScript Code";
            // 
            // codeOutput
            // 
            this.codeOutput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.codeOutput.Location = new System.Drawing.Point(12, 359);
            this.codeOutput.Multiline = true;
            this.codeOutput.Name = "codeOutput";
            this.codeOutput.ReadOnly = true;
            this.codeOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.codeOutput.Size = new System.Drawing.Size(373, 218);
            this.codeOutput.TabIndex = 7;
            // 
            // variableTypeListView
            // 
            this.variableTypeListView.Location = new System.Drawing.Point(846, 109);
            this.variableTypeListView.Name = "variableTypeListView";
            this.variableTypeListView.Size = new System.Drawing.Size(237, 468);
            this.variableTypeListView.TabIndex = 9;
            this.variableTypeListView.UseCompatibleStateImageBehavior = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 9F);
            this.label5.Location = new System.Drawing.Point(846, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(220, 28);
            this.label5.TabIndex = 10;
            this.label5.Text = "Type Information";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 9F);
            this.label6.Location = new System.Drawing.Point(7, 585);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 28);
            this.label6.TabIndex = 11;
            this.label6.Text = "Analyzer Log";
            // 
            // analyzerLog
            // 
            this.analyzerLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.analyzerLog.Location = new System.Drawing.Point(12, 619);
            this.analyzerLog.Multiline = true;
            this.analyzerLog.Name = "analyzerLog";
            this.analyzerLog.ReadOnly = true;
            this.analyzerLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.analyzerLog.Size = new System.Drawing.Size(1257, 102);
            this.analyzerLog.TabIndex = 12;
            // 
            // buttonExpandCollapse
            // 
            this.buttonExpandCollapse.Enabled = false;
            this.buttonExpandCollapse.Font = new System.Drawing.Font("Consolas", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExpandCollapse.Location = new System.Drawing.Point(638, 73);
            this.buttonExpandCollapse.Name = "buttonExpandCollapse";
            this.buttonExpandCollapse.Size = new System.Drawing.Size(200, 30);
            this.buttonExpandCollapse.TabIndex = 13;
            this.buttonExpandCollapse.Text = "Expand/Collapse";
            this.buttonExpandCollapse.UseVisualStyleBackColor = true;
            this.buttonExpandCollapse.Click += new System.EventHandler(this.buttonExpandCollapse_Click);
            // 
            // codeInput
            // 
            this.codeInput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeInput.Location = new System.Drawing.Point(40, 109);
            this.codeInput.Name = "codeInput";
            this.codeInput.Size = new System.Drawing.Size(345, 218);
            this.codeInput.TabIndex = 17;
            this.codeInput.Text = "";
            this.codeInput.VScroll += new System.EventHandler(this.codeInput_VScroll);
            this.codeInput.FontChanged += new System.EventHandler(this.codeInput_FontChanged);
            this.codeInput.TextChanged += new System.EventHandler(this.codeInput_TextChanged);
            this.codeInput.Resize += new System.EventHandler(this.codeInput_Resize);
            // 
            // codeInputLineNumbers
            // 
            this.codeInputLineNumbers.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeInputLineNumbers.Location = new System.Drawing.Point(12, 109);
            this.codeInputLineNumbers.Name = "codeInputLineNumbers";
            this.codeInputLineNumbers.ReadOnly = true;
            this.codeInputLineNumbers.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.codeInputLineNumbers.Size = new System.Drawing.Size(28, 218);
            this.codeInputLineNumbers.TabIndex = 18;
            this.codeInputLineNumbers.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 9F);
            this.label7.Location = new System.Drawing.Point(1098, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 28);
            this.label7.TabIndex = 19;
            this.label7.Text = "Options";
            // 
            // options
            // 
            this.options.FormattingEnabled = true;
            this.options.Items.AddRange(new object[] {
            "Generate Parsetree",
            "Enable TypeChecking"});
            this.options.Location = new System.Drawing.Point(1103, 109);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(166, 484);
            this.options.TabIndex = 20;
            // 
            // AnalyzerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1312, 731);
            this.Controls.Add(this.options);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.codeInputLineNumbers);
            this.Controls.Add(this.codeInput);
            this.Controls.Add(this.buttonExpandCollapse);
            this.Controls.Add(this.analyzerLog);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.variableTypeListView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.codeOutput);
            this.Controls.Add(this.parseTreeOutput);
            this.Controls.Add(this.parseButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnalyzerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AnalyzerForm";
            this.Load += new System.EventHandler(this.AnalyzerForm_Load);
            this.SizeChanged += new System.EventHandler(this.AnalyzerForm_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button parseButton;
        private System.Windows.Forms.TreeView parseTreeOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox codeOutput;
        private System.Windows.Forms.ListView variableTypeListView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox analyzerLog;
        private System.Windows.Forms.Button buttonExpandCollapse;
        private System.Windows.Forms.RichTextBox codeInput;
        private System.Windows.Forms.RichTextBox codeInputLineNumbers;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox options;
    }
}