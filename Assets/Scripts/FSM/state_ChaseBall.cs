using UnityEngine;
using StateStuff;
using UnityEngine.AI;

public class state_ChaseBall : State<AI>
{
    private static state_ChaseBall _instance;

    private state_ChaseBall()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static state_ChaseBall Instance
    {
        get
        {
            if (_instance == null)
            {
                new state_ChaseBall();
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

    public override void UpdateState(AI _owner)
    {
        _owner.distanceFromBall = Vector3.Distance(GameObject.FindGameObjectWithTag("Ball").transform.position, _owner.transform.position);
        if (_owner.distanceFromBall < 1.4f)
        {
            _owner.ball.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            _owner.hasBall = true;
            _owner.stateMachine.ChangeState(state_Wait.Instance);
            
        }

        Vector3 pos = _owner.ball.transform.position;
        _owner.GetComponent<NavMeshAgent>().SetDestination(pos);

    }
}