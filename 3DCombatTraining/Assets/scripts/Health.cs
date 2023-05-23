using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    #region Variables
    public int maxHealth;
    public int currentHealth;
    #endregion

    public void ChangeHealth(int damage)
    {
        //Health goes up or down
        currentHealth = currentHealth + damage;
        Debug.Log($"{gameObject.name} took {damage} damage!");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Compare the tag against several cases
        switch (gameObject.tag)
        {
            // If the Player just died...
            case ("Player"): 
                Debug.Log("Player has died");
                // Disable the player
                gameObject.SetActive(false);
                // Tell the Game Manager to reset the level
                FindObjectOfType<GameManager>().EndGame();
                break;
            // If an Enemy just died...
            case ("Enemy"):
                Debug.Log("Enemy has died");
                // Destroy the enemy
                Destroy(gameObject);
                break;
        }
    }
}
