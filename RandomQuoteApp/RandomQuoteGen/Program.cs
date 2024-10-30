using System;
using System.Collections.Generic;

class RandomQuoteGeneratorApp
{
    static Random random = new Random();

    // Dictionary of quotes categorized by mood or theme
    static Dictionary<string, List<string>> quotes = new Dictionary<string, List<string>>()
{
    { "motivational", new List<string> {
        "Believe you can and you're halfway there.",
        "The only way to do great work is to love what you do.",
        "Don't watch the clock; do what it does. Keep going.",
        "Success is not how high you have climbed, but how you make a positive difference in the world.",
        "Your limitation—it's only your imagination.",
        "Push yourself, because no one else is going to do it for you.",
        "Great things never come from comfort zones.",
        "Dream it. Wish it. Do it.",
        "Success doesn’t just find you. You have to go out and get it.",
        "The harder you work for something, the greater you’ll feel when you achieve it.",
        "Dream bigger. Do bigger.",
        "Don’t stop when you’re tired. Stop when you’re done.",
        "Wake up with determination. Go to bed with satisfaction.",
        "Do something today that your future self will thank you for.",
        "Little things make big days.",
        "It’s going to be hard, but hard does not mean impossible.",
        "Don’t wait for opportunity. Create it.",
        "Sometimes we’re tested not to show our weaknesses, but to discover our strengths.",
        "The key to success is to focus on goals, not obstacles.",
        "The secret of getting ahead is getting started.",
        "Do what you can with all you have, wherever you are.",
        "Only those who dare to fail greatly can ever achieve greatly.",
        "Don’t let yesterday take up too much of today.",
        "Everything you’ve ever wanted is on the other side of fear.",
        "Believe in yourself, take on your challenges, and dig deep within yourself to conquer fears.",
        "Be the person your dog thinks you are.",
        "Challenges are what make life interesting. Overcoming them is what makes life meaningful."
    }},
    { "funny", new List<string> {
        "I’m on a whiskey diet. I’ve lost three days already.",
        "My room is like the Bermuda Triangle. Stuff goes in and is never seen again.",
        "I’m not arguing, I’m just explaining why I’m right.",
        "I didn’t fall, I’m just spending some quality time with the floor.",
        "I can’t believe I forgot to go to the gym today. That’s seven years in a row now.",
        "Doing nothing is hard, you never know when you’re done.",
        "I’m not lazy, I’m on energy-saving mode.",
        "Sarcasm—because beating people up is illegal.",
        "If you think nobody cares if you're alive, try missing a couple of payments.",
        "My bed is a magical place where I suddenly remember everything I was supposed to do.",
        "I run like the winded.",
        "My wallet is like an onion. Opening it makes me cry.",
        "Life is short. Smile while you still have teeth.",
        "I'm not great at the advice. Can I interest you in a sarcastic comment?",
        "If at first, you don't succeed, skydiving is not for you.",
        "The problem with trouble is that it starts out as fun.",
        "I refuse to answer that question on the grounds that I don’t know the answer.",
        "Common sense is like deodorant. The people who need it most never use it.",
        "If you think you are too small to be effective, you have never been in bed with a mosquito.",
        "I’m on a seafood diet. I see food and I eat it.",
        "My favorite exercise is a cross between a lunge and a crunch. I call it lunch.",
        "I'm not arguing, I'm just explaining why I'm right.",
        "I'm multitasking: I can listen, ignore, and forget all at once.",
        "Sometimes I pretend to be normal, but it gets boring. So I go back to being me."
    }},
    { "philosophical", new List<string> {
        "The unexamined life is not worth living. - Socrates",
        "To be is to do. - Immanuel Kant",
        "He who has a why to live can bear almost any how. - Friedrich Nietzsche",
        "We are what we repeatedly do. Excellence, then, is not an act, but a habit. - Aristotle",
        "Do not go where the path may lead, go instead where there is no path and leave a trail. - Ralph Waldo Emerson",
        "Life is really simple, but we insist on making it complicated. - Confucius",
        "Happiness is not something ready made. It comes from your own actions. - Dalai Lama",
        "Our life is what our thoughts make it. - Marcus Aurelius",
        "No one can hurt me without my permission. - Mahatma Gandhi",
        "Everything we hear is an opinion, not a fact. Everything we see is a perspective, not the truth. - Marcus Aurelius",
        "The only true wisdom is in knowing you know nothing. - Socrates",
        "I think, therefore I am. - René Descartes",
        "Man is condemned to be free; because once thrown into the world, he is responsible for everything he does. - Jean-Paul Sartre",
        "The mind is everything. What you think you become. - Buddha",
        "It is not length of life, but depth of life. - Ralph Waldo Emerson",
        "God is dead. - Friedrich Nietzsche",
        "An unhurried sense of time is in itself a form of wealth. - Bonnie Friedman",
        "You have power over your mind – not outside events. Realize this, and you will find strength. - Marcus Aurelius",
        "Man is the only creature who refuses to be what he is. - Albert Camus",
        "Out of suffering have emerged the strongest souls; the most massive characters are seared with scars. - Khalil Gibran",
        "It is not death that a man should fear, but he should fear never beginning to live. - Marcus Aurelius",
        "The mystery of life isn't a problem to solve, but a reality to experience. - Frank Herbert",
        "Without music, life would be a mistake. - Friedrich Nietzsche"
    }},
};


