using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WordDisplay : MonoBehaviour
{
    public Text text; // reference to text element
    public float fallSpeed = 0.25f;
    public static string[] commonWords = { "punch", "tamper", "wane", "yank", "quake", "choke", "smash", "invade", "hadouken", "grab", "rabid" };
    public static string[] healingWords = { "armor-up", "dodge", "cure", "heal", "elixir", "intercept", "dodge", "cure", "heal", "elixir", "intercept" };
    public static string[] critWords = { "beatdown", "zero-in-on", "fatality", "ultimatum", "kNUckLe-SandWICh", "encroach", "shinku-hadouken", "uppercut", "FaLcoN-PuNcH", "zero-in-on", "fatality" };
    public static string[] freezeWords = { "neutralize", "blizzard", "frost", "icy", "pk-freeze", "ice-climber's", "exhaust", "neutralize", "blizzard", "frost", "icy" };
    public void SetWord (string word)

  {
       // RectTransform rt = GetComponent<RectTransform>();
       // rt.rect.width = 300;
        text.text = word;
        text.fontSize = 20;



        for (int i = 0; i < 11; i++)
        {
            if(word == commonWords[i]) { text.color = Color.white; }
            if (word == healingWords[i]) { text.color = Color.green; }
            if (word == critWords[i]) { text.color = Color.red; }
            if (word == freezeWords[i]) { text.color = Color.blue; }
        }


  }

  public void RemoveLetter()
  {

   text.text = text.text.Remove(0,1);
   text.color = Color.yellow;


  }

  public void RemoveWord()
  {
        //text.text = word;
        /*
        for (int i = 0; i < 11; i++)
        {
            if (word == critWords[i])
            {

                int randomNumber = Random.Range(0, 4);
                if (randomNumber == 3)
                {
                    commonWordScore.scoreValue += 30;
                }
                else
                {
                    commonWordScore.scoreValue += 20;
                }

            }
            else
            {
                commonWordScore.scoreValue += 10;
            }
        }

    */
   }


    public void Update()
    {

      transform.Translate(0f, -fallSpeed , 0f);



    }




}
