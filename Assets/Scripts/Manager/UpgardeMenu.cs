using Assets.Scripts.Entity.Weapons;
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

    [SerializeField] float maxHP;
    [SerializeField] float maxRegen;
    [SerializeField] int maxWeapon;
    [SerializeField] float maxAtk;
    [SerializeField] float maxCrit;
    [SerializeField] float maxSpeed;

    [SerializeField] float baseCostHP;
    [SerializeField] float baseCostRegen;
    [SerializeField] float baseCostWeapon;
    [SerializeField] float baseCostAtk;
    [SerializeField] float baseCostCrit;
    [SerializeField] float baseCostSpeed;

    private float costHP;
    private float costRegen;
    private float costWeapon;
    private float costAtk;
    private float costCrit;
    private float costSpeed;

    private Image imageHP;
    private Image imageRegen;
    private Image imageAtk;
    private Image imageCrit;
    private Image imageSpeed;
    private Image imageWeapon;

    private bool firstTime = true;
    private void Start()
    {
        upgradeMenuUI.SetActive(true);
        upgradeMenuUI.transform.localScale = Vector3.zero;
        imageHP = GameObject.Find("HealthFillImage").GetComponent<Image>();
        imageRegen = GameObject.Find("RegenFillImage").GetComponent<Image>();
        imageWeapon = GameObject.Find("WeaponFillImage").GetComponent<Image>();
        imageAtk = GameObject.Find("AtkFillImage").GetComponent<Image>();
        imageCrit = GameObject.Find("CritFillImage").GetComponent<Image>();
        imageSpeed = GameObject.Find("SpeedFillImage").GetComponent<Image>();

        GameObject player = GameObject.FindWithTag("Player");
        imageHP.fillAmount = player.GetComponent<Player>().HP / maxHP;
        imageRegen.fillAmount = player.GetComponent<Player>().regen / maxRegen;
        imageWeapon.fillAmount = (countWeaponUpgrade + 1) / (float)(maxWeapon + 1);
        imageAtk.fillAmount = Weapon.ATK / maxAtk;
        imageCrit.fillAmount = Weapon.critRate / maxCrit;
        imageSpeed.fillAmount = maxSpeed / Shooting.cooldownTime;
    }
    private void OnEnable()
    {
        //if (firstTime)
        //{
        //    FirstTime();
        //}

    }
    private void Update()
    {
        if (imageHP == null)
        {
            imageHP = GameObject.Find("HealthFillImage").GetComponent<Image>();
        }
        if (imageRegen == null)
        {
            imageRegen = GameObject.Find("RegenFillImage").GetComponent<Image>();
        }
        if (imageWeapon == null)
        {
            imageWeapon = GameObject.Find("WeaponFillImage").GetComponent<Image>();
        }
        if (imageAtk == null)
        {
            imageAtk = GameObject.Find("AtkFillImage").GetComponent<Image>();
        }
        if (imageCrit == null)
        {
            imageCrit = GameObject.Find("CritFillImage").GetComponent<Image>();
        }
        if (imageSpeed == null)
        {
            imageSpeed = GameObject.Find("SpeedFillImage").GetComponent<Image>();
        }
        if (firstTime)
        {
            FirstTime();
        }
    }

    private void FirstTime()
    {
        costHP = baseCostHP;
        costRegen = baseCostRegen;
        costWeapon = baseCostWeapon;
        costAtk = baseCostAtk;
        costCrit = baseCostCrit;
        costSpeed = baseCostSpeed;
        GameObject.Find("HealthButtonText").GetComponent<Text>().text = costHP.ToString();
        GameObject.Find("RegenButtonText").GetComponent<Text>().text = costRegen.ToString();
        GameObject.Find("WeaponButtonText").GetComponent<Text>().text = costWeapon.ToString();
        GameObject.Find("AtkButtonText").GetComponent<Text>().text = costAtk.ToString();
        GameObject.Find("CritButtonText").GetComponent<Text>().text = costCrit.ToString();
        GameObject.Find("SpeedButtonText").GetComponent<Text>().text = costSpeed.ToString();
        firstTime = false;
    }

    public void Resume()
    {
        upgradeMenuUI.transform.localScale = Vector3.zero;
        //upgradeMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }

    public void Upgrade()
    {
        upgradeMenuUI.transform.localScale = Vector3.one;
        //upgradeMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }

    public void UpgadeHealth()
    {
        GameObject text = GameObject.Find("HealthButtonText");
        GameObject player = GameObject.FindWithTag("Player");
        if (player.GetComponent<Player>().HP < maxHP)
        {
            player.GetComponent<Player>().HP += 500;
            costHP += baseCostHP;
            text.GetComponent<Text>().text = costHP.ToString();
        }
        if (player.GetComponent<Player>().HP == maxHP)
        {
            text.GetComponent<Text>().text = "Max";
        }
        imageHP.fillAmount = player.GetComponent<Player>().HP / maxHP;
    }

    public void UpgradeRegen()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player.GetComponent<Player>().regen < maxRegen)
        {
            player.GetComponent<Player>().regen += 30;
            costRegen += baseCostRegen;
            GameObject.Find("RegenButtonText").GetComponent<Text>().text = costRegen.ToString();
        }
        if (player.GetComponent<Player>().regen == maxRegen)
        {
            GameObject text = GameObject.Find("RegenButtonText");
            text.GetComponent<Text>().text = "Max";
        }
        imageRegen.fillAmount = player.GetComponent<Player>().regen / maxRegen;
    }

    public void UpradeWeapon()
    {
        GameObject text = GameObject.Find("WeaponButtonText");
        if (countWeaponUpgrade < maxWeapon)
        {
            weapons[countWeaponUpgrade].SetActive(true);
            countWeaponUpgrade++;
            costWeapon += baseCostWeapon;
            text.GetComponent<Text>().text = costWeapon.ToString();
        }
        if (countWeaponUpgrade == maxWeapon)
        {
            text.GetComponent<Text>().text = "Max";
        }
        imageWeapon.fillAmount = (float)(countWeaponUpgrade + 1) / (float)(maxWeapon + 1);
    }

    public void UpgradeSpeed()
    {
        GameObject text = GameObject.Find("SpeedButtonText");
        if (Shooting.cooldownTime > maxSpeed)
        {
            Shooting.cooldownTime -= (float)0.2;
            costSpeed += baseCostSpeed;
            text.GetComponent<Text>().text = costSpeed.ToString();
        }
        if (Shooting.cooldownTime == maxSpeed)
        {
            text.GetComponent<Text>().text = "Max";
        }
        imageSpeed.fillAmount = maxSpeed / Shooting.cooldownTime;
    }

    public void UpgradeAtk()
    {
        GameObject text = GameObject.Find("AtkButtonText");
        if (Weapon.ATK < maxAtk)
        {
            Weapon.ATK += 100;
            costAtk += baseCostAtk;
            text.GetComponent<Text>().text = costAtk.ToString();
        }
        if (Weapon.ATK == maxAtk)
        {
            text.GetComponent<Text>().text = "Max";
        }
        imageAtk.fillAmount = Weapon.ATK / maxAtk;
    }

    public void UpgradeCrit()
    {
        GameObject text = GameObject.Find("CritButtonText");
        if (Weapon.critRate < maxCrit)
        {
            Weapon.critRate += 1;
            costCrit += baseCostCrit;
            text.GetComponent<Text>().text = costCrit.ToString();
        }
        if (Weapon.critRate == maxCrit)
        {
            text.GetComponent<Text>().text = "Max";
        }
        imageAtk.fillAmount = Weapon.critRate / maxCrit;
    }
}
