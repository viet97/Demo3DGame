using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBattle : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    Player player1;
    Player player2;
    private State state;
    private enum State
    {
        WaitingForPlayer,
        Busy,
    }
    // Start is called before the first frame update
    void Start()
    {
      player1 = Instantiate(playerTransform, new Vector3(-5,5, 0), Quaternion.identity).GetComponent<Player>();
      player2 = Instantiate(playerTransform, new Vector3(5, 5, 0), Quaternion.identity).GetComponent<Player>();
      state = State.WaitingForPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onAttackPress()
    {
        player1.Attack(player2.transform.position,(int dame)=> {
            Debug.Log("player2.Damage"+ dame);
            player2.Damage(dame);
        });
        Debug.Log("onAttackPress");
    }
}
