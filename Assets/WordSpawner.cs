using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{


    public GameObject wordPrefab;
    public Transform wordCanvas;

    public WordDisplay SpawnWord()
    {

        Vector3 randomPosition = new Vector3 (Random.Range(100f,300f), Random.Range(300f,600f));


        GameObject wordObj = Instantiate(wordPrefab,randomPosition, Quaternion.identity,wordCanvas);
        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();

        return wordDisplay;
    }
}
