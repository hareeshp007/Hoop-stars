using System.Collections;
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

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            StartCoroutine(Tick());
            force.y = forceValue;
        }

        // Update is called once per frame
        IEnumerator Tick()
        {
            applyForce();
            float sec = Random.Range(nextTickSec, 1);
            yield return new WaitForSeconds(sec);
            StartCoroutine(Tick());
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
