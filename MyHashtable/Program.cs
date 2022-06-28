using System;
using System.Threading;
using System.Text;
namespace MyHeshtable
{
    class Test
    {
        public static string GetRandomRecipeName()
        {
            string[] names = { "Печень в шубе", "Чевапчичи", "Гречаники", "Куриные завороты","Мясо с кунжутом и мёдом",
                "Картофельное пюре", "Картофель по-португальски", "Сырно-луковый суп" };
            Random rnd = new Random();
            int randomNum = rnd.Next(0, names.Length - 1);
            return names[randomNum];
        }
        public static string GetRandomAuthorName()
        {
            string[] names = { "Трофимова Анна Станиславовна","Табаков Валерий Филиппович","Илларионов Тимофей Сергеевич","Яковлева Надежда Ростиславовна",
                "Спиваковский Георгий Родионович","Холопов Федор Андреевич","Каблукова Людмила Олеговна","Боярских Анатолий Ярославович","Левченко Лев Даниилович",
                "Батагов Вадим Владимирович","Царевский Юрий Тарасович","Бойченко Галина Викторовна","Ермолаев Вячеслав Евгеньевич","Костюкова Татьяна Ивановна","Шпак Елена Антоновна"}; 
            Random rnd = new Random();
            int randomNum = rnd.Next(0, names.Length - 1);
            return names[randomNum];
        }
        static void Main(string[] args)
        {

            //for (int i = 0; i < 15; i++)
            //{
            //    recipes[i] = new Recipe(GetRandomRecipeName(), GetRandomAuthorName(), new DateTime(2022, 12, 24));
            //    myHashTable.Add(recipes[i]);
            //}
            //myHashTable.Add(new Recipe("asasddfe", "asdzxcd", new DateTime()));
            //myHashTable.Add(new Recipe("asxzczdfe", "adcsd", new DateTime()));
            //myHashTable.Add(new Recipe("asdvdsfe", "anbnmsd", new DateTime()));
            //myHashTable.Add(new Recipe("asasdxvcdfe", "ahgjgsd", new DateTime()));
            //myHashTable.Add(new Recipe("asdasdqdfe", "asghnv2d", new DateTime()));
            //myHashTable.PrintWithStatus();
            //myHashTable.Del(recipes[1]);
            //Console.WriteLine("------------------------------------");
            //myHashTable.PrintWithStatus();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Heshtable myHashTable = new(10);

            //заполняем всю таблицу (пытаемся запихнуть в одну ячейку)
            for (int i = 0; i < 10; i++)
            {
                byte[] ab = new byte[1];
                ab[0] = (byte)(65 + 10 * i);
                string tempStr1 = Encoding.GetEncoding("windows-1251").GetString(ab);
                myHashTable.Add(new Recipe(tempStr1, "", new DateTime()));
            }
            myHashTable.PrintWithStatus();

            //удаляем четные элементы в таблице
            Console.WriteLine("--------------------------------");
            for (int i = 0; i < 10; i++)
            {
                byte[] ab = new byte[1];
                ab[0] = (byte)(65 + 20 * i);
                string tempStr1 = Encoding.GetEncoding("windows-1251").GetString(ab);
                myHashTable.Del(new Recipe(tempStr1, "", new DateTime()));
            }
            myHashTable.PrintWithStatus();

            //заполняем всю таблицу обратно
            Console.WriteLine("--------------------------------");
            for (int i = 0; i < 10; i++)
            {
                byte[] ab = new byte[1];
                ab[0] = (byte)(65 + 10 * i);
                string tempStr1 = Encoding.GetEncoding("windows-1251").GetString(ab);
                myHashTable.Add(new Recipe(tempStr1, "", new DateTime()));
            }
            myHashTable.PrintWithStatus();

            //поиск 
            Console.WriteLine("--------------------------------");
            byte[] ab1 = new byte[1];
            ab1[0] = (byte)(65 + 10);
            string tempStr2 = Encoding.GetEncoding("windows-1251").GetString(ab1);
            Console.WriteLine(myHashTable.Search(new Recipe(tempStr2, "", new DateTime())));
        }
    }
}
