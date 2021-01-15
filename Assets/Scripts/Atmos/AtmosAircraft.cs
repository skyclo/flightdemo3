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
    public GameObject fuselage;
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
        rb.mass = emptyMass + (fuelWeight * initialFuelLoad);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Fixed Update is called once per physics frame
    void FixedUpdate()
    {
        Thrust();
        Gravity();
        Drag();
        DeflectControlSurfaces();
        SurfaceLiftAndDrag();

        DebugPlane();
    }

    // Custom Methods
    // Debug Plane is called every FixedUpdate to show debug values
    void DebugPlane()
    {
        Debug.DrawRay(fuselage.transform.position, 0.001f*-9.81f*rb.mass*Vector3.up, Color.yellow);

        for (int i = 0; i < thrusters.Count; i++) {
            AtmosThrusterDebug thrusterDebug = thrusters[i].GetDebugData();
            Debug.DrawRay(thrusterDebug.pos, 0.001f*(thrusterDebug.thrustForce), Color.red);
            if (thrusterDebug.throttle > thrusterDebug.throttleABThreshold)
            {
                Debug.Log(((thrusterDebug.maxDryThrust) + ((thrusterDebug.maxWetThrust - thrusterDebug.maxDryThrust) * ((thrusterDebug.throttle - thrusterDebug.throttleABThreshold) * 10))));
            }
            else
            {
                Debug.Log(thrusterDebug.maxDryThrust * (thrusterDebug.throttle /  thrusterDebug.throttleABThreshold));
            }
            
        }

        for (int i = 0; i < fixedWings.Count; i++) {
            AtmosFixedWingDebugData fwDebug = fixedWings[i].GetDebugData();
            Debug.DrawRay(fwDebug.pos, 0.001f*(fwDebug.lv), Color.blue);
            Debug.DrawRay(fwDebug.pos, 0.001f*(fwDebug.dv), Color.red);
        }
    }

    // Deflect Control Surfaces is called every FixedUpdate and moves all ControlSurfaces
    void DeflectControlSurfaces()
    {   

    }

    // Surface Lift and Drag is called every FixedUpdate and adds lift/drag vectors for all surfaces
    void SurfaceLiftAndDrag()
    {
        for (int i = 0; i < fixedWings.Count; i++) {
            fixedWings[i].ApplyForce();
        }
    }

    // Drag is called every FixedUpdate and adds all drag for all non-CS/FW objects
    void Drag()
    {

    }

    // Thrust is called every FixedUpdate and adds all thrust from the engines
    void Thrust()
    {
        for (int i = 0; i < thrusters.Count; i++) {
            thrusters[i].ApplyForce();
        }
    }

    // Gravity is called every Fixed Update and adds the rigidbody's current mass
    void Gravity()
    {
        rb.AddForceAtPosition(-9.81f*rb.mass*Vector3.up, fuselage.transform.position);
    }
}
