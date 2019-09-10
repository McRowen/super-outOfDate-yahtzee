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
        public GameView()
        {
            InitializeComponent();
        }
        bool[] diceThrow = new bool[] { false, false, false, false, false };
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Gamelogic.Gamelogic gamelogic = new Gamelogic.Gamelogic();
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
            
        }

        private void Dice1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            diceThrow[0] = true;
            
        }

        private void Dice2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            diceThrow[1] = true;
        }

        private void Dice3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            diceThrow[2] = true;
        }

        private void Dice4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            diceThrow[3] = true;
        }

        private void Dice5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            diceThrow[4] = true;
        }

        private void btn_test_Click(object sender, RoutedEventArgs e)
        {
            SQLCommands.SQLCommands sql = new SQLCommands.SQLCommands();
            MessageBox.Show(sql.GetAllPlayer().ToString());
        }





    }
}
