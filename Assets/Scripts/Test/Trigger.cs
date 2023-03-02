using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    int _hp = 3;
    [SerializeField] GameObject _hptext;

    private void OnTriggerEnter(Collider other)
    {
        if (_hp == 1)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            _hp--;
            _hptext.GetComponent<TextMeshProUGUI>().text = "Жизни: " + _hp;
            Destroy(other.gameObject);
        }
    }
}
