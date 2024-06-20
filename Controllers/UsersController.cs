using Microsoft.AspNetCore.Mvc;
using PR49.Context;
using PR49.Modell;
using System;
using System.Linq;

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
        /// <response code="500">При выполнении запроса возникли ошибки</response>
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
        /// <summary>
        /// Авторизация пользователя                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
        /// </summary>
        /// <param name="Email">Почта пользователя</param>
        /// <param name="Password">Пароль пользователя</param>
        /// <returns>Данный метод предназначен для регистрации пользователя в базе данных</returns>
        /// <response code="200">Успешный вход</response>
        /// <response code="400">Проблема аутентификации</response>
        /// <response code="401">Пользователь не найден</response>
        [Route("SignIn")]
        [HttpPost]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public ActionResult SignIn([FromForm] string Email, [FromForm] string Password)
        {
            if (Email == null || Password == null) return StatusCode(400);
            try
            {
                UsersContext userContext = new UsersContext();
                Users User = userContext.Users.Where(x => x.email == Email && x.password == Password).First();
                Random random = new Random();
                User.token = random.Next(int.MinValue, int.MaxValue);
                Users.Token = User.token;
                userContext.SaveChanges();
                return Json(User);
            }
            catch (Exception ex) { return StatusCode(401); }
        }
    }
}
