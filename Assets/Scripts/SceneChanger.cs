using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(int buildIndex)
    {
        ChangeSceneStat(buildIndex);
    }
    public static void ChangeSceneStat(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
