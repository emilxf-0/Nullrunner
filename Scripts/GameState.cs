
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

public class GameState 
{
    public Deck RunnerDeck { get; set; }
    public Deck CorpDeck { get; set; }
    public List<Card> RunnerHand { get; set; }
    public List<Card> CorpHand { get; set; }
    public List<Card> RunnerDiscard { get; set; }
    public List<Card> CorpDiscard { get; set; }
    public int RunnerCredits { get; set; }
    public int CorpCredits { get; set; }
    public int RunnerClicks { get; set; }
    public int CorpClicks { get; set; }
    public bool RunnerTurn { get; set; }
    public bool CorpTurn { get; set; }
    public bool GameOver { get; set; }
    public bool RunnerWin { get; set; }
    public bool CorpWin { get; set; }
    public bool RunnerAction { get; set; }
    public bool CorpAction { get; set; }
    public bool RunnerActionComplete { get; set; }
    public bool CorpActionComplete { get; set; }

    public GameState()
    {
        RunnerDeck = new Deck();
        CorpDeck = new Deck();

        RunnerHand = new List<Card>();
        CorpHand = new List<Card>();

        // Use Path.Combine to build the full path
        string runnerDeckPath = Path.Combine("CardLists", "RunnerCards.csv");
        string corpDeckPath = Path.Combine("CardLists", "CorpCards.csv");

        if (File.Exists(runnerDeckPath)) {
            RunnerDeck.LoadDeckFromCSV(runnerDeckPath);
        }
        else {
            Debug.WriteLine($"Runner deck file not found: {runnerDeckPath}");
        }

        if (File.Exists(corpDeckPath)) {
            CorpDeck.LoadDeckFromCSV(corpDeckPath);
        }
        else {
            Console.WriteLine($"Corp deck file not found: {corpDeckPath}");
        }
    }

    public void Init()
    {
        RunnerCredits = 5;
        CorpCredits = 5;
        RunnerClicks = 4;
        CorpClicks = 3;
        RunnerTurn = false;
        CorpTurn = true;
        GameOver = false;
        RunnerWin = false;
        CorpWin = false;
        RunnerAction = false;
        CorpAction = false;
        RunnerActionComplete = false;
        CorpActionComplete = false;
    }

    public void DrawCardFromDeck(Deck deck, List<Card> hand)
    {
        Card card = deck.DrawCard();
        if (card != null)
        {
            hand.Add(card);
        }
    }

    public void DrawStartingHands(int numberOfCards)
    {
        for (int i = 0; i < numberOfCards; i++)
        {
            RunnerHand.Add(RunnerDeck.DrawCard());
            CorpHand.Add(CorpDeck.DrawCard());
        }
    }

    public void EndTurn()
    {
        if (RunnerTurn)
        {
            RunnerTurn = false;
            CorpTurn = true;
            CorpClicks = 3;
        }
        else if (CorpTurn)
        {
            CorpTurn = false;
            RunnerTurn = true;
            RunnerClicks = 4;
        }
    }

}


