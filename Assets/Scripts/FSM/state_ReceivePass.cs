using UnityEngine;
using StateStuff;
using UnityEngine.AI;

public class state_ReceivePass : State<AI>
{
    private static state_ReceivePass _instance;

    private state_ReceivePass()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static state_ReceivePass Instance
    {
        get
        {
            if (_instance == null)
            {
                new state_ReceivePass();
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
        _owner.distanceFromBall = Vector3.Distance(_owner.ball.transform.position, _owner.transform.position);
        


        if (_owner.distanceFromBall < 2.5f)
        {
            _owner.receivingPass = false;
            //_owner.hasBall = true;
            _owner.stateMachine.ChangeState(state_ChaseBall.Instance);
            
            
            //_owner.stateMachine.ChangeState(state_Wait.Instance);
        }
    }
}