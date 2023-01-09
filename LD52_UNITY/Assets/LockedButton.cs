using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedButton : MonoBehaviour
{
    public Image LockImage;
    public string PrefsName, UnlocksPrefsName;
    public bool StartsUnlocked;

    // Start is called before the first frame update
    void Start()
    {
        if (StartsUnlocked)
        {
            PlayerPrefs.SetInt(PrefsName, 1);
        }
        bool unlocked = PlayerPrefs.GetInt(PrefsName) == 1;
        if (unlocked)
        {
            Destroy(LockImage.gameObject);
        }
        GetComponent<Button>().interactable = unlocked;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UnlockNext()
    {
        PlayerPrefs.SetInt(UnlocksPrefsName, 1);
    }
}
