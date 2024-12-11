using PerfumeManagement.BLL.Service;
using PerfumeManagement.DAL.Entities;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PerfumeManagement_StudentCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PerfumeService _PerService = new();

        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            DetailWindow d = new();
            d.ShowDialog();//
            FillDataGrid(_PerService.GetAllPerfume());
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            PerfumeInformation? selected = PerfumeDataGrid.SelectedItem as PerfumeInformation;
            if (selected == null)
            {
                MessageBox.Show("Please select A Perfume Before Update", "Select A Perfume to update!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DetailWindow d = new();
            d.EditedOne = selected;
            d.ShowDialog();// làm xong rồi mới quay về MainWindow
            FillDataGrid(_PerService.GetAllPerfume());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            PerfumeInformation? selected = PerfumeDataGrid.SelectedItem as PerfumeInformation;
            if (selected == null)
            {
                MessageBox.Show("Please select A Perfume Before Deleting", "Select A Perfume to delete!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult? answer = MessageBox.Show("Are You Sure Delete???", "Confirm Delete???", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.No)
                return;
            _PerService.DeletePerfume(selected);

            FillDataGrid(_PerService.GetAllPerfume());
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PerfumeDataGrid.ItemsSource = _PerService.GetAll();
        }

        private void FillDataGrid(List<PerfumeInformation> list)
        {
            PerfumeDataGrid.ItemsSource = null;  
            PerfumeDataGrid.ItemsSource = list;
        }
    }
}