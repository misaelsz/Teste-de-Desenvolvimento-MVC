using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBNE.BLL
{
    public static class Helper
    {
        public static string ConnectionValue(string name)
        {
           return ConfigurationManager.ConnectionStrings[name].ConnectionString.ToString();
        }
    }
}
