using System;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "SnakeCoilingDebugger", menuName = "ScriptableObjects/SnakeCoilingDebugger")]
public class SnakeCoilingDebugger : ScriptableObject {
    [TextArea(6,30)] public string whatDoesTheSnakeDo;
    Snake snake;

    public void PrintSnakeBehaviour() {
        snake = FindObjectOfType<Snake>();
        for (int i = 0; i < snake.snakeBehaviourQueue.Count; i++) {
            whatDoesTheSnakeDo += snake.snakeBehaviourQueue.Dequeue();
            if (i < snake.snakeBehaviourQueue.Count - 1)
                whatDoesTheSnakeDo += $"{Environment.NewLine}";
        }
        snake.snakeBehaviourQueue.Clear();
    }

    public void ClearOutput() {
        whatDoesTheSnakeDo = "";
    }
}

[CustomEditor(typeof(SnakeCoilingDebugger))]
public class SnakeCoilingDebuggerEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        SnakeCoilingDebugger so = (SnakeCoilingDebugger) target;

        if (GUILayout.Button("Check Snake's Behaviour Queue")) {
            so.PrintSnakeBehaviour();
        }
        
        if (GUILayout.Button("Clear")) {
            so.ClearOutput();
        }
    }
}