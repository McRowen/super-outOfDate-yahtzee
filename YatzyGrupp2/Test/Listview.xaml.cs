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

namespace YatzyGrupp2.Test
{
    /// <summary>
    /// Interaction logic for Listview.xaml
    /// </summary>
    public partial class Listview : Window
    {
        
        public Listview()
        {
            InitializeComponent();
            
        }

        private void initListView()
        {/*
            // Add columns
            lvRegAnimals.Columns.Add("Id", -2, HorizontalAlignment.Left);
            lvRegAnimals.Columns.Add("Name", -2, HorizontalAlignment.Left);
            lvRegAnimals.Columns.Add("Age", -2, HorizontalAlignment.Left);
         */
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            List<DataTest> dataTests;
            dataTests = new List<DataTest>();
            dataTests.Add(new DataTest("Spelare", 1, 2, 3, 4));
            listView.ItemsSource = dataTests;
        }
    }
}
