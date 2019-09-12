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
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : Window
    {
        GamePlayer.GamePlayer gp = new GamePlayer.GamePlayer();
        List<Player.Player> gamePlayers = new List<Player.Player>();
        public GameView()
        {
            InitializeComponent();
            gamePlayers = StartView.players;
            if (gamePlayers.Count <= 1)
            {
                MessageBox.Show("Du måste välja minst två spelare");                
            }
            else if (gamePlayers.Count == 2)
            {
                lblPlayer1.Content = gamePlayers[0].Nickname;
                lblPlayer2.Content = gamePlayers[1].Nickname;
                lblPlayer3.Content = "";
                lblPlayer4.Content = "";
            }
            else if (gamePlayers.Count == 3)
            {
                lblPlayer1.Content = gamePlayers[0].Nickname;
                lblPlayer2.Content = gamePlayers[1].Nickname;
                lblPlayer3.Content = gamePlayers[2].Nickname;
                lblPlayer4.Content = "";
            }
            else
            {
                lblPlayer1.Content = gamePlayers[0].Nickname;
                lblPlayer2.Content = gamePlayers[1].Nickname;
                lblPlayer3.Content = gamePlayers[2].Nickname;
                lblPlayer4.Content = gamePlayers[3].Nickname;
            }
            
        }
        bool[] diceThrow = new bool[] { false, false, false, false, false };
        Gamelogic.Gamelogic gamelogic = new Gamelogic.Gamelogic();
        /*----Vilka Färger----*/

        Color clickColor = Colors.Green;
        Color mouseNotOnColor = Colors.White;
        Color mouseOnColor = Colors.Gray;        

        private void Button_Click(object sender, RoutedEventArgs e)
        {           
            int[] dice = new int[5];
             
            dice = gamelogic.GetRandomDice();
            if(diceThrow[0] != true)
            {
                Dice1.Content = Convert.ToString(dice[0]);
            }
            if(diceThrow[1] != true)
            {
                Dice2.Content = Convert.ToString(dice[1]);
            }
            if(diceThrow[2] != true)
            {
                Dice3.Content = Convert.ToString(dice[2]);
            }
            if(diceThrow[3] != true)
            {
                Dice4.Content = Convert.ToString(dice[3]);
            }
            if(diceThrow[4] != true)
            {
                Dice5.Content = Convert.ToString(dice[4]);
            }

            gamelogic.IncrementRound();

            if (gamelogic.TurnOver())
            {
                ThrowDice.IsEnabled = false;
            }
            else
            {
                ThrowDice.IsEnabled = true;
            }
        }

        private void Dice1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int i = 0;

            if (diceThrow[i] != true)
            {
                diceThrow[i] = true;
                Dice1.Background = new SolidColorBrush(clickColor);
            }
            else
            {
                diceThrow[i] = false;
                Dice1.Background = new SolidColorBrush(mouseNotOnColor);
            }

        }

        private void Dice2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int i = 1;

            if (diceThrow[i] != true)
            {
                diceThrow[i] = true;
                Dice2.Background = new SolidColorBrush(clickColor);
            }
            else
            {
                diceThrow[i] = false;
                Dice2.Background = new SolidColorBrush(mouseNotOnColor);
            }

        }

        private void Dice3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int i = 2;

            if (diceThrow[i] != true)
            {
                diceThrow[i] = true;
                Dice3.Background = new SolidColorBrush(clickColor);
            }
            else
            {
                diceThrow[i] = false;
                Dice3.Background = new SolidColorBrush(mouseNotOnColor);
            }

        }

        private void Dice4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int i = 3;

            if (diceThrow[i] != true)
            {
                diceThrow[i] = true;
                Dice4.Background = new SolidColorBrush(clickColor);
            }
            else
            {
                diceThrow[i] = false;
                Dice4.Background = new SolidColorBrush(mouseNotOnColor);
            }

        }

        private void Dice5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int i = 4;

            if (diceThrow[i] != true)
            {
                diceThrow[i] = true;
                Dice4.Background = new SolidColorBrush(clickColor);
            }
            else
            {
                diceThrow[i] = false;
                Dice4.Background = new SolidColorBrush(mouseNotOnColor);
            }

        }

        private void Dice1_MouseEnter(object sender, MouseEventArgs e)
        {
            if (diceThrow[0] != true)
            {
                Dice1.Background = new SolidColorBrush(mouseOnColor);
            }
            
        }

        private void Dice1_MouseLeave(object sender, MouseEventArgs e)
        {
            if (diceThrow[0] != true)
            {
                Dice1.Background = new SolidColorBrush(mouseNotOnColor);
            }
        }

        private void Dice2_MouseEnter(object sender, MouseEventArgs e)
        {
            if (diceThrow[1] != true)
            {
                Dice2.Background = new SolidColorBrush(mouseOnColor);
            }
        }

        private void Dice2_MouseLeave(object sender, MouseEventArgs e)
        {
            if (diceThrow[1] != true)
            {
                Dice2.Background = new SolidColorBrush(mouseNotOnColor);
            }
        }

        private void Dice3_MouseEnter(object sender, MouseEventArgs e)
        {
            if (diceThrow[2] != true)
            {
                Dice3.Background = new SolidColorBrush(mouseOnColor);
            }
        }

        private void Dice3_MouseLeave(object sender, MouseEventArgs e)
        {
            if (diceThrow[2] != true)
            {
                Dice3.Background = new SolidColorBrush(mouseNotOnColor);
            }
        }

        private void Dice4_MouseEnter(object sender, MouseEventArgs e)
        {
            if (diceThrow[3] != true)
            {
                Dice4.Background = new SolidColorBrush(mouseOnColor);
            }
        }

        private void Dice4_MouseLeave(object sender, MouseEventArgs e)
        {
            if (diceThrow[3] != true)
            {
                Dice4.Background = new SolidColorBrush(mouseNotOnColor);
            }
        }

        private void Dice5_MouseEnter(object sender, MouseEventArgs e)
        {
            if (diceThrow[4] != true)
            {
                Dice5.Background = new SolidColorBrush(mouseOnColor);
            }
        }

        private void Dice5_MouseLeave(object sender, MouseEventArgs e)
        {
            if (diceThrow[4] != true)
            {
                Dice5.Background = new SolidColorBrush(mouseNotOnColor);
            }
        }

        private void btn_test_Click(object sender, RoutedEventArgs e)
        {
            ////SQLCommands.SQLCommands sql = new SQLCommands.SQLCommands();
            ////MessageBox.Show(sql.GetAllPlayer().ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            StartView startview = new StartView();
            startview.ShowDialog();
        }
    }
}
