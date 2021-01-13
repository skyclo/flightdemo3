using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtmosFixedWing : MonoBehaviour
{

    /* ---------------------------------------------------------------------------------------------- */
    /*                                         CLASS VARIABLES                                        */
    /* ---------------------------------------------------------------------------------------------- */
    /* ------------------------------------------ Rigidbody ----------------------------------------- */
    public Rigidbody rb;
    /* --------------------------------------- Wing Properties -------------------------------------- */
    public float wingArea;
    public AnimationCurve liftCurve = new AnimationCurve(
        new Keyframe(0f, 0f), 
        new Keyframe(35f, 1.9f),
        new Keyframe(45f, 0f),
        new Keyframe(50f, 0.5f),
        new Keyframe(90f, 0f),
        new Keyframe(130f, -0.5f),
        new Keyframe(135f, 0f),
        new Keyframe(145f, -1.9f),
        new Keyframe(180f, 0f)
    );
    public AnimationCurve dragCurve = new AnimationCurve(
        new Keyframe(0f, 0.001f),
        new Keyframe(40f, 1.7f),
        new Keyframe(180f, 0.01f)
    ); 
    /* ---------------------------------- Lift And Drag Properties ---------------------------------- */
    private Vector3 localVelocity;
    private float angleOfAttack;

    private Vector3 liftVector;
    private float liftForce = 0f;
    private float liftCoefficient = 0f;
    private Vector3 liftDirection;

    private Vector3 dragVector;
    private float dragForce = 0f;
    private float dragCoefficient = 0f;
    private Vector3 dragDirection;
    

    /* ---------------------------------------------------------------------------------------------- */
    /*                                             METHODS                                            */
    /* ---------------------------------------------------------------------------------------------- */
    // Start is called before the first frame update
    void Start()
    {
        if (wingArea == 0f) {
            wingArea = transform.localScale.x * transform.localScale.z * 0.5f;
        }
    }

    // Awake is called upon rigidbody physics activation
    void Awake() {
        rb = GetComponentInParent<Rigidbody>();
    }

    // Apply Force is called every FixedUpdate
    public void ApplyForce()
    {
        localVelocity = transform.InverseTransformDirection(rb.GetPointVelocity(rb.transform.position));
        localVelocity.x = 0f;

        angleOfAttack = Vector3.Angle(Vector3.forward, localVelocity.normalized);

        liftCoefficient = liftCurve.Evaluate(angleOfAttack);
        dragCoefficient = dragCurve.Evaluate(angleOfAttack);

        liftForce = liftCoefficient * AtmosWorldSettings.airDensity * localVelocity.sqrMagnitude * wingArea * 0.5f * -Mathf.Sign(localVelocity.normalized.y);
        liftDirection = transform.up;
        liftVector = liftForce * liftDirection;

        dragForce = dragCoefficient * AtmosWorldSettings.airDensity * localVelocity.sqrMagnitude * wingArea * 0.5f;
        dragDirection = -rb.velocity.normalized;
        dragVector = dragForce * dragDirection;
    }
    
    public AtmosFixedWingDebugData GetDebugData()
    {
        AtmosFixedWingDebugData fwDebug = new AtmosFixedWingDebugData();
        fwDebug.aoa = angleOfAttack;
        fwDebug.cL = liftCoefficient;
        fwDebug.cD = dragCoefficient;
        fwDebug.lf = liftForce;
        fwDebug.ld  = liftDirection;
        fwDebug.lv = liftVector;
        fwDebug.df = dragForce;
        fwDebug.dd = dragDirection;
        fwDebug.dv = dragVector;
        fwDebug.pos = transform.position;
        return fwDebug;
    }
}

public class AtmosFixedWingDebugData {
    public float aoa;
    public float cL;
    public float cD;
    public float lf;
    public Vector3 ld;
    public Vector3 lv;
    public float df;
    public Vector3 dd;
    public Vector3 dv;
    public Vector3 pos;
}
