using UnityEngine;
using UnityEngine.UI;

// Name entry.
public class NameEntry : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------  
  // Serialized fields
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Input field for player name.
  [SerializeField]
  [Tooltip("Input field for player name")]
  private InputField input_field;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Private fields
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Scoreboard.
  private ScoreboardLocal scoreboard;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Private methods
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Get scoreboard.
    this.scoreboard=GameObject.FindObjectOfType<ScoreboardLocal>();
    // Add listener to submit/end editing of input field.
    this.input_field.onEndEdit.AddListener(delegate { OnSave(this.input_field.text); });

    // * This is other way of doing the same. See documentation: 
    // InputField.onEndEdit -> SubmitEvent -> Events.UnityEvent_1 -> UnityEvent<T0> 
    // <T0> means that this even will automatically have one parametr attached to it, in this case input value (text).
    // this.input_field.onEndEdit.AddListener(this.OnSave);

    // Other example of listener (without parameters):
    // Add listener to save button.
    // this.save_btn.onClick.AddListener(this.OnSaveBtn);
  } // End of Start

  // Event - on submit/end editing input field.
  private void OnSave(string player_name)
  {
    // Claim top score by player.
    this.scoreboard.TopScoreClaim(player_name," ... ");
    // Load top scores scene.
    LevelManager.Instance.SceneLoad(LevelManager.Scenes.TOP_SCORES,0.0F);
  } // End of OnSave

  // Event - on buton click (only for purpose of learning listeners).
  private void OnSaveBtn()
  {
    OnSave(this.input_field.text);
  } // End of OnSaveBtn

  #endregion

} // End of NameEntry