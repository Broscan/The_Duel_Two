using The_Duel_Two;


Players playerOne = new(100, 0, "");

Players playerTwo = new(100, 0, "");



// Fråga spelaren om denna vill (A)ttackera, (B)locka, (D)odga, (P)repare switch-case

// Blocka ska reducera skadan som den andra spelaren har gjort (x2)
// Dodga ska det finnas en ökad chans att ta bort skadan helt och hållet.
// Printa ut hur mycket skada den andra spelaren har tagit
// När någon spelare dött ska programmet avslutas
// Printa ut vem som vann
// Implementera så att det finns en crit chans på varje (a)ttack. Random
// Block ska reducera 

Console.WriteLine("********************");
Console.WriteLine("WELCOME TO THE DUEL");
Console.WriteLine("********************");

Console.WriteLine("What is your name Chosen one?");

playerOne.Name = Console.ReadLine();

Console.WriteLine("Great! What is the other Chosen ones name");

playerTwo.Name = Console.ReadLine();


Console.WriteLine("Generating who begins the round....");

Random whichPlayerStarts = new();

bool playerOneStarts = whichPlayerStarts.Next(2) == 0;

while (playerOne.Health > 0 && playerTwo.Health > 0)
{

    if (playerOneStarts)
    {
        Console.WriteLine($"The Player who begins this round is {playerOne.Name}");
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("Choose (A)ttack, (B)lock or (D)odge");
        string? playerInput = Console.ReadLine();
        switch (playerInput)
        {
            case "A":
            case "a":
                Console.WriteLine("Do you want to do a (Q)uick Attack --- 80% Chance or a (S)trong attack? --- 45% Chance");
                string playerInputAttack = Console.ReadLine();

                if (playerInputAttack == "Q" || playerInputAttack == "q")
                {
                    Console.WriteLine("You have chosen Quick Attack");
                    PressKey();

                    int damageDoneQuick = QuickAttack(playerOne, playerTwo);

                    Console.WriteLine($"{playerOne.Name} hit {playerTwo.Name} for {damageDoneQuick}");
                    Console.WriteLine($" {playerTwo.Name} has {playerTwo.Health} health remaining");

                }
                else if (playerInputAttack == "S" || playerInputAttack == "s")
                {
                    Console.WriteLine("You have chosen Strong Attack ");
                    PressKey();

                    int damageDoneStrong = StrongAttack(playerOne, playerTwo);

                    Console.WriteLine($"{playerOne.Name} hit {playerTwo.Name} for {damageDoneStrong}");
                    Console.WriteLine($" {playerTwo.Name} has {playerTwo.Health} health remaining");

                }
                PressKey();

                break;



            case "B":
            case "b":

                Console.WriteLine("You have chosen Block!");
                Console.WriteLine("Await your next turn...");
                playerOne.IsBlocking = true;

                PressKey();

                break;




            case "D":
            case "d":

                Dodge();


                break;

        }

    }




    else
    {
        Console.WriteLine($"The Player who begins this round is {playerTwo.Name}");
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("Choose (A)ttack, (B)lock or (D)odge");
        string? playerInput = Console.ReadLine();
        switch (playerInput)
        {
            case "A":
            case "a":
                Console.WriteLine("You have chosen Attack");
                Console.WriteLine("Do you want to do a (Q)uick Attack --- 80% Chance or a (S)trong attack? --- 45% Chance");
                string playerInputAttack = Console.ReadLine();

                if (playerInputAttack == "Q" || playerInputAttack == "q")
                {
                    Console.WriteLine("You have chosen Quick Attack");
                    PressKey();

                    int damageDoneQuick = QuickAttack(playerOne, playerTwo);

                    Console.WriteLine($"{playerOne.Name} hit {playerTwo.Name} for {damageDoneQuick}");
                    Console.WriteLine($" {playerTwo.Name} has {playerTwo.Health} health remaining");

                }
                else if (playerInputAttack == "S" || playerInputAttack == "s")
                {
                    Console.WriteLine("You have chosen Strong Attack ");
                    PressKey();

                    int damageDoneStrong = StrongAttack(playerTwo, playerOne);

                    Console.WriteLine($"{playerTwo.Name} hit {playerOne.Name} for {damageDoneStrong}");
                    Console.WriteLine($" {playerOne.Name} has {playerOne.Health} health remaining");

                }

                PressKey();

                break;



            case "B":
            case "b":

                Console.WriteLine("You have chosen Block!");
                Console.WriteLine("Await your next turn...");
                playerTwo.IsBlocking = true;

                PressKey();

                break;




            case "D":
            case "d":

                Dodge();


                break;

        }


    }

    playerOneStarts = !playerOneStarts;

}


int QuickAttack(Players attackingPlayer, Players attackedPlayer)
{
    Random zeroToHundredRandom = new Random();

    int hitChance = zeroToHundredRandom.Next(0, 101);

    if (hitChance < 80)
    {
        Console.WriteLine("It's a hit! What a madlad!");

        int damage = attackingPlayer.RollDamageQuickAttack();

        if (attackedPlayer.IsBlocking)
        {
            damage = Convert.ToInt32(Math.Floor(damage * 0.5));
            attackedPlayer.IsBlocking = false;
        }

        attackedPlayer.Health -= damage;

        return damage;
    }

    else
    {
        Console.WriteLine("You missed u fkn noob....");
        int damage = attackingPlayer.NoDamage();

        attackedPlayer.Health -= damage;

        return damage;
    }
}

int StrongAttack(Players attackingPlayer, Players attackedPlayer)
{
    Random zeroToHundredRandom = new Random();

    int hitChance = zeroToHundredRandom.Next(0, 101);

    if (hitChance < 45)
    {
        Console.WriteLine("It's a hit! What a madlad!");

        int damage = attackingPlayer.RollDamageStrongAttack();

        if (attackedPlayer.IsBlocking)
        {
            damage = Convert.ToInt32(Math.Floor(damage * 0.5));
            attackedPlayer.IsBlocking = false;
        }

        attackedPlayer.Health -= damage;

        return damage;

    }

    else
    {
        Console.WriteLine("You missed u fkn noob....");
        int damage = attackingPlayer.NoDamage();

        attackedPlayer.Health -= damage;

        return damage;
    }

}

void PressKey()
{
    Console.WriteLine("Press any key to Continue...");
    Console.ReadKey();
}



void Block(Players blockingPlayer)
{

    int blockValue = 20;

    int baseDamage = 50;

    int actualDamage = baseDamage - blockValue;

    if (actualDamage <= 0)
    {
        Console.WriteLine("PLayer One blocked all damage!");
    }
    else
    {
        Console.WriteLine($"Player One was hit for {actualDamage}");
    }


}


void Dodge()
{

}

