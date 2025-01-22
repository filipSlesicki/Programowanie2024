using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DialogChoice", menuName = "Scriptable Objects/DialogChoice")]
public class DialogChoice : ScriptableObject
{
    public string Text;
    public DialogChoice[] Choices;
    Button buttonPrefab;
    DialogChoice choice;

    void CreateButtons()
    {
        foreach (var choice in Choices)
        {
            Button button = Instantiate(buttonPrefab);
            SetTargetChoice(choice);
            //button.onClick.AddListener(() => GoToChooice(choice));
        }
    }

    public void SetTargetChoice(DialogChoice choice)
    {
        this.choice = choice;
    }

    void GoToChooice()
    {

    }
}

