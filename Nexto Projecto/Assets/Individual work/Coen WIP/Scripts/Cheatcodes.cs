using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheatcodes : MonoBehaviour {

    [Header("Settings:")]
    public List<Transform> teleportLocations;

    GameObject player;

    private void Awake() {
        player = GameManager.gameManager.player.gameObject;
    }

    void Update () {
        Teleport();
	}

    void Teleport() {
        if(Input.GetKeyDown(KeyCode.Alpha0)) {
            player.transform.position = teleportLocations[0].transform.position;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            player.transform.position = teleportLocations[1].transform.position;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            player.transform.position = teleportLocations[2].transform.position;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            player.transform.position = teleportLocations[3].transform.position;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            player.transform.position = teleportLocations[4].transform.position;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            player.transform.position = teleportLocations[5].transform.position;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha6)) {
            PlayerController _P = player.GetComponent<PlayerController>();
            Debug.Log("You have UNLOCKED every ability.");
            _P.jump = true;
            _P.doubleJump = true;
            _P.dash = true;
            _P.smash = true;
            _P.chargeJump = true;
            _P.canSummonCompanion = true;
            return;
        }
    }
}
