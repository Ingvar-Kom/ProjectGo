using System.Data.SqlClient;
using System.Data;
using System.IO;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;
using System;

namespace my_project
{
    
    public partial class WebMainWindow : Window
    {

        WindowMuzik windowMuzik;
        DateTime DateOfBirth;
        byte[] image_bytes;
        DataBase dataBase = new DataBase();
        public WebMainWindow()
        {
            InitializeComponent();
            if(Global1.LOGG1 == 1)
            {
                YourCode();
            }
            
        }

        private void YourCode()
        {
            string connectionString = @"Data Source=DESKTOP-NTMKSG2\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";
            //string query = "SELECT * FROM register";
            string query = $"select * from register where id_user = '{Global.LOGG}'";
            //int LOGG = 0;
            //string rrr= "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command1 = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            image_bytes  = (byte[])reader["Rimage"];
                            Img.Source = ByteImage.Convert(ByteImage.GetImageFromByteArray(image_bytes));
                            InputFirstName.Content = reader.GetString(5);
                            InputLastName.Content = reader.GetString(4);

                            DateOfBirth = reader.GetDateTime(6);
                            var today = DateTime.Today;
                            var age = today.Year - DateOfBirth.Year;
                            if (DateOfBirth.Date > today.AddYears(-age)) age--;
                            InputDateOfBirth.Content += " " + age.ToString();
                        }
                    }
                }
            }
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
        private void Mes_Demo(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("сработала какая-то функция)");
        }
        private void Button_Window_Welcom(object sender, RoutedEventArgs e)
        {
            if (windowMuzik != null)
            {
                windowMuzik.Close();
            }

            WelcomeWindow welcomeWindow = new();
            welcomeWindow.Show();
            
            Close();

        }
        private void Button_Window_Main(object sender, RoutedEventArgs e)
        {
            MainWindowApplications mainWindowApplications = new();
            mainWindowApplications.Show();
            Close();
        }

        private void Button_Window_Muzic(object sender, RoutedEventArgs e)
        {
            windowMuzik = new();
            windowMuzik.Show();
        }


       
    }
}



//private void CheckBox1_Checked(object sender, RoutedEventArgs e)
//{
//    ProgressBar.Value = 25;
//}

//private void CheckBox1_Unchecked(object sender, RoutedEventArgs e)
//{
//    ProgressBar.Value = 0;
//}

//private void CheckBox2_Checked(object sender, RoutedEventArgs e)
//{
//    ProgressBar.Value = 50;
//}

//private void CheckBox2_Unchecked(object sender, RoutedEventArgs e)
//{
//    ProgressBar.Value = 0;
//}

//private void CheckBox3_Checked(object sender, RoutedEventArgs e)
//{
//    ProgressBar.Value = 75;
//}

//private void CheckBox3_Unchecked(object sender, RoutedEventArgs e)
//{
//    ProgressBar.Value = 0;
//}

//private void CheckBox4_Checked(object sender, RoutedEventArgs e)
//{
//    ProgressBar.Value = 100;
//}

//private void CheckBox4_Unchecked(object sender, RoutedEventArgs e)
//{
//    ProgressBar.Value = 0;
//}




























//private void Button_Click(object sender, RoutedEventArgs e)
//{

//    string connectionString = @"Data Source=DESKTOP-NTMKSG2\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";
//    string query = "SELECT * FROM register";
//    int LOGG;
//    using (SqlConnection connection = new SqlConnection(connectionString))
//    {
//        connection.Open();
//        using (SqlCommand command = new SqlCommand(query, connection))
//        {
//            using (SqlDataReader reader = command.ExecuteReader())
//            {
//                while (reader.Read())
//                {
//                    LOGG = reader.GetInt32(0);
//                    ListOfUsers.Items.Add(LOGG);
//                }
//            }
//        }
//    }

//    //string connectionString = @"Data Source=DESKTOP-NTMKSG2\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";
//    //string query = "SELECT * FROM register";

//    //using (SqlConnection connection = new SqlConnection(connectionString))
//    //{
//    //    connection.Open();
//    //    using (SqlCommand command = new SqlCommand(query, connection))
//    //    {
//    //        using (SqlDataReader reader = command.ExecuteReader())
//    //        {
//    //            while (reader.Read())
//    //            {
//    //                ListOfUsers.Items.Add(new { Login = reader.GetString(1), Id = reader.GetInt32(0), Pass = reader.GetString(2), LName = reader.GetString(4), FName = reader.GetString(5), Data = reader.GetDateTime(6) });
//    //            }
//    //        }
//    //    }
//    //}



//}