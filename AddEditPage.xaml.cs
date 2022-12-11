using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace таблица_лаба_2
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private const string _conString = @"Data Source=DESKTOP-E9DEOL4\MSSQLSERVER01;Initial Catalog = client; Integrated Security = True";
        private readonly ObservableCollection<Lizing> Liz;
        public AddEditPage()
        {
            InitializeComponent();
            Liz = new ObservableCollection<Lizing>();
            Lizing.ItemsSource = clientEntities2.GetContext().Lizing.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Add(null));
        }
        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите удалить?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var liz = Lizing.SelectedItem as Lizing;
                if (liz == null)
                    return;

                try
                {
                    using (var cnn = new SqlConnection(_conString))
                    using (var cmd = cnn.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM Lizing WHERE ID = @id";
                        cmd.Parameters.AddWithValue("@id", liz.ID);
                        await cnn.OpenAsync();
                        var deleted = await cmd.ExecuteNonQueryAsync();
                        MessageBox.Show($"Удалено {deleted}");
                    }
                    Liz.Remove(liz);
                    Lizing.ItemsSource = clientEntities2.GetContext().Lizing.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Add((sender as Button).DataContext as Lizing));
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                clientEntities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                Lizing.ItemsSource = clientEntities2.GetContext().Lizing.ToList();
            }
        }
    }
}
