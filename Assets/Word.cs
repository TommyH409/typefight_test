using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Word{

    public string word;
    public string color;
    private int typeIndex;
    public int damage;
    public static string[] commonWords = { "punch", "tamper", "wane", "yank", "quake", "choke", "smash", "invade", "hadouken", "grab", "rabid" };
    public static string[] healingWords = { "armor-up", "dodge", "cure", "heal", "elixir", "intercept", "dodge", "cure", "heal", "elixir", "intercept" };
    public static string[] critWords = { "beatdown", "zero-in-on", "fatality", "ultimatum", "kNUckLe-SandWICh", "encroach", "shinku-hadouken", "uppercut", "FaLcoN-PuNcH", "zero-in-on", "fatality" };
    public static string[] freezeWords = { "neutralize", "blizzard", "frost", "icy", "pk-freeze", "ice-climber's", "exhaust", "neutralize", "blizzard", "frost", "icy" };
    WordDisplay display;

    public Word (string _word, WordDisplay _display)
    {
        word = _word;
        typeIndex = 0;

        for (int i = 0; i < 11; i++)
        {
            if (word == commonWords[i])
            {
                damage = -10;
                color = "white";
            }
            if (word == healingWords[i])
            {
                damage = +30;
                color = "green";
            }
            if (word == critWords[i])
            {
                damage = -15;
                color = "red";
            }
            if (word == freezeWords[i])
            {
                damage = 0;
                color = "blue";
            }
        }

        display = _display;
        display.SetWord(word);

    }

    public char GetNextLetter()
    {
        return word[typeIndex];

    }

    public void TypeLetter()
    {
        typeIndex++;  // Remove the letter on screen
        display.RemoveLetter();
    }

    public bool WordTyped()
    {
      bool wordTyped = (typeIndex >= word.Length);
        if(wordTyped)
        {
            // Remove word on screen
            display.RemoveWord();


        }
        return wordTyped;
    }

}
