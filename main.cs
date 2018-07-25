using System;
using System.Linq;
using System.Collections.Generic;

public class Card
{
    public int ID { get; set; }
    public int instanceId { get; set; }
    public int location { get; set; }
    public int cardType { get; set; }
    public int cost { get; set; }
    public int attack { get; set; }
    public int defense { get; set; }
    public string abilities { get; set; }
    public int myHealthChange { get; set; }
    public int opponentHealthChange { get; set; }
    public int cardDraw { get; set; }
}

public class Player
{
    public int health { get; set; }
    public int mana { get; set; }
    public int deck { get; set; }
    public int rune { get; set; }
}

class Game
{
    static void Main(string[] args)
    {
        string[] inputs;
        int nbTour = 0;

        // game loop
        while (true)
        {
            Player moi = null;
            for (int i = 0; i < 2; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                if (i == 0)
                {
                    moi = new Player
                    {
                        health = int.Parse(inputs[0]),
                        mana = int.Parse(inputs[1]),
                        deck = int.Parse(inputs[2]),
                        rune = int.Parse(inputs[3])
                    };
                }
            }
            List<Card> deck = new List<Card>();
            List<Card> monPlateau = new List<Card>();
            List<Card> sonPlateau = new List<Card>();

            int opponentHand = int.Parse(Console.ReadLine());
            int cardCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < cardCount; i++)
            {
                inputs = Console.ReadLine().Split(' ');

                Card card = new Card
                {
                    ID = int.Parse(inputs[0]),
                    instanceId = int.Parse(inputs[1]),
                    location = int.Parse(inputs[2]),
                    cardType = int.Parse(inputs[3]),
                    cost = int.Parse(inputs[4]),
                    attack = int.Parse(inputs[5]),
                    defense = int.Parse(inputs[6]),
                    abilities = inputs[7],
                    myHealthChange = int.Parse(inputs[8]),
                    opponentHealthChange = int.Parse(inputs[9]),
                    cardDraw = int.Parse(inputs[10])
                };

                switch (card.location)
                {
                    case 0:
                        deck.Add(card);
                        break;
                    case 1:
                        monPlateau.Add(card);
                        break;
                    case -1:
                        sonPlateau.Add(card);
                        break;
                    default:
                        break;
                }
            }
            
            if (nbTour < 30)
                Console.WriteLine("PASS");
            else
            {
                string ret = string.Empty;
                Card card = deck.FirstOrDefault(c => c.cost <= moi.mana);
                if (card != null)
                    ret = "SUMMON " + card.instanceId + ";";

                foreach (var c in monPlateau)
                {
                    ret = ret + "ATTACK " + c.instanceId + " -1;";
                }

                if (string.IsNullOrEmpty(ret))
                    Console.WriteLine("PASS");
                else
                    Console.WriteLine(ret);

            }
            nbTour++;
        }
    }
}