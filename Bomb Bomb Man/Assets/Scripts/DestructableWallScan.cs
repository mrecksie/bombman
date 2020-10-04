using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableWallScan : MonoBehaviour
{
    public List<GameObject> gameObjectsAround = new List<GameObject>();
    Movement player;
    private void Awake()
    {
        player = FindObjectOfType<Movement>();
        player.OnExplosion += KillAll; // When player explodes anything in the radius will get destroyed
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != null)
        {
            gameObjectsAround.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObjectsAround.Remove(collision.gameObject);
    }

    private void KillAll()
    {
        foreach (GameObject _gameObject in gameObjectsAround)
        {

            if (_gameObject != null)
            {
                IExplode destructable = _gameObject.GetComponent<IExplode>();
                if (destructable != null)
                {
                    destructable.OnExplode((Vector2)this.transform.position);
                }
            }
        }

    }
}

public interface IExplode
{
    void OnExplode(Vector2 explosionLocation);
}
