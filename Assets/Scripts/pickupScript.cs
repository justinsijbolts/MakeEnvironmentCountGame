using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupScript : MonoBehaviour
{
    public float pickupsPicked;
    GameObject PickupBar;
    public float maxPickups;
    bool pickupsCounted;

    GameObject Water;

    Camera Camera;


    GameObject OxygenBar;

    finishScript finishScript;

    void Start() {
        PickupBar = GameObject.Find("PP_ANCHOR");
        OxygenBar = GameObject.Find("OX_ANCHOR");
        Camera = Camera.main;
        Water = GameObject.Find("Water");

        foreach (GameObject pickup in GameObject.FindGameObjectsWithTag("Collectable"))
        {
            maxPickups++;
        }
    }

    void Update() {
        // camera has a collider, if the "Water" gameobject is hit, then the player has lost
        if (Camera.main.GetComponent<BoxCollider>().bounds.Intersects(Water.GetComponent<BoxCollider>().bounds))
        {
            if(OxygenBar.transform.localScale.x < 1) {
                OxygenBar.transform.localScale = new Vector3(OxygenBar.transform.localScale.x + 0.1f * Time.deltaTime, 1, 1);
                GameObject.Find("waterEffect").transform.localScale = new Vector3(1, 1, 1);
            } else {
                finishScript = GameObject.Find("playerCapsule").GetComponent<finishScript>();
                finishScript.playerLost = true;
            }
        } else {
            GameObject.Find("waterEffect").transform.localScale = new Vector3(0, 0, 0);
            if (OxygenBar.transform.localScale.x > 0)
            {
                OxygenBar.transform.localScale = new Vector3(OxygenBar.transform.localScale.x - 0.1f * Time.deltaTime, 1, 1);
            }
        }
    }

    // Start is called before the first frame update
    void ProgressBarUpdate() {
        // 0 Pickups picked scale = 0. All pickups picked scale = 1
        //(6 / 12) x 100 = 50

        float scale = pickupsPicked / maxPickups;
        PickupBar.transform.localScale = new Vector3(scale, 1, 1);
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Collectable")
        {
            pickupsCounted = true;
            pickupsPicked++;
            Destroy(col.gameObject);
            ProgressBarUpdate();
        }
    }
}
