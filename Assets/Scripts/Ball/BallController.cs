using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject BallPref;
    public Transform PossSpawn;
    public Gameplayer Gameplayer;
    private Ball _player;

    public void Spawn()
    {
        GameObject go =
            Instantiate(BallPref, PossSpawn.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        Ball ball = go.GetComponent<Ball>();
        _player = ball;
        Gameplayer.PauseManager.Register(ball);
    }

    public Ball GetPlayer()
    {
        return _player;
    }

    public void Reset()
    {
        if (_player == null) return;
        Gameplayer.PauseManager.Unregister(_player);
        Destroy(_player.gameObject);
    }

    public void Respawn()
    {
        Gameplayer.PauseManager.Unregister(_player);
        Destroy(_player.gameObject);
        Spawn();
    }
}