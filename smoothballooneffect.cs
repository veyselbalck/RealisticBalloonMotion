using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ObjVelocityReader : MonoBehaviour
{
    Vector3 PrevPos;
    Vector3 NewPos;

    Vector3 PrevRot;
    Vector3 NewRot;

    public Vector3 ObjVelocity;
    public Vector3 ObjRotation;
    public float minimumclamp = -5;
    public float maximumclamp = 5;
    public float smoother = 0.01f;
    public float velocitydivisor = 100;
    // Start is called before the first frame update
    void Start()
    {
        PrevPos = transform.position;
        PrevRot = transform.localEulerAngles;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        NewPos = transform.position;  // each frame track the new position
        ObjVelocity = (NewPos - PrevPos) / Time.fixedDeltaTime;
        PrevPos = NewPos;  // update position for next frame calculation
        Debug.Log("ObjVlinear" + ObjVelocity);

        NewRot = transform.localEulerAngles;  // each frame track the new rotation
        ObjRotation = (NewRot - PrevRot) / Time.fixedDeltaTime;
        PrevRot = NewRot;  // update position for next frame calculation

        gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Mathf.Clamp(ObjVelocity.z / velocitydivisor, minimumclamp, maximumclamp), transform.rotation.eulerAngles.y, Mathf.Clamp(ObjVelocity.x / velocitydivisor, minimumclamp, maximumclamp)), smoother);
    }

    
}
