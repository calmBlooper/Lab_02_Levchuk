using Lab_02_Levchuk.Models;
using Lab_02_Levchuk.Tools;
using Lab_02_Levchuk.Tools.Exceptions;
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
            get => LoaderVisibility == Visibility.Collapsed&& !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Surname) && !string.IsNullOrWhiteSpace(Email)&&ChosenDate.HasValue; 
        }
        public bool NameEnabled
        {
            get => LoaderVisibility ==Visibility.Collapsed;
        }
        public bool SurnameEnabled
        {
            get => LoaderVisibility == Visibility.Collapsed;
        }
        public bool EmailEnabled
        {
            get => LoaderVisibility == Visibility.Collapsed;
        }
        public bool DateEnabled
        {
            get => LoaderVisibility == Visibility.Collapsed;
        }
        public string UserInfo { set; get; } = "";
        public Visibility LoaderVisibility { set; get; } = Visibility.Collapsed;
        public ICommand ButtonCommand { get; set; }
        protected virtual void OnPropertyChanged(string propertyName)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }


    
        private void CheckInterface()
        {
            OnPropertyChanged("NameEnabled");
            OnPropertyChanged("SurnameEnabled");
            OnPropertyChanged("EmailEnabled");
            OnPropertyChanged("DateEnabled");
            OnPropertyChanged("ButtonEnabled");

        }
        private async void MainButtonClick(object sender)
        {
            ShowLoader();
            await Task.Run(() =>
            {
                try
                {
                    if (_userObject == null) _userObject = new Person(Name, Surname, Email, ChosenDate.Value);
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
                    HideLoader();
                    if (_userObject.IsBirthday) MessageBox.Show("He, it`s your birthday today! Congratulations!");
                    CheckInterface();
                }
                catch (Exception ex)
                {
                    HideLoader();
                    UserInfo = "";
                    OnPropertyChanged("UserInfo");
                    MessageBox.Show(ex.Message);
                    CheckInterface();
                }  
            });

        }
        private void ShowLoader()
        {
            LoaderVisibility = Visibility.Visible;
            OnPropertyChanged("LoaderVisibility");
            CheckInterface();
        }
        private void HideLoader()
        {
            LoaderVisibility = Visibility.Collapsed;
            OnPropertyChanged("LoaderVisibility");
        }
    }
}
