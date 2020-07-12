using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int count;
        public int Count
        {
            get => this.count;
            set => this.SetProperty(ref this.count, value);
        }
        private string pluginDir;
        public string PluginDir
        {
            get => this.pluginDir;
            set => this.SetProperty(ref this.pluginDir, value);
        }
        private string input;
        public string Input
        {
            get => this.input;
            set => this.SetProperty(ref this.input, value);
        }
        private string outstring;
        public string OutString
        {
            get => this.outstring;
            set => this.SetProperty(ref this.outstring, value);
        }
        private ObservableCollection<PluginBase.ModPlugin> plugins = new ObservableCollection<PluginBase.ModPlugin>();
        public ObservableCollection<PluginBase.ModPlugin> Plugins
        {
            get => this.plugins;
            set => this.SetProperty(ref this.plugins, value);
        }
        protected void SetProperty<T>(ref T property, T value, [CallerMemberName]string propertyName = "")
        {
            property = value;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
