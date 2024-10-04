using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Convenience_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddFriendPage : Page
    {
        public AddFriendPage()
        {
            this.InitializeComponent();
        }

        public class Information //Tạo 1 cấu trúc để lưu các thông tin  
        {
            public string Name { get; set; } = "ABC"; //Property với tham số mặc định  
            public string Email { get; set; } = "abc@fetel.hcmus.edu.vn";
            public string PhoneNumber { get; set; } = "0123456789";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Information infoParameter = new Information();
            infoParameter.Name = NameTextBox.Text;
            infoParameter.Email = EmailTextBox.Text;
            infoParameter.PhoneNumber = PhoneNumberTextBox.Text;
            Frame.Navigate(typeof(ContactInfoPage), infoParameter); //Điều hướng sang ContactInfoPage với tham số
        }
    }
}
