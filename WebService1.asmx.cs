using Newtonsoft.Json;
using System;
using System.Web.Services;
using WebServiceCSharp.Models;
using WebServiceCSharp.Repository;


namespace WebServiceCSharp
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : WebService
    {
        private UserRepository _userRepository;

        public WebService1()
        {
            // Configurar la cadena de conexión
            string connectionString = "Data Source=localhost;Initial Catalog=test;User Id=test;Password=test";

            // Crear una instancia del contexto de base de datos
            UserDataContext dataContext = new UserDataContext(connectionString);

            // Crear una instancia del repositorio de usuarios
            _userRepository = new UserRepository(dataContext);
        }

        [WebMethod]
        public string CreateUser(string userJson)
        {
            try
            {
                User user = JsonConvert.DeserializeObject<User>(userJson);
                _userRepository.InsertUser(user);
                return "Success"; // Inserción exitosa
            }
            catch (Exception ex)
            {
                // Manejo de excepción
                // Puedes agregar lógica adicional de manejo de errores aquí si lo deseas
                return ex.Message.ToString(); // Error al realizar la inserción
            }
        }

        [WebMethod]
        public string UpdateUser(string userJson)
        {
            try
            {
                User user = JsonConvert.DeserializeObject<User>(userJson);
                _userRepository.UpdateUser(user);
                return "Success"; // Inserción exitosa
            }
            catch (Exception ex)
            {
                // Manejo de excepción
                // Puedes agregar lógica adicional de manejo de errores aquí si lo deseas
                return ex.Message.ToString(); // Error al realizar la inserción
            }
        }
    }
}
