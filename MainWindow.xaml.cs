using BeautySolutions.View.ViewModel;
using MaterialDesignThemes.Wpf;
using System;
using KMCCC.Authentication;
using System.Collections.Generic;
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
using KMCCC.Launcher;
using Panuon.UI.Silver;
using System.Diagnostics;

namespace ANGCRAFT
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : WindowX
    {
        public MainWindow()
        {
            InitializeComponent();
            KMCCC.Launcher.Version[] versions = Core.GetVersions().ToArray();
            versionsList.ItemsSource = versions;

            

            var menuRegister = new List<SubItem>();
            menuRegister.Add(new SubItem("Customer"));
            menuRegister.Add(new SubItem("Providers"));
            menuRegister.Add(new SubItem("Employees"));
            menuRegister.Add(new SubItem("Products"));
            var item6 = new ItemMenu("Register", menuRegister, PackIconKind.Register);

            var menuSchedule = new List<SubItem>();
            menuSchedule.Add(new SubItem("Services"));
            menuSchedule.Add(new SubItem("Meetings"));
            var item1 = new ItemMenu("Appointments", menuSchedule, PackIconKind.Schedule);

            var menuReports = new List<SubItem>();
            menuReports.Add(new SubItem("Customers"));
            menuReports.Add(new SubItem("Providers"));
            menuReports.Add(new SubItem("Products"));
            menuReports.Add(new SubItem("Stock"));
            menuReports.Add(new SubItem("Sales"));
            var item2 = new ItemMenu("Reports", menuReports, PackIconKind.FileReport);

            var menuExpenses = new List<SubItem>();
            menuExpenses.Add(new SubItem("Fixed"));
            menuExpenses.Add(new SubItem("Variable"));
            var item3 = new ItemMenu("Expenses", menuExpenses, PackIconKind.ShoppingBasket);

            var menuFinancial = new List<SubItem>();
            menuFinancial.Add(new SubItem("Cash flow"));
            var item4 = new ItemMenu("Financial", menuFinancial, PackIconKind.ScaleBalance);

            var item0 = new ItemMenu("Dashboard", new UserControl(), PackIconKind.ViewDashboard);

          /*Menu.Children.Add(new UserControl1(item0));
            Menu.Children.Add(new UserControl1(item6));
            Menu.Children.Add(new UserControl1(item1));
            Menu.Children.Add(new UserControl1(item2));
            Menu.Children.Add(new UserControl1(item3));
            Menu.Children.Add(new UserControl1(item4));*/
        }
        public static LauncherCore Core = LauncherCore.Create();
        public static KMCCC.Launcher.Version[] versions;


        public void GameStart() 
        {
            if(versionsList.Text != string.Empty)
            {
                try
                {
                    Core.JavaPath = javaCombo.Text;
                    //Core.JavaPath = @"D:\Java\bin\javaw.exe";
                    var ver = (KMCCC.Launcher.Version)versionsList.SelectedItem;
                    var result = Core.Launch(new LaunchOptions
                    {
                        Version = ver, //Ver为Versions里你要启动的版本名字
                        MaxMemory = Convert.ToInt32( MB.Text ), //最大内存，int类型
                        Authenticator = new OfflineAuthenticator(name.Text),
                        //Authenticator = new YggdrasilLogin("ipmcqrint@outlook.com", "123QWE-cv", true), // 正版启动，最后一个为是否twitch登录
                        Mode = LaunchMode.MCLauncher, //启动模式，这个我会在后面解释有哪几种
                        //Server = new ServerInfo { Address = "服务器IP地址", Port = "服务器端口" }, //设置启动游戏后，自动加入指定IP的服务器，可以不要
                        Size = new WindowSize { Height = 768, Width = 1280 } //设置窗口大小，可以不要
                    });
            if(!result.Success)
            {
                switch(result.ErrorType)
                {
                    case ErrorType.NoJAVA:
                        MessageBoxX.Show("java错误,详细信息"+result.ErrorType,"错误");
                        break;
                    case ErrorType.AuthenticationFailed:
                        MessageBoxX.Show("登录错误,详细信息" + result.ErrorType, "错误");
                        break;
                    case ErrorType.UncompressingFailed:
                        MessageBoxX.Show("文件错误,详细信息" + result.ErrorType, "错误");
                        break;
                    default:
                        MessageBoxX.Show ("未知错误,详细信息" + result.ErrorType, "错误");
                        break;
                }
            }
                }
                catch
                {
                    MessageBoxX.Show("启动失败", "错误");
                }
            }
            

        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            GameStart();
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void versionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void javaCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
    }
}
