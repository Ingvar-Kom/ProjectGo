using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using XamlAnimatedGif;

namespace my_project
{
    public partial class MainWindowApplications : Window
    {
        public MainWindowApplications()
        {
            InitializeComponent();
        }
        private void Label_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();
        private void Button_Close_Window_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Button_Minimized_Window_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized; 
        }
        private void New_Info_Messeg(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Это основное окно приложения.\n" +
                " и это кнопка в которой будет\n" +
                " подробная информация о работе приложения,\n" +
                " и о всех её возможностях.\n" +
                " если есть идеи по улочшению функционала приложения\n" +
                " буду рад услышать ваше мнение");
        }
        private void New_Messeg_Save(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("пока-что нечего сохранять");
        }

        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://ya.ru");
        }

        private void Button_ImitationOfWebsiteOperation_Click(object sender, RoutedEventArgs e)
        {
            
            myImage.Source = new BitmapImage(new Uri("/Assets/GIF/ImitationOfWebsiteOperationPlanet.gif", UriKind.Relative));
        }

        private void Mes_Demo(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("сработала какая-то функция)"); 
        }
        private void Button_Window_Welcom(object sender, RoutedEventArgs e)
        {
            WelcomeWindow welcomeWindow = new WelcomeWindow();
            welcomeWindow.Show();
            Close();
        }
        private void Button_Window_Reg(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            Close();
        }
        private void Button_Window_Web(object sender, RoutedEventArgs e)
        {
            WebMainWindow webMainWindow = new WebMainWindow();
            webMainWindow.Show();
            Close();
        }

        private void Button_Window_Muzic(object sender, RoutedEventArgs e)
        {
            WindowMuzik windowMuzik = new();
            windowMuzik.Show();
        }
    }
}
