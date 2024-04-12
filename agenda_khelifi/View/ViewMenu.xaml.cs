using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace agenda_khelifi.View
{
    /// <summary>
    /// Logique d'interaction pour ViewMenu.xaml
    /// </summary>
    public partial class ViewMenu : UserControl
    {
        public ViewMenu()
        {
            InitializeComponent();
            TB_Host.Text = ConfigurationManager.AppSettings["host"];
            TB_user.Text = ConfigurationManager.AppSettings["user"];
            TB_password.Text = ConfigurationManager.AppSettings["password"];
        }

        private void Button_change(object sender, RoutedEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["host"].Value = TB_Host.Text;
            config.AppSettings.Settings["user"].Value = TB_user.Text;
            config.AppSettings.Settings["password"].Value = TB_password.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

    }
}
