using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chun_attack : MonoBehaviour
{
    [SerializeField]
    public GameObject chun_anim_test;

    public Animator test_chun;
    public bool isAttacking = false;
    public bool isHit = false;
    public bool victory = false;

    // Start is called before the first frame update
    void Start()
    {
        test_chun = chun_anim_test.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
