﻿namespace Temperature
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
            this.labelInitialTemperature.AutoSize = true;
            this.labelInitialTemperature.Location = new System.Drawing.Point(3, 0);
            this.labelInitialTemperature.Name = "labelInitialTemperature";
            this.labelInitialTemperature.Size = new System.Drawing.Size(93, 13);
            this.labelInitialTemperature.TabIndex = 0;
            this.labelInitialTemperature.Text = "Temperature initial";
            // 
            // labelResultTemperature
            // 
            this.labelResultTemperature.AutoSize = true;
            this.labelResultTemperature.Location = new System.Drawing.Point(3, 49);
            this.labelResultTemperature.Name = "labelResultTemperature";
            this.labelResultTemperature.Size = new System.Drawing.Size(95, 13);
            this.labelResultTemperature.TabIndex = 1;
            this.labelResultTemperature.Text = "Temperature result";
            // 
            // buttonConvert
            // 
            this.buttonConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConvert.Location = new System.Drawing.Point(3, 101);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(75, 23);
            this.buttonConvert.TabIndex = 2;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // comboBoxInitialScale
            // 
            this.comboBoxInitialScale.FormattingEnabled = true;
            this.comboBoxInitialScale.Items.AddRange(new object[] {});
            this.comboBoxInitialScale.Location = new System.Drawing.Point(423, 3);
            this.comboBoxInitialScale.Name = "comboBoxInitialScale";
            this.comboBoxInitialScale.Size = new System.Drawing.Size(136, 21);
            this.comboBoxInitialScale.TabIndex = 3;
            this.comboBoxInitialScale.DropDown += new System.EventHandler(comboBoxInitialScale_DropDown);
            this.comboBoxInitialScale.SelectedIndexChanged += new System.EventHandler(this.comboBoxInitialScale_SelectedIndexChanged);
            // 
            // labelInitialScale
            // 
            this.labelInitialScale.AutoSize = true;
            this.labelInitialScale.Location = new System.Drawing.Point(283, 0);
            this.labelInitialScale.Name = "labelInitialScale";
            this.labelInitialScale.Size = new System.Drawing.Size(60, 13);
            this.labelInitialScale.TabIndex = 4;
            this.labelInitialScale.Text = "Scale initial";
            // 
            // labelResultScale
            // 
            this.labelResultScale.AutoSize = true;
            this.labelResultScale.Location = new System.Drawing.Point(283, 49);
            this.labelResultScale.Name = "labelResultScale";
            this.labelResultScale.Size = new System.Drawing.Size(62, 13);
            this.labelResultScale.TabIndex = 5;
            this.labelResultScale.Text = "Scale result";
            // 
            // comboBoxResultScale
            // 
            this.comboBoxResultScale.FormattingEnabled = true;
            this.comboBoxResultScale.Items.AddRange(new object[] {});
            this.comboBoxResultScale.Location = new System.Drawing.Point(423, 52);
            this.comboBoxResultScale.Name = "comboBoxResultScale";
            this.comboBoxResultScale.Size = new System.Drawing.Size(136, 21);
            this.comboBoxResultScale.TabIndex = 6;
            this.comboBoxResultScale.DropDown += new System.EventHandler(comboBoxResultScale_DropDown);
            this.comboBoxResultScale.SelectedIndexChanged += new System.EventHandler(this.comboBoxResultScale_SelectedIndexChanged);
            // 
            // boxInitialTemperature
            // 
            this.boxInitialTemperature.Location = new System.Drawing.Point(143, 3);
            this.boxInitialTemperature.Name = "boxInitialTemperature";
            this.boxInitialTemperature.Size = new System.Drawing.Size(134, 20);
            this.boxInitialTemperature.TabIndex = 7;
            this.boxInitialTemperature.TextChanged += new System.EventHandler(this.boxInitialTemperature_TextChanged);
            // 
            // boxResultTemperature
            // 
            this.boxResultTemperature.Location = new System.Drawing.Point(143, 52);
            this.boxResultTemperature.Name = "boxResultTemperature";
            this.boxResultTemperature.ReadOnly = true;
            this.boxResultTemperature.Size = new System.Drawing.Size(134, 20);
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
            this.tableLayoutTemperature.Controls.Add(this.buttonConvert, 0, 2);
            this.tableLayoutTemperature.Controls.Add(this.comboBoxResultScale, 3, 1);
            this.tableLayoutTemperature.Controls.Add(this.boxResultTemperature, 1, 1);
            this.tableLayoutTemperature.Controls.Add(this.labelResultScale, 2, 1);
            this.tableLayoutTemperature.Controls.Add(this.boxInitialTemperature, 1, 0);
            this.tableLayoutTemperature.Controls.Add(this.comboBoxInitialScale, 3, 0);
            this.tableLayoutTemperature.Controls.Add(this.labelInitialScale, 2, 0);
            this.tableLayoutTemperature.Controls.Add(this.labelResultTemperature, 0, 1);
            this.tableLayoutTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutTemperature.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutTemperature.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutTemperature.Name = "tableLayoutTemperature";
            this.tableLayoutTemperature.RowCount = 3;
            this.tableLayoutTemperature.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutTemperature.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutTemperature.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutTemperature.Size = new System.Drawing.Size(562, 128);
            this.tableLayoutTemperature.TabIndex = 9;
            // 
            // FormTemperature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 128);
            this.Controls.Add(this.tableLayoutTemperature);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(570, 155);
            this.Name = "FormTemperature";
            this.Text = "Temperature converter";
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

