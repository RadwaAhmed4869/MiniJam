using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBoxScript : MonoBehaviour
{
    [SerializeField]
    private float forceMagnitude;
    private Animator character_animator;
    [SerializeField] private AudioSource audio;

    private string PUSH_PARAM = "push";
    private string BOX_TAG = "PuuzzelBox";
    private string PUSH_BOX_TAG = "pushBox";
    private bool isBox;
    private float rotateY;

    private void Start()
    {
        character_animator = GetComponent<Animator>();
    }

    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{

    //        Rigidbody rigidbody = hit.collider.attachedRigidbody;
    //        if (rigidbody != null && hit.collider.CompareTag(BOX_TAG))
    //        {
    //            rigidbody.isKinematic = false;
    //            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
    //            forceDirection.y = 0.0f;
    //            forceDirection.Normalize();

    //            rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
    //        }
    //        else
    //        {
    //            character_animator.SetBool(PUSH_PARAM, false);
    //            //rigidbody.isKinematic = true;

    //        }
    //}


    private void OnTriggerStay(Collider other)
    {
        Rigidbody rigidbody = other.attachedRigidbody;
        if (other.CompareTag(PUSH_BOX_TAG) && rigidbody!=null)
        {
            rigidbody.isKinematic = false;
            Vector3 forceDirection = other.gameObject.transform.position - transform.position;
            forceDirection.y = 0.0f;
            forceDirection.Normalize();

            //rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
            audio.volume = 0.1f;
            if (!audio.isPlaying)
            {
                audio.PlayOneShot(audio.clip);
            }
           
            character_animator.SetBool(PUSH_PARAM, true);

        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        Rigidbody rigidbody = other.attachedRigidbody;
        if (other.CompareTag(PUSH_BOX_TAG))
        {
            rigidbody.isKinematic = true;
            character_animator.SetBool(PUSH_PARAM, false);

        }
    }
}
