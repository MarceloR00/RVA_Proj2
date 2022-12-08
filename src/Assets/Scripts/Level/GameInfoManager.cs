using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameInfoManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI remaining_mirrors;

    int mirrors_detected = 0;

    public void MirrorDetected() {
        int current_number_of_mirrors = GetCurrentNumberOfMirrors();
        current_number_of_mirrors -= 1;
        UpdateText(current_number_of_mirrors);

        mirrors_detected += 1;
    }

    public void MirrorUndetected() {
        if (mirrors_detected <= 0) return;

        int current_number_of_mirrors = GetCurrentNumberOfMirrors();
        current_number_of_mirrors += 1;
        UpdateText(current_number_of_mirrors);

        mirrors_detected -= 1;
    }

    void UpdateText(int number_of_mirrors) {
        int index_of_colon = remaining_mirrors.text.IndexOf(":");
        string default_text = remaining_mirrors.text.Substring(0, index_of_colon + 2);
        remaining_mirrors.text = default_text + number_of_mirrors.ToString();
    }

    int GetCurrentNumberOfMirrors() {
        int index_of_colon = remaining_mirrors.text.IndexOf(":");
        string number_of_mirrors = remaining_mirrors.text.Substring(index_of_colon + 2);
        return int.Parse(number_of_mirrors);
    }
}
