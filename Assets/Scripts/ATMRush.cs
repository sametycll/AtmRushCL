using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATMRush : MonoBehaviour
{
    public static ATMRush instance;
    public List<GameObject> cubes = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {

    }


    void Update()
    {

    }
}
