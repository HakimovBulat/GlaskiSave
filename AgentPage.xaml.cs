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
    /// Логика взаимодействия для AgentPage.xaml
    /// </summary>
    public partial class AgentPage : Page
    {
        int CountRecords;
        int CountPage;
        int CurrentPage = 0;
        public List<Agent> CurrentPageList = new List<Agent>();
        public List<Agent> TableList;
        public AgentPage()
        {
            InitializeComponent();

            var currentAgents = HakimovGlaskiSaveEntities.GetContext().Agent.ToList();
            var currentTypes = HakimovGlaskiSaveEntities.GetContext().AgentType.ToList();
            for (int i = 0; i < currentAgents.Count; i++)
            {
                if (currentAgents[i].Logo == "")
                    currentAgents[i].Logo = "res\\picture.png";
                for (int j = 0; j < currentTypes.Count; j++)
                {
                    if (currentAgents[i].AgentTypeID == currentTypes[j].ID)
                    {
                        currentAgents[i].AgentTypeString = currentTypes[j].Title;
                        break;
                    }
                }
            }
            var types = new List<string> { "Все типы" };

            for (int i = 0; i < currentTypes.Count; i++)
                types.Add(currentTypes[i].Title);

            ComboBoxAgentType.ItemsSource = types;
            AgentListView.ItemsSource = currentAgents;
            ComboBoxAgent.SelectedIndex = 0;
            ComboBoxAgentType.SelectedIndex = 0;
        }
        private void UpdateAgents()
        {
            var currentAgents = HakimovGlaskiSaveEntities.GetContext().Agent.ToList();
            var currentTypes = HakimovGlaskiSaveEntities.GetContext().AgentType.ToList();
            var types = new List<string> { "Все типы" };
            for (int i = 0; i < currentTypes.Count; i++)
                types.Add(currentTypes[i].Title);

            //if (TBoxSearch.Text.ToLower().Contains())
            var currentSearchAgents = currentAgents.Where(p => p.Title.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            if (currentSearchAgents.Count == 0)
            {
                currentSearchAgents = currentAgents.Where(p => p.Email.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            }
            if (currentSearchAgents.Count == 0)
            {
                currentSearchAgents = currentAgents.Where(p => p.Phone.ToLower().Replace("-", "").Replace("+", "").Replace("(", "").Replace(")", "").Replace(" ", "").Contains(TBoxSearch.Text.ToLower().Replace("-", "").Replace("+", "").Replace("(", "").Replace(")", "").Replace(" ", ""))).ToList();
            }
            if (currentSearchAgents.Count == 0)
            {
                currentSearchAgents = currentAgents.Where(p => p.Title.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            }
            currentAgents = currentSearchAgents;
            if (ComboBoxAgent.SelectedIndex == 1)
                currentAgents = currentAgents.OrderBy(p => p.Title).ToList();
            else if (ComboBoxAgent.SelectedIndex == 2)
                currentAgents = currentAgents.OrderByDescending(p => p.Title).ToList();
            else if (ComboBoxAgent.SelectedIndex == 3)
                currentAgents = currentAgents.OrderBy(p => p.Priority).ToList();
            else if (ComboBoxAgent.SelectedIndex == 4)
                currentAgents = currentAgents.OrderByDescending(p => p.Priority).ToList();

            if (ComboBoxAgentType.SelectedIndex != -1)
            {
                var currentAgentsNew = new List<Agent> { };
                for (int i = 0; i < currentAgents.Count; i++)
                {
                    if (currentAgents[i].AgentTypeString.Contains(types[ComboBoxAgentType.SelectedIndex]))
                        currentAgentsNew.Add(currentAgents[i]);
                }
                AgentListView.ItemsSource = currentAgentsNew;
                TableList = currentAgentsNew;
            }
            if (ComboBoxAgentType.SelectedIndex == 0 || ComboBoxAgentType.SelectedIndex == -1)
            {
                AgentListView.ItemsSource = currentAgents;
                TableList = currentAgents;
            }
            ChangePage(0, 0);
        }
        private void ChangePage(int direction, int? selectedPage)
        {
            CurrentPageList.Clear();
            CountRecords = TableList.Count;
            if (CountRecords % 10 > 0)
                CountPage = CountRecords / 10 + 1;
            else
                CountPage = CountRecords / 10;
            Boolean Ifupdate = true;
            int min;

            if (selectedPage.HasValue)
            {
                if (selectedPage >= 0 && selectedPage <= CountPage)
                {
                    CurrentPage = (int)selectedPage;
                    min = CurrentPage * 10 + 10 < CountRecords ? CurrentPage * 10 + 10 : CountRecords;
                    for (int i = CurrentPage * 10; i < min; i++)
                    {
                        CurrentPageList.Add(TableList[i]);
                    }
                }
            }
            else
            {
                switch (direction)
                {
                    case 1:
                        if (CurrentPage > 0)
                        {
                            CurrentPage--;
                            min = CurrentPage * 10 + 10 < CountRecords ? CurrentPage * 10 + 10 : CountRecords;
                            for (int i = CurrentPage * 10; i < min; i++)
                            {

                                CurrentPageList.Add(TableList[i]);
                            }
                        }

                        else
                        {
                            Ifupdate = false;
                        }
                        break;
                    case 2:
                        if (CurrentPage < CountPage - 1)
                        {
                            CurrentPage++;
                            min = CurrentPage * 10 + 10 < CountRecords ? CurrentPage * 10 + 10 : CountRecords;
                            for (int i = CurrentPage * 10; i < min; i++)
                            {
                                CurrentPageList.Add(TableList[i]);
                            }
                        }
                        else
                        {
                            Ifupdate = false;
                        }
                        break;
                }
            }
            if (Ifupdate)
            {
                PageListBox.Items.Clear();
                for (int i = 1; i <= CountPage; i++)
                {
                    PageListBox.Items.Add(i);
                }
                PageListBox.SelectedIndex = CurrentPage;
                AgentListView.ItemsSource = CurrentPageList;
                AgentListView.Items.Refresh();
                min = CurrentPage * 10 + 10 < CountRecords ? CurrentPage * 10 + 10 : CountRecords;
                TBCount.Text = min.ToString();
                TBAllRecords.Text = "из" + CountRecords.ToString();
            }
        }
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void ComboBoxAgent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void ComboBoxAgentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void PageListBox_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ChangePage(0, Convert.ToInt32(PageListBox.SelectedItem.ToString()) - 1);
        }

        private void LeftDirButton_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(1, null);
        }

        private void RightDirButton_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(2, null);
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                HakimovGlaskiSaveEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                AgentListView.ItemsSource = HakimovGlaskiSaveEntities.GetContext().Agent.ToList();
                UpdateAgents();
            }
        }
    }
}
