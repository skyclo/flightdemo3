using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtmosThruster : MonoBehaviour
{

    /* ---------------------------------------------------------------------------------------------- */
    /*                                         CLASS VARIABLES                                        */
    /* ---------------------------------------------------------------------------------------------- */
    /* ------------------------------------------ Rigidbody ----------------------------------------- */
    public Rigidbody rb;
    /* --------------------------------------- Thruster Config -------------------------------------- */
    public float maxDryThrust;
    public float maxWetThrust;
    public float throttleRange = 1.0f;
    public float throttleABThreshold = 0.9f;
    public float startThrottle = 0f;
    public float startSpeed = 0f;
    public float throttle;
    /* ------------------------------------------- Forces ------------------------------------------- */
    private Vector3 thrustForce;

    /* ---------------------------------------------------------------------------------------------- */
    /*                                             METHODS                                            */
    /* ---------------------------------------------------------------------------------------------- */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Awake is called when the Rigidbody wakes up to physics
    void Awake()
    {
        rb = GetComponentInParent<Rigidbody>();
        if (startThrottle > 0f) {
            // Ignore Initial Engine Spool Time
            throttle = startThrottle;
        }
        if (startSpeed > 0f) {
            rb.velocity = new Vector3(0f, 0f, startSpeed);
        }
    }

    // Apply Force is called every FixedUpdate
    public void ApplyForce()
    {
        // Check if AB mode or not
        if (throttle > throttleABThreshold) {
            rb.AddForceAtPosition(maxWetThrust * (throttle - throttleABThreshold) * rb.transform.forward, transform.position);
        } else {
            rb.AddForceAtPosition(maxDryThrust * throttle * rb.transform.forward, transform.position);
        }
    }
}
