using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using StateStuff;



public class AI : MonoBehaviour 
{
    [SerializeField] public GameObject Team;


    public Vector3 passDirection;
    public Vector3 shootDirection;
    [SerializeField] public GameObject ball;
    [SerializeField] public GameObject TeamMember1;
    [SerializeField] public GameObject TeamMember2;
    [SerializeField] public GameObject TeamMember3;
    [SerializeField] public GameObject TeamMember4;
    [SerializeField] public GameObject DefenderOfThis;
    [SerializeField] public GameObject Defender1;
    [SerializeField] public GameObject Defender2;
    [SerializeField] public GameObject Defender3;
    [SerializeField] public GameObject Defender4;

    public Vector3 dribble_Spot;
    
    public bool switchState = false;
    public float gameTimer;
    public int seconds = 0;


    /*----------------------IN GAME INFORMATIONS---------------*/
    public bool dribbleSuccessed = false;
    [SerializeField] public float distanceFromBall;
    public bool hasBall = false;
    public bool wasLastOwner = false;
    public bool receivingPass = false;
    public bool settledPosition = false;
    public float distanceFromDefender;
    /*--------------END OF IN GAME INFOS----------------------*/

    public StateMachine<AI> stateMachine { get; set; }

    private void Start()
    {
        stateMachine = new StateMachine<AI>(this);
        stateMachine.ChangeState(state_Wait.Instance);
        gameTimer = Time.time;
    }

    private void Update()
    {      
        
        stateMachine.Update();
        Debug.Log(this.name + this.stateMachine.currentState);
        if (this.tag == "Player2") {
            //Debug.Log("Defender " + DefenderOfThis.transform.position);
            //Debug.Log("Atacker " + this.transform.position); 
        }
    }
    public void isDribbleSuccessed(ref AI _owner)
    {
        if (_owner.dribble_Spot == _owner.transform.position)
            _owner.dribbleSuccessed = true;
        else
            _owner.dribbleSuccessed = false;
    }
    public bool isClosestTeamMemberToBall()
    {

        distanceFromBall = Vector3.Distance(ball.transform.position, this.transform.position);
        float distanceFromBallTeamMember1 = Vector3.Distance(ball.transform.position, TeamMember1.transform.position);
        float distanceFromBallTeamMember2 = Vector3.Distance(ball.transform.position, TeamMember2.transform.position);
        float distanceFromBallTeamMember3 = Vector3.Distance(ball.transform.position, TeamMember3.transform.position);
        float distanceFromBallTeamMember4 = Vector3.Distance(ball.transform.position, TeamMember4.transform.position);


        if ((distanceFromBall < distanceFromBallTeamMember1) &&
            (distanceFromBall < distanceFromBallTeamMember2) &&
            (distanceFromBall < distanceFromBallTeamMember3) &&
            (distanceFromBall < distanceFromBallTeamMember4))
        {
            return true;
        }
        else
            return false;
    }

    [System.Obsolete]
    public int passToWho()
    {

        Random.seed = (int)System.DateTime.Now.Ticks;
        int var = Random.Range(1, 4);
        return var;

    }

}
