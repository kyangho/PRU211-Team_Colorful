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

    [SerializeField] float maxHP = 10000;
    [SerializeField] float maxRegen = 300;
    [SerializeField] int maxWeapon = 5;
    [SerializeField] float maxAtk = 10f;
    [SerializeField] float maxCrit = 10f;
    [SerializeField] float maxSpeed = 10f;

    private Image imageHP;
    private Image imageRegen;
    private Image imageAtk;
    private Image imageCrit;
    private Image imageSpeed;
    private Image imageWeapon;

    //float originHP;

    private void Start()
    {
        imageHP = GameObject.Find("HealthFillImage").GetComponent<Image>();
        imageRegen = GameObject.Find("RegenFillImage").GetComponent<Image>();
        imageWeapon = GameObject.Find("WeaponFillImage").GetComponent<Image>();
        imageAtk = GameObject.Find("AtkFillImage").GetComponent<Image>();
        imageCrit = GameObject.Find("CritFillImage").GetComponent<Image>();
        imageSpeed = GameObject.Find("SpeedFillImage").GetComponent<Image>();

        //originHP = GameObject.FindWithTag("Player").GetComponent<Player>().HP;

        GameObject player = GameObject.FindWithTag("Player");
        imageHP.fillAmount = player.GetComponent<Player>().HP / maxHP;
        imageRegen.fillAmount = player.GetComponent<Player>().regen / maxRegen;
        imageWeapon.fillAmount = (countWeaponUpgrade + 1) / (float)(maxWeapon + 1);
        imageAtk.fillAmount = 0f;
        imageCrit.fillAmount = 0f;
        imageSpeed.fillAmount = 0f;
    }

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
        //Debug.Log(player.GetComponent<Player>().HP);
        player.GetComponent<Player>().HP *= 1.1f;
        if (player.GetComponent<Player>().HP > maxHP)
        {
            player.GetComponent<Player>().HP = maxHP;
            GameObject text = GameObject.Find("HealthButtonText");
            text.GetComponent<Text>().text = "Max";
        }
        imageHP.fillAmount = player.GetComponent<Player>().HP / maxHP;
        //Debug.Log(imageHP.fillAmount);
    }

    public void UpgradeRegen()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player.GetComponent<Player>().regen <= maxRegen)
        {
            player.GetComponent<Player>().regen += 30;
        }
        else
        {
            GameObject text = GameObject.Find("RegenButtonText");
            text.GetComponent<Text>().text = "Max";
        }
        imageRegen.fillAmount = player.GetComponent<Player>().regen / maxRegen;
    }

    public void UpradeWeapon()
    {
        if (countWeaponUpgrade < maxWeapon)
        {
            weapons[countWeaponUpgrade].SetActive(true);
            countWeaponUpgrade++;
        }
        if (countWeaponUpgrade == maxWeapon)
        {
            GameObject text = GameObject.Find("WeaponButtonText");
            text.GetComponent<Text>().text = "Max";
        }
        //Debug.Log(countWeaponUpgrade + "\t" + maxWeapon);
        imageWeapon.fillAmount = (float)(countWeaponUpgrade + 1) / (float)(maxWeapon + 1);
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
