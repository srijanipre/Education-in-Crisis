using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabletMatchingGame : MonoBehaviour
{
    [Header("Letter Buttons")]
    public Button letterAButton;
    public Button letterBButton;
    public Button letterCButton;

    [Header("Word Buttons")]
    public Button appleButton;
    public Button bananaButton;
    public Button carButton;

    [Header("UI Text")]
    public TMP_Text messageText;

    [Header("Optional")]
    public GameObject bigTabletToHide;
    public GameObject floatingLettersToShow;

    private string selectedLetter = "";

    private bool aDone = false;
    private bool bDone = false;
    private bool cDone = false;

    void Start()
    {
        if (messageText != null)
            messageText.text = "Pick A, B, or C";

        // Laptop mouse/UI support
        letterAButton.onClick.AddListener(() => SelectLetter("A"));
        letterBButton.onClick.AddListener(() => SelectLetter("B"));
        letterCButton.onClick.AddListener(() => SelectLetter("C"));

        appleButton.onClick.AddListener(MatchApple);
        bananaButton.onClick.AddListener(MatchBanana);
        carButton.onClick.AddListener(MatchCar);
    }

    void Update()
    {
        // -------------------------
        // Desktop keyboard fallback
        // -------------------------
        if (Input.GetKeyDown(KeyCode.A))
            SelectLetter("A");

        if (Input.GetKeyDown(KeyCode.B))
            SelectLetter("B");

        if (Input.GetKeyDown(KeyCode.C))
            SelectLetter("C");

        if (Input.GetKeyDown(KeyCode.Alpha1))
            MatchApple();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            MatchBanana();

        if (Input.GetKeyDown(KeyCode.Alpha3))
            MatchCar();

        // -------------------------
        // CAVE2 controls
        // -------------------------
        if (CAVE2.GetButtonDown(CAVE2.Button.ButtonUp))
            SelectLetter("A");

        if (CAVE2.GetButtonDown(CAVE2.Button.ButtonLeft))
            SelectLetter("B");

        if (CAVE2.GetButtonDown(CAVE2.Button.ButtonRight))
            SelectLetter("C");

        // Confirm current selected match using either ButtonDown or Button7
        if (CAVE2.GetButtonDown(CAVE2.Button.ButtonDown) ||
            CAVE2.GetButtonDown(CAVE2.Button.Button7))
        {
            ConfirmSelectedLetter();
        }
    }

    void SelectLetter(string letter)
    {
        if (letter == "A" && aDone) return;
        if (letter == "B" && bDone) return;
        if (letter == "C" && cDone) return;

        selectedLetter = letter;

        if (messageText != null)
            messageText.text = "Selected: " + letter;
    }

    void ConfirmSelectedLetter()
    {
        if (selectedLetter == "")
        {
            if (messageText != null)
                messageText.text = "Pick a letter first.";
            return;
        }

        if (selectedLetter == "A")
            MatchApple();
        else if (selectedLetter == "B")
            MatchBanana();
        else if (selectedLetter == "C")
            MatchCar();
    }

    void MatchApple()
    {
        if (aDone) return;
        TryMatch("A", letterAButton, appleButton);
    }

    void MatchBanana()
    {
        if (bDone) return;
        TryMatch("B", letterBButton, bananaButton);
    }

    void MatchCar()
    {
        if (cDone) return;
        TryMatch("C", letterCButton, carButton);
    }

    void TryMatch(string correctLetter, Button correctLetterButton, Button wordButton)
    {
        if (selectedLetter == "")
        {
            if (messageText != null)
                messageText.text = "Pick a letter first.";
            return;
        }

        if (selectedLetter == correctLetter)
        {
            if (correctLetter == "A") aDone = true;
            if (correctLetter == "B") bDone = true;
            if (correctLetter == "C") cDone = true;

            MarkButtonComplete(correctLetterButton);
            MarkButtonComplete(wordButton);

            selectedLetter = "";

            if (messageText != null)
                messageText.text = "Correct!";
        }
        else
        {
            selectedLetter = "";

            if (messageText != null)
                messageText.text = "Try again.";
        }

        CheckIfFinished();
    }

    void MarkButtonComplete(Button button)
    {
        ColorBlock colors = button.colors;
        colors.normalColor = Color.green;
        colors.highlightedColor = Color.green;
        colors.pressedColor = Color.green;
        colors.selectedColor = Color.green;
        button.colors = colors;

        button.interactable = false;
    }

    void CheckIfFinished()
    {
        if (aDone && bDone && cDone)
        {
            if (messageText != null)
                messageText.text = "Great job!";

            if (floatingLettersToShow != null)
                floatingLettersToShow.SetActive(true);

            if (bigTabletToHide != null)
                bigTabletToHide.SetActive(false);
        }
    }
}