using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject UIElements;
    [SerializeField] Text dialogueTxt;
    [SerializeField] string[] NPCDialogue;
    [SerializeField] Text btnText;
    
    NPCDialogue NPCDialogueScript;
    int dialogueIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        NPCDialogueScript = other.gameObject.GetComponent<NPCDialogue>();
        if (NPCDialogueScript)
        {
            UIElements.SetActive(true);
            NPCDialogue = NPCDialogueScript.data.dialogueLines;
            ShowNextDialogueLine();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        NPCDialogueScript = other.gameObject.GetComponent<NPCDialogue>();
        if (NPCDialogueScript)
        {
            UIElements.SetActive(false);
            dialogueIndex = 0;
        }
    }

    public void ShowNextDialogueLine()
    {
        if(btnText.text == "Cerrar")
        {
            UIElements.SetActive(false);
        }

        if (dialogueIndex < NPCDialogue.Length)
        {
            btnText.text = "Siguiente";
            dialogueTxt.text = NPCDialogue[dialogueIndex];
            dialogueIndex++;

            if(dialogueIndex == NPCDialogue.Length)
            {
                btnText.text = "Cerrar";
            }
        }
        
        
    }
}
