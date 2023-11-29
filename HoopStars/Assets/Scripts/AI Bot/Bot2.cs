using System.Collections;
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

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            force.y = forceValue;
            StartCoroutine(Tick());
        }
        IEnumerator Tick()
        {
            applyForce();
            float sec = Random.Range(nextTickSec, 1);
            yield return new WaitForSeconds(sec);
            StartCoroutine(Tick());
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
