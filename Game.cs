using System;

namespace Allsvenskan
{
    public class Game{
        public int homeGoals;
        public int awayGoals;
        public int round;
        public bool played;
        public int winner;
        public Team homeTeam;
        public Team awayTeam;

        public Game(){
            homeGoals=0;
            awayGoals=0;
            played = false;
            winner = 0;
            round= 0;
            homeTeam=new Team("temp");
            awayTeam = new Team("temp");
        }
        public Game(Team hTeam, Team aTeam, int aRound){
            homeGoals = 0;
            awayGoals = 0;
            played = false;
            round= aRound;
            homeTeam =hTeam;
            awayTeam =aTeam;
            homeTeam.addGameToTeam(this);
            awayTeam.addGameToTeam(this);            
        }
        public Game(Team hTeam, Team aTeam, int hGoals, int aGoals, int omg){
            setResult(hGoals, aGoals);
            round= omg;
            homeTeam =hTeam;
            awayTeam =aTeam;
            homeTeam.addGameToTeam(this);
            awayTeam.addGameToTeam(this);
        }
        public void setResult(int hGoals, int aGoals){
            homeGoals=hGoals;
            awayGoals=aGoals;
            played=true;
        }
        public string printGame(){
            if(played){
                return ("\n" + round + ":\t" + homeTeam.name + "\t" + homeGoals + "-" + awayGoals + "\t" + awayTeam.name);
            }else{
                return ("\n" + round + ":\t" + homeTeam.name + " - " + awayTeam.name);
            }
        }
        public void GuessTheGame(int result){
            if(result == 1){
                homeTeam.AddToEndPoints(3);
            }
            else if(result == 2){
                awayTeam.AddToEndPoints(3);

            }
            else{
                homeTeam.AddToEndPoints(1); 
                awayTeam.AddToEndPoints(1);  
            }
        }
    }
}