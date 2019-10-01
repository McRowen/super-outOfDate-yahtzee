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
        GamePlayer.GamePlayer g = new GamePlayer.GamePlayer();
        Game.Game game = new Game.Game();
        int click = 0;
        public static List<Player.Player> players = new List<Player.Player>();
        public static bool styrdYatzy = false;
        public StartView()
        {           
            InitializeComponent();
            listViewDbPlayers.ItemsSource = null;
            listViewDbPlayers.ItemsSource = sql.GetAllPlayers();
            listViewChosenPlayers.ItemsSource = null;
            listViewStartedGames.ItemsSource = null;
            listViewStartedGames.ItemsSource = sql.PlayersInGame();


            if (players.Count < 2)
            {
                btnStart.IsEnabled = false;
            }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
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
            sql.AddPlayerTest(txtFirstName.Text, txtLastName.Text, txtNickName.Text);
            listViewDbPlayers.ItemsSource = null;
            listViewDbPlayers.ItemsSource = sql.GetAllPlayers();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtNickName.Clear();
        }

        private void BtnChoose_Click(object sender, RoutedEventArgs e)
        {
            if (players.Count >= 1)
            {
                btnStart.IsEnabled = true;
            }
            players.Add(sql.GetChosenPlayer((Player.Player)listViewDbPlayers.SelectedItem));
            listViewChosenPlayers.ItemsSource = null;
            listViewChosenPlayers.ItemsSource = players;
            click++;

            for (int i = 0; i < click; i++)
            {
                if (click == 4)
                {
                    BtnChoose.IsEnabled = false;                   
                }                
            }            
        }

        private void ListViewChosenPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Du har nu {click} spelare i ditt spel, då spelar vi.");

            styrdYatzy = true;
            //sql.GetStyrtGame(); //metod för styrt yatzy.
            Test.FormLabelTest f = new Test.FormLabelTest();
            this.Hide();
            f.Show();

        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            HelpView helpview = new HelpView();
            helpview.ShowDialog();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Du har nu {click} spelare i ditt spel, då spelar vi.");

            //sql.GetGame();
            //sql.StartNewGamePlayer(players); //Dessa två skickar upp all information till databsen och tar ut game_id m.m

            Test.FormLabelTest f = new Test.FormLabelTest();
            this.Hide();
            f.Show();
        }

        private void BtnStartGame_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Du har nu {click} spelare i ditt spel, då spelar vi.");
            //sql.StartNewGame();
            //sql.GameID();
            //sql.GetGame();
            //sql.StartNewGamePlayer(players);

            GameView gameView = new GameView();
            gameView.Show();
            //this.Hide();
        }


        private void ListViewDbPlayers_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            if (players.Count >= 1)
            {
                btnStart.IsEnabled = true;
            }
            players.Add(sql.GetChosenPlayer((Player.Player)listViewDbPlayers.SelectedItem));           
            listViewChosenPlayers.ItemsSource = null;
            listViewChosenPlayers.ItemsSource = players;

            click++;

            for (int i = 0; i < click; i++)
            {
                if (click == 4)
                {
                    BtnChoose.IsEnabled = false;
                    listViewDbPlayers.IsEnabled = false;
                }
            }           
        }

        private void ListViewChosenPlayers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i] == listViewChosenPlayers.SelectedItem)
                {
                    players.Remove(players[i]);
                }
            }
            listViewChosenPlayers.ItemsSource = null;
            listViewChosenPlayers.ItemsSource = players;
        }
    }    
}
