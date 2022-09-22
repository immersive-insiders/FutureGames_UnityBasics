using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterPush : MonoBehaviour
{
    [SerializeField] private float force;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if(rigidbody!= null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - gameObject.transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rigidbody.AddForceAtPosition(force * forceDirection, transform.position, ForceMode.Impulse);
        }
    }
}
