using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using webservicecsharpasmx.Helpers;
using webservicecsharpasmx.Models;
using webservicecsharpasmx.Repository;

namespace webservicecsharpasmx
{

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]

    public class WebService1 : WebService
    {
        private UserRepository _userRepository;

        public WebService1()
        {
            InitializeRepository();
        }

        private void InitializeRepository()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=test;User Id=test;Password=test";
            UserDataContext dataContext = new UserDataContext(connectionString);
            _userRepository = new UserRepository(dataContext);
        }

        [WebMethod]
        public XmlDocument AuthenticationUser(string entity)
        {
            try
            {
                User user = JsonConvert.DeserializeObject<User>(entity);
                User response = _userRepository.AuthenticationUser(user);
                XmlDocument xmlDoc = Utils.Instance.ConvertObjectToXmlDocument(response);
                return xmlDoc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string CreateUser(string entity)
        {
            try
            {
                User user = JsonConvert.DeserializeObject<User>(entity);
                _userRepository.CreateUser(user);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }


        [WebMethod]
        public XmlDocument GetUserById(int id)
        {
            try
            {
                User user = _userRepository.GetUserById(id);
                XmlDocument xmlDoc = Utils.Instance.ConvertObjectToXmlDocument(user);
                return xmlDoc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [WebMethod]
        public XmlDocument GetAllUsers()
        {
            try
            {
                List<User> users = _userRepository.GetAllUsers();
                XmlDocument xmlDoc = Utils.Instance.ConvertObjectToXmlDocument(users);
                return xmlDoc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string UpdateUser(string entity)
        {
            try
            {
                User user = JsonConvert.DeserializeObject<User>(entity);
                _userRepository.UpdateUser(user);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }


        [WebMethod]
        public string DeleteUserById(int id)
        {
            try
            {
                _userRepository.DeleteUser(id);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

    }
}
