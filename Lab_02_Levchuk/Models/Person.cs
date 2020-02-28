using System;

namespace Lab_02_Levchuk.Models
{
    class Person
    {
        private String _name, _surname, _email;
        private DateTime _birthDay;
        //Eastern zodiacs helping array, for easier and faster computation of the "ChineseSign" method
        private  string[] _chineseZodiacs = { "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat" };
        public Person(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _email = email;
        }

        public Person(string name, string surname, string email, DateTime birthDay)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthDay = birthDay;
        }
        public Person(string name, string surname, DateTime birthDay)
        {
            _name = name;
            _surname = surname;
            _birthDay = birthDay;
        }
        public String Name
        {
            set => _name = value;
            get => _name;
        }
        public String Surname
        {
            set => _surname = value;
            get => _surname;
        }
        public String Email
        {
            set => _email = value;
            get => _email;
        }
        public DateTime BirthDay
        {
            set => _birthDay = value;
            get => _birthDay;
        }
        public bool IsAdult {
            get
            {
                int Age = DateTime.Now.Year - _birthDay.Year;
                if (_birthDay.AddYears(Age) > DateTime.Now) Age--;
                return Age > 18;
            }
        }
        public string SunSign
        {
            get
            {
                int Month = _birthDay.Month, Day = _birthDay.Day;
                switch (Month)
                {
                    case 1:
                        if (Day < 20)
                            return "Capricorn";
                        else
                            return "Aquarius";
                    case 2:
                        if (Day < 19)
                            return "Aquarius";
                        else
                            return "Pisces";
                    case 3:
                        if (Day < 21)
                            return "Pisces";
                        else
                            return "Aries";
                    case 4:
                        if (Day < 20)
                            return "Aries";
                        else
                            return "Taurus";
                    case 5:
                        if (Day < 21)
                            return "Taurus";
                        else
                            return "Gemini";
                    case 6:
                        if (Day < 21)
                            return "Gemini";
                        else
                            return "Cancer";
                    case 7:
                        if (Day < 23)
                            return "Cancer";
                        else
                            return "Leo";
                    case 8:
                        if (Day < 23)
                            return "Leo";
                        else
                            return "Virgo";
                    case 9:
                        if (Day < 23)
                            return "Virgo";
                        else
                            return "Libra";
                    case 10:
                        if (Day < 23)
                            return "Libra";
                        else
                            return "Scorpio";
                    case 11:
                        if (Day < 22)
                            return "Scorpio";
                        else
                            return "Sagittarius";
                    default:
                        if (Day < 22)
                            return "Sagittarius";
                        else
                            return "Capricorn";
                }
            }
        }
public string ChineseSign {
            get
            {
                return _chineseZodiacs[_birthDay.Year % 12];
            }
            }
public bool IsBirthday
        {
            get
            {
                return DateTime.Now.Month == _birthDay.Month && DateTime.Now.Day == _birthDay.Day;
            }
        }
    }
}
