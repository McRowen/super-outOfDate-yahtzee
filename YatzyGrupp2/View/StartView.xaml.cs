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

namespace YatzyGrupp2.View
{
    /// <summary>
    /// Interaction logic for StartView.xaml
    /// </summary>
    public partial class StartView : Window
    {
        SQLCommands.SQLCommands sql = new SQLCommands.SQLCommands();
        
        public StartView()
        {
            
            InitializeComponent();
            listViewDbPlayers.ItemsSource = null;
            listViewDbPlayers.ItemsSource = sql.GetAllPlayers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SQLCommands.SQLCommands sql = new SQLCommands.SQLCommands();

            //MessageBox.Show(sql.GetAllPlayer().ToString());
            sql.AddPlayerTest(txtFirstName.Text, txtLastName.Text, txtNickName.Text);
            txtFirstName.Clear();
            txtLastName.Clear();
            txtNickName.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HighScoreView highScore = new HighScoreView();
            highScore.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SQLCommands.SQLCommands sql = new SQLCommands.SQLCommands();

            //MessageBox.Show(sql.GetAllPlayer().ToString());
            sql.AddPlayerTest(txtFirstName.Text, txtLastName.Text, txtNickName.Text);
            txtFirstName.Clear();
            txtLastName.Clear();
            txtNickName.Clear();
        }

        private void BtnChoose_Click(object sender, RoutedEventArgs e)
        {
            sql.GetChosenPlayer((Player.Player)listViewDbPlayers.SelectedItem);
            listViewChosenPlayers.ItemsSource = null;
            listViewChosenPlayers.Items.Add(sql.GetChosenPlayer((Player.Player)listViewDbPlayers.SelectedItem));

        }

        private void ListViewChosenPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //listViewDbPlayers.ItemsSource = null;
            //listViewDbPlayers.ItemsSource = sql.GetChosenPlayer();
        }
    }
}
