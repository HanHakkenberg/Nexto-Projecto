using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{

    public Cinemachine.CinemachineFreeLook Vcam { get { return GameObject.Find("Main Virtual Camera").GetComponent<Cinemachine.CinemachineFreeLook>(); } }
    public GameObject companionInstance;

    public bool FollowsCompanion;

    //references to baby and companion
    public GameObject baby;
    public GameObject companion;

    public Transform camTarget;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if(GameManager.gameManager.gameTimeout == true) return;

        if (Input.GetButtonDown("SwitchKey"))
        {
            if (!FollowsCompanion)
            {
                FollowsCompanion = true;
                baby.GetComponent<PlayerController>().ToggleController(false);
                companion = Instantiate(companionInstance, baby.transform.position, Quaternion.identity);
                companion = companion.transform.GetChild(0).gameObject;
                camTarget.SetParent(companion.transform);

                Vcam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Orbits[0].m_Radius = 2f;
                Vcam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Orbits[1].m_Radius = 3f;
                Vcam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Orbits[2].m_Radius = 2f;
            }
            else
            {
                FollowsCompanion = false;
                baby.GetComponent<PlayerController>().ToggleController(true);
                camTarget.SetParent(baby.transform);
                Destroy(companion.transform.parent.gameObject);

                Vcam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Orbits[0].m_Radius = 4f;
                Vcam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Orbits[1].m_Radius = 6f;
                Vcam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Orbits[2].m_Radius = 4f;
            }
        }
        if (!FollowsCompanion)
        {
            camTarget.position = Vector3.Lerp(camTarget.transform.position, baby.transform.position + new Vector3(0, 0.7f, 0), 4f*Time.deltaTime);

        }
        else if (FollowsCompanion)
        {
            camTarget.position = Vector3.Lerp(camTarget.transform.position, companion.transform.position, 1f*Time.deltaTime);

        }
    }
}
