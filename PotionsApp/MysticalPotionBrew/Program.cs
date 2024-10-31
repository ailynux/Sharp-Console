using System;
using System.Collections.Generic;
using System.Threading;

class MysticalPotionBrewer
{
    static Random random = new Random();
    static List<string> potionLog = new List<string>();
    
    // Ingredient options with special effects
    static readonly string[] ingredients = { "Dragon Scale 🐉", "Phoenix Feather 🪶", "Unicorn Tear 🦄", "Goblin Toenail 🧌", "Mermaid Hair 🧜‍♀️", "Fairy Dust ✨", "Mystic Mushroom 🍄", "Celestial Star ✨", "Vampire Fang 🧛", "Werewolf Claw 🐺" };
    
    // Potion effects by rarity type
    static readonly Dictionary<string, string[]> effects = new Dictionary<string, string[]>
    {
        { "Common", new string[] { "Minor Luck", "Night Vision", "Fresh Breath", "Sparkly Hair", "Calming Aura" } },
        { "Rare", new string[] { "Invisibility", "Super Strength", "Mind Reading", "Endless Laughter", "Glow in the Dark" } },
        { "Legendary", new string[] { "Flight", "Immortality (Temporary)", "Time Travel (1 Minute)", "Control Weather", "Speak in Riddles" } },
        { "Mythical", new string[] { "True Sight", "Command Animals", "Shapeshift", "Reality Bending", "Eternal Wisdom" } }
    };

    static void Main()
    {
        Console.Title = "Mystical Potion Brewer - Advanced Edition";
        ShowIntro();
        StartPotionBrewing();
    }

    static void ShowIntro()
    {
        string introArt = @"
        ╔═╗╦═╗╔═╗╔╦╗╦═╗╦╔╗╔  ╔═╗╦═╗╔═╗╦ ╦
        ║  ╠╦╝║╣  ║ ╠╦╝║║║║  ║  ╠╦╝║ ║║ ║
        ╚═╝╩╚═╚═╝ ╩ ╩╚═╩╝╚╝  ╚═╝╩╚═╚═╝╚═╝
       ✨ Welcome to the Mystical Potion Brewer ✨
            - Every Potion is a Mystery! -";
        
        AnimateText(introArt, true);
        Thread.Sleep(2000);
    }

    static void StartPotionBrewing()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n✨ Choose ingredients to brew a mystical potion! ✨\n");
            Console.ResetColor();

            DisplayIngredients();
            List<string> selectedIngredients = SelectIngredients();
            BrewPotion(selectedIngredients);

            Console.WriteLine("\n🌌 Would you like to brew another potion? (y/n)");
            if (Console.ReadKey().KeyChar != 'y') break;
        }

        ShowPotionLog();
    }

    static void DisplayIngredients()
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {ingredients[i]}");
        }
    }

    static List<string> SelectIngredients()
    {
        List<string> chosenIngredients = new List<string>();
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"\nChoose ingredient {i + 1} (1-{ingredients.Length}): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= ingredients.Length)
            {
                string ingredient = ingredients[choice - 1];
                chosenIngredients.Add(ingredient);
                Console.WriteLine($"🔮 You selected: {ingredient}");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select a valid ingredient.");
                i--;
            }
        }
        return chosenIngredients;
    }

    static void BrewPotion(List<string> ingredients)
    {
        Console.Clear();
        Console.WriteLine("\n🌫️ Mystical energies swirl as you mix the ingredients... 🌫️\n");
        Thread.Sleep(2000);

        string potionRarity = DeterminePotionRarity();
        string effect = GetRandomEffect(potionRarity);
        string potionName = $"{potionRarity} Potion of {effect}";

        AnimatePotionCreation(potionName, ingredients, effect);

        potionLog.Add($"{potionName} - {string.Join(", ", ingredients)} - Effect: {effect}");
    }

    static string DeterminePotionRarity()
    {
        int rarityRoll = random.Next(100);
        if (rarityRoll < 50) return "Common";
        if (rarityRoll < 75) return "Rare";
        if (rarityRoll < 90) return "Legendary";
        return "Mythical";
    }

    static string GetRandomEffect(string rarity)
    {
        return effects[rarity][random.Next(effects[rarity].Length)];
    }

    static void AnimatePotionCreation(string potionName, List<string> ingredients, string effect)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n✨ You've crafted a {potionName}! ✨");
        Console.ResetColor();
        Console.WriteLine("Ingredients used:");
        
        foreach (string ingredient in ingredients)
        {
            Console.WriteLine($"🧪 {ingredient}");
            Thread.Sleep(500);
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nEffect: {effect}");
        Console.ResetColor();
    }

    static void ShowPotionLog()
    {
        Console.Clear();
        Console.WriteLine("\n📜 Your Enchanted Potion Log 📜");
        foreach (var potion in potionLog)
        {
            Console.WriteLine($"• {potion}");
        }
        Console.WriteLine("\nThank you for brewing with the Mystical Potion Brewer! 🧪");
    }

    static void AnimateText(string text, bool rainbow = false)
    {
        ConsoleColor[] colors = { ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.Cyan, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Red };
        foreach (char c in text)
        {
            if (rainbow) Console.ForegroundColor = colors[random.Next(colors.Length)];
            Console.Write(c);
            Thread.Sleep(5);
        }
        Console.ResetColor();
    }
}
