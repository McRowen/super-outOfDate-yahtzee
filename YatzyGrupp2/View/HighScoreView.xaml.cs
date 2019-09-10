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
    /// Interaction logic for HighScoreView.xaml
    /// </summary>
    public partial class HighScoreView : Window
    {
        public HighScoreView()
        {
            SQLCommands.SQLCommands db = new SQLCommands.SQLCommands();
            InitializeComponent();
            HighScore.ItemsSource = null;
            HighScore.ItemsSource = db.GetHighScore();
        }
    }
}
