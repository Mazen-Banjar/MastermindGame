# 🎮 Mastermind Game (Savvy Kickstarter Skills Assessment - Gameplay Programming Track)

This is a C# console-based implementation of the classic **Mastermind** game, developed as part of the 2025 Savvy Kickstarter Program's Gameplay Programming track.

The goal of the game is for the player to guess a **4-digit secret code** (digits 0–8, no duplicates) within a limited number of attempts. After each guess, the player receives feedback on how many digits are well-placed and how many are misplaced.

---

## 🧠 Game Rules

- The secret code consists of **4 distinct digits** from **0 to 8**.
- The player has a default of **10 attempts** to guess the code (customizable via `-t`).
- After each guess, the game tells you:
  - How many digits are **well-placed** (correct digit & correct position).
  - How many digits are **misplaced** (correct digit, wrong position).
- The game ends when:
  - The player guesses the code (🎉 win),
  - The player runs out of attempts (❌ lose),
  - Or enters EOF (`Ctrl + Z` in Windows) to exit.

---

## ⚙️ Command-Line Arguments

You can optionally pass in:

| Option | Description |
|--------|-------------|
| `-c [CODE]` | Set a custom secret code (must be 4 distinct digits from 0 to 8) |
| `-t [ATTEMPTS]` | Set the number of max attempts (default: 10) |

### Example:

```bash
MastermindGame.exe -c 1234 -t 8