    static void Main()
    {
        Console.Title = "Random Quote Generator";
        ShowIntro();
        ShowMenu();
    }

    static void ShowIntro()
    {
        // Random for colors
        Random random = new Random();
        string introArt = @"
    ╔═══╗╔═══╗╔═╗ ╔╗╔═══╗╔═══╗╔═╗╔═╗    ╔═══╗╔╗ ╔╗╔═══╗╔════╗╔═══╗╔═══╗
    ║╔═╗║║╔═╗║║║╚╗║║╚╗╔╗║║╔═╗║║║╚╝║║    ║╔═╗║║║ ║║║╔═╗║║╔╗╔╗║║╔══╝║╔═╗║
    ║╚═╝║║║ ║║║╔╗╚╝║ ║║║║║║ ║║║╔╗╔╗║    ║║ ║║║║ ║║║║ ║║╚╝║║╚╝║╚══╗║╚═╝║
    ║╔╗╔╝║╚═╝║║║╚╗║║ ║║║║║║ ║║║║║║║║    ║║ ║║║║ ║║║║ ║║  ║║  ║╔══╝║╔╗╔╝
    ║║║╚╗║╔═╗║║║ ║║║╔╝╚╝║║╚═╝║║║║║║║    ║╚═╝║║╚═╝║║╚═╝║ ╔╝╚╗ ║╚══╗║║║╚╗
    ╚╝╚═╝╚╝ ╚╝╚╝ ╚═╝╚═══╝╚═══╝╚╝╚╝╚╝    ╚═══╝╚═══╝╚═══╝ ╚══╝ ╚═══╝╚╝╚═╝
";

        string[] lines = introArt.Split('\n');

        foreach (string line in lines)
        {
            foreach (char c in line)
            {
                // Generate random RGB values
                int r = random.Next(256);
                int g = random.Next(256);
                int b = random.Next(256);

                // Set color using ANSI escape codes for true RGB color
                Console.Write($"\x1b[38;2;{r};{g};{b}m{c}");
            }
            Console.WriteLine();
        }

        // Reset color
        Console.Write("\x1b[0m");
        Thread.Sleep(1500);
    }

