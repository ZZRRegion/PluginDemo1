using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PluginBase
{
    public class PluginOperate
    {
        public string DirName { get; }
        public List<ModPlugin> PluginList = new List<ModPlugin>();

        public PluginOperate(string dir)
        {
            this.DirName = dir;
        }
        public bool LoadPlugin()
        {
            this.PluginList.Clear();
            DirectoryInfo directory = new DirectoryInfo(this.DirName);
            if (!directory.Exists)
            {
                return false;
            }
            foreach(FileInfo fileInfo in directory.GetFiles("*.dll"))
            {
                try
                {
                    byte[] buffer = File.ReadAllBytes(fileInfo.FullName);
                    Assembly assembly = Assembly.Load(buffer);
                    Type[] types = assembly.GetTypes();
                    foreach(Type type in types)
                    {
                        if(type.GetInterface(typeof(IDev).Name) != null)
                        {
                            this.PluginList.Add(new ModPlugin(Activator.CreateInstance(type) as IDev));
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return true;
        }
        public string Execute(string str)
        {
            foreach(var item in this.PluginList)
            {
                str = item.Execute(str);
            }
            return str;
        }
    }
}
