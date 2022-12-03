using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExplainationText : MonoBehaviour
{
    [SerializeField]
    [TextArea]
    public string _explainationText = null;

    private void OnTriggerEnter(Collider other)
    {
        PlayerManager player = other.GetComponentInParent<PlayerManager>();
        ExplanationManager explanation = other.GetComponentInParent<ExplanationManager>();

        if (player != null && explanation != null)
        {
            explanation.AddToExplanationList(this);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        PlayerManager player = other.GetComponentInParent<PlayerManager>();
        ExplanationManager explanation = other.GetComponentInParent<ExplanationManager>();

        if (player != null && explanation != null)
        {
            explanation.RemoveToExplanationList(this);
        }
    }
}
