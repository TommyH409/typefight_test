using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ken_attack : MonoBehaviour
{
    [SerializeField]
    public GameObject ken_anim_test;

    public Animator test_ken;
    public bool isAttacking = false;
    public bool isHit = false;
    public bool victory = false;

    // Start is called before the first frame update
    void Start()
    {
        test_ken = ken_anim_test.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
