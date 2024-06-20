namespace PR49.Modell
{
    /// <summary>
    /// Класс хранящий информацию о пользователе
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Код
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Почта
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        public string login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// Токен пользователя
        /// </summary>
        public int? token { get; set; }
        /// <summary>
        /// Полученый от базы данных токен
        /// </summary>
        public static int? Token { get; set; }
    }
}
