﻿using System;
using WaldenHospitalConsumer.Utilities;
using WaldenHospitalConsumer.Model.Catalog;
using WaldenHospitalConsumer.Model;
using Windows.UI.Popups;
using WaldenHospitalConsumer.View;

namespace WaldenHospitalConsumer.ViewModel
{
    public class LoginViewModel: NotificationClass
    {
        private string _adminCpr;
        private string _password;
        private bool _allowLogin = false;

        public IObservable<User> Users { get; set; }


        public bool AllowLogin
        {
            get { return _allowLogin; }
            set { _allowLogin = value; }
        }
        public string AdminCpr
        {
            get { return _adminCpr; }
            set { _adminCpr = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        public RelayCommand LoginCommand { get; set; }
        public RelayCommand DoShowCreateAccount { get; set; }
        

        //Constructor
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            DoShowCreateAccount = new RelayCommand(ShowCreateAccount);
        }
        //was supposed to be async but duuno where to put await xD


        public void ShowCreateAccount(object s)
        {
            Type type = typeof(CreateAccountView);
            FrameNavigation.ActivateFrameNavigation(type);
        }

        public async void Login(object s)
        {
            try
            {
                UserCatalog UserCatalog = new UserCatalog();
                if(UserCatalog!= null)
                {
                    

                    foreach(var user in UserCatalog.Users)
                    {
                        if(user.AdminCpr.Trim() == AdminCpr.Trim() && user.Password.Trim() == Password.Trim())
                        {    
                                Type typeProfile = typeof(NewsView);
                                FrameNavigation.ActivateFrameNavigation(typeProfile);
                                AllowLogin = true;
                                break;
                            
                        }
                    }
                     
                    if(AllowLogin == false)
                    {

                        var dialog = new MessageDialog("Wrong email or password!");
                        await dialog.ShowAsync();
                        
                    }


                }        


            }
            catch (Exception)
            {

            }
          
           
        }


    }
}
