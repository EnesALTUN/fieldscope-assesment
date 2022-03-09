using FieldscopeAssesment.Business.Abstract;
using FieldscopeAssesment.Entities.Enum;

namespace FieldscopeAssesment.Business.Concrete;

public class FieldRobot : IMoveable, IScanner
{
    public FieldRobot()
    {
        Random randomGenerator = new();

        Location = randomGenerator.Next(-100000, 100000);
        LandingLocation = Location;

        Console.WriteLine($"{RobotCount++}. robot start location: {Location}");
    }

    private static int RobotCount = 1;

    public int Location { get; set; }

    public int LandingLocation { get; }

    public bool IsFoundParachute { get; set; } = false;

    public bool IsFoundRobot { get; set; } = false;

    public MoveDirection FoundParachuteDirection { get; set; } = MoveDirection.None;

    public void MoveLeft(int movesNumber, int stepsCount, FieldRobot targetRobot)
    {
        ResetLocation();

        MoveWithoutScanning((movesNumber * -1) + stepsCount);

        if (!FoundParachuteDirection.Equals(MoveDirection.Right))
        {
            for (int i = 0; i < movesNumber; i++)
            {
                Location--;
                LeftScanning(targetRobot);

                if (IsFoundRobot)
                    break;
            }
        }
    }

    public void MoveRight(int movesNumber, int stepsCount, FieldRobot targetRobot)
    {
        ResetLocation();

        MoveWithoutScanning(movesNumber - stepsCount);

        if (!FoundParachuteDirection.Equals(MoveDirection.Left))
        {
            for (int i = 0; i < movesNumber; i++)
            {
                Location++;
                RightScanning(targetRobot);

                if (IsFoundRobot)
                    break;
            }
        }
    }

    public void ResetLocation()
    {
        Location = LandingLocation;
    }

    public void MoveWithoutScanning(int movesNumber)
    {
        Location += movesNumber;
    }

    public void FirstScanning(FieldRobot targetRobot)
    {
        LeftScanning(targetRobot);

        if (!IsFoundRobot)
            RightScanning(targetRobot);
    }

    public void LeftScanning(FieldRobot targetRobot)
    {
        if ((Location - 1).Equals(targetRobot.Location))
        {
            targetRobot.IsFoundRobot = true;
            IsFoundRobot = true;
        }
        if ((Location - 1).Equals(targetRobot.LandingLocation))
        {
            IsFoundParachute = true;
            FoundParachuteDirection = MoveDirection.Left;
        }
    }

    public void RightScanning(FieldRobot targetRobot)
    {
        if ((Location + 1).Equals(targetRobot.Location))
        {
            targetRobot.IsFoundRobot = true;
            IsFoundRobot = true;
        }
        if ((Location + 1).Equals(targetRobot.LandingLocation))
        {
            IsFoundParachute = true;
            FoundParachuteDirection= MoveDirection.Right;
        }
    }
}