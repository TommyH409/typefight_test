using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class commonWordScore : MonoBehaviour
{

    public static int scoreValue = 100;
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Life: " + scoreValue;

    }
    /*
    void addPoints()
    {
        scoreValue += 10;
    }

    void minusPoints()
    {
        scoreValue -= 10;
    }
    */
}
