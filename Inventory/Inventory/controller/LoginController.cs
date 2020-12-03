﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.view;
using System.Windows;
using Inventory.model;


namespace Inventory.controller
{
    class LoginController
    {
        private LoginModel model;
        private Window1 view;

        public LoginController(Window1 view)
        {
            this.view = view;
            model = new LoginModel();
        }

        public void HasilLogin()
        {
            model.CheckLogin(view.txtUsername.Text, view.txtPassword.Password);
            bool hasil = model.GetHasil();
            if (hasil)
            {
                MenuUtama home = new MenuUtama();
                home.Show();
                view.Close();
            }
            else
            {
                MessageBox.Show("Username/password salah !");
                view.txtUsername.Text = "username";
                view.txtPassword.Password = "password";
                view.txtUsername.Focus();
            }
        }
    }
}
