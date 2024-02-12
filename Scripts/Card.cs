public class Card
{
    public string Name { get; set; }
    public string Faction { get; set; }
    public int Cost { get; set; }
    public string Type { get; set; }

    public Card(string name, string faction, int cost, string type) 
    {
        Name = name;
        Faction = faction;
        Cost = cost;
        Type = type;
    }
}