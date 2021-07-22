using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScreen : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    public void UpdateScoreTXT(float score)
    {
        textMesh.text = score.ToString();
    }

}
