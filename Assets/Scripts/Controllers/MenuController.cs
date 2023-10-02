using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public const string SCENE_TOP_VIEW = "TopView";
    public const string SCENE_SIDE_VIEW = "SideView2Wall";
    public const string SCENE_EXTRA = "SideView4Wall";

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
        ChangeScene(SCENE_TOP_VIEW);
    }

    public void OnClickSideView()
    {
        ChangeScene(SCENE_SIDE_VIEW);
    }

    public void OnClickExtra()
    {
        ChangeScene(SCENE_EXTRA);
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
