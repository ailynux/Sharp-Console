using System;
using System.Collections.Generic;
using System.Threading;

class HauntedHouseEscape
{
    static Random random = new Random();
    static List<string> inventory = new List<string>();
    static bool hasFinalKey = false;  // Track if the final key to escape is obtained
    static bool foundMysteriousNote = false;
    static string currentRoom = "Entrance Hall";  // Track the current room

    static void Main()
    {
        Console.Title = "🎃 Haunted House Escape Adventure 🎃";
        ShowIntro();
        ExploreRoom(currentRoom);

        while (!hasFinalKey)
        {
            string choice = GetPlayerChoice();
            ProcessChoice(choice);
        }

        ShowFinalScene();
    }

    static void ShowIntro()
    {
        string pumpkinGhost = @"
                        ..'''''..                    
                    .';:cccccccc:;'.                
                  .:cccccccccccccccc:.              
                .:cccccccccccccccccccc:.            
               ;cccccccccccccccccccccccc;           
              :ccccccc;,,;cccccc;,,;ccccc:          
             :ccccccc;  ;cccccc:  ;cccccc:         
            :ccccccccc,,ccccccccc,,ccccccc:        
           :ccccccccccccccccccccccccccccccc:       
           cccccccccccccccccccccccccccccccc:       
           cccc'''';cccccccccccccccc;'''':cc       
           cccc;   ;cccccccccccccccc;   ;cc:       
            :ccc;,,;cccccccccccccccc;,,;cc:        
             ':cccccccccc;,,,,;cccccccccc:'        
               ':cccccccc;    ;cccccccc:'          
                 '::cccc:;    ;:cccc::'            
                    ''::;      ;::''                
                                                   
        🎃 The Haunted House of Midnight Terrors 👻
    ";

        string introText = @"
╔══════════════════════════════════════════════════════════════╗
║  As the clock approaches midnight on All Hallows' Eve,       ║
║  you find yourself drawn to an ancient mansion where         ║
║  tortured spirits roam the halls, seeking new company...     ║
║                                                              ║
║  Legend speaks of those who entered on Halloween night,      ║
║  never to be seen again. Their souls forever trapped         ║
║  within these cursed walls...                                ║
║                                                              ║
║  You must escape before the final bell tolls at midnight,    ║
║  or join the eternal dance of the damned!                    ║
║                                                              ║
║  🕯️  Beware the shadows...                                    ║
║  🦇  Trust nothing...                                        ║ 
║  ⚰️  Survive everything...                                    ║ 
╚══════════════════════════════════════════════════════════════╝
";

        // Function to slowly type out text for spooky effect
        void TypeWriter(string text, int delay = 10)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        // Clear console and set window title
        Console.Clear();
        Console.Title = "🎃 The Haunted House of Midnight Terrors 👻";

        // Display the pumpkin ghost in orange
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(pumpkinGhost);
        Console.ResetColor();

        // Flicker effect for the title
        for (int i = 0; i < 3; i++)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.Red;
            Thread.Sleep(200);
        }

        // Display the intro text with typewriter effect
        Console.ForegroundColor = ConsoleColor.DarkRed;
        TypeWriter(introText, 30);
        Console.ResetColor();

        // Spooky prompt
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\n🕸️  Press any key to enter... if you dare... 🕸️");
        Console.ResetColor();

        Console.ReadKey(true);
        Console.Clear(); // Clear screen for game start
    }

    static void ExploreRoom(string roomName)
    {
        currentRoom = roomName;  // Update the current room
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"You are in the {roomName}. The atmosphere is chilling, and shadows flicker on the walls...\n");

        if (roomName == "Entrance Hall")
        {
            Console.WriteLine("A heavy silence fills the air. You see a grand staircase leading up, and a door to the Living Room.");
            Console.WriteLine("A faded painting stares back at you from across the room, its eyes seeming to follow your every move.");
        }
        else if (roomName == "Living Room")
        {
            Console.WriteLine("The Living Room feels like it hasn’t been touched in decades.");
            Console.WriteLine("A fireplace crackles with cold flames, and a dusty old mirror hangs on the wall, slightly tilted.");
            if (!foundMysteriousNote)
                Console.WriteLine("A faint glimmer under the carpet catches your eye...");
        }
        else if (roomName == "Kitchen")
        {
            Console.WriteLine("The Kitchen reeks of decay. You can see rusted pots and broken glass scattered on the floor.");
            Console.WriteLine("A bloody handprint marks the fridge door, which sits slightly ajar...");
        }

        Console.ResetColor();
    }

    static string GetPlayerChoice()
    {
        Console.WriteLine("\nWhat would you like to do?");
        Console.WriteLine("1. Look around the room");
        Console.WriteLine("2. Check inventory");
        Console.WriteLine("3. Move to another room");
        Console.WriteLine("4. Quit");

        Console.Write("\nChoose an action (1-4): ");
        return Console.ReadLine() ?? ""; // Ensure the return is non-null
    }

    static void ProcessChoice(string choice)
    {
        switch (choice)
        {
            case "1":
                LookAround();
                break;
            case "2":
                ShowInventory();
                break;
            case "3":
                MoveRooms();
                break;
            case "4":
                QuitGame();
                break;
            default:
                Console.WriteLine("Invalid choice! Try again.");
                break;
        }
    }

    static void LookAround()
    {
        string[] spookyFindings = {
            "a spider crawls up your arm!", "you hear faint whispers...", "a shadow flits past you...",
            "an eerie child’s laughter echoes down the hall...", "a cold breeze brushes your neck, though all windows are closed..."
        };
        string finding = spookyFindings[random.Next(spookyFindings.Length)];

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"As you look around, {finding}");
        Console.ResetColor();
        
        Thread.Sleep(2000);

        if (random.Next(2) == 0)
        {
            string item = (currentRoom == "Living Room" && !foundMysteriousNote) ? "Mysterious Note" : "Skeleton Key";
            Console.WriteLine($"You find a {item} and add it to your inventory!");
            inventory.Add(item);

            if (item == "Mysterious Note")
            {
                foundMysteriousNote = true;
                Console.WriteLine("\nThe note reads: 'The way out is hidden beneath the floor...'");
            }

            if (item == "Skeleton Key" && currentRoom == "Kitchen") // Final key needed to escape
            {
                hasFinalKey = true;
            }
        }
    }

    static void ShowInventory()
    {
        Console.Clear();
        Console.WriteLine("Your Inventory:");
        if (inventory.Count == 0)
        {
            Console.WriteLine("It's empty... Keep exploring!");
        }
        else
        {
            foreach (var item in inventory)
            {
                Console.WriteLine($"- {item}");
            }
        }
        Thread.Sleep(2000);
    }

    static void MoveRooms()
    {
        Console.WriteLine("\nChoose a room to explore:");
        Console.WriteLine("1. Entrance Hall");
        Console.WriteLine("2. Living Room");
        Console.WriteLine("3. Kitchen");

        Console.Write("\nEnter your choice: ");
        string roomChoice = Console.ReadLine();
        
        switch (roomChoice)
        {
            case "1":
                ExploreRoom("Entrance Hall");
                break;
            case "2":
                ExploreRoom("Living Room");
                break;
            case "3":
                ExploreRoom("Kitchen");
                break;
            default:
                Console.WriteLine("Invalid room choice.");
                break;
        }
    }

    static void QuitGame()
    {
        Console.Clear();
        Console.WriteLine("Thanks for playing! 🎃 Stay spooky! 🎃");
        Environment.Exit(0);
    }

    static void ShowFinalScene()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("After collecting the final Skeleton Key, you make your way to the front door...");
        Console.WriteLine("With shaking hands, you insert the key into the rusty lock. It turns, and the door creaks open.");
        Console.WriteLine("The cold night air rushes in, chilling you to the bone, but you’re free.");
        Console.ResetColor();
        
        Console.WriteLine("\n🏚️ Congratulations! You escaped the Haunted House... or did you?");
        Console.WriteLine("As you walk away, you feel a gaze on your back... but when you turn, there’s nothing there.");
        Console.WriteLine("The house sits silent, but a faint light glows from within... the spirits will await your return.");
        Environment.Exit(0);
    }
}
