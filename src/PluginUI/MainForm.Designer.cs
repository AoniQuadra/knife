namespace PluginUI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BuildButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SwordLengthTextBox = new System.Windows.Forms.TextBox();
            this.BladeLengthTextBox = new System.Windows.Forms.TextBox();
            this.BladeThiklessTextBox = new System.Windows.Forms.TextBox();
            this.GuardWidhtTextBox = new System.Windows.Forms.TextBox();
            this.HandleDiameterTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.HandleLenghtWithGuardTextBox = new System.Windows.Forms.TextBox();
            this.WaveguideParametersPictureBox = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WaveguideParametersPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(277, 305);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(82, 23);
            this.BuildButton.TabIndex = 0;
            this.BuildButton.Text = "BUILD";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.63977F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.36023F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.SwordLengthTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BladeLengthTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.BladeThiklessTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.GuardWidhtTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.HandleDiameterTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.HandleLenghtWithGuardTextBox, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(25, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(334, 271);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sword Lenght (1000-1500 mm)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Blade Lenght (700-1000 mm) ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Blade Thikless (5-15 mm)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Handle Lenght With Guard (175-250 mm)";
            // 
            // SwordLengthTextBox
            // 
            this.SwordLengthTextBox.Location = new System.Drawing.Point(252, 3);
            this.SwordLengthTextBox.Name = "SwordLengthTextBox";
            this.SwordLengthTextBox.Size = new System.Drawing.Size(79, 20);
            this.SwordLengthTextBox.TabIndex = 6;
            this.SwordLengthTextBox.Text = "1000";
            this.SwordLengthTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // BladeLengthTextBox
            // 
            this.BladeLengthTextBox.Location = new System.Drawing.Point(252, 48);
            this.BladeLengthTextBox.Name = "BladeLengthTextBox";
            this.BladeLengthTextBox.Size = new System.Drawing.Size(79, 20);
            this.BladeLengthTextBox.TabIndex = 7;
            this.BladeLengthTextBox.Text = "700";
            this.BladeLengthTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // BladeThiklessTextBox
            // 
            this.BladeThiklessTextBox.Location = new System.Drawing.Point(252, 93);
            this.BladeThiklessTextBox.Name = "BladeThiklessTextBox";
            this.BladeThiklessTextBox.Size = new System.Drawing.Size(79, 20);
            this.BladeThiklessTextBox.TabIndex = 8;
            this.BladeThiklessTextBox.Text = "10";
            this.BladeThiklessTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // GuardWidhtTextBox
            // 
            this.GuardWidhtTextBox.Location = new System.Drawing.Point(252, 138);
            this.GuardWidhtTextBox.Name = "GuardWidhtTextBox";
            this.GuardWidhtTextBox.Size = new System.Drawing.Size(79, 20);
            this.GuardWidhtTextBox.TabIndex = 9;
            this.GuardWidhtTextBox.Text = "200";
            this.GuardWidhtTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // HandleDiameterTextBox
            // 
            this.HandleDiameterTextBox.Location = new System.Drawing.Point(252, 183);
            this.HandleDiameterTextBox.Name = "HandleDiameterTextBox";
            this.HandleDiameterTextBox.Size = new System.Drawing.Size(79, 20);
            this.HandleDiameterTextBox.TabIndex = 10;
            this.HandleDiameterTextBox.Text = "10";
            this.HandleDiameterTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Guard Widht (200 - 300 мм)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Handle Diameter (10-30 mm)";
            // 
            // HandleLenghtWithGuardTextBox
            // 
            this.HandleLenghtWithGuardTextBox.Location = new System.Drawing.Point(252, 228);
            this.HandleLenghtWithGuardTextBox.Name = "HandleLenghtWithGuardTextBox";
            this.HandleLenghtWithGuardTextBox.Size = new System.Drawing.Size(79, 20);
            this.HandleLenghtWithGuardTextBox.TabIndex = 11;
            this.HandleLenghtWithGuardTextBox.Text = "175";
            this.HandleLenghtWithGuardTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // WaveguideParametersPictureBox
            // 
            this.WaveguideParametersPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("WaveguideParametersPictureBox.Image")));
            this.WaveguideParametersPictureBox.Location = new System.Drawing.Point(377, 28);
            this.WaveguideParametersPictureBox.Name = "WaveguideParametersPictureBox";
            this.WaveguideParametersPictureBox.Size = new System.Drawing.Size(151, 300);
            this.WaveguideParametersPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.WaveguideParametersPictureBox.TabIndex = 65;
            this.WaveguideParametersPictureBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 340);
            this.Controls.Add(this.WaveguideParametersPictureBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.BuildButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sword building in KOMPAS-3D";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WaveguideParametersPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox SwordLengthTextBox;
        private System.Windows.Forms.TextBox BladeLengthTextBox;
        private System.Windows.Forms.TextBox BladeThiklessTextBox;
        private System.Windows.Forms.TextBox GuardWidhtTextBox;
        private System.Windows.Forms.TextBox HandleDiameterTextBox;
        private System.Windows.Forms.TextBox HandleLenghtWithGuardTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox WaveguideParametersPictureBox;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

