using UnityEngine;

public class Dialogo : MonoBehaviour
{
    public Sprite profile;           
    public string[] speechTxt;       
    public string actorName;         

    public LayerMask playerLayer;
    [SerializeField]
    public float radius; 

    private DialogoControl dc;
    bool onRadius;
    private bool isDialogueActive = false;


    private void Start()
    {
        dc = FindObjectOfType<DialogoControl>();
    }
    private void FixedUpdate()
    {

        Interact();
    }

    public void Interact()
    {
        
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
        

        if (hit != null)
        {
           onRadius = true;

        }
        else
        {
            onRadius = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onRadius && !dc.dialogueObj.activeSelf)
        {
            dc.Speech(profile, speechTxt, actorName); 
        }

        if (Input.GetKeyDown(KeyCode.E) && dc.dialogueObj.activeSelf)
        {
            dc.SkipToNextSentence();
        }

        if (Input.GetKeyDown(KeyCode.Space) && dc.dialogueObj.activeSelf)
        {
            dc.NextSentence(); 
        }
    }



    private void OnDrawGizmosSelected()
    {
        
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}




