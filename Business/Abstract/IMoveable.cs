using FieldscopeAssesment.Business.Concrete;

namespace FieldscopeAssesment.Business.Abstract;

public interface IMoveable
{
    void MoveLeft(int movesNumber, int stepsCount, FieldRobot targetRobot);

    void MoveRight(int movesNumber, int stepsCount, FieldRobot targetRobot);

    void ResetLocation();

    void MoveWithoutScanning(int movesNumber);
}
