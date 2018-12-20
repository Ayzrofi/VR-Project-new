using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int P_health;
    [SerializeField]
    int P_currentHealth;
    [SerializeField]
    Text P_HealthTxt;
    [SerializeField]
    Slider P_HealthBar;
    public Animation P_anim;

    public AudioSource PlayerSound;
    public AudioClip PlayerHurt;

    private void Awake()
    {
        //P_anim = GetComponent<Animation>();
        P_currentHealth = P_health;
        P_HealthTxt.text =  P_currentHealth + " %";
        P_HealthBar.maxValue = P_currentHealth;
        P_HealthBar.value = P_currentHealth;

    }
    public void Damage(int Dmg)
    {
        P_anim.Play("P_kenaHit");
        PlayerSound.PlayOneShot(PlayerHurt);
        P_currentHealth -= Dmg;
        P_HealthTxt.text = P_currentHealth + " %";
        P_HealthBar.value = P_currentHealth;
        if (P_currentHealth <= 0)
			SceneManager.LoadScene("Dead_Menu");
    }
    public void TambahDarah(int HealthPoint)
    {
        P_currentHealth += HealthPoint;
        P_HealthTxt.text = P_currentHealth + " %";
        P_HealthBar.value = P_currentHealth;
        if (P_currentHealth >= P_health)
        {
            P_currentHealth = P_health;
            P_HealthTxt.text = P_currentHealth + " %";
            P_HealthBar.value = P_currentHealth;
        }
    }
}
