using Oyun;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

Character character = new Character();

Console.WriteLine("Hoşgeldiniz. Oyuna başlamadan önce Kullanıcı adınızı yazınız:  ");
character.Name = Console.ReadLine();


while (true)
{
    Console.WriteLine("Kullanmak istediğiniz sınıfı seçiniz: ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("" +
        "  [1] Kılıç ustası: Can = 100 Saldırı = 30 Savunma = 10 \n" +
        "  [2] Şovalye:      Can = 140 Saldırı = 20 Savunma = 20 \n" +
        "  [3] Okçu:         Can = 80 Saldırı = 30 Savunma = 10 \n");
    Console.ForegroundColor = ConsoleColor.Gray;
    var secim = Console.ReadLine();
    if (secim == "1")
    {
        character.Swordmaster();
        break;
    }
    else if (secim == "2")
    {
        character.Knight();
        break;
    }
    else if (secim == "3")
    {
        character.Archer();
        break;
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Geçersiz seçim. Yeniden deneyiniz...");
    }
}

int protection = 0;
int protectionCooldown = 1;

Console.Clear();
Console.WriteLine("{0} {1} \n Seviye: {2} \n Can: {3} \n Saldırı: {4} Defans: {5}\n \n"
    , character.Name, character.Class, character.Level, character.Health, character.Attack, character.Defence);

while (true)
{
    Monster monster = new Monster(character.Level);

    int num = MonsterCreate();

    if (num == 0)
    {
        monster.Slime();
    }
    else if (num == 1)
    {
        monster.Skeleton();
    }
    else if (num == 2)
    {
        monster.Zombie();
    }

    int round = 0;
    Console.WriteLine("Savaş başlıyor... ");

    while (true)
    {

        if (character.Health <= 0)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Savaş esnasında canından fazlasını kaybettin...");
                Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(" [1] Yeniden Dene \n [2] Çık");
                var sec = Console.ReadLine();
                if (sec == "1")
                {
                    break;
                }
                else if (sec == "2")
                {
                    Environment.Exit(0);
                }
            }
        }
        if (monster.Health <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Tebrikler canavarı yendin...");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(" [1] Devam et \n [2] Çık"); Console.ForegroundColor = ConsoleColor.Gray;
            var sec = Console.ReadLine();
            if (sec == "2")
            {
                Environment.Exit(0);
            }
            else
            {
                LevelUp();
                break;
            }
        }
        protectionCooldown--;
        if (protection != 0)
        {
            protection--;
            if (protection == 0)
            {
                character.Defence -= 20;
            }
        }


        round++;
        Console.WriteLine("{0}.Tur", round);
        Console.WriteLine(" {0} Seviye: {1} Can: {2} Saldırı: {3} Savunma: {4} ", monster.Name, monster.Level, monster.Health, monster.Attack, monster.Defence); ;
        Console.WriteLine(" {0} Seviye: {1} Can: {2}/{3} Saldırı: {4} Savunma: {5}", character.Name, character.Level, character.Health, character.Max_Health, character.Attack, character.Defence);

        bool flee = CharacterTurn();
        if (flee == true) { break; }

        MonsterTurn();
    }


    int MonsterCreate()
    {
        Random seed = new Random();
        int num = seed.Next(0, 3);
        return num;
    }

    bool CharacterTurn()
    {
        bool flee = false;
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Senin sıran... \n [1] Saldır \n [2] Savun \n [3] Kaç"); Console.ForegroundColor = ConsoleColor.Gray;
            var CharacterTurn = Console.ReadLine();
            Console.Clear();
            if (CharacterTurn == "1")

            {

                int damage = character.Attack - monster.Defence;
                if (damage > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("{0} kadar hasar verdin...", damage); Console.ForegroundColor = ConsoleColor.Gray;
                    monster.Health -= damage;
                    return flee;
                }
                else
                {
                    Console.WriteLine("Hasar veremedin...");
                    return flee;
                }
            }
            else if (CharacterTurn == "2")
            {
                if (protectionCooldown <= 0)
                {
                    Console.WriteLine("Defansın 50 arttı");
                    character.Defence += 20;
                    Console.Clear();
                    protection = 2;
                    protectionCooldown = 3;
                    return flee;
                }
                else
                {
                    Console.WriteLine("Bu eylemi kullanman için {0} tur beklemelisin",protectionCooldown);
                }
                
                
            }
            else if (CharacterTurn == "3")
            {
                Random luck = new Random();
                int number = luck.Next(1, 5);
                Console.WriteLine(number);
                if (number == 4)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Kaçış başarılı... \n");
                    flee = true;
                    return flee;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Kaçış başarısız"); Console.ForegroundColor = ConsoleColor.Gray;
                    return flee;
                }
            }
        }

    }
    void MonsterTurn()
    {
        Console.WriteLine("{0} ın sırası", monster.Name);
        int damage = monster.Attack - character.Defence;
        if (damage > 0)
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("{0} kadar hasar verdi...", damage); Console.ForegroundColor = ConsoleColor.Gray;
            character.Health -= damage;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Hasar veremedi..."); Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
void LevelUp()
{
    character.Level++;
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(" Seviye atladın!"); Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("[1] Saldırı +20 \n" +
            "[2] Defans +10 \n" +
            "[3] Can +30 ");
        var select = Console.ReadLine();
        if (select == "1")
        {
            character.Health = character.Max_Health;
            character.Attack += 20;
            break;
        }
        else if (select == "2")
        {
            character.Health = character.Max_Health;
            character.Defence += 10;
            break;
        }
        else if (select == "3")
        {
            character.Max_Health += 30;
            character.Health = character.Max_Health;
            break;
        }
    }

}