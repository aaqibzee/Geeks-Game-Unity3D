
public class DataConstants
{
    #region Constants
    //Events constants
    public const string PointsWinEvent = "PointsWin";
    public const string PointsLoseEvent = "PointsLose";
    public const string SpawnImageEvent = "SpawnImage";
    public const string TelecastImageTagEvent = "SpawnedImageTag";
    public const string GameEndEvent = "GameEnd";

    //Tags
    public const string JapaneseNationality = "Japanese";
    public const string ChineseNationality = "Chinese";
    public const string KoreanNationality = "Korean";
    public const string ThaiNationality = "Thai";
    public const string FinishTag = "Finish";

    //Scenes
    public const string GamePlaySceneName = "Game Play";

    //Others
    public const string ImagesFodlerName = "Images/";
    //Enumerations
    public enum Nationalities
    {
        Japanese,
        Chinese,
        Korean,
        Thai,
        MaxNationalties = 4,
    }
    public enum MaxImagesForNationality
    {
        Japanese=3,
        Chinese=3,
        Korean=3,
        Thai=3
    }
    #endregion
}
