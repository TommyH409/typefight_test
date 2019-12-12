using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; //BOT CODE

public class WordManager : MonoBehaviour{

    public List<Word>  words;
    public WordSpawner wordSpawner;
    private Word activeWord;   // stores the ActiveWord
    public Slider myhealthBar;
    public Slider enemyhealthBar;
    public Text TimerText;
    public LoadScene Loader;

    public float timeStart = 60;
    public int counter = 0;
    public int word_damage = 0;
    private bool hasActiveWord;
    private bool freezed = false;
    private bool player_freeze = false;

    private float playerStrength = 10;

    //BOT CODE
    private float botStrength = 5;
    private float damageInterval = 2;
    private float timerTime = 2;
    public static int[] values = { 0, 0, 0, 0, 0, 0, 1, 1, 1, 2, 3, 3, 4, 4 };
    //public static int[] values = { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
    //BOT CODE

    //FREEZE CODE
    private float freezeInterval = 10;
    private float freezeTimerTime = 10;

    private float playerFreezeInterval = 2;
    private float playerFreezeTime = 2;
    public float playerAttackMultiplier = 1;

    // Attack booleans ===================================================
    public ken_attack ken_test;
    public chun_attack chun_test;
    public Lose_screen loser;
    public Win_screen winner;
   
    public float ken_delay = .3f;
    public float chun_delay = .3f;

    public DifficultyLoader test_diff;
    public int diff = 1;

    private void Start()
    { 
        TimerText.text = timeStart.ToString();
        myhealthBar.value = 100;

        if (diff == 0)
        {
            Debug.Log("easy_test");
            botStrength = 1;
        }
        if (diff == 1)
        {
            Debug.Log("normal_test");
            botStrength = 10;
        }
        else if (diff == 2)
        {
            Debug.Log("hard_test");
            botStrength = 100;
            Debug.Log(botStrength);
        }
    }
    public void activateFreeze()
    {
        if (freezeInterval >= 0 && freezed == true)
        {
            botStrength = 0;
            freezeInterval -= Time.deltaTime;
        }
        else
        {
            freezeInterval = freezeTimerTime;
            botStrength = 10;
            freezed = false;
        }
    }

    public void freezePlayer()
    {
        if (player_freeze == true && playerFreezeInterval >= 0)
        {
            playerFreezeInterval -= Time.deltaTime;
            playerAttackMultiplier = 0;
        }
        else
        {
            player_freeze = false;
            playerFreezeInterval = playerFreezeTime;
            playerAttackMultiplier = 1;
        }
    }

    //BOT CODE
    void botDamage()
    {
        if (!ken_test.victory)
        {
            int selected = values[UnityEngine.Random.Range(0, 14)];
            switch (selected)
            {
                case 0:
                    Attack_chun();
                    myhealthBar.value -= botStrength;
                    Random_chun_attack();
                    Invoke("Random_ken_hit", ken_delay);
                    break;
                case 1:
                    Attack_chun();
                    myhealthBar.value -= (float)(1.5 * botStrength);
                    Random_chun_attack();
                    Invoke("Random_ken_hit", ken_delay);
                    break;
                case 2:
                    Attack_chun();
                    myhealthBar.value -= (float)(2.5 * botStrength);
                    Random_chun_attack();
                    Invoke("Random_ken_hit", ken_delay);
                    break;
                case 3:
                    enemyhealthBar.value += 3*botStrength;
                    chun_test.test_chun.SetTrigger("parry");
                    break;
                case 4:
                    player_freeze = true;
                    Random_chun_attack();
                    Invoke("Random_ken_hit", ken_delay);
                    break;

            }
        }
    }
    void updateBar()
    {
        enemyhealthBar.value -= commonWordScore.scoreValue;
    }

    private void Update()
    {
        activateFreeze();
        freezePlayer();
        timerTime -= Time.deltaTime;
        timeStart -= Time.deltaTime;
        if (timeStart >= 0)
        {
            TimerText.text = Mathf.Round(timeStart).ToString();
        }
        else
        {
            if (myhealthBar.value > enemyhealthBar.value)
            {
                Loader.SceneLoader(3);
            }
            else if (enemyhealthBar.value > myhealthBar.value)
            {
                Loader.SceneLoader(2);
            }
        }

        int tempTime = Int32.Parse(TimerText.text);
        if(timerTime <= 0)
        {
          botDamage();
          timerTime = damageInterval;
        }

        // Enemy wins =============================================
        if(myhealthBar.value == 0 && !chun_test.victory)
        {
            Loader.SceneLoader(2);
            myhealthBar.value = 100;
            enemyhealthBar.value = 100;
            timeStart = 60;
            commonWordScore.scoreValue = 100;

        }

        // Player wins =============================================
        if (enemyhealthBar.value == 0 && !ken_test.victory)
        {
            Loader.SceneLoader(3);
            myhealthBar.value = 100;
            enemyhealthBar.value = 100;
            timeStart = 60;
            commonWordScore.scoreValue = 100;
      }
    }

