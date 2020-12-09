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
    public List<AtmosControlSurface> elevons;
    public List<AtmosControlSurface> alerion;
    public List<AtmosControlSurface> rudders;
    public List<AtmosFixedWing> fixedWings;
    /* ------------------------------------------- Forces ------------------------------------------- */
    private Vector3 appliedForce;
    private Vector3 thrustForce;
    private Vector3 liftForce;
    private Vector3 dragForce;
    private Vector3 gravityForce;
    /* --------------------------------------- Thruster Config -------------------------------------- */
    public List<AtmosThruster> thrusters;
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
    void DeflectControlSurfaces()
    {

    }

    // Calculate Control Surfaces is called every FixedUpdate and adds lift vectors
    void CalculateLiftForAllSurfaces()
    {

    }

    // Calculate Control Surfaces is called every FixedUpdate and adds drag vectors
    void CalculateDragForAllSurfaces() {

    }

    // Calculate Drag is called every FixedUpdate and adds all drag for all non-CS/FW objects
    void CalculateDrag()
    {

    }

    // Calculate Thrust is called every FixedUpdate and adds all thrust from the engines
    void CalculateThrust() {

    }

    // Calculate Gravity is called every Fixed Update and adds the rigidbody's current mass
    void CalculateGravity() {

    }

    // Calculate Forces is called every fixed update and combines all force equations
    void CalculateForces() {
        
    }
}
