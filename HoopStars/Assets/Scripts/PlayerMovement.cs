using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Vector3 force;
    [SerializeField]
    private float forceValue;
    [SerializeField]
    private bool currentlyOnScoreBall;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        force.y = forceValue;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            force.x = -forceValue;
            rb.AddForce(force, ForceMode.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            force.x = forceValue;
            rb.AddForce(force, ForceMode.Impulse);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ScoreBall>() != null && !currentlyOnScoreBall)
        {
            currentlyOnScoreBall = true;
            Debug.Log("Score increased");
            OnTriggerExitAsync(other);
        }
    }
    private void OnTriggerExitAsync(Collider other)
    {
        currentlyOnScoreBall = false;
    }

}

