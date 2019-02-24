namespace Searthtone
{
    public class Warrior : Card
    {
        public Warrior(string name, int attackValue, int health, int manaValue)
        {
            this.Name = name;
            this.AttackValue = attackValue;
            this.Health = health;
            this.ManaValue = manaValue;
        }
    }
}
