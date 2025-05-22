using UnityEngine;
using UnityEngine.UI;

public static class GetLevel
{
    public static int[] scoreLevels = { 100, 80, 50, 20, 0 };
    public static string[] levels = { "Perfect", "Great", "Good", "OK", "Miss" };

    public static void SetScoreLevel(int indexLevel, int score, string level)
    {
        score += scoreLevels[indexLevel];
        level = levels[indexLevel];
        //可以在这里添加相应等级动画
    }

    public static int GetSocre(float value)
    {
        if (value >= 0.823f && value <= 0.829f)
        {
            return 0;
        }
        else if (
            (value >= 0.775f && value < 0.823f)
            || (value >= 0.829f && value < 0.9f))
        {
            return 1;
        }
        else if ((value >= 0.7f && value < 0.775f)
            || (value >= 0.9f && value < 1f))
        {
            return 2;
        }
        else if (value >= 0.6f && value < 0.7f)
        {
            return 3;
        }
        else
        {
            return 4;
        }

    }

}
