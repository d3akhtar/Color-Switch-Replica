using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{

    public enum Scene
    {
        MainMenuScene,
        LoadingScene,
        GameScene
    }

    private static Scene targetScene;

    public static void Load(Scene targetSceneName)
    {
        Loader.targetScene = targetSceneName;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoaderCallBack()
    {
        SceneManager.LoadScene(Loader.targetScene.ToString());
    }

}
