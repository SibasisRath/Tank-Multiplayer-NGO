using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;


[InitializeOnLoad]
public class StartupSceneLoader
{
    static StartupSceneLoader()
    {
        EditorApplication.playModeStateChanged += LoadStartUpScene;
    }

    private static void LoadStartUpScene(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode )
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo(); 
        }

        if (state == PlayModeStateChange.EnteredPlayMode) 
        {
            if(EditorSceneManager.GetActiveScene().buildIndex != 0)
            {
                EditorSceneManager.LoadScene(0);
            }
        }
    }
}
