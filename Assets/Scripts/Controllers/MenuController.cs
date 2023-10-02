using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public const string m_SceneTopView = "TopView";
    public const string m_SceneSideView = "SideView2Wall";
    public const string m_SceneExtra = "SideView4Wall";

    [SerializeField]
    private GameObject m_menu;

    [SerializeField]
    private bool m_ShowMenu = false;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            OnClickMenu();
        }

        m_menu.SetActive(m_ShowMenu);


        if (m_ShowMenu) PauseGame();
        else ResumeGame();
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }
    private void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void OnClickMenu()
    {
        m_ShowMenu = !m_ShowMenu;
    }

    public void OnClickTopView()
    {
        ChangeScene(m_SceneTopView);
    }

    public void OnClickSideView()
    {
        ChangeScene(m_SceneSideView);
    }

    public void OnClickExtra()
    {
        ChangeScene(m_SceneExtra);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void ChangeScene(string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
    }
}
