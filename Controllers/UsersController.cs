using Microsoft.AspNetCore.Mvc;
using PR49.Context;
using PR49.Modell;
using System;

namespace PR49.Controllers
{
    [Route("api/UsersController")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class UsersController : Controller
    {
        /// <summary>
        /// Регистрация пользователя                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
        /// </summary>
        /// <param name="Email">Почта пользователя</param>
        /// <param name="Login">Логин пользователя</param>
        /// <param name="Password">Пароль пользователя</param>
        /// <returns>Данный метод предназначен для регистрации пользователя в базе данных</returns>
        /// <response code="200">Пользователь успешно добавлен</response>
        /// <response code="403">Ошибка запроса, данные не указаны</response>
        /// <response code="200">При выполнении запроса возникли ошибки</response>
        [Route("RegIn")]
        [HttpPost]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public ActionResult RegIn([FromForm] string Email, [FromForm] string Login, [FromForm] string Password)
        {
            if (Email == null || Login == null || Password == null) return StatusCode(403);
            try
            {
                Users user = new Users { email = Email, login = Login, password = Password };
                new UsersContext().Users.Add(user);
                return Json(User);
            }
            catch (Exception ex) { return StatusCode(500); }
        }
    }
}
