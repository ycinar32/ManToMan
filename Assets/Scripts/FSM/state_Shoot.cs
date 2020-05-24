using UnityEngine;
using StateStuff;
using UnityEngine.AI;

public class state_Shoot : State<AI>
{
    private static state_Shoot _instance;

    private state_Shoot()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static state_Shoot Instance
    {
        get
        {
            if (_instance == null)
            {
                new state_Shoot();
            }

            return _instance;
        }
    }

    public override void EnterState(AI _owner)
    {
        // Debug.Log("Entering state_Wait State");
    }

    public override void ExitState(AI _owner)
    {
        // Debug.Log("Exiting state_Wait State");
    }

    public override void UpdateState(AI _owner)
    {
                _owner.hasBall = false;
                _owner.shootDirection = (GameObject.FindGameObjectWithTag("hoop").transform.position - _owner.transform.position + new Vector3(0f , 60f , 0f)).normalized;
                _owner.ball.GetComponent<Rigidbody>().AddForce(_owner.shootDirection * 4200f);
                _owner.ball.GetComponent<Ball>().ball_on_air = true;
                _owner.ball.GetComponent<Rigidbody>().useGravity = true;
                _owner.stateMachine.ChangeState(state_Wait.Instance);

    }
}