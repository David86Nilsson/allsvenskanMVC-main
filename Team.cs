using System;
namespace Allsvenskan{
public class Team{
    public string name;
    public int points;
    public int grassGames;
    public int grassPoints;
    public double plastPoints;
    public double plastGames;
    public int goalsFor;
    public int goalsAgainst;
    public int goalDiff;
    public int rank;
    public int games;
    public List<string> playedTeam;
    public List<Game> schedule;
    public double average;
    public double specialaverage;
    public double pPerDiff;
    public double pPerGrass;
    public double pPerPlastic;
    public double endPoint;
    public double pPerGame;
    public string pitch; 

    public Team(String aName){
        name = aName;
        points = 0;
        grassPoints = 0;
        grassGames = 0;
        goalsFor = 0;
        goalsAgainst = 0;
        goalDiff = 0;
        rank = 1;
        games = 0;
        average=0;
        specialaverage=0.0;
        pPerDiff=0.0;
        pPerGame=0.0;
        pPerGrass=0.0;
        endPoint=0.0;
        plastGames=0.0;
        plastPoints=0.0;
        pitch = "nothing";
        playedTeam = new List<string>(); 
        schedule = new List<Game>();
        pitch = WhatPitch();
    }

    public void addGameToTeam(Game g){
        schedule.Add(g);
        if(g.played==true){
            

            if(g.homeTeam.name.Equals(name)){
                games++; 
                if(pitch.Contains("Grass")){
                    grassGames++;
                }else{
                    plastGames++;
                }
                goalsFor = goalsFor + g.homeGoals;
                goalsAgainst = goalsAgainst + g.awayGoals;
                goalDiff = goalsFor - goalsAgainst; 

                if(g.homeGoals == g.awayGoals){
                    points++;
                    endPoint++;
                    if(pitch.Contains("Grass")){
                        grassPoints++;                        
                    }else{
                        plastPoints++;
                    }
                }else if(g.homeGoals>g.awayGoals){
                    points = points + 3; 
                    endPoint += 3;
                    if(pitch.Contains("Grass")){
                        grassPoints+=3;                       
                    }else{
                        plastPoints+=3;
                    }
                }
                playedTeam.Add(g.awayTeam.name);
            }else{
                games++;
                if(g.homeTeam.pitch.Contains("Grass")){
                    grassGames++;
                }else{
                    plastGames++;
                }
                goalsFor = goalsFor + g.awayGoals;
                goalsAgainst = goalsAgainst + g.homeGoals;
                goalDiff = goalsFor - goalsAgainst; 

                if(g.homeGoals == g.awayGoals){
                    points++;
                    endPoint++;
                    if(g.homeTeam.pitch.Contains("Grass")){                       
                        grassPoints++;
                    }else{
                        plastPoints++;
                    }
                }else if(g.homeGoals<g.awayGoals){
                    points = points + 3;
                    endPoint += 3; 
                    if(g.homeTeam.pitch.Contains("Grass")){
                        grassPoints += 3;
                    }else{
                        plastPoints += 3;
                    }
                }
                playedTeam.Add(g.homeTeam.name);
            }
        }
    }

    //public  void addGameToTeam(int aGoalsFor, int aGoalsAgainst, Team opponent){
    
    //    games++; 
    //    playedTeam.Add(opponent.name);
    //    schedule.Add(opponent.name);
    //    goalsFor = goalsFor + aGoalsFor;
    //    goalsAgainst = goalsAgainst + aGoalsAgainst;
    //    goalDiff = goalsFor - goalsAgainst; 

    //    if(aGoalsFor == aGoalsAgainst){
    //        points++;
    //    }else if(aGoalsFor>aGoalsAgainst){
    //        points = points + 3; 
    //    }
    //}
    public void playedAGame(int aGoalsFor, int aGoalsAgainst){

    }
    public void setSpecial(double d){
        specialaverage=d;
    }
    public void setAverage(double a){
        average=a;    
        
    }
    public void endPoints(){
        endPoint=0.0;
        foreach (Game aGame in schedule)
        {
            if(!aGame.played){

                    if (aGame.homeTeam.pitch.Equals("gräs"))
                    {
                        endPoint +=  pPerGrass;
                    }
                    else
                    {
                        endPoint +=  pPerPlastic;
                    }
                }
        }
        endPoint= Math.Round(endPoint+points, 2, MidpointRounding.AwayFromZero);
    }
    public void printSchedule(){
        for(int i=0; i<schedule.Count;i++){
            System.Console.WriteLine(i+1 + ": " + schedule[i]);
        }
    }
    public string WhatPitch(){
        if (name.Contains("Djur") || name.Contains("cken") || name.Contains("Hammarby") || name.Contains("Elfsborg") || name.Contains("Sirius") || name.Contains("Norrk") || name.Contains("Sundsvall")){
            return "Plast";
        }
        else{
            return "Grass";
        }
    }
    public void AddToEndPoints(int p){
        endPoint += p;
    }
   
}
}