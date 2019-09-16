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
            LowerPart();
        
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
                "tärningar du vill kasta om. Spara en tärning genom att klicka på den, tärningarna" +
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
                "fått Yatzy.\n\n" +
                "Om du redan har FYRTAL eller SEXOR skrivs poängen av hela slaget in vid CHANS.\n"+
                "Du kan också välja att stryka något kast från protokollet.";
        }

        public string LowerPart()
        {
            return lowerPart.Text = "ETT PAR: Ex. 5-3-3-2-1, 2st 3:or\n" +
                "TVÅ PAR: Ex. 5-3-3-4-4, 2st 3:or, 2st 4:or\n"+
                "TRETAL: Ex. 5-3-3-3-2, 3st 3:or\n"+
                "FYRTAL: Ex. 5-4-4-4-4, 4st 4:or\n"+
                "LITEN STRAIGHT: Ex. 1-2-3-4-5\n"+
                "STOR STRAIGHT: Ex. 2-3-4-5-6\n" +
                "KÅK: Ex. 3-5-5-3-3, 3st 3:or, 2st 5:or\n"+
                "CHANS: Alla de fem tärningarnas ögontal räknas och summan av dessa förs in i protokollet.\n"+
                "Den här rubriken används när ingen annan lämplig rubrik är ledig\n\n"+
                "YATZY: Alla de fem tärningarna visar lika och då ger Yatzy alltid 50 poäng."
                ;
        }

    }
}
