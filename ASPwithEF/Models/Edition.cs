namespace ASPwithEF.Models
{
    //класс Издания
    public class Edition
    {
        public int Id { get; set; }
        //Индекс издания по каталогу (строка из цифр)
        public string Index { get; set; }
        //Вид издания (газета, журнал, альманах, каталог, …)
        public string Type { get; set; }
        //Наименование издания (название газеты, журнала, …)
        public string Name { get; set; }
        //Цена 1 экземпляра (в руб.)
        public int Cost { get; set; }
        //Дата начала подписки
        public DateTime DateOfSub { get; set; }
        //Длительность подписки (количество месяцев)
        public int Duration { get; set; }
    }
}
