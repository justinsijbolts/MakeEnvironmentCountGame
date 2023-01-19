using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainWaterScript : MonoBehaviour
{
    characterControllerScr characterControllerScr;
    bool hasReachedWater;

    // Start is called before the first frame update
    void Start()
    {
        characterControllerScr = GameObject.Find("playerCapsule").GetComponent<characterControllerScr>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0.05f * Time.deltaTime, 0);
        
        if (transform.position.y > -101.07f && !hasReachedWater)
        {
            characterControllerScr.speed -= 1f;
            Debug.Log("Water has reached level surface");
            hasReachedWater = true;
        }

        if (transform.position.y > -101.5f && characterControllerScr.speed > 0)
        {
            characterControllerScr.speed -= 0.5f * Time.deltaTime;
        }
    }
}
