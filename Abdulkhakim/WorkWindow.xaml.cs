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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Abdulkhakim
{
    /// <summary>
    /// Interaction logic for WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        public WorkWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Abdulkhakim.WorldSkills2020DataSet worldSkills2020DataSet = ((Abdulkhakim.WorldSkills2020DataSet)(this.FindResource("worldSkills2020DataSet")));
            // Загрузить данные в таблицу Receipts. Можно изменить этот код как требуется.
            Abdulkhakim.WorldSkills2020DataSetTableAdapters.ReceiptsTableAdapter worldSkills2020DataSetReceiptsTableAdapter = new Abdulkhakim.WorldSkills2020DataSetTableAdapters.ReceiptsTableAdapter();
            worldSkills2020DataSetReceiptsTableAdapter.Fill(worldSkills2020DataSet.Receipts);
            System.Windows.Data.CollectionViewSource receiptsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("receiptsViewSource")));
            receiptsViewSource.View.MoveCurrentToFirst();
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
