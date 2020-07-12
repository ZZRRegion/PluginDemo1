using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using PluginBase;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private PluginOperate plugin = null;
        private MainWindowViewModel viewmodel;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this.viewmodel = new MainWindowViewModel();
        }

        private void btnOpenDir_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true,
                Title = "请选择插件所在文件夹",
            };
            var result = dialog.ShowDialog(this);
            if(result == CommonFileDialogResult.Ok)
            {
                this.viewmodel.PluginDir = dialog.FileName;
                this.plugin = new PluginOperate(this.viewmodel.PluginDir);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string dir = System.IO.Path.Combine(Environment.CurrentDirectory, "plugins");
            if (Directory.Exists(dir))
            {
                this.viewmodel.PluginDir = dir;
                this.plugin = new PluginOperate(dir);
            }
        }

        private void btnLoadPlugin_Click(object sender, RoutedEventArgs e)
        {
            this.viewmodel.Plugins.Clear();
            if (this.plugin != null)
            {
                if (!this.plugin.LoadPlugin())
                {
                    MessageBox.Show("插件加载失败");
                }
                else
                {
                    if(this.plugin.PluginList.Count > 0)
                    {
                        this.viewmodel.Count = this.plugin.PluginList.Count;
                        this.plugin.PluginList.ForEach(item => this.viewmodel.Plugins.Add(item));
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                MessageBox.Show("未选择插件文件夹");
            }
        }

        private void btnTxt_Click(object sender, RoutedEventArgs e)
        {
            if(this.plugin != null)
            {
                this.viewmodel.OutString = this.plugin.Execute(this.viewmodel.Input);
            }
            else
            {
                MessageBox.Show("未选择插件文件夹");
            }
        }
    }
}
