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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Gamelogic.Gamelogic gamelogic = new Gamelogic.Gamelogic();
            int[] dice = new int[5];
            dice = gamelogic.GetRandomDice();
            Dice1.Content = Convert.ToString(dice[0]);
            Dice2.Content = Convert.ToString(dice[1]);
            Dice3.Content = Convert.ToString(dice[2]);
            Dice4.Content = Convert.ToString(dice[3]);
            Dice5.Content = Convert.ToString(dice[4]);
        }

        private void btn_test_Click(object sender, RoutedEventArgs e)
        {
            SQLCommands.SQLCommands sql = new SQLCommands.SQLCommands();
            MessageBox.Show(sql.GetAllPlayer().ToString());
        }





    }
}
