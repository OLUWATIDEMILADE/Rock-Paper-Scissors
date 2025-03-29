using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Button rockButton;
    public Button paperButton;
    public Button scissorsButton;
    public Button shootButton;
    public Button replayButton;
    public Button homeButton; 

    public TMP_Text playerChoiceText;
    public TMP_Text computerChoiceText;
    public TMP_Text resultText;

    private enum Choice { Rock, Paper, Scissors }
    private Choice playerChoice;
    private Choice computerChoice;
    private bool choiceMade = false;

    void Start()
    {
        // Set up button listeners
        rockButton.onClick.AddListener(() => OnChoiceMade(Choice.Rock));
        paperButton.onClick.AddListener(() => OnChoiceMade(Choice.Paper));
        scissorsButton.onClick.AddListener(() => OnChoiceMade(Choice.Scissors));
        shootButton.onClick.AddListener(DetermineWinner);
        replayButton.onClick.AddListener(ResetGame);
        homeButton.onClick.AddListener(GoToHome); // Added Home Button Listener

        // Initialize UI and button states
        replayButton.interactable = false;
        shootButton.interactable = false;
        resultText.text = "Result: ";
    }

    void OnChoiceMade(Choice choice)
    {
        if (choiceMade) return; // Prevent changing choice after it's made

        playerChoice = choice;
        playerChoiceText.text = "Player Choice: " + choice.ToString();
        choiceMade = true;
        shootButton.interactable = true; // Enable the Shoot button
    }

    void DetermineWinner()
    {
        if (!choiceMade) return;

        // Generate a random choice for the computer
        computerChoice = (Choice)UnityEngine.Random.Range(0, 3);
        computerChoiceText.text = "Computer Choice: " + computerChoice.ToString();

        // Determine the result using a switch statement
        switch (playerChoice)
        {
            case Choice.Rock:
                if (computerChoice == Choice.Rock)
                    resultText.text = "Result: It's a Draw!";
                else if (computerChoice == Choice.Scissors)
                    resultText.text = "Result: Player Wins!";
                else
                    resultText.text = "Result: Computer Wins!";
                break;

            case Choice.Paper:
                if (computerChoice == Choice.Paper)
                    resultText.text = "Result: It's a Draw!";
                else if (computerChoice == Choice.Rock)
                    resultText.text = "Result: Player Wins!";
                else
                    resultText.text = "Result: Computer Wins!";
                break;

            case Choice.Scissors:
                if (computerChoice == Choice.Scissors)
                    resultText.text = "Result: It's a Draw!";
                else if (computerChoice == Choice.Paper)
                    resultText.text = "Result: Player Wins!";
                else
                    resultText.text = "Result: Computer Wins!";
                break;
        }

        // Disable buttons and enable "Replay"
        DisableChoiceButtons();
        shootButton.interactable = false;
        replayButton.interactable = true;
    }

    void ResetGame()
    {
        // Reset UI and game state
        playerChoiceText.text = "Player Choice: ";
        computerChoiceText.text = "Computer Choice: ";
        resultText.text = "Result: ";

        choiceMade = false;
        EnableChoiceButtons();
        shootButton.interactable = false;
        replayButton.interactable = false;
    }

    void GoToHome()
    {
        // Load the home scene (Replace "MainMenu" with the actual scene name)
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    void DisableChoiceButtons()
    {
        rockButton.interactable = false;
        paperButton.interactable = false;
        scissorsButton.interactable = false;
    }

    void EnableChoiceButtons()
    {
        rockButton.interactable = true;
        paperButton.interactable = true;
        scissorsButton.interactable = true;
    }
}
