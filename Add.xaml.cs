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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace таблица_лаба_2
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        private Lizing _currentLizing = new Lizing();
        public Add(Lizing selectedLizing)
        {
            InitializeComponent();

            if (selectedLizing != null)
                _currentLizing = selectedLizing;

            DataContext = _currentLizing;
            ComboAuto.ItemsSource = clientEntities2.GetContext().Auto.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentLizing.ID == 0)
                clientEntities2.GetContext().Lizing.Add(_currentLizing);
            try
            {
                clientEntities2.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
