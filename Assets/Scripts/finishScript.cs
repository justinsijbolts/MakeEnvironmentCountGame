using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishScript : MonoBehaviour
{
    // Start is called before the first frame update
    pickupScript pickupScript;
    bool playerWon;
    void Start()
    {
        pickupScript = GameObject.Find("playerCapsule").GetComponent<pickupScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickupScript.pickupsPicked == pickupScript.maxPickups)
        {
            playerWon = true;
        }
    }
}
