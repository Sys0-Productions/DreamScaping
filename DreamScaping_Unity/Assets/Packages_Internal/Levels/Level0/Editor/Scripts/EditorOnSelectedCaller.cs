#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class EditorOnSelectedCaller : Editor
{
    [SerializeField]
    private GameObject _lastSelection;
    
    void Update()
    {
        var holder = Selection.activeTransform.gameObject;
        if (_lastSelection != holder)
        {
            Debug.Log("Changed");
        }
        _lastSelection = Selection.activeTransform.gameObject;
    }
}
#endif