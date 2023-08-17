using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobinActAllower : MonoBehaviour
{
    public GameObject robin;

    public void canAct()
    {
        robin.GetComponent<Robin>().currState = robinState.canAct;
    }

    public void cantAct()
    {
        robin.GetComponent<Robin>().currState = robinState.cantAct;
    }
}
