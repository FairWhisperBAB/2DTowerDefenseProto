using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _infoText;
    [SerializeField] private TMP_Text _towerName;
    [SerializeField] private TMP_Text _towerCost;
    [SerializeField] private TMP_Text _towerDescription;

    [SerializeField] private TextMeshProUGUI _startBtn;

    // Start is called before the first frame update
    void Start()
    {
        HideTowerInformation();
    }

    public void ShowTowerInformation(Towers TowerInformation)
    {
        _infoText.SetActive(true);

        _towerName.text = TowerInformation.Name;
        _towerCost.text = $"Cost: {TowerInformation.Cost.ToString()}";
        _towerDescription.text = TowerInformation.Description;
    }

    public void HideTowerInformation()
    {
        _towerName.text = "";
        _towerCost.text = "";
        _towerDescription.text = "";

        _infoText.SetActive(false);
    }

    public void StartWave()
    {
        Debug.Log("WAVE HAS STARTED!!");
    }

}
