using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebInformation.DataAccess;
using WebInformation.Models;

namespace WebInformation
{
    public partial class ContactInfoList : System.Web.UI.Page
    {
        DAL dal = new DAL();
        Helper help = new Helper();
        public static List<DataFile> datafile;
        DataTable dataTable = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewContactList.Font.Size = FontUnit.Medium;
            string Box1 = GenerateListData();
        }

        private string GenerateListData()
        {
            string respon = "";

            datafile = new List<DataFile>();

            dataTable.Columns.AddRange(new DataColumn[] {
                        new DataColumn("Nama"),
                        new DataColumn("Phone"),
                        new DataColumn("Email"),
                        new DataColumn("Company"),
                        new DataColumn("Country"),
                        new DataColumn("Zip_code"),
                        new DataColumn("State"),
                        new DataColumn("City")
                        
            });

            datafile = dal.GenerateFile(respon);


            foreach (var itm in datafile)
            {
                dataTable.Rows.Add(new object[] { itm.Nama,
                                                  itm.Phone,
                                                  itm.Email,
                                                  itm.Company,
                                                  itm.Country,
                                                  itm.Zip_code,
                                                  itm.State,
                                                  itm.City,
                                                  
                });
            }


            GridViewContactList.DataSource = dataTable;
            GridViewContactList.DataBind();

            return respon;
        }

        protected void LinkBtn_Click(object sender, EventArgs e)
        {
            string data = (sender as LinkButton).CommandArgument;
            string param2Variable = "Edit";
                       
            //Response.Redirect("~/ContactInfo.aspx?Nama=" + data);

            Response.Redirect("~/ContactInfo.aspx?Param1=" + data + "&param2=" + param2Variable);



        }

        protected void AddContact_Click(object sender, EventArgs e)
        {
            string param2Variable = "Insert";
            Response.Redirect("~/ContactInfo.aspx?param2=" + param2Variable);
        }
    }
}