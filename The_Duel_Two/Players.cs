namespace The_Duel_Two
{
    internal class Players
    {
        public int Health { get; set; }
        public int Damage { get; set; }
        public string Name { get; set; }

        public bool IsBlocking { get; set; } = false;

        public Players(int health, int damage, string name)
        {

            Health = health;
            Damage = damage;
            Name = name;

        }

        public int RollDamageQuickAttack()
        {
            Random randomQuickDamage = new Random();

            randomQuickDamage.Next(2, 15);

            return randomQuickDamage.Next(2, 15);
        }

        public int RollDamageStrongAttack()
        {
            Random randomStrongDamage = new Random();

            randomStrongDamage.Next(10, 30);

            return randomStrongDamage.Next(10, 30);
        }


        public int NoDamage()
        {
            Random randomDamage = new Random();

            randomDamage.Next(0, 0);

            return randomDamage.Next(0, 0);
        }




    }
}
