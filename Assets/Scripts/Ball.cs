using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Ball : MonoBehaviour
{
    float bounce = 0.3f;
    int counter = 0;
    
    public bool ball_on_air = false;

void Update()
    {
        
        if (Team.Instance.teamHasBall)
        {
            
            if (Team.Instance.Player1.GetComponent<AI>().hasBall)
            {
                this.transform.position = Team.Instance.Player1.transform.position - new Vector3(+1f, bounce + 0.8f , 0);
            }
            else if(Team.Instance.Player2.GetComponent<AI>().hasBall)
            {
                this.transform.position = Team.Instance.Player2.transform.position - new Vector3(+1f, bounce + 0.8f, 0);
            }
            else if (Team.Instance.Player3.GetComponent<AI>().hasBall)
            {
                this.transform.position = Team.Instance.Player3.transform.position - new Vector3(+1f, bounce + 0.8f, 0);
            }
            else if (Team.Instance.Player4.GetComponent<AI>().hasBall)
            {
                this.transform.position = Team.Instance.Player4.transform.position - new Vector3(+1f, bounce + 0.8f, 0);
            }
            else if (Team.Instance.Player1.GetComponent<AI>().hasBall)
            {
                this.transform.position = Team.Instance.Player5.transform.position - new Vector3(+1f, bounce + 0.8f, 0);
            }
            counter++;
        }
        if (counter == 10)
        {
            bounce *= -1;
            counter = 0;
        }
    }
}

