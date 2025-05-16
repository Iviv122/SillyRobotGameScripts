
public class OnDeath : Trigger 
{
    LevelEndBroadCast levelEndBroadCast;
    public void Construct(LevelEndBroadCast levelEndBroadCast){
        this.levelEndBroadCast = levelEndBroadCast;
    }
    void Start()
    {
        levelEndBroadCast.Subscribe();
    }
    void OnDestroy()
    {
        levelEndBroadCast.UnSubscribe();
        Triggered();
    }
}
