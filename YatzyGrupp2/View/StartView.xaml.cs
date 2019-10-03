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

        // inititerar klasser och skapar listor
        SQLCommands.SQLCommands sql = new SQLCommands.SQLCommands();
        GamePlayer.GamePlayer g = new GamePlayer.GamePlayer();
        Game.Game game = new Game.Game();
        int click = 0;
        public static List<Player.Player> players = new List<Player.Player>();
        public static bool styrdYatzy = false;
        public static List<Player.Player> allPlayers = new List<Player.Player>();
       
        // konstruktorn lägger rensar och lägger in information i listviewsen
        public StartView()
        {           
            InitializeComponent();
            listViewDbPlayers.ItemsSource = null;
            allPlayers = sql.GetAllPlayers();
            listViewDbPlayers.ItemsSource = allPlayers;
            listViewChosenPlayers.ItemsSource = null;
            listViewStartedGames.ItemsSource = null;
            listViewStartedGames.ItemsSource = sql.PlayersInGame();

            // gör så att start knapparna inte går att trycka på om det är mindre än två spelare
            if (players.Count < 2)
            {
                btnStyrt.IsEnabled = false;
                btnStart.IsEnabled = false;
            }
        }
        // lägger in en ny spelare i databasen
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sql.AddPlayerTest(txtFirstName.Text, txtLastName.Text, txtNickName.Text);
            txtFirstName.Clear();
            txtLastName.Clear();
            txtNickName.Clear();
        }
        //öppnar highscore listan
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HighScoreView highScore = new HighScoreView();
            highScore.ShowDialog();
        }
        // lägger också in en spelare i databasen???
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            sql.AddPlayerTest(txtFirstName.Text, txtLastName.Text, txtNickName.Text);
            listViewDbPlayers.ItemsSource = null;
            listViewDbPlayers.ItemsSource = allPlayers;
            txtFirstName.Clear();
            txtLastName.Clear();
            txtNickName.Clear();
        }
        // lägger in en spelare från alla spelare listan till spelare som ska spela listen
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
        // startar styrt yatzy

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Du har nu {click} spelare i ditt spel, då spelar vi.");

            styrdYatzy = true;

            sql.GetStyrtGame(); //metod för styrt yatzy.
            sql.StartNewGamePlayer(players);
            Test.FormLabelTest f = new Test.FormLabelTest();
            this.Hide();
            f.Show();

        }
        // öppnar helpwindow
        private void Help_Click(object sender, RoutedEventArgs e)
        {
            HelpView helpview = new HelpView();
            helpview.ShowDialog();
        }
        // Startar ett vanligt spel.
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Du har nu {click} spelare i ditt spel, då spelar vi.");

            sql.GetGame();
            sql.StartNewGamePlayer(players); //Dessa två skickar upp all information till databsen och tar ut game_id m.m

            Test.FormLabelTest f = new Test.FormLabelTest();
            f.Show();
            this.Hide();
        }

      
        // Gör så att man kan dubbelklicka på listviewn för att lägga till en spelare till "chosen players"
        private void ListViewDbPlayers_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            if (listViewDbPlayers.SelectedItem == null)
            {
                MessageBox.Show("Du måste välja en spelare");
            }
            else
            {
                players.Add(sql.GetChosenPlayer((Player.Player)listViewDbPlayers.SelectedItem));
                listViewChosenPlayers.ItemsSource = null;
                listViewChosenPlayers.ItemsSource = players;
                    click++;

                // om det är mer än 1 spelare så går det klicka på starta knapparna
                if (players.Count > 1)
                {
                    btnStyrt.IsEnabled = true;
                    btnStart.IsEnabled = true;
                }
                              
                // click är en variabel som räknar ut hur många spelare det är i spelet.
                for (int i = 0; i < click; i++)
                {
                    if (click == 4)
                    {
                        BtnChoose.IsEnabled = false;
                        listViewDbPlayers.IsEnabled = false;
                    }
                }
                for (int i = 0; i < allPlayers.Count; i++)
                {
                    if (allPlayers[i] == listViewDbPlayers.SelectedItem)
                    {
                        allPlayers.Remove(allPlayers[i]);
                    }
                }
                listViewDbPlayers.ItemsSource = null;
                listViewDbPlayers.ItemsSource = allPlayers;
            }     
        }
        // gör så att man kan ta bort en spelare från spelet
        private void ListViewChosenPlayers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i] == listViewChosenPlayers.SelectedItem)
                {

                    players.Remove(players[i]);
                    allPlayers.Add((Player.Player)listViewChosenPlayers.SelectedItem);

                }
            }
            if (listViewChosenPlayers.SelectedItem != null)
            {
            click--;
            }
            if (click == 1)
            {
                btnStart.IsEnabled = false;
                btnStyrt.IsEnabled = false;
                BtnChoose.IsEnabled = false;
                listViewDbPlayers.IsEnabled = true;
               
            }
            if (click >= 2)
                {
                    BtnChoose.IsEnabled = true;
                btnStyrt.IsEnabled = true;
                BtnChoose.IsEnabled = true;
                listViewDbPlayers.IsEnabled = true;
                }
            if (click > 4)
            {
                btnStart.IsEnabled = false;
                btnStyrt.IsEnabled = false;
                BtnChoose.IsEnabled = false;
                listViewDbPlayers.IsEnabled = false;
            }

            listViewChosenPlayers.ItemsSource = null;
            listViewChosenPlayers.ItemsSource = players;
            listViewDbPlayers.ItemsSource = null;
            listViewDbPlayers.ItemsSource = allPlayers;
        }
        // stänger av programmet om man trycker på krysset.
        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }    
        
}
