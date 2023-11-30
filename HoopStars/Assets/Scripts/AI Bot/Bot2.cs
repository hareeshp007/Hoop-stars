
using UnityEngine;

namespace hoopStars.Bot
{
    public class Bot2 : MonoBehaviour
    {
        public Transform ScoreBall;
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

        // Start is called before the first frame update
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
            timer += Time.deltaTime;

        }
        

        private void applyForce()
        {
            Vector3 direction = ScoreBall.position - transform.position;
            direction.Normalize();
            int resultValue = (direction.x < 0) ? -1 : 1;
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
                
                rb.AddForce(force, ForceMode.Impulse);
            }

        }

        public void SetScoreBall(Transform scoreBall)
        {
            ScoreBall = scoreBall;
        }
    }
}
