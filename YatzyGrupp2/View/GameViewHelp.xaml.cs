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
    /// Interaction logic for GameViewHelp.xaml
    /// </summary>
    public partial class GameViewHelp : Window
    {
        public GameViewHelp()
        {
            InitializeComponent();
            GameRules();
            GameExample();
        
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        public string GameRules()
        {
            return gameRules.Text = "På skärmen kommer det visas tydligt vems tur det är. " +
                "Varje gång det blir din tur har du rätt till högst 3 tärningskast. \n" +
                "För var slag avgör du vilka tärningar du vill spara till nästa kast och vilka " +
                "tärningar du vill kasta om. Spara en tärning\n genom att klicka på den, tärningarna" +
                " blir grön när du har sparat dem. Efter alla kast förs poängsumman in intill en av rubrikerna.\n\n" +
                "Spelar ni ett vanligt spel behöver ordningen i protokollet följas, spelar ni ett styrt spel " +
                "behöver \nordningen på protokollet ej följas.";


        }

        public string GameExample()
        {
            return gameExample.Text = "Första kastet ger: 6 - 6 - 3 - 6 - 6\n\n" +
                "Du låter sexorna ligga kvar och kastar om trean. Trean blir en FYRA " +
                "och du kastar det tredje och sista slaget blir en FEMMA.\n" +
                "Resultatet blir FYRTAL eller SEXOR med poängsumma 24, som antecknas " +
                "vid rubrikerna som väljs. \nSkulle det sista kastet blivit en SEXA hade du " +
                "fått Yatzy.";
        }

    }
}
