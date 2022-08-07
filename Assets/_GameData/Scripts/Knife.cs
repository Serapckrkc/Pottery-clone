
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Knife : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float hitDamage;
    [SerializeField] private Wood wood;

    [SerializeField] private ParticleSystem woodFx;

    private ParticleSystem.EmissionModule woodFxEmission;
    
    private Rigidbody knifeRb;
    private Vector3 movementVector;
    private bool isMoving = false;

    private void Start()
    {
        knifeRb = GetComponent<Rigidbody>();
        woodFxEmission = woodFx.emission;
    }

    private void Update()
    {
        isMoving = Input.GetMouseButton(0);

        if (isMoving)
        {
            movementVector = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f) * movementSpeed * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            knifeRb.position += movementVector; 
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        woodFxEmission.enabled = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        Colli colli = collision.collider.GetComponent<Colli>();
        if (colli != null)
        {
            //hit Collider:
            woodFxEmission.enabled = true;
            woodFx.transform.position = collision.contacts[0].point;
            colli.HitCollider(hitDamage);
            wood.Hit(colli.index, hitDamage);
        }
    }
}
