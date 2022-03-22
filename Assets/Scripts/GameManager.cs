using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        #region Declarations
        [SerializeField]
        private Text text;
        [SerializeField]
        private GameObject gameEndScreen;
        #endregion

        #region Private Methods
        /// <summary>s
        /// Default method provided by Unity Engine.
        /// Start method is invoked on the start of scene. Initializations, registrations, should be made here.
        /// </summary>
        private void Start()
        {
            EventHub.AttachListener(DataConstants.GameEndEvent, GameEnd);
            gameEndScreen.SetActive(false);
            EventHub.TriggerEvent(DataConstants.SpawnImageEvent);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Replay the game
        /// </summary>
        public void ReplayGame()
        {
            SceneManager.LoadSceneAsync(DataConstants.GamePlaySceneName);
        }

        /// <summary>
        /// Game end event activites to be done here
        /// </summary>
        public void GameEnd()
        {
            gameEndScreen.SetActive(true);
            text.text += PlayerPrefsManager.GetTotalPoints();
        }
        #endregion
    }

}
