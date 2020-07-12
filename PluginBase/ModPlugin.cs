using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginBase
{
    public class ModPlugin
    {
        public IDev Plugin { get; }
        public string PluginName => this.Plugin?.PluginName;
        public string PluginDesc => this.Plugin?.PluginDesc;
        public string PluginPara => this.Plugin?.PluginPara;
        public ModPlugin(IDev plugin)
        {
            this.Plugin = plugin;
        }
        public string Execute(string str)
        {
            return this.Plugin?.Execute(str);
        }
    }
}
