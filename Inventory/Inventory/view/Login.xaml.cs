﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows;
using Inventory.controller;

namespace Inventory.view
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private PetugasController controller;

        /*
        ###### CONSTRUCTOR ######
        */

        public Window1()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ResizeMode = ResizeMode.NoResize;
            txtUsername.Focus();
            controller = new PetugasController(this);
        }

        /*
        ###### OPERASI ######
        */
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            controller.LoginCheck();
        }

        /*
        ###### NAVIGASI ######
        */

        //navigasi register
        private void btnRegister_Click_1(object sender, RoutedEventArgs e)
        {
            register registerPage = new register();
            registerPage.Show();
            this.Close();
        }

        //navigasi exit
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
