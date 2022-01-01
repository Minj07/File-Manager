namespace FileManager
{
    partial class CustomForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        protected System.ComponentModel.IContainer components = null;

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
            this.OuterTablePanel = new FileManager.RoundedTablePanel();
            this.MainTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.HeaderTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.BtnExit = new FileManager.RoundedButton();
            this.BtnMinimize = new FileManager.RoundedButton();
            this.BtnMaximize = new FileManager.RoundedButton();
            this.LbTitle = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.OuterLeftEdge = new System.Windows.Forms.Panel();
            this.OuterBottomEdge = new System.Windows.Forms.Panel();
            this.OuterTablePanel.SuspendLayout();
            this.MainTablePanel.SuspendLayout();
            this.HeaderTablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // OuterTablePanel
            // 
            this.OuterTablePanel.BackColor = System.Drawing.Color.Transparent;
            this.OuterTablePanel.BorderColor = System.Drawing.Color.Empty;
            this.OuterTablePanel.ColumnCount = 3;
            this.OuterTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.OuterTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OuterTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.OuterTablePanel.Controls.Add(this.MainTablePanel, 1, 0);
            this.OuterTablePanel.Controls.Add(this.OuterLeftEdge, 0, 0);
            this.OuterTablePanel.Controls.Add(this.OuterBottomEdge, 1, 1);
            this.OuterTablePanel.CornerRadius = 40;
            this.OuterTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OuterTablePanel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.OuterTablePanel.Location = new System.Drawing.Point(0, 0);
            this.OuterTablePanel.Margin = new System.Windows.Forms.Padding(5);
            this.OuterTablePanel.Name = "OuterTablePanel";
            this.OuterTablePanel.Rounded = true;
            this.OuterTablePanel.RowCount = 2;
            this.OuterTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OuterTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.OuterTablePanel.Size = new System.Drawing.Size(545, 506);
            this.OuterTablePanel.TabIndex = 3;
            this.OuterTablePanel.TrueBackColor = System.Drawing.SystemColors.Control;
            // 
            // MainTablePanel
            // 
            this.MainTablePanel.ColumnCount = 1;
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTablePanel.Controls.Add(this.HeaderTablePanel, 0, 1);
            this.MainTablePanel.Controls.Add(this.MainPanel, 0, 2);
            this.MainTablePanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTablePanel.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MainTablePanel.Location = new System.Drawing.Point(5, 0);
            this.MainTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTablePanel.Name = "MainTablePanel";
            this.MainTablePanel.RowCount = 3;
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTablePanel.Size = new System.Drawing.Size(535, 501);
            this.MainTablePanel.TabIndex = 0;
            // 
            // HeaderTablePanel
            // 
            this.HeaderTablePanel.ColumnCount = 6;
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.HeaderTablePanel.Controls.Add(this.BtnExit, 1, 0);
            this.HeaderTablePanel.Controls.Add(this.BtnMinimize, 2, 0);
            this.HeaderTablePanel.Controls.Add(this.BtnMaximize, 3, 0);
            this.HeaderTablePanel.Controls.Add(this.LbTitle, 4, 0);
            this.HeaderTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeaderTablePanel.Location = new System.Drawing.Point(0, 2);
            this.HeaderTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.HeaderTablePanel.Name = "HeaderTablePanel";
            this.HeaderTablePanel.RowCount = 1;
            this.HeaderTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.HeaderTablePanel.Size = new System.Drawing.Size(535, 37);
            this.HeaderTablePanel.TabIndex = 5;
            // 
            // BtnExit
            // 
            this.BtnExit.ActivatedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(77)))), ((int)(((byte)(71)))));
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(87)))), ((int)(((byte)(84)))));
            this.BtnExit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(77)))), ((int)(((byte)(71)))));
            this.BtnExit.BorderSize = 1F;
            this.BtnExit.CornerRadius = 5;
            this.BtnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnExit.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnExit.Image = global::FileManager.Properties.Resources.close;
            this.BtnExit.Location = new System.Drawing.Point(16, 9);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(21, 19);
            this.BtnExit.TabIndex = 0;
            this.BtnExit.UseVisualStyleBackColor = false;
            // 
            // BtnMinimize
            // 
            this.BtnMinimize.ActivatedColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(161)))), ((int)(((byte)(69)))));
            this.BtnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(187)))), ((int)(((byte)(64)))));
            this.BtnMinimize.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(161)))), ((int)(((byte)(69)))));
            this.BtnMinimize.BorderSize = 1F;
            this.BtnMinimize.CornerRadius = 5;
            this.BtnMinimize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnMinimize.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(0)))));
            this.BtnMinimize.Image = global::FileManager.Properties.Resources.subtract;
            this.BtnMinimize.Location = new System.Drawing.Point(43, 9);
            this.BtnMinimize.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.BtnMinimize.Name = "BtnMinimize";
            this.BtnMinimize.Size = new System.Drawing.Size(21, 19);
            this.BtnMinimize.TabIndex = 1;
            this.BtnMinimize.UseVisualStyleBackColor = false;
            // 
            // BtnMaximize
            // 
            this.BtnMaximize.ActivatedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(166)))), ((int)(((byte)(75)))));
            this.BtnMaximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(71)))));
            this.BtnMaximize.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(166)))), ((int)(((byte)(75)))));
            this.BtnMaximize.BorderSize = 1F;
            this.BtnMaximize.CornerRadius = 5;
            this.BtnMaximize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnMaximize.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.BtnMaximize.Image = global::FileManager.Properties.Resources.maximize;
            this.BtnMaximize.Location = new System.Drawing.Point(70, 9);
            this.BtnMaximize.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.BtnMaximize.Name = "BtnMaximize";
            this.BtnMaximize.Size = new System.Drawing.Size(21, 19);
            this.BtnMaximize.TabIndex = 2;
            this.BtnMaximize.UseVisualStyleBackColor = false;
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbTitle.Enabled = false;
            this.LbTitle.Location = new System.Drawing.Point(97, 0);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(351, 37);
            this.LbTitle.TabIndex = 3;
            this.LbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 39);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(535, 462);
            this.MainPanel.TabIndex = 6;
            // 
            // OuterLeftEdge
            // 
            this.OuterLeftEdge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OuterLeftEdge.Location = new System.Drawing.Point(0, 0);
            this.OuterLeftEdge.Margin = new System.Windows.Forms.Padding(0);
            this.OuterLeftEdge.Name = "OuterLeftEdge";
            this.OuterLeftEdge.Size = new System.Drawing.Size(5, 501);
            this.OuterLeftEdge.TabIndex = 1;
            // 
            // OuterBottomEdge
            // 
            this.OuterBottomEdge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OuterBottomEdge.Location = new System.Drawing.Point(5, 501);
            this.OuterBottomEdge.Margin = new System.Windows.Forms.Padding(0);
            this.OuterBottomEdge.Name = "OuterBottomEdge";
            this.OuterBottomEdge.Size = new System.Drawing.Size(535, 5);
            this.OuterBottomEdge.TabIndex = 2;
            // 
            // CustomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 506);
            this.Controls.Add(this.OuterTablePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomForm";
            this.Text = "CustomForm";
            this.OuterTablePanel.ResumeLayout(false);
            this.MainTablePanel.ResumeLayout(false);
            this.HeaderTablePanel.ResumeLayout(false);
            this.HeaderTablePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected RoundedTablePanel OuterTablePanel;
        protected System.Windows.Forms.TableLayoutPanel MainTablePanel;
        protected System.Windows.Forms.TableLayoutPanel HeaderTablePanel;
        protected RoundedButton BtnExit;
        protected RoundedButton BtnMinimize;
        protected RoundedButton BtnMaximize;
        protected System.Windows.Forms.Label LbTitle;
        protected System.Windows.Forms.Panel OuterLeftEdge;
        protected System.Windows.Forms.Panel OuterBottomEdge;
        protected System.Windows.Forms.Panel MainPanel;
    }
}