    public void AddWord()
      {
        Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
        words.Add(word);
        //Debug.Log("MY DEBUG LINE 1: " + word.word); // The letters of the word that just spawned
        //Debug.Log("MY DEBUG LINE 2: " + word.damage); //The damage of the word that just spawned
    }

    public void TypeLetter (char letter)
    {
        // to check if the letter that we typed is in the sequence and remove it from the word if it is true
        if (hasActiveWord)   
        {
            if(activeWord.GetNextLetter() == letter)
            {
                  activeWord.TypeLetter();
            }
        }
        else {
                foreach( Word word in words)
                {

                  if(word.GetNextLetter() == letter )
                    {
                        activeWord = word;
                        hasActiveWord = true;
                        word.TypeLetter();
                        break;

                    }
                }

        }

        // Color checks
          if (hasActiveWord && activeWord.WordTyped())
          {
            if (activeWord.color == "blue")
            {
                freezed = true;
            }
            if (activeWord.color == "white")
            {
                playerStrength = 10;
                Debug.Log(playerStrength);
            }
            if (activeWord.color == "red")
            {
                playerStrength = (float)1.5 * (10);
                Debug.Log(playerStrength);
            }
            if (activeWord.color == "green")
            {
                playerStrength = (float)3 * (10);
                Debug.Log(playerStrength);
            }


            hasActiveWord = false;
            //activeWord is the word that spawns after typing a word
            words.Remove(activeWord); 
            counter++;
            if(counter % 1 == 0)
            {
               AddWord();
            }

            if (playerStrength == (float)3 * (10))
            {
                myhealthBar.value += 20;
                ken_test.test_ken.SetTrigger("parry");
            }
            else
            {
                //activeWord.damage = (int)playerStrength;
                Debug.Log(activeWord.damage);
                commonWordScore.scoreValue += (activeWord.damage);
                //commonWordScore.scoreValue += (int)playerStrength;
                enemyhealthBar.value = commonWordScore.scoreValue;         //This is the healthbar value
                Attack_ken();
                Random_ken_attack();
                Invoke("Random_chun_hit", chun_delay);
            }

            //Debug.Log("THIS IS COMMONWS: " + commonWordScore.scoreValue);
            //Debug.Log("THIS IS HP VALUE: " + myhealthBar.value);
            // if (commonWordScore.scoreValue == 0)
            // {
            //     Debug.Log("YOU WIN");
            //     gameActive = false;
            //     Debug.Log(gameActive);
            // }

          }
    }
    // Ken animations =====================================================
    void Random_ken_attack()
    {
        if(ken_test.isAttacking == true && !ken_test.victory)
        {
            int index = UnityEngine.Random.Range(1, 4);
            ken_test.test_ken.SetTrigger("attack" + index);
            Invoke("Reset_ken", .15f);
        }
    }

    void Random_ken_hit()
    {
        if (ken_test.isHit == true && !ken_test.victory)
        {
            int index = UnityEngine.Random.Range(1, 2);
            ken_test.test_ken.SetTrigger("hit" + index);
            Invoke("Reset_ken", .15f);
        }
    }

    void Attack_ken()
    {
        ken_test.isAttacking = true;
        chun_test.isHit = true;
    }
    void Reset_ken()
    {
        ken_test.isAttacking = false;
        ken_test.isHit = false;
    }

    // Chun Li animations =====================================================
    void Random_chun_attack()
    {
        if (chun_test.isAttacking == true && !chun_test.victory)
        {
            int index = UnityEngine.Random.Range(1, 4);
            chun_test.test_chun.SetTrigger("attack" + index);
            Invoke("Reset_chun", .15f);
        }
    }
    void Random_chun_hit()
    {
        if (chun_test.isHit == true && !chun_test.victory)
        {
            int index = UnityEngine.Random.Range(1, 2);
            chun_test.test_chun.SetTrigger("hit" + index);
            Invoke("Reset_chun", .15f);
        }
    }
    void Attack_chun()
    {
        chun_test.isAttacking = true;
        ken_test.isHit = true;
    }
    void Reset_chun()
    {
        chun_test.isAttacking = false;
        chun_test.isHit = false;
    }
}
