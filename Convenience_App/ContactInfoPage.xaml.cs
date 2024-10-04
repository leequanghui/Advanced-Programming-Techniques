using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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
using static Convenience_App.AddFriendPage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Convenience_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContactInfoPage : Page
    {
        public ContactInfoPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var infoParameter = (Information)e.Parameter;
            if (infoParameter != null)
            {
                InforTextBlock.Text = $"Name: {infoParameter.Name}; Email: {infoParameter.Email}; Phone Number: {infoParameter.PhoneNumber}"; 
            }
            else
            {
                InforTextBlock.Text = "Dữ liệu bị trống, hãy nhập dữ liệu";
            }

        }
    }
}
