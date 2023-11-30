
using hoopStars.Bot;
using hoopStars.player;
using hoopStars.UI;
using UnityEngine;

namespace hoopStars.Score
{
    public class ScoreBall : MonoBehaviour
    {
        public SphereCollider SphereCollider;

        [SerializeField]
        private int playerScore=0;
        [SerializeField]
        private int Bot1Score=0;
        [SerializeField]
        private int Bot2Score = 0;


        private void OnEnable()
        {
            if(BotService.Instance!=null)
            {
                BotService.Instance.SetScoreBall(this.transform);
            }
        }
        

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.GetComponent<PlayerMovement>() != null)
            {
                UIManager.Instance.SetPlayerScore(++playerScore);
            }
            else if(other.gameObject.GetComponent<Bot1>() != null)
            {
                UIManager.Instance.SetBot1Score(++Bot1Score);
            }
            else if (other.gameObject.GetComponent<Bot2>() != null)
            {
                UIManager.Instance.SetBot2Score(++Bot2Score);
            }
        }
    }
}
