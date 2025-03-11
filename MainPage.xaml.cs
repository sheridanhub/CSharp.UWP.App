using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CSharp.UWP.App.Pages;
using System.Drawing;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CSharp.UWP.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            this.InitializeComponent();
            
        }
        /// <summary>
        /// Navigation Item Selected, page loaded 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void NavTopLevelNav_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            Type _page = null;

            
            switch (args.InvokedItem)
            {
                case "Earbuds":
                    
                    _page = typeof(EarbudsPage);
                    break;
                case "Watchs":
                    _page = typeof(WatchPage);
                    break;
                case "Thermostat":
                    _page = typeof(ThermostatPage);
                    break;
                case "Laptops":
                    _page = typeof(LaptopPage);
                    break;
                case "Accessories":
                    _page = typeof(AccessoriesPage);
                    break;
            }
            
            NavView_Navigate(_page, args.RecommendedNavigationTransitionInfo);
            NavTopLevelNav.SelectedItem = _page;
        }
        /// <summary>
        /// Navigation for selected Nav Item
        /// </summary>
        /// <param name="_page"></param>
        /// <param name="transitionInfo"></param>
        private void NavView_Navigate(
    Type _page,
    Windows.UI.Xaml.Media.Animation.NavigationTransitionInfo transitionInfo)
        {
            

            // Only navigate if the selected page isn't currently loaded.
            if (!(_page is null) && !Type.Equals(contentFrame.CurrentSourcePageType, _page))
            {
                contentFrame.Navigate(_page, null, transitionInfo);
            }
            else
            {
                contentFrame.Navigate(typeof(HomePage));
                NavTopLevelNav.SelectedItem = typeof(HomePage);
            }
        }
        /// <summary>
        /// Top Menu Icon for viewing previous pages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void NavTopLevelNav_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (contentFrame.CanGoBack)
            {
                contentFrame.GoBack();
            }
        }
        /// <summary>
        /// On Page Load, default page - HomePage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavTopLevelNav_Loaded(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(HomePage));
            NavTopLevelNav.SelectedItem = typeof(HomePage);
        }

    }

}
