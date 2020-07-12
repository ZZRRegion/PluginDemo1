using PluginBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LetterUpper
{
    public class Plugin : IDev
    {
        public string PluginName => "字母转大写";

        public string PluginDesc => "将指定部分";

        public string PluginPara => "{Upper}(待替换字符串)";

        public string Execute(string str)
        {
            Regex regex = new Regex("\\{Upper\\}\\((.*?)\\)");
            Match match = regex.Match(str);
            while (match.Success)
            {
                str = regex.Replace(str, match.Groups[1].Value.ToUpper());

                match = match.NextMatch();
            }
            return str;
        }
    }
}
