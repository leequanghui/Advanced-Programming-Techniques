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
    public sealed partial class PlayPage : Page
    {
        float bestTime;

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

        DispatcherTimer timer = new DispatcherTimer(); //Tạo biến timer  
        int tenthsOfSecondsElapsed; //Tạo biến đếm thời gian 1/10 giây   
        int matchesFound; //Số cặp được trùng khớp

        public PlayPage()
        {
            this.InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick; ;
            SetUpGame();
        }

        private void Timer_Tick(object sender, object e)
        {
            tenthsOfSecondsElapsed++;
            timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
            if (matchesFound == 8)
            {
                float currentTime = tenthsOfSecondsElapsed / 10F;
                if (bestTime == 0 || currentTime < bestTime)
                {
                    bestTime = currentTime;
                    bestTimeTextBlock.Text = "Best Time: " + bestTime.ToString("0.0s");
                }

                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
            }
        }

        private void SetUpGame()
        {
            List<string> animalEmoiji = new List<string>()
            {
                "🐯", "🐯",
                "🐶", "🐶",
                "🦊", "🦊",
                "🤡", "🤡",
                "🦉", "🦉",
                "😽", "😽",
                "💩", "💩",
                "🦖", "🦖",
            };
            Random random = new Random(); //Tạo biến random   
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(animalEmoiji.Count); //Tạo giá trị ngẫu nhiên 0 - kích thước của list
                string nextEmoiji = animalEmoiji[index]; //Tạo emoiji ngẫu nhiên từ list với index
                textBlock.Text = nextEmoiji; //Gán Emoij cho textBlock   
                animalEmoiji.RemoveAt(index); //Xóa phần tử vừa gán   
                textBlock.Visibility = Visibility.Visible; // Reset trạng thái của các TextBlock
            }
            tenthsOfSecondsElapsed = 0;
            matchesFound = 0;
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Collapsed;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text && textBlock != lastTextBlockClicked)
            {
                textBlock.Visibility = Visibility.Collapsed;
                matchesFound++; // Tăng số lượng cặp hình giống nhau đã tìm thấy 
                if (matchesFound == 8)
                {
                    float currentTime = tenthsOfSecondsElapsed / 10F;
                    if (bestTime == 0 || currentTime < bestTime)
                    {
                        bestTime = currentTime;
                        bestTimeTextBlock.Text = "Best Time: " + bestTime.ToString("0.0s");
                    }
                    timer.Stop(); // Dừng timer nếu tất cả cặp hình giống nhau đã được tìm thấy
                    timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
                }
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }

        private void timeTextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (matchesFound == 8 || tenthsOfSecondsElapsed == 0)
            {
                SetUpGame();
                timer.Start(); // Khởi động timer khi bắt đầu hoặc chơi lại 
            }
        }
    }
}
