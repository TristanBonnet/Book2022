using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplanationManager : MonoBehaviour
{
    [SerializeField]
    private List<TriggerExplainationText> _listExplanationText;

    private TriggerExplainationText _currentExplanationText = null;


    public void AddToExplanationList(TriggerExplainationText explanationText)
    {

        _listExplanationText.Add(explanationText);
        _currentExplanationText = explanationText;
        AddToUI();

    }

    public void RemoveToExplanationList(TriggerExplainationText explanationText)
    {

        _listExplanationText.Remove(explanationText);
        if (_listExplanationText.Count > 0 && _listExplanationText[_listExplanationText.Count - 1] != null )
        {
            _currentExplanationText = _listExplanationText[_listExplanationText.Count - 1];
            
        }

        else
        {
            GameManager._instance.UIManager.SetExplicationTextVisibility(false);
        }
    }

    private void AddToUI()
    {

        GameManager._instance.UIManager.UpdateExplicationText(_currentExplanationText._explainationText);
        GameManager._instance.UIManager.SetExplicationTextVisibility(true);


    }
}
