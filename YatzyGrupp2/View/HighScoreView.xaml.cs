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
using System.Configuration;
using Npgsql;

namespace YatzyGrupp2.View
{
    /// <summary>
    /// Interaction logic for HighScoreView.xaml
    /// </summary>
    public partial class HighScoreView : Window
    {
        public HighScoreView()
        {
            SQLCommands.SQLCommands db = new SQLCommands.SQLCommands();
            InitializeComponent();
            try
            {
                HighScore.ItemsSource = null;
                HighScore.ItemsSource = db.GetHighScore();
            }
            catch (PostgresException ex)
            {
               MessageBox.Show(ex.Message);
            }
            HighScore.ItemsSource = null;
            HighScore.ItemsSource = db.GetHighScore(); //Denna blir en error när man fösöker gå in på Highscore sidan. Om man kommenterar bort denna plus methoden fungerar knapparna.
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MostGamesView mostgames = new MostGamesView();
            mostgames.ShowDialog();
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
