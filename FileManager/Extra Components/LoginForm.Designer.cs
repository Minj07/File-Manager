namespace FileManager
{
    partial class LoginForm
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
            this.MainTable = new System.Windows.Forms.TableLayoutPanel();
            this.UsernameTable = new System.Windows.Forms.TableLayoutPanel();
            this.TxtBxUsername = new System.Windows.Forms.TextBox();
            this.LbUsername = new System.Windows.Forms.Label();
            this.PasswordTable = new System.Windows.Forms.TableLayoutPanel();
            this.LbPassword = new System.Windows.Forms.Label();
            this.TxtBxPassword = new System.Windows.Forms.TextBox();
            this.ButtonsTable = new System.Windows.Forms.TableLayoutPanel();
            this.BtnSignUp = new System.Windows.Forms.Button();
            this.BtnLogIn = new System.Windows.Forms.Button();
            this.OuterLeftEdge = new System.Windows.Forms.Panel();
            this.OuterBottomEdge = new System.Windows.Forms.Panel();
            this.OuterTablePanel.SuspendLayout();
            this.MainTablePanel.SuspendLayout();
            this.HeaderTablePanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.MainTable.SuspendLayout();
            this.UsernameTable.SuspendLayout();
            this.PasswordTable.SuspendLayout();
            this.ButtonsTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // OuterTablePanel
            // 
            this.OuterTablePanel.BackColor = System.Drawing.Color.Transparent;
            this.OuterTablePanel.BorderColor = System.Drawing.Color.Empty;
            this.OuterTablePanel.ColumnCount = 3;
            this.OuterTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.OuterTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OuterTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.OuterTablePanel.Controls.Add(this.MainTablePanel, 1, 0);
            this.OuterTablePanel.Controls.Add(this.OuterLeftEdge, 0, 0);
            this.OuterTablePanel.Controls.Add(this.OuterBottomEdge, 1, 1);
            this.OuterTablePanel.CornerRadius = 40;
            this.OuterTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OuterTablePanel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.OuterTablePanel.Location = new System.Drawing.Point(0, 0);
            this.OuterTablePanel.Margin = new System.Windows.Forms.Padding(4);
            this.OuterTablePanel.Name = "OuterTablePanel";
            this.OuterTablePanel.Rounded = true;
            this.OuterTablePanel.RowCount = 2;
            this.OuterTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OuterTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.OuterTablePanel.Size = new System.Drawing.Size(423, 367);
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
            this.MainTablePanel.Location = new System.Drawing.Point(4, 0);
            this.MainTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTablePanel.Name = "MainTablePanel";
            this.MainTablePanel.RowCount = 3;
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTablePanel.Size = new System.Drawing.Size(415, 363);
            this.MainTablePanel.TabIndex = 0;
            // 
            // HeaderTablePanel
            // 
            this.HeaderTablePanel.ColumnCount = 6;
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
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
            this.HeaderTablePanel.Size = new System.Drawing.Size(415, 30);
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
            this.BtnExit.Location = new System.Drawing.Point(12, 7);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(2, 7, 2, 7);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(16, 16);
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
            this.BtnMinimize.Location = new System.Drawing.Point(32, 7);
            this.BtnMinimize.Margin = new System.Windows.Forms.Padding(2, 7, 2, 7);
            this.BtnMinimize.Name = "BtnMinimize";
            this.BtnMinimize.Size = new System.Drawing.Size(16, 16);
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
            this.BtnMaximize.Location = new System.Drawing.Point(52, 7);
            this.BtnMaximize.Margin = new System.Windows.Forms.Padding(2, 7, 2, 7);
            this.BtnMaximize.Name = "BtnMaximize";
            this.BtnMaximize.Size = new System.Drawing.Size(16, 16);
            this.BtnMaximize.TabIndex = 2;
            this.BtnMaximize.UseVisualStyleBackColor = false;
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbTitle.Enabled = false;
            this.LbTitle.Location = new System.Drawing.Point(72, 0);
            this.LbTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(278, 30);
            this.LbTitle.TabIndex = 3;
            this.LbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Controls.Add(this.MainTable);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 32);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(415, 331);
            this.MainPanel.TabIndex = 6;
            // 
            // MainTable
            // 
            this.MainTable.ColumnCount = 1;
            this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.MainTable.Controls.Add(this.UsernameTable, 0, 1);
            this.MainTable.Controls.Add(this.PasswordTable, 0, 2);
            this.MainTable.Controls.Add(this.ButtonsTable, 0, 3);
            this.MainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTable.Location = new System.Drawing.Point(0, 0);
            this.MainTable.Margin = new System.Windows.Forms.Padding(2);
            this.MainTable.Name = "MainTable";
            this.MainTable.RowCount = 4;
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.MainTable.Size = new System.Drawing.Size(415, 331);
            this.MainTable.TabIndex = 0;
            // 
            // UsernameTable
            // 
            this.UsernameTable.ColumnCount = 1;
            this.UsernameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.UsernameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.UsernameTable.Controls.Add(this.TxtBxUsername, 0, 1);
            this.UsernameTable.Controls.Add(this.LbUsername, 0, 0);
            this.UsernameTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsernameTable.Location = new System.Drawing.Point(0, 82);
            this.UsernameTable.Margin = new System.Windows.Forms.Padding(0);
            this.UsernameTable.Name = "UsernameTable";
            this.UsernameTable.RowCount = 2;
            this.UsernameTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.UsernameTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.UsernameTable.Size = new System.Drawing.Size(415, 82);
            this.UsernameTable.TabIndex = 0;
            // 
            // TxtBxUsername
            // 
            this.TxtBxUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtBxUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtBxUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtBxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxUsername.Location = new System.Drawing.Point(22, 41);
            this.TxtBxUsername.Margin = new System.Windows.Forms.Padding(22, 0, 22, 0);
            this.TxtBxUsername.Name = "TxtBxUsername";
            this.TxtBxUsername.Size = new System.Drawing.Size(371, 19);
            this.TxtBxUsername.TabIndex = 0;
            // 
            // LbUsername
            // 
            this.LbUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LbUsername.AutoSize = true;
            this.LbUsername.Location = new System.Drawing.Point(22, 20);
            this.LbUsername.Margin = new System.Windows.Forms.Padding(22, 0, 22, 8);
            this.LbUsername.Name = "LbUsername";
            this.LbUsername.Size = new System.Drawing.Size(58, 13);
            this.LbUsername.TabIndex = 1;
            this.LbUsername.Text = "Username:";
            // 
            // PasswordTable
            // 
            this.PasswordTable.ColumnCount = 1;
            this.PasswordTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PasswordTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.PasswordTable.Controls.Add(this.LbPassword, 0, 0);
            this.PasswordTable.Controls.Add(this.TxtBxPassword, 0, 1);
            this.PasswordTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PasswordTable.Location = new System.Drawing.Point(0, 164);
            this.PasswordTable.Margin = new System.Windows.Forms.Padding(0);
            this.PasswordTable.Name = "PasswordTable";
            this.PasswordTable.RowCount = 2;
            this.PasswordTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PasswordTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PasswordTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.PasswordTable.Size = new System.Drawing.Size(415, 82);
            this.PasswordTable.TabIndex = 1;
            // 
            // LbPassword
            // 
            this.LbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LbPassword.AutoSize = true;
            this.LbPassword.Location = new System.Drawing.Point(22, 20);
            this.LbPassword.Margin = new System.Windows.Forms.Padding(22, 0, 22, 8);
            this.LbPassword.Name = "LbPassword";
            this.LbPassword.Size = new System.Drawing.Size(56, 13);
            this.LbPassword.TabIndex = 2;
            this.LbPassword.Text = "Password:";
            // 
            // TxtBxPassword
            // 
            this.TxtBxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtBxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtBxPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtBxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxPassword.Location = new System.Drawing.Point(22, 41);
            this.TxtBxPassword.Margin = new System.Windows.Forms.Padding(22, 0, 22, 0);
            this.TxtBxPassword.Name = "TxtBxPassword";
            this.TxtBxPassword.PasswordChar = '*';
            this.TxtBxPassword.Size = new System.Drawing.Size(371, 19);
            this.TxtBxPassword.TabIndex = 1;
            // 
            // ButtonsTable
            // 
            this.ButtonsTable.ColumnCount = 2;
            this.ButtonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonsTable.Controls.Add(this.BtnSignUp, 1, 0);
            this.ButtonsTable.Controls.Add(this.BtnLogIn, 0, 0);
            this.ButtonsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonsTable.Location = new System.Drawing.Point(0, 246);
            this.ButtonsTable.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonsTable.Name = "ButtonsTable";
            this.ButtonsTable.RowCount = 1;
            this.ButtonsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.ButtonsTable.Size = new System.Drawing.Size(415, 85);
            this.ButtonsTable.TabIndex = 2;
            // 
            // BtnSignUp
            // 
            this.BtnSignUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSignUp.Location = new System.Drawing.Point(252, 16);
            this.BtnSignUp.Margin = new System.Windows.Forms.Padding(45, 16, 45, 16);
            this.BtnSignUp.Name = "BtnSignUp";
            this.BtnSignUp.Size = new System.Drawing.Size(118, 53);
            this.BtnSignUp.TabIndex = 1;
            this.BtnSignUp.Text = "Make new account";
            this.BtnSignUp.UseVisualStyleBackColor = true;
            this.BtnSignUp.Click += new System.EventHandler(this.BtnSignUp_Click);
            // 
            // BtnLogIn
            // 
            this.BtnLogIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogIn.Location = new System.Drawing.Point(45, 16);
            this.BtnLogIn.Margin = new System.Windows.Forms.Padding(45, 16, 45, 16);
            this.BtnLogIn.Name = "BtnLogIn";
            this.BtnLogIn.Size = new System.Drawing.Size(117, 53);
            this.BtnLogIn.TabIndex = 0;
            this.BtnLogIn.Text = "Log in";
            this.BtnLogIn.UseVisualStyleBackColor = true;
            this.BtnLogIn.Click += new System.EventHandler(this.BtnLogIn_Click);
            // 
            // OuterLeftEdge
            // 
            this.OuterLeftEdge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OuterLeftEdge.Location = new System.Drawing.Point(0, 0);
            this.OuterLeftEdge.Margin = new System.Windows.Forms.Padding(0);
            this.OuterLeftEdge.Name = "OuterLeftEdge";
            this.OuterLeftEdge.Size = new System.Drawing.Size(4, 363);
            this.OuterLeftEdge.TabIndex = 1;
            // 
            // OuterBottomEdge
            // 
            this.OuterBottomEdge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OuterBottomEdge.Location = new System.Drawing.Point(4, 363);
            this.OuterBottomEdge.Margin = new System.Windows.Forms.Padding(0);
            this.OuterBottomEdge.Name = "OuterBottomEdge";
            this.OuterBottomEdge.Size = new System.Drawing.Size(415, 4);
            this.OuterBottomEdge.TabIndex = 2;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 367);
            this.Controls.Add(this.OuterTablePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.OuterTablePanel.ResumeLayout(false);
            this.MainTablePanel.ResumeLayout(false);
            this.HeaderTablePanel.ResumeLayout(false);
            this.HeaderTablePanel.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.MainTable.ResumeLayout(false);
            this.UsernameTable.ResumeLayout(false);
            this.UsernameTable.PerformLayout();
            this.PasswordTable.ResumeLayout(false);
            this.PasswordTable.PerformLayout();
            this.ButtonsTable.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel MainTable;
        private System.Windows.Forms.TableLayoutPanel UsernameTable;
        private System.Windows.Forms.TextBox TxtBxUsername;
        private System.Windows.Forms.TableLayoutPanel PasswordTable;
        private System.Windows.Forms.TextBox TxtBxPassword;
        private System.Windows.Forms.Label LbUsername;
        private System.Windows.Forms.Label LbPassword;
        private System.Windows.Forms.TableLayoutPanel ButtonsTable;
        private System.Windows.Forms.Button BtnSignUp;
        private System.Windows.Forms.Button BtnLogIn;
    }
}