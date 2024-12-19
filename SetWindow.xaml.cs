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

namespace Лаба_10
{
    /// <summary>
    /// Логика взаимодействия для SetWindow.xaml
    /// </summary>
    public partial class SetWindow : Window
    {
        public SetWindow(int maxPriority)
        {
            InitializeComponent();
            TBPriority.Text = maxPriority.ToString();
        }

        private void SetBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}