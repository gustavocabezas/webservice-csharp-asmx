using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Web.Services;
using webservicecsharpasmx.Models;
using webservicecsharpasmx.Repository;


namespace webservicecsharpasmx
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]

    public class WebService1 : WebService
    {
        private UserRepository _userRepository;

        public WebService1()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=test;User Id=test;Password=test";
            UserDataContext dataContext = new UserDataContext(connectionString);
            _userRepository = new UserRepository(dataContext);
        }

        [WebMethod]
        public string CreateUser(string userJson)
        {
            try
            {
                User user = JsonConvert.DeserializeObject<User>(userJson);
                _userRepository.InsertUser(user);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        [WebMethod]
        public string UpdateUser(string userJson)
        {
            try
            {
                User user = JsonConvert.DeserializeObject<User>(userJson);
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

        /*[ScriptMethod(ResponseFormat = ResponseFormat.Json)]*/
        [WebMethod]
        public string GetUserById(int id)
        {
            try
            {
                User user = _userRepository.GetUserById(id);
                return JsonConvert.SerializeObject(user);
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        [WebMethod]
        public string GetAllUsers()
        {
            try
            {
                List<User> users = _userRepository.GetAllUsers();
                return JsonConvert.SerializeObject(users);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
