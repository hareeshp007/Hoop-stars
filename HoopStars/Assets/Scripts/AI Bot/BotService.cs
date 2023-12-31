
using UnityEngine;

namespace hoopStars.Bot
{
    public class BotService : MonoSingletonGeneric<BotService>
    {
        public Transform Bot1Position;
        public Transform Bot2Position;

        public Transform ScoreBall;
        public GameObject Bot1Prefab;
        public GameObject Bot2Prefab;
        [SerializeField]
        private GameObject bot1;
        [SerializeField]
        private GameObject bot2;

        private void Awake()
        {
            base.Awake();
            Initilization();
        }

        private void Initilization()
        {
            bot1 = GameObject.Instantiate(Bot1Prefab, Bot1Position);
            bot1.SetActive(false);
            bot2 = GameObject.Instantiate(Bot2Prefab, Bot2Position);
            bot2.SetActive(false);
        }

        public void SpawnOneBot()
        {
            bot1.SetActive(true); 
            bot2.GetComponent<Bot2>().SetScoreBall(ScoreBall);
        }
        public void SpwanTwoBot()
        {
            bot1.SetActive(true);
            bot2.GetComponent<Bot2>().SetScoreBall(ScoreBall);
            bot2.SetActive(true);
        }

        public void SetScoreBall(Transform transform)
        {
            ScoreBall = transform;
        }

        public void GameRestart()
        {
            changePos(bot1.transform, Bot1Position);
            bot1.GetComponent<Bot1>().StopAllCoroutines();
            bot1.SetActive(false); 
            changePos(bot2.transform, Bot2Position);
            bot2.GetComponent<Bot2>().StopAllCoroutines();
            bot2.SetActive(false);
        }

        private void changePos(Transform bot, Transform botPosition)
        {
            bot.transform.position = botPosition.position;
            bot.transform.rotation = botPosition.rotation;
            bot.transform.localScale = botPosition.localScale;
        }
    }

}
