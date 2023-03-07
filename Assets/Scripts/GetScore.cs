using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("goalsScored").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
