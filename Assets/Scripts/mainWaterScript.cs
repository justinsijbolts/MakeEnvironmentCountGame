using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainWaterScript : MonoBehaviour
{
    characterControllerScr characterControllerScr;
    GameObject playerCapsule;
    bool currentlyInWater = false;

    // Start is called before the first frame update
    void Start()
    {
        playerCapsule = GameObject.Find("playerCapsule");
        characterControllerScr = playerCapsule.GetComponent<characterControllerScr>();
    }

    void CharControllerSpeed()
    {
        if(characterControllerScr.speed > 3 && currentlyInWater) {
            characterControllerScr.speed -= 0.2f * Time.deltaTime;
        }

        if(characterControllerScr.speed < 10 && !currentlyInWater) {
            characterControllerScr.speed += 1f * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Handles water movement
        transform.Translate(0, 0.25f * Time.deltaTime, 0);

        CharControllerSpeed();
    }

    void OnTriggerEnter(Collider other)
    {
        currentlyInWater = true;
    }

    void OnTriggerExit(Collider other)
    {
        currentlyInWater = false;
    }
}
