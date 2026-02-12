# OSE Character Generator

A command-line character generator for Old-School Essentials (OSE) tabletop RPG, built as part of my Object-Oriented Programming course at Høgskolen i Østfold.

## Description

This C# console application generates random player characters for Old-School Essentials RPG. The program rolls ability scores (Strength, Intelligence, Wisdom, Dexterity, Constitution, Charisma), determines available character classes based on the character's strengths, and calculates starting hit points.

### Features

- Rolls 3d6 for each of the six ability scores
- Offers reroll if average score is too low (≤8)
- Determines available classes based on top two ability scores
- Validates user input to prevent crashes
- Calculates hit points with Constitution modifier
- Displays complete character sheet

## How to Run

1. Open the project in JetBrains Rider
2. Press the green "Run" button, or
3. Use terminal: `dotnet run`

## Project Structure
```
csArbeidskrav1/
├── CharacterClass.cs       # Base class and class types (Fighter, Thief, etc.)
├── Character.cs            # Main character logic
├── Program.cs              # Entry point
└── README.md
```

## What I Learned

This project helped me understand several key OOP concepts:

- **Inheritance**: Creating Fighter, Thief, Cleric, and MagicUser classes that inherit from CharacterClass
- **Properties**: Using private fields with public get/set properties
- **Constructors**: Understanding how `:base()` calls parent constructors
- **Collections**: Working with Lists and arrays
- **Input validation**: Using `int.TryParse` instead of `int.Parse` to prevent crashes

## AI Usage & Learning Process

I used Claude AI to help me understand concepts, learn about tools I need and how to shorten or find best practice codes. Here are examples of how I used AI as a learning tool:

**Prompt:**
> "What does `=>` mean in properties like `get => _name;`? Is it different from a regular method?"

> "I see `foreach` and `for` loops. When should I use each one?"

>  "My code has a lot of repetition displaying each ability score. Is there a shorter way to write this?"

>  "My validation code is really long - I'm checking if input is a number, then checking if it's in range. Can this be shortened?"

> "What's the difference between `int.Parse()` and `int.TryParse()`? My program keeps crashing when users type letters."

> "Can you explain what `out` means in `int.TryParse(input, out int number)`?"

> "My teacher uses `List<>` but I also see arrays `[]`. Which should I use for storing classes?"

> "I have a while loop with validation but it still crashes. How do I make it completely safe from user errors?"

> "How do I find the top 2 highest ability scores when there might be ties? For example, if STR:14, WIS:14, DEX:15 - all three should count as top scores."

> "How can I not lose the key of the value I'm trying to sort while using sort method?"

> "How does `Array.Sort()` work? Does it sort from smallest to largest or largest to smallest?"

> "When should I use a method that returns a value vs a method that returns void?"


## Challenges I Faced

1. **Understanding Properties**: Initially confused about why we need both private fields and public properties. Learned this is about encapsulation and control.

2. **Handling Ties in Scores**: Struggled with how to handle when multiple abilities have the same value (e.g., two abilities both score 14). Solved by checking if each ability's value matches either of the top 2 values.

3. **Input Validation**: My program crashed when users typed letters instead of numbers. Learned to use `int.TryParse()` instead of `int.Parse()`.

4. **Constructor Chaining**: Didn't understand what `:base()` did at first. Now I understand it calls the parent class constructor before the child constructor runs.

## Reflection

This assignment helped me understand why object-oriented programming is useful. Instead of having separate variables for each class's properties (like `fighterName`, `fighterHitDie`, `thiefName`, `thiefHitDie`), I created one blueprint (CharacterClass) and made specific versions (Fighter, Thief, etc.). This makes the code cleaner and easier to maintain.

I understood and logic and knew what I wanted to do but the hardest part was to find tools, as in syntax and methods or any built-in methods I need to apply to what I'm trying to do.

**Author**: Panida Paethanom
**Course**: Backend study, Gokstad Academy