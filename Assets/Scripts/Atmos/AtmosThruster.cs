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
        if (startThrottle > 0f)
        {
            // Ignore Initial Engine Spool Time
            throttle = startThrottle;
        }
        if (startSpeed > 0f)
        {
            rb.velocity = new Vector3(0f, 0f, startSpeed);
        }
    }

    // Apply Force is called every FixedUpdate
    public void ApplyForce()
    {
        // Check if AB mode or not
        if (throttle > throttleABThreshold)
        {
            thrustForce = ((maxDryThrust) + ((maxWetThrust - maxDryThrust) * ((throttle - throttleABThreshold) * 10))) * rb.transform.forward;
        }
        else
        {
            thrustForce = maxDryThrust * (throttle /  throttleABThreshold) * rb.transform.forward;
        }
        rb.AddForceAtPosition(thrustForce, transform.position);
    }

    public AtmosThrusterDebug GetDebugData()
    {
        AtmosThrusterDebug thrusterDebug = new AtmosThrusterDebug();
        thrusterDebug.maxDryThrust = maxDryThrust;
        thrusterDebug.maxWetThrust = maxWetThrust;
        thrusterDebug.throttleRange = throttleRange;
        thrusterDebug.throttleABThreshold = throttleABThreshold;
        thrusterDebug.startThrottle = startThrottle;
        thrusterDebug.throttle = throttle;
        thrusterDebug.thrustForce = thrustForce;
        thrusterDebug.pos = transform.position;
        return thrusterDebug;
    }
}

public class AtmosThrusterDebug
{
    public float maxDryThrust;
    public float maxWetThrust;
    public float throttleRange;
    public float throttleABThreshold;
    public float startThrottle;
    public float startSpeed;
    public float throttle;
    public Vector3 thrustForce;
    public Vector3 pos;
}
