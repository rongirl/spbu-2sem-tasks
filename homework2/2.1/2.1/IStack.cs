namespace Task2_1;

public interface IStack
{
    void Push(double value);

    double Pop();

    bool IsEmpty();
}