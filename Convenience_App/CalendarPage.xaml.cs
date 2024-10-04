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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Convenience_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CalendarPage : Page
    {
        Library library = new Library();

        public CalendarPage()
        {
            this.InitializeComponent();
        }

        private async void Display_Loaded(object sender, RoutedEventArgs e)
        {
            library.Start(ref Picker);
            Display.ItemsSource = await library.ListAsync((DateTimeOffset)Picker.Date);
        }

        private async void Picker_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            Display.ItemsSource = await library.ListAsync((DateTimeOffset)Picker.Date);
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            if (await library.AddAsync(Add, App.Current.Resources))
            {
                Display.ItemsSource = await library.ListAsync((DateTimeOffset)Picker.Date);
            }
        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (await library.EditAsync((AppBarButton)sender, App.Current.Resources))
            {
                Display.ItemsSource = await library.ListAsync((DateTimeOffset)Picker.Date);
            }
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (await library.DeleteAsync((AppBarButton)sender))
            {
                Display.ItemsSource = await library.ListAsync((DateTimeOffset)Picker.Date);
            }
        }
    }
}
