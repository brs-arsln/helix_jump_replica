using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private Transform player;

    [SerializeField] GameObject[] childRings;
    private float radius = 100;
    private float force = 500;


    //private void Start()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player").transform;
    //}

    //public void ExplodeRings()
    //{
    //    for (int i = 0; i < childRings.Length; i++)
    //    {
    //        Rigidbody childRingRb = childRings[i].GetComponent<Rigidbody>();
    //        childRingRb.isKinematic = false;
    //        childRingRb.useGravity = true;

    //        childRingRb.AddExplosionForce(force, transform.position, radius);

    //        childRings[i].GetComponent<MeshCollider>().enabled = false;
    //        childRings[i].transform.parent = null;
    //        Destroy(childRings[i].gameObject, 2f);
    //        Destroy(gameObject, 5f);
    //    }
    //    enabled = false;
    //}

    public void ExplodeRings()
    {
        //Rigidbody[] childRingRbs = new Rigidbody[childRings.Length];
        //MeshCollider[] childRingColliders = new MeshCollider[childRings.Length];

        //for (int i = 0; i < childRings.Length; i++)
        //{
        //    childRingRbs[i] = childRings[i].GetComponent<Rigidbody>();
        //    childRingRbs[i].isKinematic = false;
        //    childRingRbs[i].useGravity = true;

        //    childRingRbs[i].AddExplosionForce(force, transform.position, radius);

        //    childRingColliders[i] = childRings[i].GetComponent<MeshCollider>();
        //    childRingColliders[i].enabled = false;

        //    childRings[i].transform.parent = null;
        //    StartCoroutine(DestroyAfterDelay(childRings[i].gameObject, 2f));
        //}

        foreach (GameObject childRing in childRings)
        {
            Rigidbody childRingRb = childRing.GetComponent<Rigidbody>();
            MeshCollider childRingCollider = childRing.GetComponent<MeshCollider>();

            childRingRb.isKinematic = false;
            childRingRb.useGravity = true;
            childRingRb.AddExplosionForce(force, transform.position, radius);

            childRingCollider.enabled = false;

            childRing.transform.parent = null;
            StartCoroutine(DestroyAfterDelay(childRing, 2f));
        }

        StartCoroutine(DestroyAfterDelay(gameObject, 5f));
        enabled = false;
    }

    IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
}