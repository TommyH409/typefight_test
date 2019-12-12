using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{

    public Slider myhealthBar;


    // Start is called before the first frame update
    void Start()
    {
        //myhealthBar.value = commonWordScore.scoreValue;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            myhealthBar.value += 1;
            Debug.Log(myhealthBar.value);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            myhealthBar.value -= 1;
            Debug.Log(myhealthBar.value);
        }
        */
        //myhealthBar.value += commonWordScore.scoreValue;
        //Debug.Log(myhealthBar.value);
    }
    void updateBar()
    {
        myhealthBar.value -= commonWordScore.scoreValue;
        Debug.Log(myhealthBar.value);
    }
}
