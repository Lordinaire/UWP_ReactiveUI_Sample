﻿using UWPReactiveUI.Core;
using Windows.UI.Xaml.Controls;
using Autofac;

namespace UWPReactiveUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public HipsterViewModel ViewModel { get; set; }

        public MainPage()
        {
            InitializeComponent();

            var container = AutofacBootstrapper.Start();
            var viewModel = container.Resolve<HipsterViewModel>();
            DataContext = viewModel;
            ViewModel = viewModel;
        }
    }
}
