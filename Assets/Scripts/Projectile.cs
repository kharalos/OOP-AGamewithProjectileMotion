using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // launch variables
    [SerializeField] private Transform TargetObject;
    [Range(15.0f, 75.0f)] public float LaunchAngle;
    // state
    private bool launched;
    // cache
    private Rigidbody rigid;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", gameObject.GetComponent<MeshRenderer>().material.color);
        gameObject.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        rigid = GetComponent<Rigidbody>();
        launched = false;
    }

    // launches the object towards the TargetObject with a given LaunchAngle
    void Launch()
    {
        // think of it as top-down view of vectors: 
        //   we don't care about the y-component(height) of the initial and target position.
        Vector3 projectileXZPos = new Vector3(transform.position.x, 0.0f, transform.position.z);
        Vector3 targetXZPos = new Vector3(TargetObject.position.x, 0.0f, TargetObject.position.z);

        // rotate the object to face the target
        transform.LookAt(targetXZPos);

        // shorthands for the formula
        float R = Vector3.Distance(projectileXZPos, targetXZPos);
        float G = Physics.gravity.y;
        float tanAlpha = Mathf.Tan(LaunchAngle * Mathf.Deg2Rad);
        float H = TargetObject.position.y - transform.position.y;

        // calculate the local space components of the velocity 
        // required to land the projectile on the target object 
        float Vz = Mathf.Sqrt(G * R * R / (2.0f * (H - R * tanAlpha)));
        float Vy = tanAlpha * Vz;

        // create the velocity vector in local space and get it in global space
        Vector3 localVelocity = new Vector3(0f, Vy, Vz);
        Vector3 globalVelocity = transform.TransformDirection(localVelocity);

        // launch the object by setting its initial velocity and flipping its state
        rigid.velocity = globalVelocity;
        launched = true;
        gameObject.GetComponent<AudioSource>().Play();
        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        LaunchAngle = FindObjectOfType<GameManager>().angleSlider.value;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!launched)
            {
                Launch();
            }
        }
    }
}
