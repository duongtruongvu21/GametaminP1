using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalNumberOnclick : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => OnClickNumber());
    }
    public void OnClickNumber()
    {
        string value = gameObject.GetComponentInChildren<TMP_Text>().text;
        AppController.Instance.AddNumber(value);
    }
}
