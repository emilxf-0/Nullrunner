using System;
using System.Collections.Generic;
using System.IO;

public class Deck
{
    private List<Card> _cards;
    private Random _random;

    public Deck()
    {
        _cards = new List<Card>();
        _random = new Random();
    }

    public void LoadDeckFromCSV(string filename)
    {
        using var reader = new StreamReader(filename);

        reader.ReadLine(); // skip the header line

        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (line == null) continue;
            string[] values = line.Split(',');
            string name = values[0];
            string faction = values[1];
            int cost; 
            if (int.TryParse(values[2].Trim(), out cost))
            {
                cost = int.Parse(values[2]);
            }
            else
            {
                cost = 0;
            }
            string type = values[3];
            _cards.Add(new Card(name, faction,cost, type));
        }
    }

    public Card DrawCard()
    {
        if (_cards.Count == 0)
        {
            return null;
        }

        int index = _random.Next(_cards.Count);
        Card card = _cards[index];
        _cards.RemoveAt(index);
        return card;
    }

    public void Shuffle(List<Card> discardPile)
    {
        //When you shuffle a deck, you should shuffle the discard pile back into the deck
        //and then shuffle the deck
        _cards.AddRange(discardPile);
        discardPile.Clear();
        for (int i = 0; i < _cards.Count; i++)
        {
            Card temp = _cards[i];
            int randomIndex = _random.Next(_cards.Count);
            _cards[i] = _cards[randomIndex];
            _cards[randomIndex] = temp;
        }


    }
}