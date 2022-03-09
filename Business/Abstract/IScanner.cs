using FieldscopeAssesment.Business.Concrete;

namespace FieldscopeAssesment.Business.Abstract;

public interface IScanner
{
    void FirstScanning(FieldRobot targetRobot);

    void LeftScanning(FieldRobot targetRobot);

    void RightScanning(FieldRobot targetRobot);
}