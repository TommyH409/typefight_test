using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_screen : MonoBehaviour
{
    public GameObject Lose_obj;
    public GameObject Win_obj;

    public Animator test_lose;
    public Animator test_win;
    // Start is called before the first frame update
    void Start()
    {
        test_win = Win_obj.GetComponent<Animator>();
        test_lose = Lose_obj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
