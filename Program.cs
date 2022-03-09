using FieldscopeAssesment.Business.Concrete;
using System.Diagnostics;

Stopwatch timer = new();
timer.Start();

int countOfDirectionChanges = 1;
int stepsCount = 20;

FieldRobot robot1 = new();
FieldRobot robot2 = new();

robot1.FirstScanning(robot2);

while(!robot1.IsFoundRobot)
{
    int movesNumber = stepsCount * countOfDirectionChanges;

    robot1.MoveLeft(movesNumber, stepsCount, robot2);

    if (!robot1.IsFoundRobot)
    {
        robot2.MoveRight(movesNumber, stepsCount, robot1);
    }

    if (!robot2.IsFoundRobot)
    {
        robot1.MoveRight(movesNumber, stepsCount, robot2);

        if (!robot1.IsFoundRobot)
        {
            robot2.MoveLeft(movesNumber, stepsCount, robot1);
        }
    }
    countOfDirectionChanges++;
}

timer.Stop();
Console.WriteLine($"\nRobot is found {timer.Elapsed.Seconds} seconds {timer.Elapsed.Milliseconds} miliseconds");