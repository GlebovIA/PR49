using Microsoft.AspNetCore.Mvc;
using PR49.Context;
using PR49.Modell;
using System.Linq;

namespace PR49.Controllers
{
    [Route("api/OrdersController")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class OrdersController : Controller
    {
        /// <summary>
        /// Отправка заказа                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
        /// </summary>
        /// <param name="orders">Данные о заказе</param>
        /// <param name="token">Токен пользователя</param>
        /// <returns>Данный метод предназначен для регистрации заказа в базе данных</returns>
        /// <response code="200">Заказ успешно добавлен</response>
        /// <response code="400">Проблемы при запросе</response>
        /// <response code="401">Неавторизованный доступ</response>
        [Route("CreateOrder")]
        [HttpPost]
        [ProducesResponseType(typeof(Orders), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public ActionResult CreateOrder([FromForm] Orders orders, string token)
        {
            OrdersContext ordersContext = new OrdersContext();
            UsersContext usersContext = new UsersContext();
            if (orders == null) return StatusCode(400);
            if (usersContext.Users.Where(x => x.token.ToString() == token).First() == null) return StatusCode(401);
            ordersContext.Add(orders);
            ordersContext.SaveChanges();
            return Json(orders);
        }
        /// <summary>
        /// Получение истории заказов                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
        /// </summary>
        /// <returns>Данный метод предназначен для получения истории заказов из базы данных</returns>
        /// <response code="200">Запрос успешно выполнен</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("OrdersHistory")]
        [HttpGet]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(typeof(Orders), 200)]
        [ProducesResponseType(500)]
        public ActionResult OrdersHistory()
        {
            return Json(new OrdersContext().Orders);
        }
    }
}
