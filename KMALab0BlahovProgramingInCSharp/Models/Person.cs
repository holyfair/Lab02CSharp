using KMALab02BlahovProgramingInCSharp.Properties;
using KMALab0BlahovProgramingInCSharp.Exceptions;
using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace KMALab02BlahovProgramingInCSharp.Models
{
    [Serializable]
    public class Person
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _dateOfBirth = DateTime.Today;
        private readonly bool _isAdult;
        private readonly string _sunSign;
        private readonly string _chineseSign;
        private readonly bool _isBirthday;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("E-mail");
            }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }

        public bool IsAdult => _isAdult;

        public string SunSign => _sunSign;

        public string ChineseSign => _chineseSign;

        public bool IsBirthday => _isBirthday;

        private enum Month
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        private enum Animal
        {
            Monkey,
            Cock,
            Dog,
            Pig,
            Rat,
            Bull,
            Tiger,
            Rabbit,
            Dragon,
            Snake,
            Horse,
            Goat
        }

        public Person(string name, string surname, string email) : this(name, surname, email, DateTime.Today)
        {
        }

        public Person(string name, string surname, DateTime dateOfBirth) : this(name, surname, "", DateTime.Today)
        {
        }

        public Person(string name, string surname, string email, DateTime dateOfBirth)
        {
            IsCorrectDateOfBirth(dateOfBirth);
            IsEmailValid(email);
            Name = name;
            Surname = surname;
            Email = email;
            DateOfBirth = dateOfBirth;
            _isAdult = CalcAdult();
            _sunSign = CalcSunSign();
            _chineseSign = CalcChineseSign();
            _isBirthday = CalcIsBirthday();
        }

        public Person()
        {
        }

        private bool CalcAdult()
        {
            int age = DateTime.Today.Year - DateOfBirth.Year;
            if (age > 17)
                return true;

            return false;
        }

        private string CalcSunSign()
        {
            Month month = (Month)DateOfBirth.Month;
            int day = DateOfBirth.Day;

            switch (month)
            {
                case Month.January:
                    return day < 20 ? "Козерог" : "Водолей";
                case Month.February:
                    return day < 19 ? "Водолей" : "Рыбы";
                case Month.March:
                    return day < 21 ? "Рыбы" : "Овен";
                case Month.April:
                    return day < 21 ? "Овен" : "Телец";
                case Month.May:
                    return day < 21 ? "Телец" : "Близнецы";
                case Month.June:
                    return day < 21 ? "Близнецы" : "Рак";
                case Month.July:
                    return day < 23 ? "Рак" : "Лев";
                case Month.August:
                    return day < 23 ? "Лев" : "Дева";
                case Month.September:
                    return day < 24 ? "Дева" : "Весы";
                case Month.October:
                    return day < 24 ? "Весы" : "Скорпион";
                case Month.November:
                    return day < 22 ? "Скорпион" : "Стрелец";
                case Month.December:
                    return day < 22 ? "Стрелец" : "Козерог";
            }

            return "Козерог";
        }

        private string CalcChineseSign()
        {
            Animal animal = (Animal)(DateOfBirth.Year % 12);

            switch (animal)
            {
                case Animal.Monkey:
                    return "Обезьяна";
                case Animal.Cock:
                    return "Петушара";
                case Animal.Dog:
                    return "Собака";
                case Animal.Pig:
                    return "Свинья";
                case Animal.Rat:
                    return "Крыса";
                case Animal.Bull:
                    return "Бык";
                case Animal.Tiger:
                    return "Тигр";
                case Animal.Rabbit:
                    return "Кролик";
                case Animal.Dragon:
                    return "Дракон";
                case Animal.Snake:
                    return "Змея";
                case Animal.Horse:
                    return "Лошадь";
                case Animal.Goat:
                    return "Коза";
            }

            return "Обезьяна";
        }

        private bool CalcIsBirthday()
        {
            if (DateTime.Today.Month == DateOfBirth.Month && DateTime.Today.Day == DateOfBirth.Day)
            {
                return true;
            }

            return false;
        }

        private void IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
            }
            catch (FormatException)
            {
                throw new IllegalEmailException();
            }
        }

        private void IsCorrectDateOfBirth(DateTime date)
        {
            int age = DateTime.Today.Year - date.Year;

            if (date > DateTime.Today)
                throw new IsNotBirthException();
            else if (age > 135)
                throw new IsDeadException();
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}


