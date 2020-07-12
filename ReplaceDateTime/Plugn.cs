using PluginBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceDateTime
{
    public class Plugn : IDev
    {
        public string PluginName => "时间替换";

        public string PluginDesc => "将参数插件替换为当前时间";

        public string PluginPara => "{DateTime}";

        public string Execute(string str)
        {
            return str.Replace(this.PluginPara, DateTime.Now.ToString());
        }
    }
}
