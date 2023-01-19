using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupScript : MonoBehaviour
{
    public float pickupsPicked;
    GameObject PickupBar;
    private float maxPickups;
    bool pickupsCounted;

    void Start() {
        PickupBar = GameObject.Find("PP_ANCHOR");

        foreach (GameObject pickup in GameObject.FindGameObjectsWithTag("Collectable"))
        {
            maxPickups++;
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
