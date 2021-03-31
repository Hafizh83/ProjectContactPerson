using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using WebInformation.Core;
using WebInformation.Models;

namespace WebInformation.DataAccess
{
    public class DAL
    {

        private List<DataFile> List_file;
        private static Contact_person person;

        internal List<DataFile> GenerateFile( string response)
        {
            Helper help = new Helper();
            List_file = new List<DataFile>();


            ORMDataContext db = new ORMDataContext(help.conStrODBC);
            db.Connection.Open();

            if(response =="")
            {
                var persons = (from q in db.Contact_persons
                               select q).AsQueryable().ToList();

                foreach (var item in persons)
                {

                    string _Nama = item.Nama;
                    string _Phone = item.Phone;
                    string _Email = item.Email;
                    string _Company = item.Company;
                    string _Country = item.Country;
                    string _Zip_code = item.Zip_code;
                    string _State = item.State_;
                    string _City = item.City;

                    List_file.Add(new DataFile
                    {

                        Nama = _Nama,
                        Phone = _Phone,
                        Email = _Email,
                        Company = _Company,
                        Country = _Country,
                        Zip_code = _Zip_code,
                        State = _State,
                        City = _City

                    });



                }
            }
            else
            {
                var persons = (from q in db.Contact_persons where q.Nama == response
                               select q).AsQueryable().ToList();

                foreach (var item in persons)
                {

                    string _Nama = item.Nama;
                    string _Phone = item.Phone;
                    string _Email = item.Email;
                    string _Company = item.Company;
                    string _Country = item.Country;
                    string _Zip_code = item.Zip_code;
                    string _State = item.State_;
                    string _City = item.City;

                    List_file.Add(new DataFile
                    {

                        Nama = _Nama,
                        Phone = _Phone,
                        Email = _Email,
                        Company = _Company,
                        Country = _Country,
                        Zip_code = _Zip_code,
                        State = _State,
                        City = _City

                    });



                }

            }
           

            db.Connection.Close();

            return List_file;
        }

        internal string Updatedata(string nama, string phone, string email, string company, string country, string zip, string state, string city)
        {
            string respon = "";
            Helper Help = new Helper();
            ORMDataContext db = new ORMDataContext(Help.conStrODBC);
            db.Connection.Open();
            var txOptions = new System.Transactions.TransactionOptions();
            txOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

            using (var tran = new TransactionScope(TransactionScopeOption.Required, txOptions))
            {
                try
                {
                    person = (from q in db.Contact_persons
                                where q.Nama == nama
                                select q).Take(1).FirstOrDefault();
                    person.Nama = nama;
                    person.Phone = phone;
                    person.Email = email;
                    person.Company = company;
                    person.Country = country;
                    person.Zip_code = zip;
                    person.State_ = state;
                    person.City = city;

                    db.SubmitChanges();
                    tran.Complete();
                    respon = "Sukses";
                }
                catch (Exception ex)
                {
                    string data = ex.Message;
                    tran.Dispose();
                    respon = "Error : " + data;
                }

            }

            db.Connection.Close();
            return respon;
        }

        internal string Insertdata(string nama, string phone, string email, string company, string country, string zip, string state, string city)
        {
            string response = "";
            #region Insert_MST_Spreed
            Helper Help = new Helper();
            ORMDataContext db = new ORMDataContext(Help.conStrODBC);
            db.Connection.Open();


            person = new Contact_person()
            {
                Nama = nama,
                Phone = phone,
                Email = email,
                Company = company,
                Country = country,
                Zip_code = zip,
                State_ = state,
                City = city


            };



            var txOptions = new System.Transactions.TransactionOptions();
            txOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

            using (var tran = new TransactionScope(TransactionScopeOption.Required, txOptions))
            {
                try
                {
                    db.Contact_persons.InsertOnSubmit(person);
                    db.SubmitChanges();
                    tran.Complete();
                    response = "Sukses";

                }
                catch (Exception ex)
                {
                    Console.WriteLine("==> Error Data Insert MST_Spreed  " + ex.Message);

                    string data = ex.Message;
                    tran.Dispose();
                    response = "Error : " + data;


                }

            }

            db.Connection.Close();

            return response;
            #endregion
        }
    }
}