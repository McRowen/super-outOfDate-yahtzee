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
using Npgsql;

namespace YatzyGrupp2.View
{
    /// <summary>
    /// Interaction logic for MostGamesView.xaml
    /// </summary>
    public partial class MostGamesView : Window
    {
        public MostGamesView()
        {
            SQLCommands.SQLCommands db = new SQLCommands.SQLCommands();
            InitializeComponent();
            try
            {
                HighScore.ItemsSource = null;
                HighScore.ItemsSource = db.GetMostWins();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HighScoreView highscore = new HighScoreView();
            highscore.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WinsInRow winsinrow = new WinsInRow();
            winsinrow.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            StartView startview = new StartView();
            startview.ShowDialog();
        }
    }
}
