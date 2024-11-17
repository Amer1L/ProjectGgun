using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcKillPhysTest : MonoBehaviour
{
    [SerializeField] private GameObject _collider;
    [SerializeField] private Rigidbody[] _ragdollRigidbody;
    [SerializeField] private float _velocityToKill;

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if(rb != null)
        {
            if(rb.velocity.sqrMagnitude >= _velocityToKill)
            {
                RagdollKill();
                Destroy(_collider);
            }
        }
    }

    private void RagdollKill()
    {
        for(int i = 0; i < _ragdollRigidbody.Length; i++)
        {
            _ragdollRigidbody[i].isKinematic = false;
        }
    }
}
