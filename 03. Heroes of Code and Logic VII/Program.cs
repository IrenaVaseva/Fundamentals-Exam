namespace _03._Heroes_of_Code_and_Logic_VII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //a hero can have a maximum of 100 HP and 200 MP
            //HP <= 100, MP <= 200
            int countHeroes = int.Parse(Console.ReadLine());
            Dictionary<string, Hero> dicHeroes = new Dictionary<string, Hero>();

            for (int i = 0; i < countHeroes; i++)
            {
                string[] detailsH = Console.ReadLine().Split().ToArray();
                string name = detailsH[0];
                int hp = int.Parse(detailsH[1]);
                int mp = int.Parse(detailsH[2]);

                Hero newHero = new Hero(name, hp, mp);
                dicHeroes.Add(name, newHero);
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(" - ").ToArray();
                string nameHero = command[1];

                switch (command[0])
                {
                    case "CastSpell":
                        int mp = int.Parse(command[2]);
                        string spellName = command[3];
                        CastSpell(dicHeroes, nameHero, mp, spellName);
                        break;
                    case "TakeDamage":
                        int damage = int.Parse(command[2]);
                        string attacker = command[3];
                        TakeDamage(dicHeroes, nameHero, damage, attacker);
                        break;
                    case "Recharge":
                        int amount = int.Parse(command[2]);
                        Rechange(dicHeroes, nameHero, amount);
                        break;
                    case "Heal":
                        int amountH = int.Parse(command[2]);
                        Heal(dicHeroes, nameHero, amountH);
                        break;
                }
            }

            foreach (var hero in dicHeroes)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value.HP}");
                Console.WriteLine($"  MP: {hero.Value.MP}");
            }
        }

        private static void Heal(Dictionary<string, Hero> dicHeroes, string nameHero, int amount)
        {
            int hp = dicHeroes[nameHero].HP;
            if (hp + amount > 100)
            {
                amount = 100 - hp;
                hp = 100;
            }
            else
            {
                hp += amount;
            }

            dicHeroes[nameHero].HP = hp;

            Console.WriteLine($"{nameHero} healed for {amount} HP!");
        }

        private static void Rechange(Dictionary<string, Hero> dicHeroes, string nameHero, int amount)
        {
            int mp = dicHeroes[nameHero].MP;
            if (mp + amount > 200)
            {
                amount = 200 - mp;
                mp = 200;
            }
            else
            {
                mp += amount;
            }

            dicHeroes[nameHero].MP = mp;

            Console.WriteLine($"{nameHero} recharged for {amount} MP!");
        }

        private static void TakeDamage(Dictionary<string, Hero> dicHeroes, string nameHero, int damage, string attacker)
        {
            dicHeroes[nameHero].HP -= damage;
            int hp = dicHeroes[nameHero].HP;
            if (hp > 0)
            {
                Console.WriteLine($"{nameHero} was hit for {damage} HP by {attacker} and now has {hp} HP left!");
            }
            else
            {
                dicHeroes.Remove(nameHero);
                Console.WriteLine($"{nameHero} has been killed by {attacker}!");
            }
        }

        private static void CastSpell(Dictionary<string, Hero> dicHeroes, string nameHero, int mp, string spellName)
        {
            int mpHero = dicHeroes[nameHero].MP;

            if (mpHero >= mp)
            {
                mpHero -= mp;
                Console.WriteLine($"{nameHero} has successfully cast {spellName} and now has {mpHero} MP!");
                dicHeroes[nameHero].MP = mpHero;
            }
            else
            {
                Console.WriteLine($"{nameHero} does not have enough MP to cast {spellName}!");
            }
        }
    }
    public class Hero
    {
        public Hero(string name, int hP, int mP)
        {
            Name = name;
            HP = hP;
            MP = mP;
        }

        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
    }
}