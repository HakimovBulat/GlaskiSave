using Microsoft.Win32;
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

namespace Лаба_10
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Agent currentAgent = new Agent();
        public AddEditPage(Agent SelectedAgent)
        {
            InitializeComponent();
            if (SelectedAgent != null)
            {
                currentAgent = SelectedAgent;
            }
            DataContext = currentAgent;
            var currentTypes = HakimovGlaskiSaveEntities.GetContext().AgentType.ToList();
            var types = new List<string> { };

            for (int i = 0; i < currentTypes.Count; i++)
                types.Add(currentTypes[i].Title);
            ComboType.ItemsSource = types;

            var currentSales = HakimovGlaskiSaveEntities.GetContext().ProductSale.ToList();
            currentSales = currentSales.Where(p => p.AgentID == currentAgent.ID).ToList();
            SaleListBox.ItemsSource = currentSales;
        }

        private void ChangedPictureBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myOpenFileDialog = new OpenFileDialog();
            if (myOpenFileDialog.ShowDialog() == true)
            {
                currentAgent.Logo = myOpenFileDialog.FileName;
                LogoImage.Source = new BitmapImage(new Uri(myOpenFileDialog.FileName));
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (ComboType.SelectedItem == null)
                errors.AppendLine("Укажите тип агента");
            if (currentAgent.Priority <= 0)
                errors.AppendLine("Укажите положительный приоритет агента");
            if (string.IsNullOrWhiteSpace(currentAgent.Title))
                errors.AppendLine("Укажите наименование агента");
            if (string.IsNullOrWhiteSpace(currentAgent.Address))
                errors.AppendLine("Укажите адрес агента");
            if (string.IsNullOrWhiteSpace(currentAgent.DirectorName))
                errors.AppendLine("Укажите ФИО директора");
            if (string.IsNullOrWhiteSpace(currentAgent.Priority.ToString()))
                errors.AppendLine("Укажите приоритет агента");
            if (string.IsNullOrWhiteSpace(currentAgent.INN))
                errors.AppendLine("Укажите ИНН агента");
            if (string.IsNullOrWhiteSpace(currentAgent.KPP))
                errors.AppendLine("Укажите КПП агента");
            if (string.IsNullOrWhiteSpace(currentAgent.Phone))
                errors.AppendLine("Укажите телефон агента");
            else
            {
                string ph = currentAgent.Phone.Replace("+", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "");
                if (((ph[1] == '9' || ph[1] == '4' || ph[1] == '8') && ph.Length != 11) || (ph[1] == '3' && ph.Length != 12))
                    errors.AppendLine("Укажите правильный телефон агента");
            }
            if (string.IsNullOrWhiteSpace(currentAgent.Email))
                errors.AppendLine("Укажите почту агента");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            var currentTypes = HakimovGlaskiSaveEntities.GetContext().AgentType.ToList();
            var types = new List<string> { };

            for (int i = 0; i < currentTypes.Count; i++)
                types.Add(currentTypes[i].Title);

            //ComboType.ItemsSource = types;

            currentAgent.AgentTypeID = ComboType.SelectedIndex + 1;
            currentAgent.AgentTypeString = types[ComboType.SelectedIndex];
            if (currentAgent.ID == 0)
                HakimovGlaskiSaveEntities.GetContext().Agent.Add(currentAgent);

            try
            {
                HakimovGlaskiSaveEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentClientServices = HakimovGlaskiSaveEntities.GetContext().ProductSale.ToList();
            currentClientServices = currentClientServices.Where(p => p.AgentID == currentAgent.ID).ToList();
            if (currentClientServices.Count != 0) //если есть записи на этот сервис
                MessageBox.Show("Невозможно выполнить удаление, так как существуют записи на эту услугу");
            else
            {
                if (MessageBox.Show("Вы точно хотите выполнить удаление?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        HakimovGlaskiSaveEntities.GetContext().Agent.Remove(currentAgent);
                        HakimovGlaskiSaveEntities.GetContext().SaveChanges();
                        Manager.MainFrame.GoBack();
                        //выводим в листвью измененную таблицу Сервис
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            }

        private void AddSaleBtn_Click(object sender, RoutedEventArgs e)
        {
            SaleWindow myWindow = new SaleWindow();
            myWindow.ShowDialog();
            ProductSale newSale = new ProductSale();
            newSale.SaleDate =  Convert.ToDateTime(myWindow.SaleDate.Text);
            var currentProducts = HakimovGlaskiSaveEntities.GetContext().Product.ToList();
            //var currentProduct = currentProducts.Where(p => p.Title == myWindow.ComboProducts.SelectedItem).ToList()[0];
            newSale.ProductID = myWindow.ComboProducts.SelectedIndex + 1;
            newSale.ProductCount = Convert.ToInt32(myWindow.TBSaleCount.Text.ToString());
            newSale.AgentID = currentAgent.ID;
            HakimovGlaskiSaveEntities.GetContext().ProductSale.Add(newSale);
            try
            {
                HakimovGlaskiSaveEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                var currentSales = HakimovGlaskiSaveEntities.GetContext().ProductSale.ToList();
                var currentSale = currentSales.Where(p => p.AgentID == currentAgent.ID).ToList()[0];
                //HakimovGlaskiSaveEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                HakimovGlaskiSaveEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                SaleListBox.ItemsSource = HakimovGlaskiSaveEntities.GetContext().ProductSale.ToList().Where(p => p.AgentID == currentAgent.ID).ToList();
                //Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void DeleteSaleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SaleListBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выбери продажу");
                return;
            }
            if (SaleListBox.SelectedItems.Count == 1)
            {
                var currentSales = HakimovGlaskiSaveEntities.GetContext().ProductSale.ToList();
                var currentSale = currentSales.Where(p => p.AgentID == currentAgent.ID).ToList()[SaleListBox.SelectedIndex];
                HakimovGlaskiSaveEntities.GetContext().ProductSale.Remove(currentSale);
                HakimovGlaskiSaveEntities.GetContext().SaveChanges();
                MessageBox.Show("Продажа удалена");
                HakimovGlaskiSaveEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                SaleListBox.ItemsSource = HakimovGlaskiSaveEntities.GetContext().ProductSale.ToList().Where(p => p.AgentID == currentAgent.ID).ToList();
                return;
            }
            else
            {
                MessageBox.Show("Выбери 1 продажу");
                return;
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                HakimovGlaskiSaveEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                SaleListBox.ItemsSource = HakimovGlaskiSaveEntities.GetContext().ProductSale.ToList().Where(p => p.AgentID == currentAgent.ID).ToList();
            }
        }
    }
    }

