#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class AiCommentData
{
    public string comment;
}

public class AiCommentSheet : Sheet<AiCommentData>
{
#if UNITY_EDITOR
    [MenuItem("DataSheet/AiCommentSheet")]
    public static void CreateData()
    {
        ScriptableObjectUtillity.CreateAsset<AiCommentSheet>();
    }
#endif
}