using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtmosAircraft : MonoBehaviour
{
    /* ---------------------------------------------------------------------------------------------- */
    /*                                         CLASS VARIABLES                                        */
    /* ---------------------------------------------------------------------------------------------- */
    /* ------------------------------------------ Rigidbody ----------------------------------------- */
    public Rigidbody rb;
    public float emptyMass;
    public float fuelWeight;
    public float initialFuelLoad = 1f;
    private float remainingFuel;
    /* -------------------------------------------- Wings ------------------------------------------- */
    public AtmosControlSurface[] elevons;
    public AtmosControlSurface[] alerion;
    public AtmosControlSurface[] rudders;
    public AtmosFixedWing[] fixedWings;
    /* ------------------------------------------- Forces ------------------------------------------- */
    private Vector3 appliedForce;
    private Vector3 thrustForce;
    private Vector3 liftForce;
    private Vector3 dragForce;
    private Vector3 gravityForce;
    /* --------------------------------------- Thruster Config -------------------------------------- */
    public float maxEngineThrust;
    public float maxABThrust;
    public float throttleRange = 1.0f;
    public float throttleABThreshold = 0.9f;
    public float startThrottle = 0f;
    private float throttle;

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

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Fixed Update is called once per physics frame
    void FixedUpdate()
    {

    }

    // Custom Methods
    // Debug Plane is called every FixedUpdate to show debug values
    void DebugPlane()
    {

    }

    // Deflect Control Surfaces is called every FixedUpdate and moves all ControlSurfaces
}
