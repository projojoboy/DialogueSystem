using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    bool colliding = false;
    GameObject collObject;
    DialogueManager dm;

    private void Start()
    {
        dm = GameObject.Find("DialogueManagerGM").GetComponent<DialogueManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && colliding)
        {
            collObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "NPC")
        {
            coll.GetComponent<DialogueTrigger>().pressText.SetActive(true);
            colliding = true;
            collObject = coll.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "NPC")
        {
            coll.GetComponent<DialogueTrigger>().pressText.SetActive(false);
            colliding = false;
            dm.EndDialogue();
        }
    }
}
