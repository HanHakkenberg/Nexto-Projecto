using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{

    public Cinemachine.CinemachineFreeLook Vcam { get { return GameObject.Find("Main Virtual Camera").GetComponent<Cinemachine.CinemachineFreeLook>(); } }
    public GameObject companionInstance;

    public bool followsCompanion;

    //references to baby and companion
    public GameObject baby;
    public GameObject companion;
    public GameObject dialogueTarget;

    public Transform camTarget;

    [Header("Groundpound Checks:")]
    public bool canFollowAgain = true;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        ToggleController(false);
    }

    public void ToggleController(bool _ForceOverride) {
        if (GameManager.gameManager.gameTimeout == true && _ForceOverride == false)
        {
            camTarget.position = Vector3.Lerp(camTarget.transform.position, dialogueTarget.transform.position + new Vector3(0, 0.7f, 0), 4f * Time.deltaTime);
            return;
        }

        if (Input.GetButtonDown("SwitchKey") || _ForceOverride == true)
        {
            if (!followsCompanion)
            {
                followsCompanion = true;
                baby.GetComponent<PlayerController>().ToggleController(false);
                companion = Instantiate(companionInstance, baby.transform.position, Quaternion.identity);
                companion = companion.transform.GetChild(0).GetChild(2).gameObject;
                camTarget.SetParent(companion.transform);

                Vcam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Orbits[0].m_Radius = 1f;
                Vcam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Orbits[1].m_Radius = 4f;
                Vcam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Orbits[2].m_Radius = 2f;
            }
            else
            {
                followsCompanion = false;
                baby.GetComponent<PlayerController>().ToggleController(true);
                camTarget.SetParent(baby.transform);
                Destroy(companion.transform.parent.gameObject);

                Vcam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Orbits[0].m_Radius = 2f;
                Vcam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Orbits[1].m_Radius = 4f;
                Vcam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Orbits[2].m_Radius = 2f;
            }
        }
        if (!followsCompanion)
        {
            camTarget.position = Vector3.Lerp(camTarget.transform.position, baby.transform.position, 4f*Time.deltaTime);

        }
        else if (followsCompanion)
        {
            camTarget.position = Vector3.Lerp(camTarget.transform.position, companion.transform.position, 1f*Time.deltaTime);

        }
    }

    public void SetFollowMode(int _ID) {
        if(_ID == 0)
            canFollowAgain = true;
        else if(_ID == 1)
            canFollowAgain = false;
    }
}
