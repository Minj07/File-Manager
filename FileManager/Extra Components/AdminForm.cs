using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using FileManager.Properties;
using System.Threading;

namespace FileManager
{
    public partial class AdminForm : Form
    {
        private Size NormalSize;
        private Point mouseDownLocation; //Use for dragging the form
        public Theme currentTheme;
        private Database.User activeUser;
        private Database database = new Database();
        private Icon adminIcon;
        private Icon userIcon;
        private List<Icon> ActionIcons;



        #region Initialize
        public AdminForm(Database.User user)
        {
            this.activeUser = user;
            this.DoubleBuffered = true;
            Theme dark = new Theme(Color.FromArgb(30, 30, 30));

            currentTheme = dark;
            InitializeComponent();

            adminIcon = Icon.FromHandle(Theme.ResizeImage(Resources.admin, 16, 16).GetHicon());
            userIcon = Icon.FromHandle(Theme.ResizeImage(Resources.user, 16, 16).GetHicon());
            ActionIcons = new List<Icon>();
            ActionIcons.Add(Icon.FromHandle(Theme.ResizeImage(Resources.cut, 16, 16).GetHicon()));
            ActionIcons.Add(Icon.FromHandle(Theme.ResizeImage(Resources.copy, 16, 16).GetHicon()));
            ActionIcons.Add(Icon.FromHandle(Theme.ResizeImage(Resources.rename, 16, 16).GetHicon()));
            ActionIcons.Add(Icon.FromHandle(Theme.ResizeImage(Resources.trash, 16, 16).GetHicon()));
            ActionIcons.Add(Icon.FromHandle(Theme.ResizeImage(Resources.merge, 16, 16).GetHicon()));
            ActionIcons.Add(Icon.FromHandle(Theme.ResizeImage(Resources.new_file, 16, 16).GetHicon()));

            this.MaximizedBounds = Screen.GetWorkingArea(this);

            HeaderTablePanel.MouseDown += new MouseEventHandler(HeaderTablePanel_MouseDown);
            LbTitle.MouseDown += new MouseEventHandler(HeaderTablePanel_MouseDown);
            HeaderTablePanel.MouseMove += new MouseEventHandler(HeaderTablePanel_MouseMove);

            BtnExit.Click += new EventHandler(BtnExit_Click);
            BtnMinimize.Click += new EventHandler(BtnMinimize_Click);
            BtnMaximize.Click += new EventHandler(BtnMaximize_Click);

            BtnToggleAdmin.Click += BtnToggleAdmin_Click;
            BtnDelete.Click += BtnDelete_Click;

            this.Resize += new EventHandler(MainForm_SizeChanged);

            BtnToggleAdmin.Enabled = activeUser.isAdministrator;
            this.LsViewUsers.ItemSelectionChanged += LsViewUsers_ItemSelectionChanged;

            ReloadTheme();
            UpdateLsViewUsers();
            NormalSize = this.Size;
        }




        #endregion

        #region Flags
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                OuterTablePanel.Rounded = true;
                this.BtnMaximize.Image = Resources.maximize;
                NormalSize = this.Size;
            }
            else
            {
                OuterTablePanel.Rounded = false;
                this.BtnMaximize.Image = Resources.shrink;

            }
            OuterTablePanel.Refresh();
        }

        #endregion

        #region Control Buttons
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }


        #endregion

        #region Theme
        public void ReloadTheme()
        {
            //Form
            this.BackColor = currentTheme.Unused;
            OuterTablePanel.BackColor = currentTheme.Unused;
            this.TransparencyKey = currentTheme.Unused;
            OuterTablePanel.TrueBackColor = currentTheme.darkerMain;
            this.MainPanel.BackColor = currentTheme.lighterMain;
            this.LbTitle.ForeColor = currentTheme.text;
            this.LbTitle.Font = this.Font;

            foreach (Control c in this.Controls)
            {
                c.Font = this.Font;
            }

            foreach (Button btn in new Button[] {BtnToggleAdmin, BtnDelete})
            {
                btn.BackColor = currentTheme.lighterMain;
                btn.FlatAppearance.MouseOverBackColor = currentTheme.main;
            }

            foreach (ListView ls in new ListView[] {LsViewUsers, LsViewActivites} )
            {
                ls.BackColor = currentTheme.main;
                ls.ForeColor = currentTheme.text;
            }

            this.Refresh();

        }

        #endregion

        #region Dragging
        private void HeaderTablePanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownLocation = new Point(-e.X, -e.Y);
        }

        private void HeaderTablePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mouseOffset = Control.MousePosition;
                if (MousePosition.Y < 50 && this.WindowState == FormWindowState.Normal)
                {
                    mouseOffset.Offset(mouseDownLocation.X, mouseDownLocation.Y);
                    this.Location = mouseOffset;
                    this.WindowState = FormWindowState.Maximized;
                }
                else if (MousePosition.Y >= 50 && this.WindowState == FormWindowState.Maximized)
                {
                    mouseDownLocation.X = -NormalSize.Width / 2;
                    mouseOffset.Offset(mouseDownLocation.X, mouseDownLocation.Y);
                    this.Location = mouseOffset;
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    mouseOffset.Offset(mouseDownLocation.X, mouseDownLocation.Y);
                    this.Location = mouseOffset;
                }
            }
        }



        #endregion

        #region Display

        private void UpdateLsViewUsers()
        {
            if (LsViewUsers.Items.Count != 0)
            {
                LsViewUsers.Items.Clear();
            }

            foreach (Database.User user in Database.Users.Where(u => (this.activeUser.isAdministrator||u.uid==this.activeUser.uid) ))
            {
                ListViewItem item = new ListViewItem();
                item.Text = user.uid.ToString();
                item.SubItems.Add(user.username);
                Icon icon = (user.isAdministrator ? adminIcon : userIcon);
                item.Tag = new CustomListView.ListViewItemTag(null, icon, icon);
                LsViewUsers.Items.Add(item);
            }
        }

        private void LsViewUsers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Database.User user = Database.GetUser(int.Parse(e.Item.Text));
            UpdateLsViewActivity(user);
        }

        private void UpdateLsViewActivity(Database.User user)
        {
            if (LsViewActivites.Items.Count != 0)
            {
                LsViewActivites.Items.Clear();
            }

            foreach (Database.User.Activity activity in user.activities)
            {
                ListViewItem item = new ListViewItem();
                item.Text = activity.actionType.ToString();
                item.SubItems.Add(activity.source);
                item.SubItems.Add(activity.destination);
                item.SubItems.Add(activity.time.ToString("G"));
                Icon icon = ActionIcons[(int) activity.actionType];
                item.Tag = new CustomListView.ListViewItemTag(null, icon, icon);
                LsViewActivites.Items.Add(item);
            }
        }

        #endregion

        #region Main Function
        
        private void BtnToggleAdmin_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in LsViewUsers.SelectedItems)
            {
                Database.User user = Database.GetUser(int.Parse(item.Text));
                user.ChangePriviliege(!user.isAdministrator);
            }
            
            UpdateLsViewUsers();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in LsViewUsers.SelectedItems)
            {
                Database.User user = Database.GetUser(int.Parse(item.Text));
                user.Delete();
            }
            UpdateLsViewUsers();
        }

        #endregion
    }


}