    static void ShowMenu()
    {
        while (true) // Ensure the menu loops
        {
            Console.Clear();
            Random random = new Random();

            // Menu header (unchanged ASCII art)
            string menuArt = @"
╔══════════════════════════════════════════════════════════╗
║     ███╗   ███╗███████╗███╗   ██╗██╗   ██╗               ║
║     ████╗ ████║██╔════╝████╗  ██║██║   ██║               ║
║     ██╔████╔██║█████╗  ██╔██╗ ██║██║   ██║               ║
║     ██║╚██╔╝██║██╔══╝  ██║╚██╗██║██║   ██║               ║
║     ██║ ╚═╝ ██║███████╗██║ ╚████║╚██████╔╝               ║
║     ╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝ ╚═════╝                ║
╚══════════════════════════════════════════════════════════╝
";

            // Print menu header with random colors
            foreach (string line in menuArt.Split('\n'))
            {
                foreach (char c in line)
                {
                    Console.ForegroundColor = (ConsoleColor)random.Next(1, 15);
                    Console.Write(c);
                }
                Console.WriteLine();
            }

            Console.ResetColor();

            Console.WriteLine(@"
╔══════════════════════ MAIN MENU ═════════════════════════════╗
║                                                              ║
║   [1]  ⚡ MOTIVATIONAL QUOTES ⚡                            ║
║        ╭━━━━━━━━━━━━━━━━━━━━━━━━━╮                          ║
║        ┃    IGNITE YOUR SOUL!     ┃                        ║
║        ┃    ◢██████████████◣      ┃                      ║
║        ┃    ████████████████      ┃                      ║
║        ┃    ◥██████████████◤      ┃                     ║
║        ╰━━━━━━━━━━━━━━━━━━━━━━━━━╯                        ║
║                                                            ║
║   [2]  😄 FUNNY QUOTES 😄                                  ║
║        ╭━━━━━━━━━━━━━━━━━━━━━━━━━╮                           ║
║        ┃    TIME TO LAUGH!        ┃                          ║
║        ┃    ▄██▄  ▄██▄           ┃                          ║
║        ┃    └┴┴┘  └┴┴┘           ┃                         ║
║        ┃     ヮ    ヮ             ┃                       ║
║        ╰━━━━━━━━━━━━━━━━━━━━━━━━━╯                         ║
║                                                             ║
║   [3]  🤔 PHILOSOPHICAL QUOTES 🤔                           ║
║        ╭━━━━━━━━━━━━━━━━━━━━━━━━━╮                            ║
║        ┃    EXPAND YOUR MIND      ┃                           ║
║        ┃      ╭────────╮         ┃                           ║
║        ┃    ╭─┤ ▓▓▓▓ ├─╮        ┃                           ║
║        ┃    ╰─┤ ▓▓▓▓ ├─╯        ┃                          ║
║        ╰━━━━━━━━━━━━━━━━━━━━━━━━━╯                        ║
║                                                            ║
║   [4]  🚪 EXIT PROGRAM 🚪                                   ║
║        ╭━━━━━━━━━━━━━━━━━━━━━━━━━╮                           ║
║        ┃    SEE YOU LATER!        ┃                           ║
║        ┃    ▣═══════════▣        ┃                           ║
║        ┃    ║  ▓▓   ▓▓  ║        ┃                           ║
║        ┃    ▣═══════════▣        ┃                         ║
║        ╰━━━━━━━━━━━━━━━━━━━━━━━━━╯                         ║
║                                                           ║
╚════════════════════════════════════════════════════════════

            
");

            // Prompt user for input
            Console.Write("\n🎯 Enter your choice (1-4): ");

            string choice = Console.ReadLine() ?? string.Empty;

            // Animate the selection
            Console.Clear();
            switch (choice)
            {
                case "1":
                    AnimateSelection(@"
    ⚡ LOADING MOTIVATION ⚡
    ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
                    DisplayRandomQuote("motivational");
                    PauseForReturnToMenu();
                    break;
                case "2":
                    AnimateSelection(@"
    😄 PREPARING JOKES 😄
    ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
                    DisplayRandomQuote("funny");
                    PauseForReturnToMenu();
                    break;
                case "3":
                    AnimateSelection(@"
    🤔 THINKING DEEPLY 🤔
    ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
                    DisplayRandomQuote("philosophical");
                    PauseForReturnToMenu();
                    break;
                case "4":
                    AnimateSelection(@"
    👋 GOODBYE! 👋
    ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
                    ExitProgram();
                    return; // Exit the program
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"
    ╔═══════════════════════════════════╗
    ║     ❌ INVALID SELECTION ❌        ║
    ╚═══════════════════════════════════╝");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    break;
            }
        }
    }

    static void AnimateSelection(string loadingText)
    {
        Console.Clear();
        Console.WriteLine(loadingText);
        Thread.Sleep(1000);
    }

   static void DisplayRandomQuote(string theme)
{
    Console.Clear();
    if (quotes.ContainsKey(theme))
    {
        List<string> quoteList = quotes[theme];
        string randomQuote = quoteList[random.Next(quoteList.Count)];

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Here is your {theme} quote:");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n\"{randomQuote}\"\n");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid theme selected.");
        Console.ResetColor();
    }
}

    static void ExitProgram()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        string exitArt = @"
    ╔═══╗╔═══╗╔═╗ ╔╗╔═══╗╔═══╗╔═╗╔═╗    ╔═══╗╔╗ ╔╗╔═══╗╔════╗╔═══╗╔═══╗
    ║╔═╗║║╔═╗║║║╚╗║║╚╗╔╗║║╔═╗║║║╚╝║║    ║╔═╗║║║ ║║║╔═╗║║╔╗╔╗║║╔══╝║╔═╗║
    ║╚═╝║║║ ║║║╔╗╚╝║ ║║║║║║ ║║║╔╗╔╗║    ║║ ║║║║ ║║║║ ║║╚╝║║╚╝║╚══╗║╚═╝║
    ║╔╗╔╝║╚═╝║║║╚╗║║ ║║║║║║ ║║║║║║║║    ║║ ║║║║ ║║║║ ║║  ║║  ║╔══╝║╔╗╔╝
    ║║║╚╗║╔═╗║║║ ║║║╔╝╚╝║║╚═╝║║║║║║║    ║╚═╝║║╚═╝║║╚═╝║ ╔╝╚╗ ║╚══╗║║║╚╗
    ╚╝╚═╝╚╝ ╚╝╚╝ ╚═╝╚═══╝╚═══╝╚╝╚╝╚╝    ╚═══╝╚═══╝╚═══╝ ╚══╝ ╚═══╝╚╝╚═╝
";

        Console.WriteLine(exitArt);
        Console.ResetColor();
        Console.WriteLine("\nThanks for using the Random Quote Generator! Goodbye!");
        Thread.Sleep(2000);
        Environment.Exit(0);
    }

    static void PauseForEffect()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ResetColor();
        Console.ReadKey();
    }

    static void PauseForReturnToMenu()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\nPress any key to return to the menu...");
    Console.ResetColor();
    Console.ReadKey(); // Wait for the user to press any key
}
}