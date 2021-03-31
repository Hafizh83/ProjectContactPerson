using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebInformation.Models
{
    public class Helper
    {

        #region Connection

        public string conStrSql = System.Configuration.ConfigurationManager.ConnectionStrings["MyDbSql"].ConnectionString;
        public string conStrODBC = System.Configuration.ConfigurationManager.ConnectionStrings["MyODBC"].ConnectionString;
      

        #endregion
    }
}