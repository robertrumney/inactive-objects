using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class InactiveStaticObjectsWindow : EditorWindow
{
    private Vector2 scrollPosition;
    private string[] ignoreList = new string[0];
    private Transform[] ignoreTransforms = new Transform[0];

    [MenuItem("Window/Inactive Static Objects")]
    public static void ShowWindow()
    {
        GetWindow<InactiveStaticObjectsWindow>("Inactive Static Objects");
    }

    void OnGUI()
    {
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.Width(position.width), GUILayout.Height(position.height));

        EditorGUILayout.LabelField("Ignore List", EditorStyles.boldLabel);
        int newSize = EditorGUILayout.IntField("Size", ignoreList.Length);
        if (newSize != ignoreList.Length)
        {
            System.Array.Resize(ref ignoreList, newSize);
        }
        for (int i = 0; i < ignoreList.Length; i++)
        {
            ignoreList[i] = EditorGUILayout.TextField("Element " + i, ignoreList[i]);
        }

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Ignore Transforms", EditorStyles.boldLabel);
        int newSizeTransforms = EditorGUILayout.IntField("Size", ignoreTransforms.Length);
        if (newSizeTransforms != ignoreTransforms.Length)
        {
            System.Array.Resize(ref ignoreTransforms, newSizeTransforms);
        }
        for (int i = 0; i < ignoreTransforms.Length; i++)
        {
            ignoreTransforms[i] = (Transform)EditorGUILayout.ObjectField("Element " + i, ignoreTransforms[i], typeof(Transform), true);
        }

        EditorGUILayout.Space();

        List<GameObject> inactiveObjects = FindInactiveStaticObjects();

        foreach (GameObject obj in inactiveObjects)
        {
            EditorGUILayout.LabelField("Name: " + obj.name, EditorStyles.boldLabel);
            EditorGUILayout.ObjectField("Object: ", obj, typeof(GameObject), true);
            EditorGUILayout.Space();
        }

        EditorGUILayout.EndScrollView();
    }

    List<GameObject> FindInactiveStaticObjects()
    {
        GameObject[] allObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        List<GameObject> inactiveObjects = new List<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            CheckChildObjects(obj.transform, inactiveObjects);
        }

        return inactiveObjects;
    }

    void CheckChildObjects(Transform parent, List<GameObject> inactiveObjects)
    {
        if (System.Array.Exists(ignoreTransforms, element => element == parent))
            return;

        foreach (Transform child in parent)
        {
            if (!child.gameObject.activeInHierarchy && child.gameObject.isStatic && !System.Array.Exists(ignoreList, element => element == child.gameObject.name))
            {
                inactiveObjects.Add(child.gameObject);
            }

            if (child.childCount > 0)
            {
                CheckChildObjects(child, inactiveObjects);
            }
        }
    }
}
