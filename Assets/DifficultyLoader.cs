using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyLoader : MonoBehaviour
{
    public WordManager Manager;
    public int test_int;
     public void DiffLoader(int index)
    {
        GameObject test = GameObject.FindGameObjectWithTag("difficulty");
        Manager = test.GetComponent<WordManager>();

        test_int = index;
        if (test_int == 0)
        {
            Manager.diff = 0;
            Debug.Log("WORKS_E" + Manager.diff);
        }
        if (test_int == 1)
        {
            Manager.diff = 1;
            Debug.Log("WORKS_N" + Manager.diff);
        }
        if (test_int == 2)
        {
            Manager.diff = 2;
            Debug.Log("WORKS_H" + Manager.diff);
        }
        //Debug.Log(index);
    }

    private void Start()
    {
        
    }

}
