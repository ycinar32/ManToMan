using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team :MonoBehaviour
{
    private static Team _instance;
        private Team()
        {
            if (_instance != null)
            {
                return;
            }

            _instance = this;
        }

        public static Team Instance
        {
            get
            {
                if (_instance == null)
                {
                    new Team();
                }

                return _instance;
            }
        }

        public object TacticsTable { get; private set; }

    [SerializeField] public GameObject Player1;
    [SerializeField] public GameObject Player2;
    [SerializeField] public GameObject Player3;
    [SerializeField] public GameObject Player4;
    [SerializeField] public GameObject Player5;
    public int whoHasBall;
    [SerializeField] Transform hoop;

    public bool teamHasBall = false;

    public bool teamSettledPosition = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (   Player1.GetComponent<AI>().hasBall ||
               Player2.GetComponent<AI>().hasBall ||
               Player3.GetComponent<AI>().hasBall ||
               Player4.GetComponent<AI>().hasBall ||
               Player5.GetComponent<AI>().hasBall) 
        {
            teamHasBall = true;
        }
        else 
        {
            teamHasBall = false;
        }
        if (Player1.GetComponent<AI>().hasBall) whoHasBall = 1;
        if (Player2.GetComponent<AI>().hasBall) whoHasBall = 2;
        if (Player3.GetComponent<AI>().hasBall) whoHasBall = 3;
        if (Player4.GetComponent<AI>().hasBall) whoHasBall = 4;
        if (Player5.GetComponent<AI>().hasBall) whoHasBall = 5;

        if (Player1.GetComponent<AI>().settledPosition &&
            Player2.GetComponent<AI>().settledPosition &&
            Player3.GetComponent<AI>().settledPosition &&
            Player4.GetComponent<AI>().settledPosition &&
            Player5.GetComponent<AI>().settledPosition)
        {
            teamSettledPosition = true;
        }
    }

}
