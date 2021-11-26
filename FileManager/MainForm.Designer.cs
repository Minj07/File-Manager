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
            this.roundedButton1 = new FileManager.RoundedButton();
            this.roundedButton2 = new FileManager.RoundedButton();
            this.roundedButton3 = new FileManager.RoundedButton();
            this.OuterLeftEdge = new System.Windows.Forms.Panel();
            this.OuterBottomEdge = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.OuterTablePanel.SuspendLayout();
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
            this.imageListLarge.Images.SetKeyName(1, "blank file");
            this.imageListLarge.Images.SetKeyName(2, "");
            this.imageListLarge.Images.SetKeyName(3, "");
            this.imageListLarge.Images.SetKeyName(4, "");
            this.imageListLarge.Images.SetKeyName(5, "");
            this.imageListLarge.Images.SetKeyName(6, "");
            this.imageListLarge.Images.SetKeyName(7, "");
            this.imageListLarge.Images.SetKeyName(8, "");
            this.imageListLarge.Images.SetKeyName(9, "");
            this.imageListLarge.Images.SetKeyName(10, "");
            this.imageListLarge.Images.SetKeyName(11, "");
            this.imageListLarge.Images.SetKeyName(12, "");
            this.imageListLarge.Images.SetKeyName(13, "");
            // 
            // imageListSmall
            // 
            this.imageListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSmall.ImageStream")));
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSmall.Images.SetKeyName(0, "folder");
            this.imageListSmall.Images.SetKeyName(1, "blank file");
            this.imageListSmall.Images.SetKeyName(2, "");
            this.imageListSmall.Images.SetKeyName(3, "");
            this.imageListSmall.Images.SetKeyName(4, "");
            this.imageListSmall.Images.SetKeyName(5, "");
            this.imageListSmall.Images.SetKeyName(6, "");
            this.imageListSmall.Images.SetKeyName(7, "");
            this.imageListSmall.Images.SetKeyName(8, "");
            this.imageListSmall.Images.SetKeyName(9, "");
            this.imageListSmall.Images.SetKeyName(10, "");
            this.imageListSmall.Images.SetKeyName(11, "");
            this.imageListSmall.Images.SetKeyName(12, "");
            this.imageListSmall.Images.SetKeyName(13, "");
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
            this.OuterTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.OuterTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OuterTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.OuterTablePanel.Controls.Add(this.MainTablePanel, 1, 0);
            this.OuterTablePanel.Controls.Add(this.OuterLeftEdge, 0, 0);
            this.OuterTablePanel.Controls.Add(this.OuterBottomEdge, 1, 1);
            this.OuterTablePanel.Controls.Add(this.panel1, 2, 0);
            this.OuterTablePanel.CornerRadius = 40;
            this.OuterTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OuterTablePanel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.OuterTablePanel.Location = new System.Drawing.Point(0, 0);
            this.OuterTablePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OuterTablePanel.Name = "OuterTablePanel";
            this.OuterTablePanel.RowCount = 2;
            this.OuterTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OuterTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
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
            this.MainTablePanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainTablePanel.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MainTablePanel.Location = new System.Drawing.Point(27, 0);
            this.MainTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTablePanel.Name = "MainTablePanel";
            this.MainTablePanel.RowCount = 6;
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.MainTablePanel.Size = new System.Drawing.Size(1186, 535);
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
            this.DisplayTablePanel.Location = new System.Drawing.Point(0, 151);
            this.DisplayTablePanel.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.DisplayTablePanel.Name = "DisplayTablePanel";
            this.DisplayTablePanel.RowCount = 1;
            this.DisplayTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DisplayTablePanel.Size = new System.Drawing.Size(1186, 347);
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
            this.listView.Size = new System.Drawing.Size(969, 347);
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
            this.treeView.Size = new System.Drawing.Size(213, 347);
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
            this.NavigationTablePanel.Location = new System.Drawing.Point(0, 98);
            this.NavigationTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.NavigationTablePanel.Name = "NavigationTablePanel";
            this.NavigationTablePanel.RowCount = 1;
            this.NavigationTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.NavigationTablePanel.Size = new System.Drawing.Size(1186, 49);
            this.NavigationTablePanel.TabIndex = 3;
            // 
            // TxtBxAddress
            // 
            this.TxtBxAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtBxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxAddress.Location = new System.Drawing.Point(214, 5);
            this.TxtBxAddress.Margin = new System.Windows.Forms.Padding(1, 5, 3, 5);
            this.TxtBxAddress.Name = "TxtBxAddress";
            this.TxtBxAddress.Size = new System.Drawing.Size(569, 36);
            this.TxtBxAddress.TabIndex = 1;
            // 
            // TxtBxSearch
            // 
            this.TxtBxSearch.BackColor = System.Drawing.SystemColors.Window;
            this.TxtBxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtBxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxSearch.Location = new System.Drawing.Point(789, 5);
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
            this.BtnBack.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
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
            this.BtnForward.Image = global::FileManager.Properties.Resources.right_arrow;
            this.BtnForward.Location = new System.Drawing.Point(57, 4);
            this.BtnForward.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnForward.Name = "BtnForward";
            this.BtnForward.Size = new System.Drawing.Size(45, 41);
            this.BtnForward.TabIndex = 1;
            this.BtnForward.UseVisualStyleBackColor = true;
            // 
            // BtnRecent
            // 
            this.BtnRecent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnRecent.FlatAppearance.BorderSize = 0;
            this.BtnRecent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRecent.Image = global::FileManager.Properties.Resources.expand_arrow;
            this.BtnRecent.Location = new System.Drawing.Point(110, 4);
            this.BtnRecent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnRecent.Name = "BtnRecent";
            this.BtnRecent.Size = new System.Drawing.Size(45, 41);
            this.BtnRecent.TabIndex = 2;
            this.BtnRecent.UseVisualStyleBackColor = true;
            // 
            // BtnParentFolder
            // 
            this.BtnParentFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnParentFolder.FlatAppearance.BorderSize = 0;
            this.BtnParentFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnParentFolder.Image = global::FileManager.Properties.Resources.up_arrow;
            this.BtnParentFolder.Location = new System.Drawing.Point(163, 4);
            this.BtnParentFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnParentFolder.Name = "BtnParentFolder";
            this.BtnParentFolder.Size = new System.Drawing.Size(46, 41);
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
            this.StatusTablePanel.Size = new System.Drawing.Size(1186, 37);
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
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.HeaderTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.HeaderTablePanel.Controls.Add(this.roundedButton1, 0, 0);
            this.HeaderTablePanel.Controls.Add(this.roundedButton2, 1, 0);
            this.HeaderTablePanel.Controls.Add(this.roundedButton3, 2, 0);
            this.HeaderTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeaderTablePanel.Location = new System.Drawing.Point(0, 12);
            this.HeaderTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.HeaderTablePanel.Name = "HeaderTablePanel";
            this.HeaderTablePanel.RowCount = 1;
            this.HeaderTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.HeaderTablePanel.Size = new System.Drawing.Size(1186, 37);
            this.HeaderTablePanel.TabIndex = 5;
            // 
            // roundedButton1
            // 
            this.roundedButton1.BackColor = System.Drawing.Color.Red;
            this.roundedButton1.BorderColor = System.Drawing.Color.Red;
            this.roundedButton1.BorderSize = 1F;
            this.roundedButton1.CornerRadius = 5;
            this.roundedButton1.Location = new System.Drawing.Point(3, 7);
            this.roundedButton1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(16, 16);
            this.roundedButton1.TabIndex = 0;
            this.roundedButton1.UseVisualStyleBackColor = false;
            // 
            // roundedButton2
            // 
            this.roundedButton2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.roundedButton2.BorderColor = System.Drawing.Color.Yellow;
            this.roundedButton2.BorderSize = 1F;
            this.roundedButton2.CornerRadius = 5;
            this.roundedButton2.Location = new System.Drawing.Point(30, 7);
            this.roundedButton2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.roundedButton2.Name = "roundedButton2";
            this.roundedButton2.Size = new System.Drawing.Size(16, 16);
            this.roundedButton2.TabIndex = 1;
            this.roundedButton2.UseVisualStyleBackColor = false;
            // 
            // roundedButton3
            // 
            this.roundedButton3.BackColor = System.Drawing.Color.Lime;
            this.roundedButton3.BorderColor = System.Drawing.Color.Lime;
            this.roundedButton3.BorderSize = 1F;
            this.roundedButton3.CornerRadius = 5;
            this.roundedButton3.Location = new System.Drawing.Point(57, 7);
            this.roundedButton3.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.roundedButton3.Name = "roundedButton3";
            this.roundedButton3.Size = new System.Drawing.Size(16, 16);
            this.roundedButton3.TabIndex = 2;
            this.roundedButton3.UseVisualStyleBackColor = false;
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
            this.OuterBottomEdge.Size = new System.Drawing.Size(1186, 25);
            this.OuterBottomEdge.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1216, 2);
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
            this.ClientSize = new System.Drawing.Size(1240, 560);
            this.Controls.Add(this.OuterTablePanel);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "File Manager";
            this.OuterTablePanel.ResumeLayout(false);
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
        private RoundedTablePanel OuterTablePanel;
        private RoundedButton roundedButton1;
        private RoundedButton roundedButton2;
        private RoundedButton roundedButton3;
    }
}

