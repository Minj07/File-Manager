namespace FileManager
{
    partial class AdminForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnToggleAdmin = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.SplitView = new System.Windows.Forms.SplitContainer();
            this.LsViewUsers = new FileManager.CustomListView();
            this.ColUID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LsViewActivites = new FileManager.CustomListView();
            this.ColAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColDestination = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OuterLeftEdge = new System.Windows.Forms.Panel();
            this.OuterBottomEdge = new System.Windows.Forms.Panel();
            this.OuterTablePanel.SuspendLayout();
            this.MainTablePanel.SuspendLayout();
            this.HeaderTablePanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitView)).BeginInit();
            this.SplitView.Panel1.SuspendLayout();
            this.SplitView.Panel2.SuspendLayout();
            this.SplitView.SuspendLayout();
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
            this.OuterTablePanel.Size = new System.Drawing.Size(1201, 715);
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
            this.MainTablePanel.Size = new System.Drawing.Size(1193, 711);
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
            this.HeaderTablePanel.Size = new System.Drawing.Size(1193, 30);
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
            this.LbTitle.Size = new System.Drawing.Size(1056, 30);
            this.LbTitle.TabIndex = 3;
            this.LbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Controls.Add(this.tableLayoutPanel1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(5, 37);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(5);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1183, 669);
            this.MainPanel.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.SplitView, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1183, 669);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.BtnToggleAdmin, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnDelete, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(40, 669);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // BtnToggleAdmin
            // 
            this.BtnToggleAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnToggleAdmin.FlatAppearance.BorderSize = 0;
            this.BtnToggleAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnToggleAdmin.Image = global::FileManager.Properties.Resources.admin;
            this.BtnToggleAdmin.Location = new System.Drawing.Point(0, 0);
            this.BtnToggleAdmin.Margin = new System.Windows.Forms.Padding(0);
            this.BtnToggleAdmin.Name = "BtnToggleAdmin";
            this.BtnToggleAdmin.Size = new System.Drawing.Size(40, 40);
            this.BtnToggleAdmin.TabIndex = 11;
            this.BtnToggleAdmin.UseVisualStyleBackColor = true;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDelete.FlatAppearance.BorderSize = 0;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Image = global::FileManager.Properties.Resources.trash;
            this.BtnDelete.Location = new System.Drawing.Point(0, 40);
            this.BtnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(40, 40);
            this.BtnDelete.TabIndex = 12;
            this.BtnDelete.UseVisualStyleBackColor = true;
            // 
            // SplitView
            // 
            this.SplitView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitView.Location = new System.Drawing.Point(43, 3);
            this.SplitView.Name = "SplitView";
            // 
            // SplitView.Panel1
            // 
            this.SplitView.Panel1.Controls.Add(this.LsViewUsers);
            // 
            // SplitView.Panel2
            // 
            this.SplitView.Panel2.Controls.Add(this.LsViewActivites);
            this.SplitView.Size = new System.Drawing.Size(1137, 663);
            this.SplitView.SplitterDistance = 247;
            this.SplitView.TabIndex = 1;
            // 
            // LsViewUsers
            // 
            this.LsViewUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColUID,
            this.ColUsername});
            this.LsViewUsers.DiskThreshold = 0.85F;
            this.LsViewUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LsViewUsers.FullRowSelect = true;
            this.LsViewUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LsViewUsers.HideSelection = false;
            this.LsViewUsers.HoverOverlayColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LsViewUsers.Location = new System.Drawing.Point(0, 0);
            this.LsViewUsers.MultiSelect = false;
            this.LsViewUsers.Name = "LsViewUsers";
            this.LsViewUsers.OwnerDraw = true;
            this.LsViewUsers.SelectedOverlayColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LsViewUsers.Size = new System.Drawing.Size(247, 663);
            this.LsViewUsers.TabIndex = 0;
            this.LsViewUsers.UseCompatibleStateImageBehavior = false;
            this.LsViewUsers.View = System.Windows.Forms.View.Details;
            this.LsViewUsers.ViewIndex = 0;
            // 
            // ColUID
            // 
            this.ColUID.Text = "UID";
            this.ColUID.Width = 50;
            // 
            // ColUsername
            // 
            this.ColUsername.Text = "Username";
            this.ColUsername.Width = 6000;
            // 
            // LsViewActivites
            // 
            this.LsViewActivites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColAction,
            this.ColSource,
            this.ColDestination,
            this.ColTime});
            this.LsViewActivites.DiskThreshold = 0.85F;
            this.LsViewActivites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LsViewActivites.FullRowSelect = true;
            this.LsViewActivites.HideSelection = false;
            this.LsViewActivites.HoverOverlayColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LsViewActivites.Location = new System.Drawing.Point(0, 0);
            this.LsViewActivites.MultiSelect = false;
            this.LsViewActivites.Name = "LsViewActivites";
            this.LsViewActivites.OwnerDraw = true;
            this.LsViewActivites.SelectedOverlayColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LsViewActivites.Size = new System.Drawing.Size(886, 663);
            this.LsViewActivites.TabIndex = 0;
            this.LsViewActivites.UseCompatibleStateImageBehavior = false;
            this.LsViewActivites.View = System.Windows.Forms.View.Details;
            this.LsViewActivites.ViewIndex = 0;
            // 
            // ColAction
            // 
            this.ColAction.Text = "Action";
            // 
            // ColSource
            // 
            this.ColSource.Text = "Source";
            this.ColSource.Width = 300;
            // 
            // ColDestination
            // 
            this.ColDestination.Text = "Destination";
            this.ColDestination.Width = 300;
            // 
            // ColTime
            // 
            this.ColTime.Text = "Time";
            this.ColTime.Width = 6000;
            // 
            // OuterLeftEdge
            // 
            this.OuterLeftEdge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OuterLeftEdge.Location = new System.Drawing.Point(0, 0);
            this.OuterLeftEdge.Margin = new System.Windows.Forms.Padding(0);
            this.OuterLeftEdge.Name = "OuterLeftEdge";
            this.OuterLeftEdge.Size = new System.Drawing.Size(4, 711);
            this.OuterLeftEdge.TabIndex = 1;
            // 
            // OuterBottomEdge
            // 
            this.OuterBottomEdge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OuterBottomEdge.Location = new System.Drawing.Point(4, 711);
            this.OuterBottomEdge.Margin = new System.Windows.Forms.Padding(0);
            this.OuterBottomEdge.Name = "OuterBottomEdge";
            this.OuterBottomEdge.Size = new System.Drawing.Size(1193, 4);
            this.OuterBottomEdge.TabIndex = 2;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 715);
            this.Controls.Add(this.OuterTablePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.OuterTablePanel.ResumeLayout(false);
            this.MainTablePanel.ResumeLayout(false);
            this.HeaderTablePanel.ResumeLayout(false);
            this.HeaderTablePanel.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.SplitView.Panel1.ResumeLayout(false);
            this.SplitView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitView)).EndInit();
            this.SplitView.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnToggleAdmin;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.SplitContainer SplitView;
        private CustomListView LsViewUsers;
        private CustomListView LsViewActivites;
        private System.Windows.Forms.ColumnHeader ColUID;
        private System.Windows.Forms.ColumnHeader ColUsername;
        private System.Windows.Forms.ColumnHeader ColAction;
        private System.Windows.Forms.ColumnHeader ColSource;
        private System.Windows.Forms.ColumnHeader ColDestination;
        private System.Windows.Forms.ColumnHeader ColTime;
    }
}