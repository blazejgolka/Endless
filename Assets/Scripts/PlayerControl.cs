using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [SerializeField]
    [Range(1, 10)]
    private float jumpPower;
    public float JumpPower => jumpPower;
    
    private Rigidbody2D mojRigidbody;
    private float mnoznikSkoku = 20f;
    private bool isGrounded = false;





    // Start is called before the first frame update
    void Start()
    {
        mojRigidbody = this.transform.GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        
    }




    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D inny)
    {
        if (inny.collider.tag.Equals("Ground"))
        {
            isGrounded = true;
        }
        
    }

    private void OnCollisionStay2D(Collision2D inny)
    {
        if (inny.collider.tag.Equals("Ground"))
        {
            isGrounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D inny)
    {
        if (inny.collider.tag.Equals("Ground"))
        {
            isGrounded = false;
        }

    }


    // Detects if the shift key was pressed
    void OnGUI()
    {
        GUILayout.Label("Press Enter To Start Game");

        if (Event.current.Equals(Event.KeyboardEvent("[enter]")))
        {
            //Application.LoadLevel(1);
            Debug.LogFormat("przycisk naciśnięty <color=yellow>{0}</color>", "ENTER" );
        }

        if (Event.current.Equals(Event.KeyboardEvent("return")))
        {
            Debug.LogFormat("przycisk naciśnięty <color=red> {0}</color>", "RETURN");
            
        }

        if (Event.current.Equals(Event.KeyboardEvent("space")) && isGrounded)
        {
            Debug.LogFormat("przycisk naciśnięty <color=green> {0}</color>", "SPACE");
            mojRigidbody.AddForce(Vector3.up * (jumpPower * mojRigidbody.mass * mojRigidbody.gravityScale * mnoznikSkoku));


        }
    }
}
