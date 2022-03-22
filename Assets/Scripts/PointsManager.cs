using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    #region Declarations
    [SerializeField]
    private Text points;
    private int rewardPoints = 20;
    private int damagePoints = 5;
    private int currentPoints = 0;
    private const string totalPoints = "TotalPoints ";
    #endregion 

    #region Public Methods
    /// <summary>s
    /// Default method provided by Unity Engine.
    /// Start method is invoked on the start of scene. Initializations, registrations, should be made here.
    /// </summary>
    private void Start()
    {
        AttachListeners();
        PlayerPrefsManager.SetTotalPoints(0);
    }

    /// <summary>
    /// Attach listeners to events.
    /// </summary>
    private void AttachListeners()
    {
        EventHub.AttachListener(DataConstants.PointsWinEvent, IncrementPoints);
        EventHub.AttachListener(DataConstants.PointsLoseEvent, DecrementPoints);
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Increment player points when user selects right nationality for person
    /// </summary>
    public void IncrementPoints()
    {
        currentPoints += rewardPoints;
        points.text = totalPoints + currentPoints.ToString();
        PlayerPrefsManager.SetTotalPoints(currentPoints);
    }

    /// <summary>
    /// Decrement player points when user selects wrong nationality for person
    /// </summary>
    public void DecrementPoints()
    {
        currentPoints -= damagePoints;
        points.text = totalPoints + currentPoints.ToString();
        PlayerPrefsManager.SetTotalPoints(currentPoints);
    }
    #endregion
}
