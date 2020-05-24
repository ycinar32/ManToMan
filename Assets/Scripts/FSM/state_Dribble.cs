using UnityEngine;
using StateStuff;
using UnityEngine.AI;



public class state_Dribble : State<AI>
{
    private static state_Dribble _instance;
    //Vector3 spotA,spotB, spotC, spotD, spotE, spotF, spotG, spotH;

    

    private state_Dribble()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static state_Dribble Instance
    {
        get
        {
            if (_instance == null)
            {
                new state_Dribble();
            }

            return _instance;
        }
    }


    public override void EnterState(AI _owner)
    {
       
    }

    public override void ExitState(AI _owner)
    {
        
    }

    public override void UpdateState(AI _owner)
    {
        DribbleSpotCalculator(ref _owner);
    }

    Vector3 DribbleSpotCalculator(ref AI _owner)
    {
        Vector3 player_position = _owner.transform.position;
        int pointPosA = 0;
        int pointPosB = 0;
        int pointPosC = 0;
        int pointPosD = 0;
        int pointPosE = 0;
        int pointPosF = 0;
        int pointPosG = 0;
        int pointPosH = 0;
        char bestSpot = ' ';
        Vector3 posA = player_position + new Vector3(-10f, 0f, -10f);
        Vector3 posB = player_position + new Vector3(-10f, 0f, 0f);
        Vector3 posC = player_position + new Vector3(-10f, 0f, +10f);
        Vector3 posD = player_position + new Vector3(0f, 0f, +10f);
        Vector3 posE = player_position + new Vector3(+10f , 0f, +10f);
        Vector3 posF = player_position + new Vector3(+0f , 0f, +0f);
        Vector3 posG = player_position + new Vector3( +10f, 0f, -10f);
        Vector3 posH = player_position + new Vector3( 0f, 0f, -10f);

        Vector3 danger_vector = (_owner.DefenderOfThis.transform.position - _owner.transform.position);
        //Debug.Log(danger_vector);
        Vector3 hoop_vector = (GameObject.FindGameObjectWithTag("hoop").transform.position - _owner.transform.position);
        //Debug.Log(hoop_vector);
        float degreeD = Mathf.Rad2Deg*Mathf.Atan(danger_vector.z / danger_vector.x);
        Debug.Log(degreeD);
        

        if (danger_vector.x < 0  && degreeD <= 90 && degreeD >= 25)
        {
            Debug.Log("SOL ALT");
            pointPosC = 5;  pointPosD = 5;   pointPosE = 3;
            pointPosB = 5;                   pointPosF = 3;
            pointPosA = 5;  pointPosH = 5;   pointPosG = 3;
            bestSpot = 'B';
        }
        else if(danger_vector.x < 0 && degreeD < 25 && degreeD > -25)
        {
            Debug.Log("TAM SOL");
            pointPosC = 5;  pointPosD = 5;   pointPosE = 3;
            pointPosB = 5;                   pointPosF = 3;
            pointPosA = 5;  pointPosH = 5;   pointPosG = 3;
            bestSpot = 'A';
        }
        else if (danger_vector.x < 0 && degreeD <= -25 && degreeD >= -90)
        {
             Debug.Log("SOL ÜST"); 
            pointPosC = 5; pointPosD = 5; pointPosE = 3;
            pointPosB = 5;                pointPosF = 3;
            pointPosA = 5; pointPosH = 5; pointPosG = 3;
            bestSpot = 'B';
        }
        else if (danger_vector.x >= 0 && degreeD <= -25 && degreeD >= -90)
        {
            Debug.Log("SAĞ ALT");
            pointPosC = 5; pointPosD = 5; pointPosE = 3;
            pointPosB = 5;                pointPosF = 3;
            pointPosA = 5; pointPosH = 5; pointPosG = 3;
            bestSpot = 'C';
        }
        else if (danger_vector.x >= 0 && degreeD > -25 && degreeD < 25)
        {
            Debug.Log("TAM SAĞ");
            pointPosC = 5; pointPosD = 3; pointPosE = 3;
            pointPosB = 5;                pointPosF = 3;
            pointPosA = 5; pointPosH = 3; pointPosG = 3;
            bestSpot = 'B';
        }
        else if (danger_vector.x >= 0 && degreeD <= 90 && degreeD >= 25)
        {
            Debug.Log("SAĞ ÜST");
            pointPosC = 5; pointPosD = 5; pointPosE = 3;
            pointPosB = 5;                pointPosF = 3;
            pointPosA = 5; pointPosH = 5; pointPosG = 3;
            bestSpot = 'A';
        }

        Random.seed = (Random.Range(Random.Range(Random.Range(Random.Range(0, 25), Random.Range(324, 5673)), Random.Range(Random.Range(53, 2378), Random.Range(50, 423))), Random.Range(Random.Range(Random.Range(23, 2354), Random.Range(1, 3456)), Random.Range(Random.Range(7, 32421), Random.Range(8, 23472)))));
        

        int sum = pointPosA + pointPosB + pointPosC + pointPosD + pointPosE + pointPosF + pointPosG + pointPosH;
        int var = Random.Range(1, sum);
        //Debug.Log(var);
        if(var < pointPosA) 
            bestSpot = 'A';
        else if ((var > pointPosA ) || ( var < (pointPosA + pointPosB)))
            bestSpot = 'B';
        else if ((var > (pointPosA + pointPosB )) || ( (var < pointPosA + pointPosB + pointPosC)))
            bestSpot = 'C';
        else if ((var > (pointPosA + pointPosB + pointPosC )) || (var < ( pointPosA + pointPosB + pointPosC + pointPosD)))
            bestSpot = 'D';
        else if ((var > (pointPosA + pointPosB + pointPosC + pointPosD )) || ( var < (pointPosA + pointPosB + pointPosC + pointPosD + pointPosE)))
            bestSpot = 'E';
        else if ((var > (pointPosA + pointPosB + pointPosC + pointPosD + pointPosE)) || (var < (pointPosA + pointPosB + pointPosC + pointPosD + pointPosE + pointPosF)))
            bestSpot = 'F';
        else if ((var > (pointPosA + pointPosB + pointPosC + pointPosD + pointPosE + pointPosF)) || (var < (pointPosA + pointPosB + pointPosC + pointPosD + pointPosE + pointPosF + pointPosG)))
            bestSpot = 'G';
        else 
            bestSpot = 'H';

        switch (bestSpot)
        {
            case 'A':
                _owner.GetComponent<NavMeshAgent>().destination = posA; Debug.Log(bestSpot);
                _owner.dribble_Spot = posA;
                break;
            case 'B':
                _owner.GetComponent<NavMeshAgent>().destination = posB; Debug.Log(bestSpot);
                _owner.dribble_Spot = posB;
                break;
            case 'C':
                _owner.GetComponent<NavMeshAgent>().destination = posC; Debug.Log(bestSpot);
                _owner.dribble_Spot = posC;
                break;
            case 'D':
                _owner.GetComponent<NavMeshAgent>().destination = posD; Debug.Log(bestSpot);
                _owner.dribble_Spot = posD;
                break;
            case 'E':
                _owner.GetComponent<NavMeshAgent>().destination = posE; Debug.Log(bestSpot);
                _owner.dribble_Spot = posE;
                break;
            case 'F':
                _owner.GetComponent<NavMeshAgent>().destination = posF; Debug.Log(bestSpot);
                _owner.dribble_Spot = posF;
                break;
            case 'G':
                _owner.GetComponent<NavMeshAgent>().destination = posG; Debug.Log(bestSpot);
                _owner.dribble_Spot = posG;
                break;
            case 'H':
                _owner.GetComponent<NavMeshAgent>().destination = posH; Debug.Log(bestSpot);
                _owner.dribble_Spot = posH;
                break;
        }

        _owner.stateMachine.ChangeState(state_Wait.Instance);

        return new Vector3(0,0,0) ;

    }

    

}


