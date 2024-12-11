using PerfumeManagement.BLL.Service;
using PerfumeManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace PerfumeManagement_StudentCode
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        private PerfumeService _perfumeService = new();
        private CompanyService _companyService = new();
        public PerfumeInformation EditedOne { get; set; }
        public DetailWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckVar())
                return;

            PerfumeInformation obj = new PerfumeInformation();
            obj.PerfumeId = PerfumeIDTextBox.Text;
            obj.PerfumeName = PerfumeNameTextBox.Text;
            obj.Ingredients = IngredientsTextBox.Text;
            obj.ReleaseDate = ReleaseDateDatePicker.SelectedDate;
            obj.Concentration = ConcentrationTextBox.Text;
            obj.Longevity = LongevityTextBox.Text;
            obj.ProductionCompanyId = ProductionCompanyIDComboBox.SelectedValue.ToString();

            if (EditedOne != null)
                _perfumeService.UpdatePerfume(obj);
            else
                _perfumeService.AddPerfume(obj);

            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool CheckVar()
        {
            if (string.IsNullOrWhiteSpace(PerfumeIDTextBox.Text))
            {
                MessageBox.Show("PerfumeID Is Required!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(PerfumeNameTextBox.Text))
            {
                MessageBox.Show("PerfumeName Is Required!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (PerfumeNameTextBox.Text.Trim().Length < 5 || PerfumeNameTextBox.Text.Trim().Length > 90)
            {
                MessageBox.Show("PerfumeName Length Must Be >=5 and <= 90!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            TextInfo textInfor = CultureInfo.CurrentCulture.TextInfo;

            string PerfumeName = PerfumeNameTextBox.Text.Trim();

            PerfumeName = textInfor.ToTitleCase(PerfumeName.ToLower());
            PerfumeNameTextBox.Text = PerfumeName;

            if (string.IsNullOrWhiteSpace(IngredientsTextBox.Text))
            {
                MessageBox.Show("Ingredients Is Required!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (ReleaseDateDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Release Date Is Required!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(ConcentrationTextBox.Text))
            {
                MessageBox.Show("Concentration Level Is Required!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(LongevityTextBox.Text))
            {
                MessageBox.Show("Longevity Is Required!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (ProductionCompanyIDComboBox.SelectedValue == null) 
            {
                MessageBox.Show("Company ID Is Required!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProductionCompanyIDComboBox.ItemsSource = _companyService.GetAllNCC();
            ProductionCompanyIDComboBox.DisplayMemberPath = "ProductionCompanyName";
            ProductionCompanyIDComboBox.SelectedValuePath = "ProductionCompanyId";
            if (EditedOne != null)
                FillElement();
        }

        private void FillElement()
        {
            PerfumeIDTextBox.Text = EditedOne.PerfumeId.ToString();
            PerfumeNameTextBox.Text = EditedOne.PerfumeName;
            IngredientsTextBox.Text = EditedOne.Ingredients;
            ReleaseDateDatePicker.SelectedDate = EditedOne.ReleaseDate;
            ConcentrationTextBox.Text = EditedOne.Concentration;
            LongevityTextBox.Text = EditedOne.Longevity;
            ProductionCompanyIDComboBox.SelectedValue = EditedOne.ProductionCompanyId;
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are You Sure Want To Exit!!!", "Exit!!!!", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
        }

    }
}
