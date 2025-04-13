public interface IOperationalStrategy 
{
    float Calculate(float value);
}

public class AddOperation : IOperationalStrategy{
    readonly float value;

    public AddOperation(float value){
        this.value = value;
    }
    public float Calculate(float value) => value + this.value;
}
public class MultiplyOperation : IOperationalStrategy{
    readonly float value;

    public MultiplyOperation(float value){
        this.value = value;
    }
    public float Calculate(float value) => value * this.value;
}