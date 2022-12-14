using CLZCarz.Business.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Shared.User;

namespace CLZCarz.Business.Controllers
{
    /// <summary>
    /// Classe responsável por receber a(s) requisição(ões).
    /// Funções da classe:
    ///     1. Receber requisições Get/Post/Put/Delete e encaminhar o(s) dado(s) para a classe LoginBusiness
    ///     2. Receber o(s) dado(s) do LoginBusiness e mostra-lo(s) para o usuário.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        private LoginBusiness business;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            this.business = LoginBusiness.GetInstance();
        }

        /// <summary>
        /// Requisição POST
        /// Função responsável por receber uma requisição post e encaminhar os dados para a criação de um novo usuário.
        /// </summary>
        [HttpPost("Create")]
        public object Create([FromBody] LoginModel login)
        {
            try
            {
                return Ok(this.business.CreateLogin(login));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Requisição GET(Login)
        /// Função responsável por receber uma requisição get e encaminhar o valor recebido para buscar os dados de um usuário existente. 
        /// </summary>
        [HttpGet("GetLogin")]
        public object GetLogin(int id)
        {
            try
            {
                LoginModel? login = new LoginModel();
                login = this.business.GetLogin(id);
                return Ok(login);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Requisição POST
        /// Função responsável por receber Email e senha, e gerar um token JWT.
        /// </summary>
        [HttpPost("Login")]
        public object Login(string email, string password)
        {
            try
            {

                LoginModel login = new LoginModel();
                login.Email = email;
                login.Password = password;
                login = business.GetCheckLogin(login.Email, login.Password);
                if (login == null || string.IsNullOrEmpty(login.Name))
                {
                    throw new Exception("Usuário não cadastrado");
                }
                return Ok(login);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Requisição GET(All Login)
        /// Função responsável por receber uma requisição get e retornar uma lista de todos os usuários registrados no banco de dados. 
        /// </summary>


        [HttpGet("GetAllLogin")]

        public object GetAllLogin()
        {
            try
            {
                return this.business.GetAllLogin();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Requisição PUT
        /// Função responsável por receber uma requisição put e encaminhar o(s) dado(s) para atualizar o cadastro de um usuário.
        /// </summary>
        [HttpPut("Update")]
        public object Update([FromBody] UpdateLoginModel login)
        {
            try
            {
                return Ok(this.business.UpdateLogin(login));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Requisição DELETE
        /// Função responsável por receber uma requisição delete e encaminhar o valor para a classe LoginBusiness deletar a conta de um usuário.
        /// </summary>
        [HttpDelete("Delete")]
        public object Delete(int id)
        {
            try
            {
                return Ok(this.business.DeleteLogin(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
