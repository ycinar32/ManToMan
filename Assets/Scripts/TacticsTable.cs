using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsTable : MonoBehaviour
{
    private static TacticsTable _instance;

    private TacticsTable()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static TacticsTable Instance
    {
        get
        {
            if (_instance == null)
            {
                new TacticsTable();
            }

            return _instance;
        }
    }

   //public object TacticsTable { get; private set; }

    public Vector3[] zones;
    public Vector3[] positionForPlayers;
    public TacticsTable instance;
    void Start()
    {


        //SAHAYI BOLGELERE AYIRAN KOD PARCASI-------------------------------------------------------

        zones = new Vector3[1000];
        positionForPlayers = new Vector3[5];
        int zone_counter = 0;
        float boy = transform.position.x;
        float en = transform.position.z;

        Debug.Log(transform.position.x);
        Debug.Log(transform.position.z);
        /*for (float i = boy; i < 50; i=i+5)
        {
            for (float j = en; j < 26; j=j+5)
            {
                zones[zone_counter] = new Vector3(i, 0, j);
            }
            zone_counter++;
            Debug.Log(zone_counter + ". zone =  " + zones[zone_counter - 1]);
        }*/

        zones[0] = new Vector3(-45, 0, -20);
        zones[1] = new Vector3(-20, 0, 0);
        zones[2] = new Vector3(-45, 0, 20);
        zones[3] = new Vector3(-42, 0, 4);
        zones[4] = new Vector3(-24, 0, -5);

        positionForPlayers[0] = zones[0];
        positionForPlayers[1] = zones[1];
        positionForPlayers[2] = zones[2];
        positionForPlayers[3] = zones[3];
        positionForPlayers[4] = zones[4];
    }
    // Debug.Log(this.transform.position.x + this.transform.position.y);
    //-------------------------------------------------------------------------------------------



    // Update is called once per frame
    void Update()
    {

    }
}
