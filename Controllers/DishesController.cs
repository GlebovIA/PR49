using Microsoft.AspNetCore.Mvc;
using PR49.Context;
using PR49.Modell;
using System.Linq;

namespace PR49.Controllers
{
    [Route("api/DishesController")]
    public class DishesController : Controller
    {
        /// <summary>
        /// Список версий                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
        /// </summary>
        /// <param name="id">Код версии блюда</param>
        /// <returns>Данный метод предназначен для получения списка версий</returns>
        /// <response code="200">Пользователь успешно добавлен</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Versions")]
        [HttpPost]
        [ProducesResponseType(typeof(Dishes), 200)]
        [ProducesResponseType(500)]
        public ActionResult Versions(int id)
        {
            DishesContext dishesContext = new DishesContext();
            Dishes dishes = dishesContext.Dishes.Where(x => x.version == id).First();
            return Json(dishes);
        }
    }
}
