using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginBase
{
    public interface IDev
    {
        string PluginName { get; }
        string PluginDesc { get; }
        string PluginPara { get; }
        string Execute(string str);
    }
}
