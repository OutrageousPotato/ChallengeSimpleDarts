using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Darts;
using static Darts.Darts;

namespace ChallengeSimpleDarts
{
    public partial class Default : System.Web.UI.Page
    {

        int playerOneTotalScore = 0;
        int playerTwoTotalScore = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            runGame();
            resultLabel.Text = String.Format("<p>Final Scores:<br />Player one: {0}<br />Player two: {1}</P>",
                playerOneTotalScore, playerTwoTotalScore);
            resultLabel.Text += String.Format("<p> Winner: {0}", determineWinner());
        }

        private void runGame()
        {
            System.Random random = new Random();
            Dart gameDart = new Dart(random);
            
            while (playerOneTotalScore < 300 && playerTwoTotalScore < 300)
            {
                for (int i = 1; i < 3; i++)
                {
                    playerOneTotalScore += score.calculateScore(gameDart);
                    playerTwoTotalScore += score.calculateScore(gameDart);
                } 
            }
        }

        public string determineWinner()
        {
            if (playerOneTotalScore > playerTwoTotalScore) return "Player One";
            if (playerTwoTotalScore > playerOneTotalScore) return "Player Two";
            else return "A tie! Amazing!";
        }


        public class score
        {
            public static int calculateScore(Dart dart)
            {
                int throwResult = dart.Throw();

                if (throwResult == 0)
                {
                    throwResult = (dart.randomizer.Next() % 2 == 1) ? 25 : 50;
                }
                else if (dart.doubleRingHit == true)
                {
                    throwResult = throwResult * 2;
                }
                else if (dart.tripleRingHit == true)
                {
                    throwResult = throwResult * 3;
                }
                return throwResult;
            }
        }
        
    }

}