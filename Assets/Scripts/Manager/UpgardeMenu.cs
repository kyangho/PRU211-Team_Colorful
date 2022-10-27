using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgardeMenu : MonoBehaviour
{
    public static bool isPause = false;

    private int countWeaponUpgrade = 0;

    public GameObject[] weapons; 

    public GameObject upgradeMenuUI;

    public void Resume()
    {
        upgradeMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }

    public void Upgrade()
    {
        upgradeMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }

    public void UpgadeHealth()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>().HP += (int)player.GetComponent<Player>().HP * 10 / 100;
        if(player.GetComponent<Player>().HP > 10000)
        {
            player.GetComponent<Player>().HP = 10000;
            GameObject text = GameObject.Find("HealthButtonText");
            text.GetComponent<Text>().text = "Max";
        }
    }

    public void UpgradeRegen()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player.GetComponent<Player>().regen <= 300)
        {
            player.GetComponent<Player>().regen += 30;
        }
        else
        {
            GameObject text = GameObject.Find("RegenButtonText");
            text.GetComponent<Text>().text = "Max";
        }
    }

    public void UpradeWeapon()
    {
        if (countWeaponUpgrade < 5)
        {
            weapons[countWeaponUpgrade].SetActive(true);
            countWeaponUpgrade++;
        }
        if(countWeaponUpgrade == 5)
        {
            GameObject text = GameObject.Find("WeaponButtonText");
            text.GetComponent<Text>().text = "Max";
        }
    }

    public void UpgradeSpeed()
    {

    }

    public void UpgradeAtk()
    {

    }

    public void UpgradeCrit()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
