using UnityEngine;
using Zenject;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerMovement playerMovement;
    [Inject]
    public void Construct(Player player, PlayerMovement playerMovement)
    {
        this.player = player;
        this.playerMovement = playerMovement; 
    }
    void Start()
    {
        player.Attack += CheckAttack;
        player.Attack1 += CheckAttack1;
        player.Module1 += CheckModule1;
        player.Module2 += CheckModule2;
        player.Module3 += CheckModule3;
        player.Module4 += CheckModule4;
    
        playerMovement.OnJumpInput += CheckJump;
        playerMovement.OnMoveInput += CheckMove;
    }
    public void StartTutorial()
    {
        // Start tutorial logic here
    }

    public void EndTutorial()
    {
        // Unsubscribe from events to avoid memory leaks
        player.Attack -= CheckAttack;
        player.Attack1 -= CheckAttack1;
        player.Module1 -= CheckModule1;
        player.Module2 -= CheckModule2;
        player.Module3 -= CheckModule3;
        player.Module4 -= CheckModule4;

        Destroy(gameObject);
    }
    private void CheckMove(){
        Debug.Log("Move triggered in tutorial.");
    }
    private void CheckJump(){
        Debug.Log("Jump triggered in tutorial.");
    }
    private void CheckAttack()
    {
        Debug.Log("Attack triggered in tutorial.");
    }

    private void CheckAttack1()
    {
        Debug.Log("Attack1 triggered in tutorial.");
    }

    private void CheckModule1()
    {
        Debug.Log("Module1 used in tutorial.");
    }

    private void CheckModule2()
    {
        Debug.Log("Module2 used in tutorial.");
    }

    private void CheckModule3()
    {
        Debug.Log("Module3 used in tutorial.");
    }

    private void CheckModule4()
    {
        Debug.Log("Module4 used in tutorial.");
    }
}
