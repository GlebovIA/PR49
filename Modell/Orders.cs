namespace PR49.Modell
{
    public class Orders
    {
        /// <summary>
        /// Код заказа
        /// </summary>
        public int id { get; set; }
        public string address { get; set; }
        public string date { get; set; }
        public int dishes { get; set; }
        public int count { get; set; }
    }
}
