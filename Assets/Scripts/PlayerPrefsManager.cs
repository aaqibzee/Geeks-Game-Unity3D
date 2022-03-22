using UnityEngine;

public class PlayerPrefsManager
{
    #region Constants
    private const string spawnedImageTagKey = "spawnedImageTag";
    private const string totalPointsKey = "totalPoints";
    #endregion
    
    #region Public Methods
    /// <summary>
    /// Get tag for last spawned iamge
    /// </summary>
    /// <param name="tag"></param>
    public static void SetLastSpawnedImageTag(string tag)
    {
        PlayerPrefs.SetString(spawnedImageTagKey, tag);
    }

    /// <summary>
    /// Get tag for last spawned iamge
    /// </summary>
    /// <returns></returns>
    public static string GetLastSpawnedImageTag()
    {
        return PlayerPrefs.GetString(spawnedImageTagKey, "");
    }

    /// <summary>
    /// Set toal points earned by player
    /// </summary>
    /// <param name="points"></param>
    public static void SetTotalPoints(int points)
    {
        PlayerPrefs.SetInt(totalPointsKey, points);
    }

    /// <summary>
    /// Get toal points earned by player
    /// </summary>
    /// <returns></returns>
    public static int GetTotalPoints()
    {
        return PlayerPrefs.GetInt(totalPointsKey, 0);
    }
    #endregion
}