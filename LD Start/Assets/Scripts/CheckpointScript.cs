using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmos()
    {
#if UNITY_EDITOR
        //DrawString(gameObject.name, gameObject.transform.position, Color.black, 18);
        Gizmos.DrawIcon(transform.position, "checkpoint gizmo.png", true);        
#endif
    }

    void DrawString(string text, Vector3 worldPos, Color colour, int fontSize)
    {
        UnityEditor.Handles.BeginGUI();

        var restoreColor = GUI.color;

        //if (colour.HasValue) GUI.color = colour.Value;
        var view = UnityEditor.SceneView.currentDrawingSceneView;
        Vector3 screenPos = view.camera.WorldToScreenPoint(worldPos);

        if (screenPos.y < 0 || screenPos.y > Screen.height || screenPos.x < 0 || screenPos.x > Screen.width || screenPos.z < 0)
        {
            GUI.color = restoreColor;
            UnityEditor.Handles.EndGUI();
            return;
        }

        GUIStyle style = new GUIStyle();
        style.fontSize = fontSize;
        style.fontStyle = FontStyle.Bold;

        Vector2 size = GUI.skin.label.CalcSize(new GUIContent(text));
        GUI.Label(new Rect(screenPos.x - (size.x / 2), -screenPos.y + view.position.height + 4, size.x, size.y), text, style);
        GUI.color = restoreColor;
        UnityEditor.Handles.EndGUI();
    }
}