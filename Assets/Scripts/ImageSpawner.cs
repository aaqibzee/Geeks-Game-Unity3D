using UnityEngine;
using UnityEngine.UI;

public class ImageSpawner : MonoBehaviour
{
    #region Declarations
    [SerializeField]
    private GameObject imageToSpawn;
    [SerializeField]
    private GameObject parrent;
    [SerializeField]
    private GameObject referencePoint;
    [SerializeField]
    private int MaxImagesToSpawn = 12;
    private int lastImageNumber = 0;
    private int lastNationality = 0;
    private int imagesSpawnedCount = 0;
    #endregion

    #region Private Methods
    /// <summary>s
    /// Default method provided by Unity Engine.
    /// Start method is invoked on the start of scene. Initializations, registrations, should be made here.
    /// </summary>
    private void Start()
    {
        EventHub.AttachListener(DataConstants.SpawnImageEvent, SpawnImage);
    }

    /// <summary>
    /// Get next image to spawn
    /// </summary>
    /// <returns></returns>
    private Texture GetNextImage()
    {
        lastNationality = Random.Range(1, (int)DataConstants.Nationalities.MaxNationalties + 1);
        lastImageNumber = Random.Range(1, GetMaxNumberOfImagesForNationality(lastNationality) + 1);
        return (Texture)Resources.Load(DataConstants.ImagesFodlerName +GetNationalityName(lastNationality) +"/"+ lastImageNumber.ToString());
    }

    /// <summary>
    /// Get max number of images for a nationality
    /// </summary>
    /// <param name="nationality"></param>
    /// <returns></returns>
    private int GetMaxNumberOfImagesForNationality(int nationality)
    {
        switch (nationality)
        {
            case (int)DataConstants.Nationalities.Japanese:
                {
                    return (int)DataConstants.MaxImagesForNationality.Japanese;
                }
            case (int)DataConstants.Nationalities.Chinese:
                {
                    return (int)DataConstants.MaxImagesForNationality.Chinese;
                }
            case (int)DataConstants.Nationalities.Korean:
                {
                    return (int)DataConstants.MaxImagesForNationality.Korean;
                }
            case (int)DataConstants.Nationalities.Thai:
                {
                    return (int)DataConstants.MaxImagesForNationality.Thai;
                }
            default:
                {
                    return (int)DataConstants.MaxImagesForNationality.Thai;
                }
        }
    }

    /// <summary>
    /// Get nationality name for an integer, as per defined rules.
    /// </summary>
    /// <param name="nationality"></param>
    /// <returns></returns>
    private string GetNationalityName(int nationality)
    {
        switch (nationality)
        {
            case (int)DataConstants.Nationalities.Japanese:
                {
                    return DataConstants.JapaneseNationality;
                }
            case (int)DataConstants.Nationalities.Chinese:
                {
                    return DataConstants.ChineseNationality;
                }
            case (int)DataConstants.Nationalities.Korean:
                {
                    return DataConstants.KoreanNationality;
                }
            case (int)DataConstants.Nationalities.Thai:
                {
                    return DataConstants.ThaiNationality;
                }
            default:
                {
                    return DataConstants.ThaiNationality;
                }
        }
    }

    #endregion
    #region Public Methods
    /// <summary>
    /// Spawn  new image
    /// </summary>
    public void SpawnImage()
    {
        if (imagesSpawnedCount < MaxImagesToSpawn)
        {
            GameObject instantiatedObject = Instantiate(imageToSpawn, referencePoint.transform.position, Quaternion.identity);
            instantiatedObject.GetComponent<RawImage>().texture = GetNextImage();
            instantiatedObject.SetActive(true);
            instantiatedObject.tag = GetNationalityName(lastNationality);
            instantiatedObject.transform.SetParent(parrent.transform);
            instantiatedObject.transform.localScale = Vector3.one;
            PlayerPrefsManager.SetLastSpawnedImageTag(instantiatedObject.transform.tag);
            imagesSpawnedCount++;
        }
        else
        {
            EventHub.TriggerEvent(DataConstants.GameEndEvent);
        }
    }
    #endregion
}
