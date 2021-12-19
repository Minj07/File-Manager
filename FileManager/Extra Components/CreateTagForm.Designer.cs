namespace FileManager
{
    partial class CreateTagForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnColor = new FileManager.RoundedButton();
            this.TxtBoxName = new System.Windows.Forms.TextBox();
            this.LblName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.BtnColor, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtBoxName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LblName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.BtnOk, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(332, 262);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BtnColor
            // 
            this.BtnColor.ActivatedColor = System.Drawing.Color.Empty;
            this.BtnColor.BorderColor = System.Drawing.SystemColors.Control;
            this.BtnColor.BorderSize = 2F;
            this.BtnColor.CornerRadius = 15;
            this.BtnColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnColor.HoverColor = System.Drawing.SystemColors.Control;
            this.BtnColor.Location = new System.Drawing.Point(79, 120);
            this.BtnColor.Margin = new System.Windows.Forms.Padding(30, 16, 30, 16);
            this.BtnColor.Name = "BtnColor";
            this.BtnColor.Size = new System.Drawing.Size(172, 20);
            this.BtnColor.TabIndex = 0;
            this.BtnColor.Text = "Choose Color";
            this.BtnColor.UseVisualStyleBackColor = true;
            this.BtnColor.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // TxtBoxName
            // 
            this.TxtBoxName.BackColor = this.BackColor;
            this.TxtBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBoxName.Location = new System.Drawing.Point(71, 68);
            this.TxtBoxName.Margin = new System.Windows.Forms.Padding(22, 16, 22, 16);
            this.TxtBoxName.Name = "TxtBoxName";
            this.TxtBoxName.Size = new System.Drawing.Size(188, 23);
            this.TxtBoxName.TabIndex = 1;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.BackColor = this.BackColor;
            this.LblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblName.ForeColor = System.Drawing.Color.Black;
            this.LblName.Location = new System.Drawing.Point(51, 0);
            this.LblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(228, 52);
            this.LblName.TabIndex = 2;
            this.LblName.Text = "Tag Name:";
            this.LblName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(71, 224);
            this.button1.Margin = new System.Windows.Forms.Padding(22, 16, 22, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 22);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.Color.Lime;
            this.BtnOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnOk.Location = new System.Drawing.Point(71, 172);
            this.BtnOk.Margin = new System.Windows.Forms.Padding(22, 16, 22, 16);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(188, 20);
            this.BtnOk.TabIndex = 4;
            this.BtnOk.Text = "Create";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.button2_Click);
            // 
            // CreateTagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 262);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CreateTagForm";
            this.Text = "CreateTagForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public RoundedButton BtnColor;
        public System.Windows.Forms.TextBox TxtBoxName;
        public System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button BtnOk;
    }
}