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
  // Scoreboard.
  [SerializeField]
  [Tooltip("Scoreboard")]
  private Scoreboard scoreboard;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Private methods
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Add listener to submit/end editing of input field.
    this.input_field.onEndEdit.AddListener(delegate { OnSaveName(this.input_field.text); });
    // * This is other way of doing the same. See documentation: 
    // InputField.onEndEdit -> SubmitEvent -> Events.UnityEvent_1 -> UnityEvent<T0> 
    // <T0> means that this even will automatically have one parametr attached to it, in this case input value (text).
    // this.input_field.onEndEdit.AddListener(this.OnSaveName);

    // Other example of listener (without parameters):
    // Add listener to save button.
    // this.save_btn.onClick.AddListener(this.OnSave);
  } // End of Start

  // Event - on save name.
  void OnSaveName(string player_name)
  {
    // Claim top score by player.
    this.scoreboard.TopScoreClaim(player_name);
    // Load top scores scene.
    LevelManager.Instance.TopScoresLoad(0.0F);
  } // End of OnSaveName

  #endregion

} // End of NameEntry