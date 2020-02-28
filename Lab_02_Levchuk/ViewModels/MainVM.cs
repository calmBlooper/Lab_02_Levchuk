using Lab_02_Levchuk.Models;
using Lab_02_Levchuk.Tools;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lab_02_Levchuk.ViewModels
{
    class MainVM: INotifyPropertyChanged
    {
      
        private Person _userObject;
        private string _name = "", _surname = "", _email = "";
        private DateTime? _chosenDate;
        public MainVM()
        {
            ButtonCommand = new RelayCommand(o => MainButtonClick("MainButton"));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name
        {
            set
            {
                _name = value;
                OnPropertyChanged("ButtonEnabled");
            }
                get => _name;
        }
        public string Surname
        {
            set
            {
                _surname = value;
                OnPropertyChanged("ButtonEnabled");
            }
                get => _surname;
        }
        public string Email
        {
            set
            {
                _email = value;
               OnPropertyChanged("ButtonEnabled");
            }
            get => _email;
        }
        public DateTime? ChosenDate {
        set
            {
                _chosenDate = value;
                OnPropertyChanged("ButtonEnabled");
            }
            get => _chosenDate;
        }
        public bool ButtonEnabled
        {
            get => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Surname) && !string.IsNullOrWhiteSpace(Email)&&ChosenDate.HasValue; 
        }
        public string UserInfo { set; get; } = "";
        public Visibility LoaderVisibility { set; get; } = Visibility.Collapsed;
        public ICommand ButtonCommand { get; set; }
        protected virtual void OnPropertyChanged(string propertyName)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        private int GetAge(DateTime enteredDate)
        {
            int Age = DateTime.Now.Year - enteredDate.Year;
            if (enteredDate.AddYears(Age) > DateTime.Now) Age--;
            return Age;
        }
        private bool BirthdayCorrect(DateTime enteredDate)
        {
            if (enteredDate.Year < DateTime.Now.Year)   return GetAge(enteredDate)<=135;
            if (enteredDate.Year == DateTime.Now.Year&& enteredDate.Month < DateTime.Now.Month) return GetAge(enteredDate) < 135;
            if (enteredDate.Year == DateTime.Now.Year && enteredDate.Month == DateTime.Now.Month && enteredDate.Day < DateTime.Now.Day) return GetAge(enteredDate) < 135;
            return false;
        }
    
        
        private async void MainButtonClick(object sender)
        {
            ShowLoader();
            await Task.Run(() =>
            {
                if (BirthdayCorrect(ChosenDate.Value))
                {
                   if (_userObject==null) _userObject = new Person(Name, Surname, Email, ChosenDate.Value);
                   else
                    {
                        _userObject.Name = Name;
                        _userObject.Surname = Surname;
                        _userObject.Email = Email;
                        _userObject.BirthDay = ChosenDate.Value;
                    }
                    UserInfo = "Name: " + _userObject.Name +
                    "\nSurname: " + _userObject.Surname +
                    "\nEmail: " + _userObject.Email +
                    "\nDate of birth: " + _userObject.BirthDay.ToShortDateString() +
                    "\nIs adult: " + (_userObject.IsAdult ? "Yes" : "No") +
                    "\nSun sign: " + _userObject.SunSign +
                    "\nChinese sign: " + _userObject.ChineseSign +
                    "\nIs birthday today: " + (_userObject.IsBirthday ? "Yes" : "No");
                    OnPropertyChanged("UserInfo");
                }
                else
                {
                    UserInfo = "";
                    OnPropertyChanged("UserInfo");
                }
            });
            HideLoader();
            if (!BirthdayCorrect(ChosenDate.Value))  MessageBox.Show("Your entered date of birth is wrong.\nYou can not be less than 1 day old, or older than 135 years old.");
            else if (_userObject.IsBirthday) MessageBox.Show("Hey, it`s your birthday today! Congratulations!");
        }
        private void ShowLoader()
        {
            LoaderVisibility = Visibility.Visible;
            OnPropertyChanged("LoaderVisibility");
        }
        private void HideLoader()
        {
            LoaderVisibility = Visibility.Collapsed;
            OnPropertyChanged("LoaderVisibility");
        }
    }
}
