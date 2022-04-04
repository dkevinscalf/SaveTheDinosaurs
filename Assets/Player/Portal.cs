using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public void MoveShip()
    {
        var player = FindObjectOfType<PlayerTurret>();
        Destroy(player.gameObject);
    }

    public void SelfDestruct()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("Lab");
    }
}
