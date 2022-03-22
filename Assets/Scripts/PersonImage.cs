using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PersonImage : MonoBehaviour, IDragHandler
{
    #region Declarations
    [SerializeField]
    private Transform japaneseBox;
    [SerializeField]
    private Transform chineseBox;
    [SerializeField]
    private Transform thaiBox;
    [SerializeField]
    private Transform koreanBox;
    [SerializeField]
    private Transform endPosition;
    private Vector3 targetBoxPosition;
    private RawImage image;
    private Color personImagecolor;
    private bool isDragged = false;
    private RectTransform rectTransform;
    #endregion

    #region Private Methods
    /// <summary>s
    /// Default method provided by Unity Engine.
    /// Start method is invoked on the start of scene. Initializations, registrations, should be made here.
    /// </summary>
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<RawImage>();
    }

    /// <summary>
    /// Default method provided by Unity Engine.
    /// called before the first frame update
    /// </summary>
    void Update()
    {
        personImagecolor = GetComponent<RawImage>().color;
        //Moves the GameObject from it's current position to destination over time
        if (isDragged)
        {
            transform.position = Vector2.Lerp(transform.position, targetBoxPosition, Time.deltaTime);
            image.color = new Color(personImagecolor.r, personImagecolor.g, personImagecolor.b, personImagecolor.a- Time.deltaTime/2);
        }
        else
        {
            transform.position = Vector2.LerpUnclamped(transform.position, new Vector2(endPosition.position.x, endPosition.position.y), (Time.deltaTime*7));            
        }
    }

    /// <summary>
    /// Default method provided by Unity Engine. 
    /// Called everytime when an object enter in other object's space. 
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Get object tag, this will save CPU from unnecessary calls.
        string objectTag = collision.transform.tag;

        //Check if image collided with on of four boxes
        if (objectTag.Equals(DataConstants.JapaneseNationality) || objectTag.Equals(DataConstants.ChineseNationality)
            || objectTag.Equals(DataConstants.KoreanNationality) || objectTag.Equals(DataConstants.ThaiNationality))
        {
            ValidateTarget(objectTag);
            EventHub.TriggerEvent(DataConstants.SpawnImageEvent);
            Destroy(gameObject);
        }
        if (objectTag.Equals(DataConstants.FinishTag))
        {
            EventHub.TriggerEvent(DataConstants.SpawnImageEvent);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Check if image was moved to the right nationality box
    /// </summary>
    /// <param name="tag"></param>
    private void ValidateTarget(string tag)
    {
        if (tag.Equals(PlayerPrefsManager.GetLastSpawnedImageTag()))
        {
            EventHub.TriggerEvent(DataConstants.PointsWinEvent);
        }
        else
        {
            EventHub.TriggerEvent(DataConstants.PointsLoseEvent);
        }
    }
    #endregion
    #region Public Methods
    /// <summary>
    /// Default method provided by Unity Engine.
    /// Called when mouse is dragged
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.delta;
        rectTransform.anchoredPosition += eventData.delta/5 ;
        
        if (!isDragged)
        {
            //Stop image's Physics, so that it script can move it as per its need. 
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            isDragged = true;
            //Mouse pointing towards upper right corner
            if (delta.x > 0 && delta.y > 0)
            {
                targetBoxPosition = chineseBox.position;
            }
            //Mouse pointing towards upper left corner
            else if (delta.x < 0 && delta.y > 0)
            {
                targetBoxPosition = japaneseBox.position;
            }
            //Mouse pointing towards lower right corner
            else if (delta.x > 0 && delta.y < 0)
            {
                targetBoxPosition = thaiBox.position;
            }
            //Mouse pointing towards lower left corner
            else
            {
                targetBoxPosition = koreanBox.position;
            }
        }
    }
    #endregion
}
