using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

// Class that manage levels.
public class LevelManager:MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Public fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Single static instance of 'LevelManager' (Singelton pattern).
  public static LevelManager Instance
  {
    get
    {
      return LevelManager._instance;
    }
  }
  // Enumeration of scenes.
  public enum Scenes { NONE, SPLASH, LOSE, WIN, MAIN_MENU, PAUSE_MENU, OPTIONS, HELP, TopScores, TopScoresName };
  // Enumeration of levels.
  public enum Lvls { NONE, Lvl_01, Lvl_02, Lvl_03 }

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Private fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Single static instance of 'LevelManager' (Singelton pattern).
  private static LevelManager _instance;
  // Current scene.
  private Scenes cur_scene = Scenes.NONE;
  // Current level.
  private Lvls cur_lvl = Lvls.NONE;
  // Loading panel.
  private GameObject loading_panel;
  // Progress slider.
  private Slider progress_slider;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  //  Public methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Get current scene.
  public Scenes CurSceneGet()
  {
    return Instance.cur_scene;
  } // End of CurSceneGet

  // Get current level.
  public Lvls CurLvlGet()
  {
    return Instance.cur_lvl;
  } // End of CurLvlGet

  // Quit.
  public void Quit()
  {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
  } // End of Quit

  // Load splash scene.
  public void SplashLoad(float delay)
  {
    SceneLoad(Scenes.SPLASH,delay);
  } // End of SplashLoad

  // Load lose scene.
  public void LoseLoad(float delay)
  {
    SceneLoad(Scenes.LOSE,delay);
  } // End of LoseLoad

  // Load win scene.
  public void WinLoad(float delay)
  {
    SceneLoad(Scenes.WIN,delay);
  } // End of WinLoad

  // Load main menu scene.
  public void MainMenuLoad(float delay)
  {
    SceneLoad(Scenes.MAIN_MENU,delay);
  } // End of MainMenuLoad

  // Load pause menu scene.
  public void PauseMenuLoad(float delay)
  {
    SceneLoad(Scenes.PAUSE_MENU,delay);
  } // End of PauseMenuLoad

  // Load options scene.
  public void OptionsLoad(float delay)
  {
    SceneLoad(Scenes.OPTIONS,delay);
  } // End of OptionsLoad

  // Load help scene.
  public void HelpLoad(float delay)
  {
    SceneLoad(Scenes.HELP,delay);
  } // End of HelpLoad

  // Load top scores.
  public void TopScoresLoad(float delay)
  {
    SceneLoad(Scenes.TopScores,delay);
  } // End of TopScoresLoad

  // Load top scores with name input.
  public void TopScoresNameLoad(float delay)
  {
    SceneLoad(Scenes.TopScoresName,delay);
  } // End of TopScoresNameLoad

  // Load scene.
  public void SceneLoad(Scenes scene,float delay)
  {
    // Load scene with delay.
    StartCoroutine(SceneLoadWithDelay(scene,delay));
  } // End of SceneLoad

  // Load next level.
  public void LvlLoadNext(float delay,bool is_async)
  {
    // Load next level with delay.
    StartCoroutine(LvlLoadNextWithDelay(delay,is_async));
  } // End of LvlLoadNext

  // Reload current level.
  public void LvlReload(float delay,bool is_async)
  {
    // Load next level with delay.
    StartCoroutine(LvlReloadWithDelay(delay,is_async));
  } // End of LvlReload

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Awake (used to initialize any variables or game state before the game starts).
  private void Awake()
  {
    if(LevelManager._instance==null)
    {
      LevelManager._instance=this;
    }
    else
    {
      GameObject.Destroy(this.gameObject);
    }
  } // End of Awake  

  // Initialization.
  private void Start()
  {
    // Make sure that game object will not be destroyed after loading next scene.
    GameObject.DontDestroyOnLoad(Instance.gameObject);
    // Get loading panel.
  //  Instance.loading_panel=GameObject.FindGameObjectWithTag("loading_screen").GetComponentsInChildren<Transform>(true)[1].gameObject;
    // Get progress slider.
  //  Instance.progress_slider=Instance.loading_panel.GetComponentInChildren<Slider>();
  } // End of Start

  // Load scene with delay.
  private IEnumerator SceneLoadWithDelay(Scenes scene,float delay)
  {
    // If no scene then exit from function.
    if(scene==Scenes.NONE)
    {
      yield break;
    }
    // Wait for 'time' seconds.
    yield return new WaitForSecondsRealtime(delay);
    // Set current scene.
    Instance.cur_scene=scene;
    // Actualize current level.
    Instance.cur_lvl=Lvls.NONE;
    // Load scene.
    SceneManager.LoadScene(SceneNameDecode(scene));
  } // End of SceneLoadWithDelay

  // Load next level with delay.
  private IEnumerator LvlLoadNextWithDelay(float delay,bool is_async)
  {
    // If current level is last.
    if((int)Instance.cur_lvl==Lvls.GetNames(typeof(Lvls)).Length-1)
    {
      // Load 'Win' level.
      WinLoad(delay);
      // Exit from function.
      yield break;
    }
    // Wait for 'time' seconds.
    yield return new WaitForSecondsRealtime(delay);
    // Set current scene.
    Instance.cur_scene=Scenes.NONE;
    // Actualize current level.
    Instance.cur_lvl++;
    // If asynchronouse mode.
    if(is_async)
    {
      // Load next level.
      AsyncOperation oper = SceneManager.LoadSceneAsync(LvlNameDecode(Instance.cur_lvl));
      // Activate loading panel.
      Instance.loading_panel.SetActive(true);
      // Reset slider progress.
      Instance.progress_slider.value=0.0F;
      // Duration of operation
      float duration = Time.realtimeSinceStartup;
      // Loop until operation is done.
      while(!oper.isDone)
      {
        // Compute real progress (Unity always reserve '0.1' for activation stage, so it's better to ommit that value).  
        float progress = Mathf.Clamp01(oper.progress/0.9F);
        // Change slider progress.
        Instance.progress_slider.value=progress;
        // Yield until next frame.
        yield return null;
      }
      // Compute duration of operation.
      duration = Time.realtimeSinceStartup - duration;
      // If duration of operation was shorter than 1 second.
      if(duration < 1.0F)
      {
        // Yield to at least 1 full second.
        yield return new WaitForSecondsRealtime(1.0F - duration);
      }
      // Disable loading panel.
      Instance.loading_panel.SetActive(false);
    }
    // If not asynchronouse mode.
    else
    {
      // Load next level.
      SceneManager.LoadScene(LvlNameDecode(Instance.cur_lvl));
    }
  } // End of LvlLoadNextWithDelay

  // Reload current level with delay.
  private IEnumerator LvlReloadWithDelay(float delay,bool is_async)
  {
    // Wait for 'time' seconds.
    yield return new WaitForSecondsRealtime(delay);
    // If asynchronouse mode.
    if(is_async)
    {
      // Load level.
      AsyncOperation oper = SceneManager.LoadSceneAsync(LvlNameDecode(Instance.cur_lvl));
      // Activate loading panel.
      Instance.loading_panel.SetActive(true);
      // Reset slider progress.
      Instance.progress_slider.value=0.0F;
      // Duration of operation
      float duration = Time.realtimeSinceStartup;
      // Loop until operation is done.
      while(!oper.isDone)
      {
        // Compute real progress (Unity always reserve '0.1' for activation stage, so it's better to ommit that value).  
        float progress = Mathf.Clamp01(oper.progress/0.9F);
        // Change slider progress.
        Instance.progress_slider.value=progress;
        // Yield until next frame.
        yield return null;
      }
      // Compute duration of operation.
      duration = Time.realtimeSinceStartup - duration;
      // If duration of operation was shorter than 1 second.
      if(duration < 1.0F)
      {
        // Yield to at least 1 full second.
        yield return new WaitForSecondsRealtime(1.0F - duration);
      }
      // Disable loading panel.
      Instance.loading_panel.SetActive(false);
    }
    // If not asynchronouse mode.
    else
    {
      // Load level.
      SceneManager.LoadScene(LvlNameDecode(Instance.cur_lvl));
    }
  } // End of LvlReloadWithDelay

  // Decode scene name.
  private string SceneNameDecode(Scenes scene)
  {
    switch(scene)
    {
      case Scenes.SPLASH:
      {
        return "00_Splash";
      }
      case Scenes.LOSE:
      {
        return "01_Lose";
      }
      case Scenes.WIN:
      {
        return "01_Win";
      }
      case Scenes.MAIN_MENU:
      {
        return "02_MainMenu";
      }
      case Scenes.PAUSE_MENU:
      {
        return "02_PauseMenu";
      }
      case Scenes.OPTIONS:
      {
        return "02_Options";
      }
      case Scenes.HELP:
      {
        return "02_Help";
      }
      case Scenes.TopScores:
      {
        return "04_TopScores";
      }
      case Scenes.TopScoresName:
      {
        return "04_TopScoresName";
      }
      default:
      {
        throw new System.Exception("Cannot load scene ["+scene.ToString()+"]");
      }
    }
  } // End of SceneNameDecode

  // Decode level name.
  private string LvlNameDecode(Lvls lvl)
  {
    switch(lvl)
    {
      case Lvls.Lvl_01:
      {
        return "03_Lvl_01";
      }
      case Lvls.Lvl_02:
      {
        return "03_Lvl_02";
      }
      case Lvls.Lvl_03:
      {
        return "03_Lvl_03";
      }
      default:
      {
        throw new System.Exception("Cannot load level ["+lvl.ToString()+"]");
      }
    }
  } // End of LvlNameDecode

  #endregion

} // End of LevelManager