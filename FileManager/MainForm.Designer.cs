namespace FileManager
{
    partial class MainForm
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
        private Theme currentTheme;
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.imageListTreeView = new System.Windows.Forms.ImageList(this.components);
            this.roundedTablePanel1 = new FileManager.RoundedTablePanel();
            this.MainTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.DisplayTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.listView = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.treeView = new System.Windows.Forms.TreeView();
            this.NavigationTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.TxtBxAddress = new System.Windows.Forms.TextBox();
            this.TxtBxSearch = new System.Windows.Forms.TextBox();
            this.NavigationButtonTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.BtnBack = new System.Windows.Forms.Button();
            this.BtnForward = new System.Windows.Forms.Button();
            this.BtnRecent = new System.Windows.Forms.Button();
            this.BtnParentFolder = new System.Windows.Forms.Button();
            this.StatusTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.LbStatus2 = new System.Windows.Forms.Label();
            this.HeaderTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnY = new System.Windows.Forms.Button();
            this.BtnG = new System.Windows.Forms.Button();
            this.OuterLeftEdge = new System.Windows.Forms.Panel();
            this.OuterBottomEdge = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.roundedTablePanel1.SuspendLayout();
            this.MainTablePanel.SuspendLayout();
            this.DisplayTablePanel.SuspendLayout();
            this.NavigationTablePanel.SuspendLayout();
            this.NavigationButtonTablePanel.SuspendLayout();
            this.StatusTablePanel.SuspendLayout();
            this.HeaderTablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListLarge
            // 
            this.imageListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLarge.ImageStream")));
            this.imageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListLarge.Images.SetKeyName(0, "folder.png");
            // 
            // imageListSmall
            // 
            this.imageListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSmall.ImageStream")));
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSmall.Images.SetKeyName(0, "folder");
            // 
            // imageListTreeView
            // 
            this.imageListTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTreeView.ImageStream")));
            this.imageListTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTreeView.Images.SetKeyName(0, "Computer.ico");
            this.imageListTreeView.Images.SetKeyName(1, "FloppyDisk.ico");
            this.imageListTreeView.Images.SetKeyName(2, "HardDisk.ico");
            this.imageListTreeView.Images.SetKeyName(3, "CDDisk.ico");
            this.imageListTreeView.Images.SetKeyName(4, "NetworkDrive.ico");
            this.imageListTreeView.Images.SetKeyName(5, "Folder.ico");
            // 
            // roundedTablePanel1
            // 
            this.roundedTablePanel1.BackColor = System.Drawing.Color.Transparent;
            this.roundedTablePanel1.BorderColor = System.Drawing.Color.Empty;
            this.roundedTablePanel1.ColumnCount = 3;
            this.roundedTablePanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.roundedTablePanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.roundedTablePanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.roundedTablePanel1.Controls.Add(this.MainTablePanel, 1, 0);
            this.roundedTablePanel1.Controls.Add(this.OuterLeftEdge, 0, 0);
            this.roundedTablePanel1.Controls.Add(this.OuterBottomEdge, 1, 1);
            this.roundedTablePanel1.Controls.Add(this.panel1, 2, 0);
            this.roundedTablePanel1.CornerRadius = 50;
            this.roundedTablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundedTablePanel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.roundedTablePanel1.Location = new System.Drawing.Point(0, 0);
            this.roundedTablePanel1.Margin = new System.Windows.Forms.Padding(4);
            this.roundedTablePanel1.Name = "roundedTablePanel1";
            this.roundedTablePanel1.RowCount = 2;
            this.roundedTablePanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.roundedTablePanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.roundedTablePanel1.Size = new System.Drawing.Size(1186, 560);
            this.roundedTablePanel1.TabIndex = 2;
            this.roundedTablePanel1.TrueBackColor = System.Drawing.Color.Red;
            // 
            // MainTablePanel
            // 
            this.MainTablePanel.ColumnCount = 1;
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTablePanel.Controls.Add(this.DisplayTablePanel, 0, 3);
            this.MainTablePanel.Controls.Add(this.NavigationTablePanel, 0, 2);
            this.MainTablePanel.Controls.Add(this.StatusTablePanel, 0, 4);
            this.MainTablePanel.Controls.Add(this.HeaderTablePanel, 0, 0);
            this.MainTablePanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainTablePanel.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MainTablePanel.Location = new System.Drawing.Point(27, 0);
            this.MainTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTablePanel.Name = "MainTablePanel";
            this.MainTablePanel.RowCount = 5;
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.MainTablePanel.Size = new System.Drawing.Size(1132, 535);
            this.MainTablePanel.TabIndex = 0;
            this.MainTablePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainTablePanel_Paint);
            // 
            // DisplayTablePanel
            // 
            this.DisplayTablePanel.ColumnCount = 2;
            this.DisplayTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 213F));
            this.DisplayTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DisplayTablePanel.Controls.Add(this.listView, 1, 0);
            this.DisplayTablePanel.Controls.Add(this.treeView, 0, 0);
            this.DisplayTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisplayTablePanel.Location = new System.Drawing.Point(0, 139);
            this.DisplayTablePanel.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.DisplayTablePanel.Name = "DisplayTablePanel";
            this.DisplayTablePanel.RowCount = 1;
            this.DisplayTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DisplayTablePanel.Size = new System.Drawing.Size(1132, 359);
            this.DisplayTablePanel.TabIndex = 2;
            // 
            // listView
            // 
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colDateModified,
            this.colType,
            this.colSize});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.HideSelection = false;
            this.listView.LargeImageList = this.imageListLarge;
            this.listView.Location = new System.Drawing.Point(217, 0);
            this.listView.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(915, 359);
            this.listView.SmallImageList = this.imageListSmall;
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listView_KeyPress);
            this.listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseDoubleClick);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 250;
            // 
            // colDateModified
            // 
            this.colDateModified.Text = "Date Modified";
            this.colDateModified.Width = 200;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 110;
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            this.colSize.Width = 105;
            // 
            // treeView
            // 
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageListTreeView;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Margin = new System.Windows.Forms.Padding(0);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(213, 359);
            this.treeView.TabIndex = 1;
            // 
            // NavigationTablePanel
            // 
            this.NavigationTablePanel.ColumnCount = 3;
            this.NavigationTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 213F));
            this.NavigationTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.NavigationTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.NavigationTablePanel.Controls.Add(this.TxtBxAddress, 1, 0);
            this.NavigationTablePanel.Controls.Add(this.TxtBxSearch, 2, 0);
            this.NavigationTablePanel.Controls.Add(this.NavigationButtonTablePanel, 0, 0);
            this.NavigationTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NavigationTablePanel.Location = new System.Drawing.Point(0, 86);
            this.NavigationTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.NavigationTablePanel.Name = "NavigationTablePanel";
            this.NavigationTablePanel.RowCount = 1;
            this.NavigationTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.NavigationTablePanel.Size = new System.Drawing.Size(1132, 49);
            this.NavigationTablePanel.TabIndex = 3;
            // 
            // TxtBxAddress
            // 
            this.TxtBxAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtBxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxAddress.Location = new System.Drawing.Point(214, 5);
            this.TxtBxAddress.Margin = new System.Windows.Forms.Padding(1, 5, 3, 5);
            this.TxtBxAddress.Name = "TxtBxAddress";
            this.TxtBxAddress.Size = new System.Drawing.Size(515, 36);
            this.TxtBxAddress.TabIndex = 1;
            // 
            // TxtBxSearch
            // 
            this.TxtBxSearch.BackColor = System.Drawing.SystemColors.Window;
            this.TxtBxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtBxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxSearch.Location = new System.Drawing.Point(735, 5);
            this.TxtBxSearch.Margin = new System.Windows.Forms.Padding(3, 5, 0, 5);
            this.TxtBxSearch.Name = "TxtBxSearch";
            this.TxtBxSearch.Size = new System.Drawing.Size(397, 36);
            this.TxtBxSearch.TabIndex = 2;
            // 
            // NavigationButtonTablePanel
            // 
            this.NavigationButtonTablePanel.ColumnCount = 4;
            this.NavigationButtonTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.NavigationButtonTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.NavigationButtonTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.NavigationButtonTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.NavigationButtonTablePanel.Controls.Add(this.BtnBack, 0, 0);
            this.NavigationButtonTablePanel.Controls.Add(this.BtnForward, 1, 0);
            this.NavigationButtonTablePanel.Controls.Add(this.BtnRecent, 2, 0);
            this.NavigationButtonTablePanel.Controls.Add(this.BtnParentFolder, 3, 0);
            this.NavigationButtonTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NavigationButtonTablePanel.Location = new System.Drawing.Point(0, 0);
            this.NavigationButtonTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.NavigationButtonTablePanel.Name = "NavigationButtonTablePanel";
            this.NavigationButtonTablePanel.RowCount = 1;
            this.NavigationButtonTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.NavigationButtonTablePanel.Size = new System.Drawing.Size(213, 49);
            this.NavigationButtonTablePanel.TabIndex = 3;
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnBack.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnBack.FlatAppearance.BorderSize = 0;
            this.BtnBack.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BtnBack.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBack.Image = global::FileManager.Properties.Resources.left_arrow;
            this.BtnBack.Location = new System.Drawing.Point(5, 5);
            this.BtnBack.Margin = new System.Windows.Forms.Padding(5);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(43, 39);
            this.BtnBack.TabIndex = 0;
            this.BtnBack.UseVisualStyleBackColor = false;
            // 
            // BtnForward
            // 
            this.BtnForward.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnForward.FlatAppearance.BorderSize = 0;
            this.BtnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnForward.Location = new System.Drawing.Point(58, 5);
            this.BtnForward.Margin = new System.Windows.Forms.Padding(5);
            this.BtnForward.Name = "BtnForward";
            this.BtnForward.Size = new System.Drawing.Size(43, 39);
            this.BtnForward.TabIndex = 1;
            this.BtnForward.UseVisualStyleBackColor = true;
            // 
            // BtnRecent
            // 
            this.BtnRecent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnRecent.FlatAppearance.BorderSize = 0;
            this.BtnRecent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRecent.Location = new System.Drawing.Point(111, 5);
            this.BtnRecent.Margin = new System.Windows.Forms.Padding(5);
            this.BtnRecent.Name = "BtnRecent";
            this.BtnRecent.Size = new System.Drawing.Size(43, 39);
            this.BtnRecent.TabIndex = 2;
            this.BtnRecent.UseVisualStyleBackColor = true;
            // 
            // BtnParentFolder
            // 
            this.BtnParentFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnParentFolder.FlatAppearance.BorderSize = 0;
            this.BtnParentFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnParentFolder.Location = new System.Drawing.Point(164, 5);
            this.BtnParentFolder.Margin = new System.Windows.Forms.Padding(5);
            this.BtnParentFolder.Name = "BtnParentFolder";
            this.BtnParentFolder.Size = new System.Drawing.Size(44, 39);
            this.BtnParentFolder.TabIndex = 3;
            this.BtnParentFolder.UseVisualStyleBackColor = true;
            // 
            // StatusTablePanel
            // 
            this.StatusTablePanel.ColumnCount = 5;
            this.StatusTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.StatusTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.StatusTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.StatusTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.StatusTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.StatusTablePanel.Controls.Add(this.label1, 0, 0);
            this.StatusTablePanel.Controls.Add(this.LbStatus2, 1, 0);
            this.StatusTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusTablePanel.Location = new System.Drawing.Point(0, 498);
            this.StatusTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.StatusTablePanel.Name = "StatusTablePanel";
            this.StatusTablePanel.RowCount = 1;
            this.StatusTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.StatusTablePanel.Size = new System.Drawing.Size(1132, 37);
            this.StatusTablePanel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LbStatus2
            // 
            this.LbStatus2.AutoSize = true;
            this.LbStatus2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbStatus2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LbStatus2.Location = new System.Drawing.Point(97, 0);
            this.LbStatus2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbStatus2.Name = "LbStatus2";
            this.LbStatus2.Size = new System.Drawing.Size(125, 37);
            this.LbStatus2.TabIndex = 1;
            this.LbStatus2.Text = "label2";
            this.LbStatus2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HeaderTablePanel
            // 
            this.HeaderTablePanel.ColumnCount = 5;
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.HeaderTablePanel.Controls.Add(this.BtnExit, 0, 0);
            this.HeaderTablePanel.Controls.Add(this.BtnY, 1, 0);
            this.HeaderTablePanel.Controls.Add(this.BtnG, 2, 0);
            this.HeaderTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeaderTablePanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.HeaderTablePanel.Name = "HeaderTablePanel";
            this.HeaderTablePanel.RowCount = 1;
            this.HeaderTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.HeaderTablePanel.Size = new System.Drawing.Size(1132, 37);
            this.HeaderTablePanel.TabIndex = 5;
            this.HeaderTablePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeaderTablePanel_MouseDown);
            this.HeaderTablePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HeaderTablePanel_MouseMove);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.Red;
            this.BtnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnExit.FlatAppearance.BorderSize = 0;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.ForeColor = System.Drawing.Color.Yellow;
            this.BtnExit.Location = new System.Drawing.Point(4, 4);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(4);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(32, 29);
            this.BtnExit.TabIndex = 0;
            this.BtnExit.UseVisualStyleBackColor = false;
            // 
            // BtnY
            // 
            this.BtnY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BtnY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnY.FlatAppearance.BorderSize = 0;
            this.BtnY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnY.Location = new System.Drawing.Point(44, 4);
            this.BtnY.Margin = new System.Windows.Forms.Padding(4);
            this.BtnY.Name = "BtnY";
            this.BtnY.Size = new System.Drawing.Size(32, 29);
            this.BtnY.TabIndex = 1;
            this.BtnY.UseVisualStyleBackColor = false;
            // 
            // BtnG
            // 
            this.BtnG.BackColor = System.Drawing.Color.Lime;
            this.BtnG.FlatAppearance.BorderSize = 0;
            this.BtnG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnG.Location = new System.Drawing.Point(84, 4);
            this.BtnG.Margin = new System.Windows.Forms.Padding(4);
            this.BtnG.Name = "BtnG";
            this.BtnG.Size = new System.Drawing.Size(32, 28);
            this.BtnG.TabIndex = 2;
            this.BtnG.UseVisualStyleBackColor = false;
            // 
            // OuterLeftEdge
            // 
            this.OuterLeftEdge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OuterLeftEdge.Location = new System.Drawing.Point(0, 0);
            this.OuterLeftEdge.Margin = new System.Windows.Forms.Padding(0);
            this.OuterLeftEdge.Name = "OuterLeftEdge";
            this.OuterLeftEdge.Size = new System.Drawing.Size(27, 535);
            this.OuterLeftEdge.TabIndex = 1;
            // 
            // OuterBottomEdge
            // 
            this.OuterBottomEdge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OuterBottomEdge.Location = new System.Drawing.Point(27, 535);
            this.OuterBottomEdge.Margin = new System.Windows.Forms.Padding(0);
            this.OuterBottomEdge.Name = "OuterBottomEdge";
            this.OuterBottomEdge.Size = new System.Drawing.Size(1132, 25);
            this.OuterBottomEdge.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1162, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(21, 531);
            this.panel1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1186, 560);
            this.Controls.Add(this.roundedTablePanel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "File Manager";
            this.roundedTablePanel1.ResumeLayout(false);
            this.MainTablePanel.ResumeLayout(false);
            this.DisplayTablePanel.ResumeLayout(false);
            this.NavigationTablePanel.ResumeLayout(false);
            this.NavigationTablePanel.PerformLayout();
            this.NavigationButtonTablePanel.ResumeLayout(false);
            this.StatusTablePanel.ResumeLayout(false);
            this.StatusTablePanel.PerformLayout();
            this.HeaderTablePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTablePanel;
        private System.Windows.Forms.TableLayoutPanel DisplayTablePanel;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.TableLayoutPanel NavigationTablePanel;
        private System.Windows.Forms.TextBox TxtBxAddress;
        private System.Windows.Forms.TextBox TxtBxSearch;
        private System.Windows.Forms.TableLayoutPanel NavigationButtonTablePanel;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Button BtnForward;
        private System.Windows.Forms.Button BtnRecent;
        private System.Windows.Forms.Button BtnParentFolder;
        private System.Windows.Forms.TableLayoutPanel StatusTablePanel;
        private System.Windows.Forms.TableLayoutPanel HeaderTablePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LbStatus2;
        private System.Windows.Forms.Button BtnMinimize;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.ImageList imageListTreeView;
        private System.Windows.Forms.Panel OuterLeftEdge;
        private System.Windows.Forms.Panel OuterBottomEdge;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colDateModified;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.ImageList imageListLarge;
        private System.Windows.Forms.Button BtnY;
        private System.Windows.Forms.Button BtnG;
        private RoundedTablePanel roundedTablePanel1;
    }
}

