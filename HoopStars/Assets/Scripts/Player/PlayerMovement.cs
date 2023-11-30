
using hoopStars.Score;
using hoopStars.sound;
using hoopStars.UI;
using UnityEngine;


namespace hoopStars.player 
{
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

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            force.y = forceValue*2;
            UIManager.Instance.SetPlayer(this);
        }

        void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                forceTowardsLeft();
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                forceTowardsRight();
            }
        }

        public void forceTowardsLeft()
        {
            SoundManager.Instance.Play(Sounds.ButtonClick);
            if (force.x > 0)
            {
                force.x = -forceValue * 2;
                rb.AddForce(force, ForceMode.Impulse);
            }
            else
            {
                force.x = -forceValue;
                rb.AddForce(force, ForceMode.Impulse);
            }
        }

        public void forceTowardsRight()
        {
            SoundManager.Instance.Play(Sounds.ButtonClick);
            if (force.x < 0)
            {
                force.x = forceValue * 2;
                rb.AddForce(force, ForceMode.Impulse);
            }
            else
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
}



