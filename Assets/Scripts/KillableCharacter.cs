using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableCharacter : MonoBehaviour {

    public Character character;
    public GameObject blood;

    void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.name == "Knife")
        {
            die(collision.ClosestPoint(transform.position));
        }
    }

    void die(Vector3 hitspot)
    {
        BranchManager.Instance.KillCharacter(character);
        GameObject bloodInstance = Instantiate(blood, hitspot, Quaternion.Euler(new Vector3(0,0,90)));
        Destroy(bloodInstance, 2f);
    }

}

public enum Character
{
    Duncan,
    LadyMacbeth
}