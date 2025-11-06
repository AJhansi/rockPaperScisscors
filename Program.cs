// Importing the System namespace which contains basic C# functionality (like Console, Random, etc.)
using System;

// Declare a boolean variable to control whether the game should run again
bool playAgain = true;

// Outer loop: runs the entire game until the player chooses not to play again
while (playAgain)
{
    // Display the starting message for the game
    Console.WriteLine("Rock–Paper–Scissors booted!");

    // Initialize player and CPU scores to 0 at the start of each match
    int scorePlayer = 0;
    int scoreCPU = 0;

    // Define an array of possible computer choices
    string[] options = { "ROCK", "PAPER", "SCISSORS" };

    // Create a Random object to generate random numbers for the computer's choice
    Random rng = new Random();

    // Inner loop: continues until either the player or CPU reaches 3 points
    while (scorePlayer < 3 && scoreCPU < 3)
    {
        // Prompt the player to enter their choice
        Console.Write("Enter your choice (ROCK, PAPER, or SCISSORS): ");

        // Read the player's input, remove extra spaces, and convert to uppercase for comparison
        string playerChoice = Console.ReadLine().Trim().ToUpperInvariant();

        // Validate the input: if it's not one of the three valid options
        if (playerChoice != "ROCK" && playerChoice != "PAPER" && playerChoice != "SCISSORS")
        {
            // Inform the player that the input is invalid
            Console.WriteLine("Invalid choice! Please enter ROCK, PAPER, or SCISSORS.\n");
            
            // Skip the rest of this iteration and restart the loop to ask again
            continue;
        }

        // Generate a random number between 0 and 2 (for 3 choices)
        int index = rng.Next(0, 3);

        // Use the random index to select the CPU's move from the options array
        string cpuChoice = options[index];

        // Display both the player's and the CPU's choices
        Console.WriteLine($"You chose: {playerChoice}");
        Console.WriteLine($"Computer chose: {cpuChoice}");

        // Compare both choices to determine the winner
        if (playerChoice == cpuChoice)
        {
            // If both choices are the same, it’s a draw
            Console.WriteLine("It's a DRAW!");
        }
        else if (
            // Player wins if any of these 3 winning conditions are met
            (playerChoice == "ROCK" && cpuChoice == "SCISSORS") ||
            (playerChoice == "PAPER" && cpuChoice == "ROCK") ||
            (playerChoice == "SCISSORS" && cpuChoice == "PAPER"))
        {
            // Announce player’s win and increment their score
            Console.WriteLine("You WIN!");
            scorePlayer++;
        }
        else
        {
            // If none of the above conditions are true, the CPU wins this round
            Console.WriteLine("Computer WINS!");
            scoreCPU++;
        }

        // Display the updated score after each round
        Console.WriteLine($"SCORE — You: {scorePlayer}  CPU: {scoreCPU}\n");
    }

    // Once someone reaches 3 points, announce the match winner
    if (scorePlayer == 3)
        Console.WriteLine("🎉 You won the match!");
    else
        Console.WriteLine("🤖 CPU won the match!");

    // Ask if the player wants to play another match
    Console.Write("\nPlay again? (y/n): ");

    // Read and clean up the player’s response (convert to lowercase for easy comparison)
    string? response = Console.ReadLine()?.Trim().ToLower();

    // If the player says "y", start the game again
    if (response == "y")
    {
        playAgain = true;   // Keep the outer loop running
        Console.Clear();    // Clear the console for a clean new match
    }
    else
    {
        // End the game if the player doesn’t type "y"
        playAgain = false;
        Console.WriteLine("Thanks for playing!");
    }
}
