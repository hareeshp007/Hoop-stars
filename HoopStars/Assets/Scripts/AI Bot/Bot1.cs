
using UnityEngine;

namespace hoopStars.Bot
{
    public class Bot1 : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody rb;
        [SerializeField]
        private float nextTickSec;
        [SerializeField]
        private Vector3 force;
        [SerializeField]
        private float forceValue;
        [SerializeField]
        private float nextTimer;
        [SerializeField]
        private float timer;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            force.y = forceValue;
            nextTimer = Random.Range(nextTickSec, 1);
        }
        private void Update()
        {
            if (timer > nextTimer)
            {
                nextTimer = Random.Range(nextTickSec, 1);
                timer = 0;
                applyForce();
            }
            timer+=Time.deltaTime;
            
        }

        private void applyForce()
        {
            int randomValue = Random.Range(0, 2);
            int resultValue = (randomValue == 0) ? -1 : 1;
            if (force.x > 0 && resultValue == -1)
            {
                force.x = -forceValue * 2;
                rb.AddForce(force, ForceMode.Impulse);
            }
            else if (force.x < 0 && resultValue == 1)
            {
                force.x = forceValue * 2;
                rb.AddForce(force, ForceMode.Impulse);
            }
            else
            {
                force.x = forceValue * resultValue;
                force.y = forceValue;
                rb.AddForce(force, ForceMode.Impulse);
            }
        }
        
    }
}
