using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace ListaDeContatos.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logar(string username, string senha)
        {
            MySqlConnection mySqlConnection = new MySqlConnection("server=localhost;database=CRUD_MVC_MYSQL_AULA;uid=root;pwd=Pas@2023");
            await mySqlConnection.OpenAsync();

            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = $"SELECT * FROM acesso WHERE username = '{username}' and senha = '{senha}'";

            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            if (await reader.ReadAsync())
            {
                return RedirectToAction("Index", "Usuarios");
            }
            
            return Json(new { Msg = "Verifique suas credenciais!" });
        }
    }
}
