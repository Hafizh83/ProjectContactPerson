using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebInformation.DataAccess;
using WebInformation.Models;

namespace WebInformation.Views.Home
{
    public partial class Default : System.Web.UI.Page
    {
        DAL dal = new DAL();
        Helper help = new Helper();
        private bool Editdata;
        public static List<DataFile> datafile;
        private string ParmData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Param1"] != null && Request.QueryString["Param1"] != string.Empty)
            {
                 Editdata = true;
                 datafile = new List<DataFile>();
                 ParmData = Request.QueryString["Param1"];
                 datafile = dal.GenerateFile(ParmData);
                foreach (var itm in datafile)
                {
                    TbNama.Text = itm.Nama;
                    TbPhone.Text = itm.Phone;
                    TbEmail.Text = itm.Email;
                    TbCompany.Text = itm.Company;
                    TbCountry.Text = itm.Country;
                    TbZip.Text = itm.Zip_code;
                    TbState.Text = itm.State;
                    TbCity.Text = itm.City;

                   
                }

                PropertyInfo isreadonly =   typeof(System.Collections.Specialized.NameValueCollection).GetProperty( "IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                isreadonly.SetValue(this.Request.QueryString, false, null);
                this.Request.QueryString.Remove("Param1");

            }
            if (Request.QueryString["Param2"] != null && Request.QueryString["Param2"] != string.Empty)
            {

               var Proses = Request.QueryString["Param2"];

                if(Proses =="Edit")
                {
                    Editdata = true;
                }
                else
                {
                    Editdata = false;
                }

                
            }


        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    if (FileUploadControl.PostedFile.ContentType == "image/jpeg")
                    {
                        if (FileUploadControl.PostedFile.ContentLength < 102400)
                        {
                            string filename = Path.GetFileName(FileUploadControl.FileName);
                            FileUploadControl.SaveAs(Server.MapPath("~/") + filename);
                            StatusLabel.Text = "Upload status: File uploaded!";
                        }
                        else
                            StatusLabel.Text = "Upload status: The file has to be less than 100 kb!";
                    }
                    else
                        StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ContactInfoList.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string nama = TbNama.Text;
            string phone = TbPhone.Text;
            string email = TbEmail.Text;
            string company = TbCompany.Text;
            string country = TbCountry.Text;
            string zip = TbZip.Text;
            string state = TbState.Text;
            string city = TbCity.Text;

          

            if (Editdata == true)
            {
                string Hasil = dal.Updatedata(nama, phone, email, company, country, zip, state, city);
                Response.Write("<script>alert('Proses Update = "+ Hasil + "');</script>");
            }
            else
            {
                string Hasil = dal.Insertdata(nama, phone, email, company, country, zip, state, city);
                Response.Write("<script>alert('Proses Update = " + Hasil + "');</script>");

            }
           
        }



       

    }
}