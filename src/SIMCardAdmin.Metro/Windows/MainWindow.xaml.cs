using MahApps.Metro.Controls;
using SIMCardAdmin.Core.Database;
using SIMCardAdmin.Metro.ViewModels.SIMCard;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;

namespace SIMCardAdmin.Metro.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        #region Private fields
        private const string applicationName = "SIM Card Admin";
        private static readonly Version applicationVersion = Assembly.GetExecutingAssembly().GetName().Version;
        private static readonly string applicationVersionName = string.Format("v{0}.{1}", applicationVersion.Major, applicationVersion.Minor, applicationVersion.Build, applicationVersion.Revision);
        private static readonly string applicationVersionVerboseName = string.Format("v{0}.{1} Patch {2} Build {3}", applicationVersion.Major, applicationVersion.Minor, applicationVersion.Build, applicationVersion.Revision);
        private bool _isFullscreen;
        private bool _isClosing;
        private WindowState _lastState;
        private DatabaseContext db = new DatabaseContext();
        #endregion
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);

        public MainWindow()
        {
            _isClosing = false;
            InitializeComponent();
        }

        #region GUI event delegates

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            PopulateList();
            UpdateTitle();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void PopulateList()
        {
            SIMCardListView viewModel = new SIMCardListView();
            var simCardsQuery = db.SIMCards;
            viewModel.SIMCards = simCardsQuery.Select(simcard => new SimCardListItem
            {
                SIMCardID = simcard.SIMCardID,
                TrackingCode = simcard.TrackingCode,
                NetworkID = simcard.NetworkID,
                NetworkName = simcard.Network.Name,
                ICCID = simcard.ICCID,
                MSISDN = simcard.MSISDN,
                GroupID = simcard.GroupID,
                GroupName = simcard.Group.Name,
            }).ToList();

            SIMCardList.DataContext = viewModel.SIMCards;
        }

        #endregion

        #region Private helpers

        private void UpdateTitle()
        {
            Title = string.Format("{0} ({1})", applicationName, applicationVersionName);
        }

        #endregion
    }
}
