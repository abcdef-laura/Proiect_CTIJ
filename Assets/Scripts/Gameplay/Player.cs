using Platformer.Mechanics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(18);
        HealthManager.health=3;
        PlayerManager.isGameOver=false;
    }
}
