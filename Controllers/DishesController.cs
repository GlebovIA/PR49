using Microsoft.AspNetCore.Mvc;
using PR49.Context;
using PR49.Modell;
using System.Linq;

namespace PR49.Controllers
{
    [Route("api/DishesController")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class DishesController : Controller
    {
        /// <summary>
        /// Блюда                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
        /// </summary>
        /// <param name="id">Код версии блюда</param>
        /// <returns>Данный метод предназначен для получения списка блюд</returns>
        /// <response code="200">Запрос успешно выполнен</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Dishes")]
        [HttpPost]
        [ApiExplorerSettings(GroupName = "v2")]
        [ProducesResponseType(typeof(Dishes), 200)]
        [ProducesResponseType(500)]
        public ActionResult Dishes(int id)
        {
            DishesContext dishesContext = new DishesContext();
            Dishes dishes = dishesContext.Dishes.Where(x => x.version == id).First();
            return Json(dishes);
        }
        /// <summary>
        /// Список версий                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
        /// </summary>
        /// <param name="id">Код версии блюда</param>
        /// <returns>Данный метод предназначен для получения списка версий</returns>
        /// <response code="200">Запрос успешно выполнен</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Versions")]
        [HttpGet]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(typeof(Dishes), 200)]
        [ProducesResponseType(500)]
        public ActionResult Versions()
        {
            DishesContext dishesContext = new DishesContext();
            return Json(dishesContext.Dishes);
        }
    }
}
