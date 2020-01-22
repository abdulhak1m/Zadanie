using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Abdulkhakim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            using(SqlConnection connection = new SqlConnection(Connection.Connection.GetString()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM [Authorization] where Username = '" + textBoxUsername.Text.Trim() + "' and [Password] = '" + txtPassword.Password.Trim() + "'", connection);
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("Такого пользователя нет");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            if (reader["RoleId"].ToString() == "E")
                            {
                                WorkWindow workWindow = new WorkWindow();
                                workWindow.ShowDialog();
                                Close();
                            }
                            if(reader["RoleId"].ToString() == "C")
                            {
                                ClientWindow client = new ClientWindow();
                                client.ShowDialog();
                                Close();
                            }
                        }
                    }
                }
            }
        }
    }
}
