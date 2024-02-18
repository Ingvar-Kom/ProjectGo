using Microsoft.Win32;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace my_project
{
    public partial class WindowMuzik : Window
    {
        public WindowMuzik()
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

        private void ButtonOpen_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == true)
            {
                Player.Source = new Uri(dialog.FileName, UriKind.Absolute);
            }

            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            Player.Play();
            Thread.Sleep(1500);
            Player.Stop();

            
            Position.Maximum = Player.NaturalDuration.TimeSpan.TotalSeconds;

            timer.Tick += (_, _) =>
            {
                LabelStatus.Content = Player.Source is not null
                    ? $@"{Player.Position:hh\:mm\:ss} / {Player.NaturalDuration.TimeSpan:hh\:mm\:ss}"
                    : "Нет файла...";
            };
            timer.Start();
        }

        private void ButtonPlay_OnClick(object sender, RoutedEventArgs e)
        {
            Player.Play();
        }

        private void ButtonPause_OnClick(object sender, RoutedEventArgs e)
        {
            Player.Pause();
        }

        private void ButtonStop_OnClick(object sender, RoutedEventArgs e)
        {
            Player.Stop();
        }

        private void Volume_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Player.Volume = (sender as Slider)!.Value;
        }

        private void Position_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Player.Pause();
            Player.Position = new TimeSpan(0, 0, 0, (int)(sender as Slider)!.Value);
            Player.Play();
        }
    }
}