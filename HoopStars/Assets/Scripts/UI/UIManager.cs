using hoopStars.Bot;
using hoopStars.player;
using hoopStars.sound;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace hoopStars.UI
{
    public class UIManager : MonoSingletonGeneric<UIManager>
    {
        public TextMeshProUGUI PlayerScoreText;
        public TextMeshProUGUI Bot1ScoreText;
        public TextMeshProUGUI Bot2ScoreText;

        public TextMeshProUGUI GameWonText;

        public GameObject Bot2ScoreBoard;

        public GameObject UIScore;
        public GameObject UIStatus;
        public GameObject UIGameStart;
        [SerializeField]
        private bool isTwoBot;
        [SerializeField]
        private int defaultScore;
        [SerializeField]
        private int WinScore;
        [SerializeField]
        private PlayerMovement player;

        private void Start()
        {

            SetGameObjects();
            SetTexts();
            pauseConfig();
        }

        private void SetTexts()
        {
            PlayerScoreText.text = "Score : " + defaultScore;
            Bot1ScoreText.text = "Score : " + defaultScore;
            Bot2ScoreText.text = "Score : " + defaultScore;
        }

        private void SetGameObjects()
        {
            UIScore.SetActive(false);
            UIStatus.SetActive(false);
            UIGameStart.SetActive(true);
        }

        public void SetPlayerScore(int score)
        {
            if (checkScore(score))
            {
                gameWon("Player");
            }
            PlayerScoreText.text = "Score : " + score;
        }
        public void SetBot1Score(int score)
        {
            if (checkScore(score))
            {
                gameWon("Bot 2");
            }
            Bot1ScoreText.text = "Score : " + score;
        }
        public void SetBot2Score(int score)
        {
            if (checkScore(score))
            {
                gameWon("Bot 2");
            }
            Bot2ScoreText.text = "Score : " + score;
        }

        private void gameWon(string User)
        {
            pauseConfig();
            gameWonCofig();
            GameWonText.text = User + " WON!!";
        }

        private void gameWonCofig()
        {
            UIScore.SetActive(false);
            UIStatus.SetActive(true);
        }

        private bool checkScore(int score)
        {
            return (score == WinScore)? true: false;
        }
        public void Restart()
        {
            SoundManager.Instance.Play(Sounds.ButtonClick);
            SetGameObjects();
            SetTexts();
            pauseConfig();
            BotService.Instance.GameRestart();
            Scene currentScene= SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
        public void NextLevel()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if(SceneManager.GetSceneByBuildIndex(currentScene.buildIndex+1) != null)
            {
                SceneManager.LoadScene(currentScene.buildIndex+1);
            }
        }
        public void SingleBot()
        {
            SoundManager.Instance.Play(Sounds.ButtonClick);
            BotService.Instance.SpawnOneBot();
            Bot2ScoreBoard.SetActive(false);
            isTwoBot = false;
            resumeConfig();
        }
        public void TwoBot()
        {
            SoundManager.Instance.Play(Sounds.ButtonClick);
            BotService.Instance.SpwanTwoBot();
            Bot2ScoreBoard.SetActive(true);
            isTwoBot = true;
            resumeConfig();
        }

        private void pauseConfig()
        {
            Time.timeScale = 0;
        }
        private void resumeConfig()
        {
            Time.timeScale = 1;
            IngameUI();


        }
        private void IngameUI()
        {
            UIScore.SetActive(true);
            UIStatus.SetActive(false);
            UIGameStart.SetActive(false);
        }
        public void Exit()
        {
            Application.Quit();
        }
        public void SetPlayer(PlayerMovement playerMovement)
        {
            player=playerMovement;
        }
        public void LeftSideForce()
        {
            player.forceTowardsLeft();
        }
        public void RightSideForce()
        {
            player.forceTowardsRight();
        }

    }
}

