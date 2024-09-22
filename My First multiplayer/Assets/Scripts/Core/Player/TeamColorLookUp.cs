using UnityEngine;

[CreateAssetMenu(fileName = "NewTeamColourLookup", menuName = "Scriptable Objects/Team Colour Lookup")]
public class TeamColourLookup : ScriptableObject
{
    [SerializeField] private Color[] teamColours;

    public Color GetTeamColour(int teamIndex)
    {
        if (teamIndex < 0 || teamIndex >= teamColours.Length)
        {
            return Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
        else
        {
            return teamColours[teamIndex];
        }
    }
}


