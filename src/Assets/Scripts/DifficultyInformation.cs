using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DifficultyInformation
{
    static float secondsBeforeMaxDifficulty = 60f;

    public static float GetDifficultyPercentage() {
        return Mathf.Clamp01(Time.time / secondsBeforeMaxDifficulty);
    }
}
