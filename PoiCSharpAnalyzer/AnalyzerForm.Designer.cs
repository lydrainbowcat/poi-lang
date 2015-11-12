namespace PoiCSharpAnalyzer
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
            this.codeInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.parseButton = new System.Windows.Forms.Button();
            this.parseTreeOutput = new System.Windows.Forms.TreeView();
            this.label4 = new System.Windows.Forms.Label();
            this.codeOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // codeInput
            // 
            this.codeInput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.codeInput.Location = new System.Drawing.Point(9, 82);
            this.codeInput.Margin = new System.Windows.Forms.Padding(2);
            this.codeInput.Multiline = true;
            this.codeInput.Name = "codeInput";
            this.codeInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.codeInput.Size = new System.Drawing.Size(430, 271);
            this.codeInput.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 14F);
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Poi Language Analyzer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F);
            this.label2.Location = new System.Drawing.Point(9, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Poi Source Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F);
            this.label3.Location = new System.Drawing.Point(449, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Parse Tree";
            // 
            // parseButton
            // 
            this.parseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.parseButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.parseButton.FlatAppearance.BorderSize = 2;
            this.parseButton.Font = new System.Drawing.Font("Consolas", 12F);
            this.parseButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.parseButton.Location = new System.Drawing.Point(970, 13);
            this.parseButton.Margin = new System.Windows.Forms.Padding(2);
            this.parseButton.Name = "parseButton";
            this.parseButton.Size = new System.Drawing.Size(197, 47);
            this.parseButton.TabIndex = 5;
            this.parseButton.Text = "Analyze Code";
            this.parseButton.UseVisualStyleBackColor = true;
            this.parseButton.Click += new System.EventHandler(this.parseButton_Click);
            // 
            // parseTreeOutput
            // 
            this.parseTreeOutput.Location = new System.Drawing.Point(450, 82);
            this.parseTreeOutput.Margin = new System.Windows.Forms.Padding(2);
            this.parseTreeOutput.Name = "parseTreeOutput";
            this.parseTreeOutput.Size = new System.Drawing.Size(720, 594);
            this.parseTreeOutput.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F);
            this.label4.Location = new System.Drawing.Point(9, 368);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "JavaScript Code";
            // 
            // codeOutput
            // 
            this.codeOutput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.codeOutput.Location = new System.Drawing.Point(9, 393);
            this.codeOutput.Margin = new System.Windows.Forms.Padding(2);
            this.codeOutput.Multiline = true;
            this.codeOutput.Name = "codeOutput";
            this.codeOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.codeOutput.Size = new System.Drawing.Size(430, 283);
            this.codeOutput.TabIndex = 7;
            // 
            // AnalyzerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1178, 687);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.codeOutput);
            this.Controls.Add(this.parseTreeOutput);
            this.Controls.Add(this.parseButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.codeInput);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AnalyzerForm";
            this.Text = "AnalyzerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox codeInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button parseButton;
        private System.Windows.Forms.TreeView parseTreeOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox codeOutput;
    }
}