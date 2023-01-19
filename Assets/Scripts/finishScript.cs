using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class finishScript : MonoBehaviour
{
    // Start is called before the first frame update
    pickupScript pickupScript;
    bool playerWon;
    public bool playerLost;

    GameObject StatusEndGame;

    Text StatusHeader;
    Text StatusText;
    Button RestartButton;
    void Start()
    {
        pickupScript = GameObject.Find("playerCapsule").GetComponent<pickupScript>();
        StatusEndGame = GameObject.Find("StatusEndGame");
    }

    // Update is called once per frame
    void Update()
    {
        if (pickupScript.pickupsPicked == pickupScript.maxPickups)
        {
            playerWon = true;
        }

        if (playerWon && StatusEndGame.transform.localScale != new Vector3(1, 1, 1))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;


            StatusEndGame.transform.localScale = new Vector3(1, 1, 1);
            StatusHeader = GameObject.Find("StatusHeader").GetComponent<Text>();
            StatusText = GameObject.Find("StatusText").GetComponent<Text>();
            StatusHeader.text = "GOOD JOB!";

            StatusText.text = "You've removed all the trash from this town!";

            RestartButton = GameObject.Find("RestartBtn").GetComponent<Button>();
            RestartButton.onClick.AddListener(RestartGame);
        }

        if (playerLost && StatusEndGame.transform.localScale != new Vector3(1,1,1)) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            StatusEndGame.transform.localScale = new Vector3(1, 1, 1);
            StatusHeader = GameObject.Find("StatusHeader").GetComponent<Text>();
            StatusText = GameObject.Find("StatusText").GetComponent<Text>();
            StatusHeader.text = "GAME OVER";

            StatusText.text = "You've run out of oxygen! The world has been destroyed :(";

            RestartButton = GameObject.Find("RestartBtn").GetComponent<Button>();
            RestartButton.onClick.AddListener(RestartGame);
        }
    }

    void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
