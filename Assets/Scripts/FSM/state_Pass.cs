using UnityEngine;
using StateStuff;
using UnityEngine.AI;

public class state_Pass : State<AI>
{
    private static state_Pass _instance;

    private state_Pass()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static state_Pass Instance
    {
        get
        {
            if (_instance == null)
            {
                new state_Pass();
            }

            return _instance;
        }
    }

    public override void EnterState(AI _owner)
    {
        // Debug.Log("Entering ChaseBall State");
    }

    public override void ExitState(AI _owner)
    {
        // Debug.Log("Exiting ChaseBall State");
    }

    [System.Obsolete]
    public override void UpdateState(AI _owner)
    {
        Random.seed = (int)System.DateTime.Now.Ticks;
        int var = Random.Range(1, 4);
        switch (var)
        {
            case 1:
                _owner.passDirection = ((_owner.TeamMember1.transform.position - _owner.transform.position)).normalized;
                //Debug.Log(_owner.passDirection);
                //_owner.ball.GetComponent<Rigidbody>().velocity.Set(0f, 0f, 0f);
                _owner.ball.GetComponent<Rigidbody>().AddForce(_owner.passDirection * 0.0001f);
                _owner.hasBall = false;
                _owner.TeamMember1.GetComponent<AI>().receivingPass = true;
                //Debug.Log("TM1 = " + TM1.GetComponent<Players>().receivingPass + "TeamMember1 = " + TeamMember1.GetComponent<Players>().receivingPass);
                break;
            case 2:
                _owner.passDirection = ((_owner.TeamMember2.transform.position - _owner.transform.position)).normalized;
                //_owner.ball.GetComponent<Rigidbody>().velocity.Set(0f, 0f, 0f); 
                _owner.ball.GetComponent<Rigidbody>().AddForce(_owner.passDirection * 0.0001f);
                _owner.hasBall = false;
                _owner.TeamMember2.GetComponent<AI>().receivingPass = true;
                //Debug.Log("TM2 = " + TM2.GetComponent<Players>().receivingPass + "TeamMember2 = " + TeamMember2.GetComponent<Players>().receivingPass);
                break;
            case 3:
                _owner.passDirection = ((_owner.TeamMember3.transform.position - _owner.transform.position)).normalized;
                //_owner.ball.GetComponent<Rigidbody>().velocity.Set(0f, 0f, 0f);
                _owner.ball.GetComponent<Rigidbody>().AddForce(_owner.passDirection * 0.0001f);
                _owner.hasBall = false;
                _owner.TeamMember3.GetComponent<AI>().receivingPass = true;
                //Debug.Log("TM3 = " + TM3.GetComponent<Players>().receivingPass + "TeamMember3 = " + TeamMember3.GetComponent<Players>().receivingPass);
                break;
            case 4:
                _owner.passDirection = ((_owner.TeamMember4.transform.position - _owner.transform.position)).normalized;
                //_owner.ball.GetComponent<Rigidbody>().velocity.Set(0f, 0f, 0f); 
                _owner.ball.GetComponent<Rigidbody>().AddForce(_owner.passDirection * 0.0001f);
                _owner.hasBall = false;
                _owner.TeamMember4.GetComponent<AI>().receivingPass = true;
                //Debug.Log("TM4 = " + TM4.GetComponent<Players>().receivingPass + "TeamMember4 = " + TeamMember4.GetComponent<Players>().receivingPass);
                break;
            default:
                break;
        }

        _owner.wasLastOwner = true;
        _owner.stateMachine.ChangeState(state_PassAndWait.Instance);

    }
}