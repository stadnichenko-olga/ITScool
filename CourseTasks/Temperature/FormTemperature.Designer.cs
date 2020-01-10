namespace Temperature
{
    partial class FormTemperature
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
            this.labelInitialTemperature = new System.Windows.Forms.Label();
            this.labelResultTemperature = new System.Windows.Forms.Label();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.comboBoxInitialScale = new System.Windows.Forms.ComboBox();
            this.labelInitialScale = new System.Windows.Forms.Label();
            this.labelResultScale = new System.Windows.Forms.Label();
            this.comboBoxResultScale = new System.Windows.Forms.ComboBox();
            this.boxInitialTemperature = new System.Windows.Forms.TextBox();
            this.boxResultTemperature = new System.Windows.Forms.TextBox();
            this.tableLayoutTemperature = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutTemperature.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInitialTemperature
            // 
            this.labelInitialTemperature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInitialTemperature.AutoSize = true;
            this.labelInitialTemperature.BackColor = System.Drawing.SystemColors.Control;
            this.labelInitialTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInitialTemperature.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelInitialTemperature.Location = new System.Drawing.Point(67, 25);
            this.labelInitialTemperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInitialTemperature.Name = "labelInitialTemperature";
            this.labelInitialTemperature.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelInitialTemperature.Size = new System.Drawing.Size(143, 20);
            this.labelInitialTemperature.TabIndex = 0;
            this.labelInitialTemperature.Text = "Initial temperature";
            this.labelInitialTemperature.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelResultTemperature
            // 
            this.labelResultTemperature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelResultTemperature.AutoSize = true;
            this.labelResultTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResultTemperature.Location = new System.Drawing.Point(58, 82);
            this.labelResultTemperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelResultTemperature.Name = "labelResultTemperature";
            this.labelResultTemperature.Size = new System.Drawing.Size(152, 20);
            this.labelResultTemperature.TabIndex = 1;
            this.labelResultTemperature.Text = "Result temperature";
            // 
            // buttonConvert
            // 
            this.buttonConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConvert.Location = new System.Drawing.Point(672, 143);
            this.buttonConvert.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(100, 28);
            this.buttonConvert.TabIndex = 2;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.ButtonConvert_Click);
            // 
            // comboBoxInitialScale
            // 
            this.comboBoxInitialScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInitialScale.FormattingEnabled = true;
            this.comboBoxInitialScale.Location = new System.Drawing.Point(592, 29);
            this.comboBoxInitialScale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxInitialScale.Name = "comboBoxInitialScale";
            this.comboBoxInitialScale.Size = new System.Drawing.Size(180, 24);
            this.comboBoxInitialScale.TabIndex = 3;
            this.comboBoxInitialScale.SelectedIndexChanged += new System.EventHandler(this.ComboBoxInitialScale_SelectedIndexChanged);
            // 
            // labelInitialScale
            // 
            this.labelInitialScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInitialScale.AutoSize = true;
            this.labelInitialScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInitialScale.Location = new System.Drawing.Point(491, 25);
            this.labelInitialScale.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInitialScale.Name = "labelInitialScale";
            this.labelInitialScale.Size = new System.Drawing.Size(93, 20);
            this.labelInitialScale.TabIndex = 4;
            this.labelInitialScale.Text = "Initial scale";
            // 
            // labelResultScale
            // 
            this.labelResultScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelResultScale.AutoSize = true;
            this.labelResultScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResultScale.Location = new System.Drawing.Point(482, 82);
            this.labelResultScale.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelResultScale.Name = "labelResultScale";
            this.labelResultScale.Size = new System.Drawing.Size(102, 20);
            this.labelResultScale.TabIndex = 5;
            this.labelResultScale.Text = "Result scale";
            // 
            // comboBoxResultScale
            // 
            this.comboBoxResultScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResultScale.FormattingEnabled = true;
            this.comboBoxResultScale.Location = new System.Drawing.Point(592, 86);
            this.comboBoxResultScale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxResultScale.Name = "comboBoxResultScale";
            this.comboBoxResultScale.Size = new System.Drawing.Size(180, 24);
            this.comboBoxResultScale.TabIndex = 6;
            this.comboBoxResultScale.SelectedIndexChanged += new System.EventHandler(this.ComboBoxResultScale_SelectedIndexChanged);
            // 
            // boxInitialTemperature
            // 
            this.boxInitialTemperature.Location = new System.Drawing.Point(218, 29);
            this.boxInitialTemperature.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.boxInitialTemperature.Name = "boxInitialTemperature";
            this.boxInitialTemperature.Size = new System.Drawing.Size(177, 22);
            this.boxInitialTemperature.TabIndex = 7;
            this.boxInitialTemperature.TextChanged += new System.EventHandler(this.BoxInitialTemperature_TextChanged);
            // 
            // boxResultTemperature
            // 
            this.boxResultTemperature.Location = new System.Drawing.Point(218, 86);
            this.boxResultTemperature.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.boxResultTemperature.Name = "boxResultTemperature";
            this.boxResultTemperature.ReadOnly = true;
            this.boxResultTemperature.Size = new System.Drawing.Size(177, 22);
            this.boxResultTemperature.TabIndex = 8;
            // 
            // tableLayoutTemperature
            // 
            this.tableLayoutTemperature.AutoSize = true;
            this.tableLayoutTemperature.ColumnCount = 4;
            this.tableLayoutTemperature.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutTemperature.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutTemperature.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutTemperature.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutTemperature.Controls.Add(this.labelInitialTemperature, 0, 0);
            this.tableLayoutTemperature.Controls.Add(this.comboBoxResultScale, 3, 1);
            this.tableLayoutTemperature.Controls.Add(this.boxResultTemperature, 1, 1);
            this.tableLayoutTemperature.Controls.Add(this.labelResultScale, 2, 1);
            this.tableLayoutTemperature.Controls.Add(this.boxInitialTemperature, 1, 0);
            this.tableLayoutTemperature.Controls.Add(this.comboBoxInitialScale, 3, 0);
            this.tableLayoutTemperature.Controls.Add(this.labelResultTemperature, 0, 1);
            this.tableLayoutTemperature.Controls.Add(this.labelInitialScale, 2, 0);
            this.tableLayoutTemperature.Controls.Add(this.buttonConvert, 3, 2);
            this.tableLayoutTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutTemperature.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutTemperature.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutTemperature.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutTemperature.Name = "tableLayoutTemperature";
            this.tableLayoutTemperature.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.tableLayoutTemperature.RowCount = 3;
            this.tableLayoutTemperature.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutTemperature.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutTemperature.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutTemperature.Size = new System.Drawing.Size(803, 201);
            this.tableLayoutTemperature.TabIndex = 9;
            // 
            // FormTemperature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 201);
            this.Controls.Add(this.tableLayoutTemperature);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(754, 180);
            this.Name = "FormTemperature";
            this.Text = "Temperature converter";
            this.Load += new System.EventHandler(this.FormTemperature_Load);
            this.tableLayoutTemperature.ResumeLayout(false);
            this.tableLayoutTemperature.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInitialTemperature;
        private System.Windows.Forms.Label labelResultTemperature;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.ComboBox comboBoxInitialScale;
        private System.Windows.Forms.Label labelInitialScale;
        private System.Windows.Forms.Label labelResultScale;
        private System.Windows.Forms.ComboBox comboBoxResultScale;
        private System.Windows.Forms.TextBox boxInitialTemperature;
        private System.Windows.Forms.TextBox boxResultTemperature;
        private System.Windows.Forms.TableLayoutPanel tableLayoutTemperature;
    }
}

