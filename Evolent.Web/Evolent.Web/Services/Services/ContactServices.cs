using Evolent.Web.Models;
using Evolent.Web.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Script.Serialization;

namespace Evolent.Web.Services.Services
{
    /// <summary>
    /// <see cref="ContactServices"/> class which implements <see cref="IContactServices"/> interface.
    /// </summary>
    public class ContactServices : IContactServices
    {
        /// <summary>
        /// Declare httpclient for calling webapi
        /// </summary>
        HttpClient client;
        //The URL of the WEB API Service
        string url = ConfigurationManager.AppSettings["webapibaseurl"];

        #region Constructor

        public ContactServices()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #endregion

        public List<VMContact> GetContacts()
        {
            List<VMContact> lstcontacts = new List<VMContact>();
            try
            {
                string strUri = string.Format("{0}{1}", url, "Contact");
                HttpResponseMessage responseMessage = client.GetAsync(strUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    lstcontacts = JsonConvert.DeserializeObject<List<VMContact>>(responseData);
                }

            }
            catch (Exception)
            {

            }

            return lstcontacts;
        }

        public VMContact GetContactById(int ContactID)
        {
            VMContact contact = new VMContact();
            try
            {
                string strUri = string.Format("{0}{1}/{2}", url, "Contact", ContactID);
                HttpResponseMessage responseMessage = client.GetAsync(strUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                    contact = JsonConvert.DeserializeObject<VMContact>(responseData);
                }

            }
            catch (Exception)
            {

                throw;
            }

            return contact;
        }

        public int CreateContact(VMContact ContactEntity)
        {
            int result = 0;
            try
            {
                string strUri = string.Format("{0}{1}", url, "Contact");
                HttpResponseMessage responseMessage = client.PostAsync(strUri, new StringContent(
                new JavaScriptSerializer().Serialize(ContactEntity), Encoding.UTF8, "application/json")).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    result = 1;
                }
            }
            catch (Exception)
            {

            }
            return result;
        }

        public int UpdateContact(VMContact ContactEntity)
        {
            int result = 0;
            try
            {
                string strUri = string.Format("{0}{1}", url, "Contact");
                HttpResponseMessage responseMessage = client.PutAsync(strUri, new StringContent(
                new JavaScriptSerializer().Serialize(ContactEntity), Encoding.UTF8, "application/json")).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    result = 1;
                }
            }
            catch (Exception)
            {

            }
            return result;
        }

        public int DeleteContact(int ContactID)
        {
            int result = 0;
            try
            {
                string strUri = string.Format("{0}{1}/{2}", url, "Contact", ContactID);
                HttpResponseMessage responseMessage = client.DeleteAsync(strUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    result = 1;
                }
            }
            catch (Exception)
            {

            }
            return result;
        }
    }
}