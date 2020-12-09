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

    public Vector3 liftVector;
    public float liftForce = 0f;
    private float liftCoefficient = 0f;
    public Vector3 liftDirection;

    public Vector3 dragVector;
    public float dragForce = 0f;
    private float dragCoefficient = 0f;
    public Vector3 dragDirection;
    

    /* ---------------------------------------------------------------------------------------------- */
    /*                                             METHODS                                            */
    /* ---------------------------------------------------------------------------------------------- */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Awake is called upon rigidbody physics activation
    void Awake() {
        rb = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Fixed Update is called once per physics frame
    void FixedUpdate()
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
}
