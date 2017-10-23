#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class ResultCommentData
{
    public int percentage;

    public string comment;
}

public class ResultCommentSheet : Sheet<ResultCommentData>
{
#if UNITY_EDITOR
    [MenuItem("DataSheet/ResultCommentSheet")]
    public static void CreateData()
    {
        ScriptableObjectUtillity.CreateAsset<ResultCommentSheet>();
    }
#endif
}