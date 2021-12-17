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
            this.OuterTablePanel = new FileManager.RoundedTablePanel();
            this.MainTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.DisplayTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.listView = new FileManager.CustomListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.treeView = new FileManager.CustomTreeView();
            this.NavigationTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.TxtBxSearch = new System.Windows.Forms.TextBox();
            this.NavigationButtonTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.BtnBack = new System.Windows.Forms.Button();
            this.BtnForward = new System.Windows.Forms.Button();
            this.BtnRecent = new System.Windows.Forms.Button();
            this.BtnParentFolder = new System.Windows.Forms.Button();
            this.AddressTablePanel = new FileManager.RoundedTablePanel();
            this.CbAddress = new System.Windows.Forms.ComboBox();
            this.BtnGoRefresh = new System.Windows.Forms.Button();
            this.StatusTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.HeaderTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.BtnExit = new FileManager.RoundedButton();
            this.BtnMinimize = new FileManager.RoundedButton();
            this.BtnMaximize = new FileManager.RoundedButton();
            this.LbTitle = new System.Windows.Forms.Label();
            this.ToolTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.BtnCut = new System.Windows.Forms.Button();
            this.BtnCopy = new System.Windows.Forms.Button();
            this.BtnPaste = new System.Windows.Forms.Button();
            this.BtnRename = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.MenuNew = new System.Windows.Forms.MenuStrip();
            this.MenuNewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemNewTextFile = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnChangeTheme = new System.Windows.Forms.Button();
            this.MenuTag = new System.Windows.Forms.MenuStrip();
            this.MenuTagItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.OuterLeftEdge = new System.Windows.Forms.Panel();
            this.OuterBottomEdge = new System.Windows.Forms.Panel();
            this.OuterTablePanel.SuspendLayout();
            this.MainTablePanel.SuspendLayout();
            this.DisplayTablePanel.SuspendLayout();
            this.NavigationTablePanel.SuspendLayout();
            this.NavigationButtonTablePanel.SuspendLayout();
            this.AddressTablePanel.SuspendLayout();
            this.HeaderTablePanel.SuspendLayout();
            this.ToolTablePanel.SuspendLayout();
            this.MenuNew.SuspendLayout();
            this.MenuTag.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListLarge
            // 
            this.imageListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLarge.ImageStream")));
            this.imageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListLarge.Images.SetKeyName(0, "floppy disk");
            this.imageListLarge.Images.SetKeyName(1, "hard disk");
            this.imageListLarge.Images.SetKeyName(2, "CD disk");
            this.imageListLarge.Images.SetKeyName(3, "network disk");
            this.imageListLarge.Images.SetKeyName(4, "folder");
            this.imageListLarge.Images.SetKeyName(5, "blank");
            // 
            // imageListSmall
            // 
            this.imageListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSmall.ImageStream")));
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSmall.Images.SetKeyName(0, "floppy disk");
            this.imageListSmall.Images.SetKeyName(1, "hard disk");
            this.imageListSmall.Images.SetKeyName(2, "CD disk");
            this.imageListSmall.Images.SetKeyName(3, "network disk");
            this.imageListSmall.Images.SetKeyName(4, "folder");
            this.imageListSmall.Images.SetKeyName(5, "blank");
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
            this.OuterTablePanel.Size = new System.Drawing.Size(1240, 560);
            this.OuterTablePanel.TabIndex = 2;
            this.OuterTablePanel.TrueBackColor = System.Drawing.SystemColors.Control;
            // 
            // MainTablePanel
            // 
            this.MainTablePanel.ColumnCount = 1;
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTablePanel.Controls.Add(this.DisplayTablePanel, 0, 4);
            this.MainTablePanel.Controls.Add(this.NavigationTablePanel, 0, 3);
            this.MainTablePanel.Controls.Add(this.StatusTablePanel, 0, 5);
            this.MainTablePanel.Controls.Add(this.HeaderTablePanel, 0, 1);
            this.MainTablePanel.Controls.Add(this.ToolTablePanel, 0, 2);
            this.MainTablePanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTablePanel.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MainTablePanel.Location = new System.Drawing.Point(5, 0);
            this.MainTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTablePanel.Name = "MainTablePanel";
            this.MainTablePanel.RowCount = 6;
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.MainTablePanel.Size = new System.Drawing.Size(1230, 555);
            this.MainTablePanel.TabIndex = 0;
            this.MainTablePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainTablePanel_Paint);
            // 
            // DisplayTablePanel
            // 
            this.DisplayTablePanel.ColumnCount = 2;
            this.DisplayTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 333F));
            this.DisplayTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DisplayTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.DisplayTablePanel.Controls.Add(this.listView, 1, 0);
            this.DisplayTablePanel.Controls.Add(this.treeView, 0, 0);
            this.DisplayTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisplayTablePanel.Location = new System.Drawing.Point(0, 152);
            this.DisplayTablePanel.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.DisplayTablePanel.Name = "DisplayTablePanel";
            this.DisplayTablePanel.RowCount = 1;
            this.DisplayTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DisplayTablePanel.Size = new System.Drawing.Size(1230, 366);
            this.DisplayTablePanel.TabIndex = 2;
            // 
            // listView
            // 
            this.listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView.AllowColumnReorder = true;
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colDateModified,
            this.colType,
            this.colSize});
            this.listView.DiskThreshold = 0.85F;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.HideSelection = false;
            this.listView.HoverOverlayColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listView.LabelEdit = true;
            this.listView.LargeImageList = this.imageListLarge;
            this.listView.Location = new System.Drawing.Point(337, 0);
            this.listView.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.listView.Name = "listView";
            this.listView.OwnerDraw = true;
            this.listView.SelectedOverlayColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listView.Size = new System.Drawing.Size(893, 366);
            this.listView.SmallImageList = this.imageListSmall;
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Tile;
            this.listView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView_AfterLabelEdit);
            this.listView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listView_KeyPress);
            this.listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseClick);
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
            this.colSize.Width = 10000;
            // 
            // treeView
            // 
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView.FullRowSelect = true;
            this.treeView.HotTracking = true;
            this.treeView.HoverOverlayColor = System.Drawing.Color.White;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageListTreeView;
            this.treeView.Indent = 10;
            this.treeView.ItemHeight = 22;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Margin = new System.Windows.Forms.Padding(0);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.SelectedOverlayColor = System.Drawing.Color.White;
            this.treeView.ShowLines = false;
            this.treeView.Size = new System.Drawing.Size(333, 366);
            this.treeView.TabIndex = 1;
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // NavigationTablePanel
            // 
            this.NavigationTablePanel.ColumnCount = 3;
            this.NavigationTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 213F));
            this.NavigationTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.NavigationTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.NavigationTablePanel.Controls.Add(this.TxtBxSearch, 2, 0);
            this.NavigationTablePanel.Controls.Add(this.NavigationButtonTablePanel, 0, 0);
            this.NavigationTablePanel.Controls.Add(this.AddressTablePanel, 1, 0);
            this.NavigationTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NavigationTablePanel.Location = new System.Drawing.Point(0, 88);
            this.NavigationTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.NavigationTablePanel.Name = "NavigationTablePanel";
            this.NavigationTablePanel.RowCount = 1;
            this.NavigationTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.NavigationTablePanel.Size = new System.Drawing.Size(1230, 62);
            this.NavigationTablePanel.TabIndex = 3;
            // 
            // TxtBxSearch
            // 
            this.TxtBxSearch.BackColor = System.Drawing.SystemColors.Window;
            this.TxtBxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtBxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxSearch.Location = new System.Drawing.Point(1233, 12);
            this.TxtBxSearch.Margin = new System.Windows.Forms.Padding(3, 12, 0, 2);
            this.TxtBxSearch.Name = "TxtBxSearch";
            this.TxtBxSearch.Size = new System.Drawing.Size(1, 36);
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
            this.NavigationButtonTablePanel.Size = new System.Drawing.Size(213, 62);
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
            this.BtnBack.Location = new System.Drawing.Point(4, 4);
            this.BtnBack.Margin = new System.Windows.Forms.Padding(4);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(45, 54);
            this.BtnBack.TabIndex = 0;
            this.BtnBack.UseVisualStyleBackColor = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // BtnForward
            // 
            this.BtnForward.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnForward.FlatAppearance.BorderSize = 0;
            this.BtnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnForward.Image = global::FileManager.Properties.Resources.right_arrow;
            this.BtnForward.Location = new System.Drawing.Point(57, 4);
            this.BtnForward.Margin = new System.Windows.Forms.Padding(4);
            this.BtnForward.Name = "BtnForward";
            this.BtnForward.Size = new System.Drawing.Size(45, 54);
            this.BtnForward.TabIndex = 1;
            this.BtnForward.UseVisualStyleBackColor = true;
            this.BtnForward.Click += new System.EventHandler(this.BtnForward_Click);
            // 
            // BtnRecent
            // 
            this.BtnRecent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnRecent.FlatAppearance.BorderSize = 0;
            this.BtnRecent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRecent.Image = global::FileManager.Properties.Resources.expand_down_arrow;
            this.BtnRecent.Location = new System.Drawing.Point(110, 4);
            this.BtnRecent.Margin = new System.Windows.Forms.Padding(4);
            this.BtnRecent.Name = "BtnRecent";
            this.BtnRecent.Size = new System.Drawing.Size(45, 54);
            this.BtnRecent.TabIndex = 2;
            this.BtnRecent.UseVisualStyleBackColor = true;
            this.BtnRecent.Visible = false;
            // 
            // BtnParentFolder
            // 
            this.BtnParentFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnParentFolder.FlatAppearance.BorderSize = 0;
            this.BtnParentFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnParentFolder.Image = global::FileManager.Properties.Resources.up_arrow;
            this.BtnParentFolder.Location = new System.Drawing.Point(163, 4);
            this.BtnParentFolder.Margin = new System.Windows.Forms.Padding(4);
            this.BtnParentFolder.Name = "BtnParentFolder";
            this.BtnParentFolder.Size = new System.Drawing.Size(46, 54);
            this.BtnParentFolder.TabIndex = 3;
            this.BtnParentFolder.UseVisualStyleBackColor = true;
            this.BtnParentFolder.Click += new System.EventHandler(this.BtnParentFolder_Click);
            // 
            // AddressTablePanel
            // 
            this.AddressTablePanel.BackColor = System.Drawing.Color.Transparent;
            this.AddressTablePanel.BorderColor = System.Drawing.Color.Empty;
            this.AddressTablePanel.ColumnCount = 2;
            this.AddressTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AddressTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.AddressTablePanel.Controls.Add(this.CbAddress, 0, 0);
            this.AddressTablePanel.Controls.Add(this.BtnGoRefresh, 1, 0);
            this.AddressTablePanel.CornerRadius = 50;
            this.AddressTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddressTablePanel.Location = new System.Drawing.Point(216, 2);
            this.AddressTablePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddressTablePanel.Name = "AddressTablePanel";
            this.AddressTablePanel.Rounded = false;
            this.AddressTablePanel.RowCount = 1;
            this.AddressTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AddressTablePanel.Size = new System.Drawing.Size(1011, 58);
            this.AddressTablePanel.TabIndex = 4;
            this.AddressTablePanel.TrueBackColor = System.Drawing.Color.Transparent;
            // 
            // CbAddress
            // 
            this.CbAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CbAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbAddress.FormattingEnabled = true;
            this.CbAddress.Location = new System.Drawing.Point(0, 9);
            this.CbAddress.Margin = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.CbAddress.Name = "CbAddress";
            this.CbAddress.Size = new System.Drawing.Size(976, 33);
            this.CbAddress.TabIndex = 0;
            this.CbAddress.TextChanged += new System.EventHandler(this.CbAddress_TextChanged);
            this.CbAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CbAddress_KeyPress);
            // 
            // BtnGoRefresh
            // 
            this.BtnGoRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGoRefresh.FlatAppearance.BorderSize = 0;
            this.BtnGoRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGoRefresh.Image = global::FileManager.Properties.Resources.reboot;
            this.BtnGoRefresh.Location = new System.Drawing.Point(976, 0);
            this.BtnGoRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.BtnGoRefresh.Name = "BtnGoRefresh";
            this.BtnGoRefresh.Size = new System.Drawing.Size(35, 58);
            this.BtnGoRefresh.TabIndex = 1;
            this.BtnGoRefresh.UseVisualStyleBackColor = true;
            this.BtnGoRefresh.Click += new System.EventHandler(this.BtnGoRefresh_Click);
            // 
            // StatusTablePanel
            // 
            this.StatusTablePanel.ColumnCount = 5;
            this.StatusTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.StatusTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.StatusTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.StatusTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.StatusTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.StatusTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusTablePanel.Location = new System.Drawing.Point(0, 518);
            this.StatusTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.StatusTablePanel.Name = "StatusTablePanel";
            this.StatusTablePanel.RowCount = 1;
            this.StatusTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.StatusTablePanel.Size = new System.Drawing.Size(1230, 37);
            this.StatusTablePanel.TabIndex = 4;
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
            this.HeaderTablePanel.Size = new System.Drawing.Size(1230, 37);
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
            this.LbTitle.Size = new System.Drawing.Size(1046, 37);
            this.LbTitle.TabIndex = 3;
            this.LbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ToolTablePanel
            // 
            this.ToolTablePanel.ColumnCount = 10;
            this.ToolTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.ToolTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.ToolTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.ToolTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.ToolTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.ToolTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.ToolTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.ToolTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.ToolTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.ToolTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ToolTablePanel.Controls.Add(this.BtnCut, 1, 0);
            this.ToolTablePanel.Controls.Add(this.BtnCopy, 2, 0);
            this.ToolTablePanel.Controls.Add(this.BtnPaste, 3, 0);
            this.ToolTablePanel.Controls.Add(this.BtnRename, 4, 0);
            this.ToolTablePanel.Controls.Add(this.BtnDelete, 5, 0);
            this.ToolTablePanel.Controls.Add(this.MenuNew, 0, 0);
            this.ToolTablePanel.Controls.Add(this.BtnChangeTheme, 6, 0);
            this.ToolTablePanel.Controls.Add(this.MenuTag, 7, 0);
            this.ToolTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolTablePanel.Location = new System.Drawing.Point(0, 39);
            this.ToolTablePanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.ToolTablePanel.Name = "ToolTablePanel";
            this.ToolTablePanel.RowCount = 1;
            this.ToolTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ToolTablePanel.Size = new System.Drawing.Size(1230, 48);
            this.ToolTablePanel.TabIndex = 6;
            // 
            // BtnCut
            // 
            this.BtnCut.AutoSize = true;
            this.BtnCut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnCut.FlatAppearance.BorderSize = 0;
            this.BtnCut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCut.Image = global::FileManager.Properties.Resources.cut;
            this.BtnCut.Location = new System.Drawing.Point(107, 0);
            this.BtnCut.Margin = new System.Windows.Forms.Padding(0);
            this.BtnCut.Name = "BtnCut";
            this.BtnCut.Size = new System.Drawing.Size(53, 48);
            this.BtnCut.TabIndex = 1;
            this.BtnCut.UseVisualStyleBackColor = true;
            this.BtnCut.Click += new System.EventHandler(this.BtnCut_Click);
            // 
            // BtnCopy
            // 
            this.BtnCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnCopy.FlatAppearance.BorderSize = 0;
            this.BtnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCopy.Image = global::FileManager.Properties.Resources.copy;
            this.BtnCopy.Location = new System.Drawing.Point(160, 0);
            this.BtnCopy.Margin = new System.Windows.Forms.Padding(0);
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(53, 48);
            this.BtnCopy.TabIndex = 2;
            this.BtnCopy.UseVisualStyleBackColor = true;
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // BtnPaste
            // 
            this.BtnPaste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnPaste.Enabled = false;
            this.BtnPaste.FlatAppearance.BorderSize = 0;
            this.BtnPaste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPaste.Image = global::FileManager.Properties.Resources.paste;
            this.BtnPaste.Location = new System.Drawing.Point(213, 0);
            this.BtnPaste.Margin = new System.Windows.Forms.Padding(0);
            this.BtnPaste.Name = "BtnPaste";
            this.BtnPaste.Size = new System.Drawing.Size(53, 48);
            this.BtnPaste.TabIndex = 3;
            this.BtnPaste.UseVisualStyleBackColor = true;
            this.BtnPaste.Click += new System.EventHandler(this.BtnPaste_Click);
            // 
            // BtnRename
            // 
            this.BtnRename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnRename.FlatAppearance.BorderSize = 0;
            this.BtnRename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRename.Image = global::FileManager.Properties.Resources.rename;
            this.BtnRename.Location = new System.Drawing.Point(266, 0);
            this.BtnRename.Margin = new System.Windows.Forms.Padding(0);
            this.BtnRename.Name = "BtnRename";
            this.BtnRename.Size = new System.Drawing.Size(53, 48);
            this.BtnRename.TabIndex = 4;
            this.BtnRename.UseVisualStyleBackColor = true;
            this.BtnRename.Click += new System.EventHandler(this.BtnRename_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDelete.FlatAppearance.BorderSize = 0;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Image = global::FileManager.Properties.Resources.trash;
            this.BtnDelete.Location = new System.Drawing.Point(319, 0);
            this.BtnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(53, 48);
            this.BtnDelete.TabIndex = 6;
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // MenuNew
            // 
            this.MenuNew.BackColor = System.Drawing.SystemColors.Control;
            this.MenuNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuNew.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuNew.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNewItem});
            this.MenuNew.Location = new System.Drawing.Point(0, 0);
            this.MenuNew.Name = "MenuNew";
            this.MenuNew.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MenuNew.Size = new System.Drawing.Size(107, 48);
            this.MenuNew.TabIndex = 7;
            this.MenuNew.Text = "New";
            // 
            // MenuNewItem
            // 
            this.MenuNewItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemNewFolder,
            this.MenuItemNewTextFile});
            this.MenuNewItem.Image = global::FileManager.Properties.Resources.new_file;
            this.MenuNewItem.Name = "MenuNewItem";
            this.MenuNewItem.Size = new System.Drawing.Size(77, 44);
            this.MenuNewItem.Text = "New ";
            // 
            // MenuItemNewFolder
            // 
            this.MenuItemNewFolder.Name = "MenuItemNewFolder";
            this.MenuItemNewFolder.Size = new System.Drawing.Size(226, 26);
            this.MenuItemNewFolder.Text = "New Folder";
            this.MenuItemNewFolder.Click += new System.EventHandler(this.newFolderToolStripMenuItem1_Click);
            // 
            // MenuItemNewTextFile
            // 
            this.MenuItemNewTextFile.Name = "MenuItemNewTextFile";
            this.MenuItemNewTextFile.Size = new System.Drawing.Size(226, 26);
            this.MenuItemNewTextFile.Text = "New Text Document";
            this.MenuItemNewTextFile.Click += new System.EventHandler(this.newTextDocumentToolStripMenuItem_Click);
            // 
            // BtnChangeTheme
            // 
            this.BtnChangeTheme.FlatAppearance.BorderSize = 0;
            this.BtnChangeTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnChangeTheme.Image = global::FileManager.Properties.Resources.color;
            this.BtnChangeTheme.Location = new System.Drawing.Point(372, 0);
            this.BtnChangeTheme.Margin = new System.Windows.Forms.Padding(0);
            this.BtnChangeTheme.Name = "BtnChangeTheme";
            this.BtnChangeTheme.Size = new System.Drawing.Size(53, 48);
            this.BtnChangeTheme.TabIndex = 6;
            this.BtnChangeTheme.UseVisualStyleBackColor = true;
            this.BtnChangeTheme.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // MenuTag
            // 
            this.MenuTag.BackColor = System.Drawing.Color.Transparent;
            this.MenuTag.BackgroundImage = global::FileManager.Properties.Resources.star;
            this.MenuTag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MenuTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuTag.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuTag.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuTagItem,
            this.toolStripMenuItem2});
            this.MenuTag.Location = new System.Drawing.Point(425, 0);
            this.MenuTag.Name = "MenuTag";
            this.MenuTag.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MenuTag.Size = new System.Drawing.Size(53, 48);
            this.MenuTag.TabIndex = 7;
            this.MenuTag.Text = "                            ";
            // 
            // MenuTagItem
            // 
            this.MenuTagItem.BackColor = System.Drawing.Color.Transparent;
            this.MenuTagItem.BackgroundImage = global::FileManager.Properties.Resources.star;
            this.MenuTagItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MenuTagItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3});
            this.MenuTagItem.ForeColor = System.Drawing.Color.Transparent;
            this.MenuTagItem.Name = "MenuTagItem";
            this.MenuTagItem.Size = new System.Drawing.Size(43, 44);
            this.MenuTagItem.Text = "     ";
            this.MenuTagItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(119, 26);
            this.toolStripMenuItem3.Text = "new";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(156, 44);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // OuterLeftEdge
            // 
            this.OuterLeftEdge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OuterLeftEdge.Location = new System.Drawing.Point(0, 0);
            this.OuterLeftEdge.Margin = new System.Windows.Forms.Padding(0);
            this.OuterLeftEdge.Name = "OuterLeftEdge";
            this.OuterLeftEdge.Size = new System.Drawing.Size(5, 555);
            this.OuterLeftEdge.TabIndex = 1;
            // 
            // OuterBottomEdge
            // 
            this.OuterBottomEdge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OuterBottomEdge.Location = new System.Drawing.Point(5, 555);
            this.OuterBottomEdge.Margin = new System.Windows.Forms.Padding(0);
            this.OuterBottomEdge.Name = "OuterBottomEdge";
            this.OuterBottomEdge.Size = new System.Drawing.Size(1230, 5);
            this.OuterBottomEdge.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1240, 560);
            this.Controls.Add(this.OuterTablePanel);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuNew;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "File Manager";
            this.Load += new System.EventHandler(this.FileManager_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.OuterTablePanel.ResumeLayout(false);
            this.MainTablePanel.ResumeLayout(false);
            this.DisplayTablePanel.ResumeLayout(false);
            this.NavigationTablePanel.ResumeLayout(false);
            this.NavigationTablePanel.PerformLayout();
            this.NavigationButtonTablePanel.ResumeLayout(false);
            this.AddressTablePanel.ResumeLayout(false);
            this.HeaderTablePanel.ResumeLayout(false);
            this.HeaderTablePanel.PerformLayout();
            this.ToolTablePanel.ResumeLayout(false);
            this.ToolTablePanel.PerformLayout();
            this.MenuNew.ResumeLayout(false);
            this.MenuNew.PerformLayout();
            this.MenuTag.ResumeLayout(false);
            this.MenuTag.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTablePanel;
        private System.Windows.Forms.TableLayoutPanel DisplayTablePanel;
        private CustomListView listView;
        private CustomTreeView treeView;
        private System.Windows.Forms.TableLayoutPanel NavigationTablePanel;
        private System.Windows.Forms.TextBox TxtBxSearch;
        private System.Windows.Forms.TableLayoutPanel NavigationButtonTablePanel;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Button BtnForward;
        private System.Windows.Forms.Button BtnRecent;
        private System.Windows.Forms.Button BtnParentFolder;
        private System.Windows.Forms.TableLayoutPanel StatusTablePanel;
        private System.Windows.Forms.TableLayoutPanel HeaderTablePanel;
        private System.Windows.Forms.Panel OuterLeftEdge;
        private System.Windows.Forms.Panel OuterBottomEdge;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colDateModified;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.ImageList imageListLarge;
        private RoundedTablePanel OuterTablePanel;
        private RoundedButton BtnExit;
        private RoundedButton BtnMinimize;
        private RoundedButton BtnMaximize;
        private RoundedTablePanel AddressTablePanel;
        private System.Windows.Forms.ComboBox CbAddress;
        private System.Windows.Forms.Button BtnGoRefresh;
        private System.Windows.Forms.TableLayoutPanel ToolTablePanel;
        private System.Windows.Forms.Button BtnCut;
        private System.Windows.Forms.Button BtnCopy;
        private System.Windows.Forms.Button BtnPaste;
        private System.Windows.Forms.Button BtnRename;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.ImageList imageListTreeView;
        private System.Windows.Forms.MenuStrip MenuNew;
        private System.Windows.Forms.Button BtnChangeTheme;
        private System.Windows.Forms.MenuStrip MenuTag;
        private System.Windows.Forms.ToolStripMenuItem MenuTagItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem MenuNewItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemNewFolder;
        private System.Windows.Forms.ToolStripMenuItem MenuItemNewTextFile;
        private System.Windows.Forms.Label LbTitle;
    }
}

