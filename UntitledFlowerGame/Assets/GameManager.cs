using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject ending;

    static public bool LoveMissionComplete = false;
    static public bool SadMissionComplete = false;
    static public bool PartyMissionComplete = false;
    // Update is called once per frame
    void Update()
    {
        if (LoveMissionComplete && SadMissionComplete && PartyMissionComplete)
        {
            inventory.SetActive(false);
            ending.SetActive(true);
        }
    }
}
