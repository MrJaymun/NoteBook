using System;
using System.Collections.Generic;

namespace NoteBook
{
    class Program
    {
        public static List<Unit> users = new List<Unit>();

       //Ермолин Алексей
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите действие, которое хотите совершить.");
                Console.WriteLine("Если вы хотите создать новую запись, напишите в консоль \"1\"");
                Console.WriteLine("Если вы хотите отредактировать уже существующую запись, напишите в консоль \"2\"");
                Console.WriteLine("Если вы хотите удалить запись, напишите в консоль \"3\"");
                Console.WriteLine("Если вы хотите посмотреть список всех записей, напишите в консоль \"4\"");
                Console.WriteLine("Если вы хотите посмотреть полную информацию по созданной записи, напишите в консоль \"5\"");

                int moveID = 0; 
                try
                {
                    moveID = Convert.ToInt32(Console.ReadLine());
                    switch (moveID)
                    {
                        case 1:
                            AddUnit();
                            break;
                        case 2:
                            ChangeUser();
                            break;
                        case 3:
                            DeleteUser();
                            break;
                        case 4:
                            WatchUsers();
                            break;
                        case 5:
                            WatchUserInfo();
                            break;
                        default:
                            Console.WriteLine(" "); // Для читаемости
                            Console.WriteLine("Действие выбрано некорректно");
                            Console.WriteLine(" "); // Для читаемости
                            break;
                    }
                }
                catch {
                    Console.WriteLine(" "); // Для читаемости
                    Console.WriteLine("Действие выбрано некорректно");
                    Console.WriteLine(" "); // Для читаемости
                }

            }

        }

        public static void AddUnit()
        {

            Console.WriteLine("Внесите информацию о новой записи.");
            Console.WriteLine("Если вы не хотите вносить информацию в необязательное поле, то просто нажмите Enter.");
            string surname = "";
            while (String.IsNullOrEmpty(surname))
            {
                Console.WriteLine("Введите фамилию(обязательно): ");
                surname = Console.ReadLine();
            }
            string name = "";
            while (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("Введите имя(обязательно): ");
                name = Console.ReadLine();
            }
            string secondName = "";
            Console.WriteLine("Введите отчество: ");
            secondName = Console.ReadLine();
            long phone = 0;
           
            while (phone.ToString().Length != 11)
            {
                Console.WriteLine("Введите мобильный телефон без дополнительных символов (обязательно): ");
                try
                {
                    phone = Convert.ToInt64(Console.ReadLine());
                }
                catch
                {
                }
            }
            string country = "";
            while (String.IsNullOrEmpty(country))
            {
                Console.WriteLine("Введите страну(обязательно): ");
                country = Console.ReadLine();
            }
 
            string dateOfBirth = "";
            Console.WriteLine("Вы хотите ввести данные о дате рождения? Если нет, нажмите Enter");
            string dateIsNeed = Console.ReadLine();
            if (!String.IsNullOrEmpty(dateIsNeed))
            {
                dateOfBirth = TakeDate();
            }

            string organisation = "";
            Console.WriteLine("Введите название организации: ");
            organisation = Console.ReadLine();

            string position = "";
            Console.WriteLine("Введите должность в организации: ");
            position = Console.ReadLine();

            string other = "";
            Console.WriteLine("Введите дополнительную информацию: ");
            other = Console.ReadLine();

            users.Add(new Unit(surname, name, secondName, phone, country, dateOfBirth, organisation, position, other));
            Console.WriteLine(" "); // Для читаемости
            Console.WriteLine("Запись создана!");
            Console.WriteLine(" "); // Для читаемости



        }

        //Функция просмотра информации у всех пользователей
        public static void WatchUsers()
        {
            for (int i = 0; i < users.Count; i++)
            {
                users[i].WatchInfo();
            }

        }
        
        //Функция просмотра подробной информации пользователя
        public static void WatchUserInfo()
        {
            Console.WriteLine(" "); // Для читаемости
            Console.WriteLine("Введите id записи, информацию о которой хотите узнать");
           
            Boolean isGood = false;

            try
            {
                int watchID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(" "); // Для читаемости
                for (int i = 0; i < users.Count; i++)
                {

                    if (users[i].personalNumber == watchID)
                    {
                        isGood = true;
                        users[i].WatchFullInfo();
                    }
                }
                if (!isGood)
                {
                    Console.WriteLine(" "); // Для читаемости
                    Console.WriteLine("Запись не найдена");
                    Console.WriteLine(" "); // Для читаемости
                }
            }
            catch
            {
                Console.WriteLine(" "); // Для читаемости
                Console.WriteLine("Введите корректный ID");
                Console.WriteLine(" "); // Для читаемости
            }
        }

        //Функция изменения данных у пользователя
        public static void ChangeUser()
        {
            Console.WriteLine(" "); // Для читаемости
            Console.WriteLine("Введите id записи, информацию о которой вы хотите изменить");
            int id = 0;
            Boolean isFound = false;
            try
            {
                id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(" "); // Для читаемости
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].personalNumber == id)
                    {
                        isFound = true;
                        id = i;
                       
                    }
                }
                if (isFound)
                {
                   
                    Console.WriteLine("Выберите, что вы хотите изменить:");
                    Console.WriteLine("Если вы хотите изменить фамилию, нажмите \"1\" ");
                    Console.WriteLine("Если вы хотите изменить имя, нажмите \"2\" ");
                    Console.WriteLine("Если вы хотите изменить отчество, нажмите \"3\" ");
                    Console.WriteLine("Если вы хотите изменить мобильный телефон, нажмите \"4\" ");
                    Console.WriteLine("Если вы хотите изменить страну, нажмите \"5\" ");
                    Console.WriteLine("Если вы хотите изменить дату рождения, нажмите \"6\" ");
                    Console.WriteLine("Если вы хотите изменить организацию, нажмите \"7\" ");
                    Console.WriteLine("Если вы хотите изменить должность, нажмите \"8\" ");
                    Console.WriteLine("Если вы хотите изменить прочую информацию, нажмите \"9\" ");
                    int whatToChange = 0;
                    whatToChange = Convert.ToInt32(Console.ReadLine());
                    switch (whatToChange)
                    {
                        case 1:
                            string surname = "";
                            while (String.IsNullOrEmpty(surname))
                            {
                                Console.WriteLine("Введите фамилию: ");
                                surname = Console.ReadLine();
                            }
                            users[id].surname = surname;
                            break;
                        case 2:
                            string name = "";
                            while (String.IsNullOrEmpty(name))
                            {
                                Console.WriteLine("Введите имя: ");
                                name = Console.ReadLine();
                            }
                            users[id].name = name;
                            break;
                        case 3:
                            Console.WriteLine("Введите отчество: ");
                            users[id].secondName = Console.ReadLine();
                            break;
                        case 4:
                            long phone = 0;
                        
                            while (phone.ToString().Length != 11)
                            {
                                Console.WriteLine("Введите мобильный телефон без дополнительных символов (обязательно): ");
                                try
                                {
                                    phone = Convert.ToInt64(Console.ReadLine());
                                }
                                catch
                                {
                                }
                            }
                            users[id].phone = phone;
                            break;
                        case 5:
                            string country = "";
                            while (String.IsNullOrEmpty(country))
                            {
                                Console.WriteLine("Введите страну: ");
                                country = Console.ReadLine();
                            }
                            users[id].country = country;
                            break;
                        case 6:
                            users[id].dateOfBirth = TakeDate();
                            break;
                        case 7:
                            Console.WriteLine("Введите название организации: ");
                            users[id].organisation = Console.ReadLine();
                            break;
                        case 8:
                            Console.WriteLine("Введите должность: ");
                            users[id].position = Console.ReadLine();
                            break;
                        case 9:
                            Console.WriteLine("Введите прочую информацию: ");
                            users[id].other = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine(" "); // Для читаемости
                            Console.WriteLine("Действие выбрано некорректно");
                            Console.WriteLine(" "); // Для читаемости
                            break;
                    }

                }
                else
                {
                    Console.WriteLine(" "); // Для читаемости
                    Console.WriteLine("Запись не найдена!");
                    Console.WriteLine(" "); // Для читаемости
                }
            }
            catch
            {
                Console.WriteLine(" "); // Для читаемости
                Console.WriteLine("Введите корректные значения ");
                Console.WriteLine(" "); // Для читаемости
            }
            
        }

        //Функция удаления пользователя
        public static void DeleteUser()
        {
            Console.WriteLine(" "); // Для читаемости
            Console.WriteLine("Введите id записи, которую хотите удалить");
            Boolean deleteCount = false;
            try
            {
                int deleteID = Convert.ToInt32(Console.ReadLine());
              
                for (int i = 0; i < users.Count; i++)
                {
                    if(users[i].personalNumber == deleteID)
                    {
                        deleteCount = true;
                        users.Remove(users[i]);
                    }
                }
                if (deleteCount)
                {
                    Console.WriteLine(" "); // Для читаемости
                    Console.WriteLine("Запись удалена!");
                    Console.WriteLine(" "); // Для читаемости
                }
                else
                {
                    Console.WriteLine(" "); // Для читаемости
                    Console.WriteLine("Запись не найдена!");
                    Console.WriteLine(" "); // Для читаемости
                }

            }
            catch
            {
                Console.WriteLine(" "); // Для читаемости
                Console.WriteLine("Введите корректный ID");
                Console.WriteLine(" "); // Для читаемости
            }

        }


        //Проверка даты на корректность

        public static string TakeDate() //хочется написать get, но это не совсем get по идее
        {
            string dateOfBirth ="";
            DateTime birth;
            int day = 32;
            int month = 0;
            int year = 0;
            Boolean checkDate = false;
            while (!checkDate)
            {
                year = 0;
                while (year == 0)
                {
                    try
                    {
                        Console.WriteLine("Введите день рождения: ");
                        day = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите месяц рождения: ");
                        month = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите год рождения: ");
                        year = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                    }
                }

                try
                {
                    birth = new DateTime(year, month, day);
                    if (birth < DateTime.Today)
                    {
                        dateOfBirth = birth.ToString().Substring(0, 11);
                        checkDate = true;
                    }

                }
                catch
                {
                    Console.WriteLine(" "); // Для читаемости
                    Console.WriteLine("Введите корректную дату");
                    Console.WriteLine(" "); // Для читаемости
                }
            }
            return dateOfBirth;
        }
    }


    class Unit
    {
        public static int id = 0;
        public int personalNumber;
        public string surname;
        public string name;
        public string secondName; // Не обязательное
        public long phone; // Только цифры
        public string country;
        public string dateOfBirth; // Не обязательное
        public string organisation; // Не обязательное
        public string position; // Не обязательное
        public string other; // Не обязательное

        public Unit(string surname, string name, string secondName, long phone, string country, string dateOfBirth, string organisation, string position, string other)
        {
            id++;
            this.personalNumber = id;
            this.surname = surname;
            this.name = name;
            this.secondName = secondName;
            this.phone = phone;
            this.country = country;
            this.organisation = organisation;
            this.position = position;
            this.other = other;
            this.dateOfBirth = dateOfBirth;
        }

        public void WatchInfo()
        {  
            Console.WriteLine("Фамилия: " + this.surname);
            Console.WriteLine("Имя: " + this.name);
            Console.WriteLine("Телефон: " + this.phone);
            Console.WriteLine(" "); // Для читаемости
        }
        public void WatchFullInfo()
        {
            
            Console.WriteLine("ID: " + this.personalNumber);
            Console.WriteLine("Фамилия: " + this.surname);
            Console.WriteLine("Имя: " + this.name);
            Console.WriteLine("Отчество: " + this.secondName);
            Console.WriteLine("Телефон: " + this.phone);
            Console.WriteLine("Страна: " + this.country);
            Console.WriteLine("Дата рождения: " + this.dateOfBirth);
            Console.WriteLine("Организация: " + this.organisation);
            Console.WriteLine("Должность: " + this.position);
            Console.WriteLine("Прочая информация: " + this.other);
            Console.WriteLine(" "); // Для читаемости

        }

       
    }
}
