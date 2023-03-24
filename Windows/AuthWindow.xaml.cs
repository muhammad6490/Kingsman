﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kingsman.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void BtnSignIn(object sender, RoutedEventArgs e)
        {
            var userAuth = ClassHelper.EF.context.Employe.ToList().
                Where(i => i.Login == TbLogin.Text && i.Password == PbPassword.Password).
                FirstOrDefault();
            if (userAuth != null)
            {
                MainWindow serviceWindow = new MainWindow();
                serviceWindow.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Пользователя не существует, попробуйте ещё раз", "Ошибка", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }
        private void BtnRegistr(object sender, RoutedEventArgs e)
        {
            RegistrWindow registrWindow = new RegistrWindow();
            registrWindow.Show();
            this.Close();
        }
    }
}