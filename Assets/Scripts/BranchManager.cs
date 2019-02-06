using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchManager : MonoBehaviour {

    public static BranchManager Instance;

    public Dialogue[] LadyMacbethDeath;
    public GameObject DuncanDeathTrigger;
    public GameObject DefaultTrigger;

    bool LadyMacbethDead = false;
    bool DuncanDead = false;

    public GameObject LadyMacbeth;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void KillCharacter(Character character)
    {
        if (character == Character.Duncan)
            KillDuncan();
        else
            KillLadyMacbeth();
    }

    void KillDuncan()
    {
        if (!DuncanDead)
        {
            if (!LadyMacbethDead)
                DuncanDeathTrigger.GetComponent<Collider>().enabled = true;

            SoundManager.Instance.PlayClip(SoundManager.Instance.DeathClip);
            DefaultTrigger.GetComponent<Collider>().enabled = false;
            DuncanDead = true;
        }
    }

    void KillLadyMacbeth()
    {
        if (!LadyMacbethDead)
        {
            DialogueManager.Instance.StartDialogues(LadyMacbethDeath);
            DefaultTrigger.GetComponent<Collider>().enabled = false;
            DuncanDeathTrigger.GetComponent<Collider>().enabled = false;

            SoundManager.Instance.PlayClip(SoundManager.Instance.DeathClip);
            LadyMacbeth.GetComponent<Rigidbody>().AddForce(-LadyMacbeth.transform.forward*5000);
            LadyMacbethDead = true;
        }
    }

}
