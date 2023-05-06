using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject UiNextLevel;
    FixedPoint[] fixedPoints;
    public bool BallStartMove = false;
    private void Start()
    {
        fixedPoints = FindObjectsOfType<FixedPoint>();
    }
    public void CheckColorsMatch()
    {
        foreach (var item in fixedPoints)
        {
            var ballColor = item.GetFreeBall().GetColor();

            foreach (var connector in item.GetConnectors())
            {
                var connectorColor = connector.GetFreeBall().GetColor();
                if (ballColor == connectorColor)
                {
                    return; // exit early if colors match
                }
            }
        }
        UiNextLevel.SetActive(true);
    }

}
