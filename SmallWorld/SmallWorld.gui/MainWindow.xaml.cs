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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SmallWorld.Core;

namespace SmallWorld.gui
{
    /// <summary>
    /// Interaction logic for the start window
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel MainWindowVM { get; set;}
        public MainWindow()
        {
            InitializeComponent();
            MainWindowVM = new MainWindowViewModel();
        }
    }
}
