using UnityEngine;

public class Escudo : MonoBehaviour
{
    void OnTriggerExit(Collider outro)
    {
        if (outro.gameObject.CompareTag("Obstaculo"))
        {
            Player.player.shield = false;
            this.gameObject.SetActive(false);
        }
    }
}
