# Control-System-Simulator
## Intro

This library is an implementation of simple dynamic systems simulator. It defines 4 types of systems' structures: bare system, open loop, close loop and control system (it switches between close loop and bare system modes). It contains also:
  - controllers: P, PID, Relay with hysteresis
  - models (continous and discrete) defined as a set of differential (difference) equations, transfer function or as state space model
  - differential equations integration with solvers like Euler, Runge-Kutty, Adams-Bashforth
  - signal generators: set of steps values; sine, square, triangle, saw signals

## How to use it?

To perform simulation you need to follow a few steps:
  - define your systems model (continous or dicrete, must implement IContinousModel or IDiscreteModel)
  - create system from model (can contain transport delay, define initial state and solver if continous); must implement ISystem
  - create loop (bare system, open loop: controller + system without feedback, close loop: controller + system with feedback, control system: contains close loop and bare system inside); loops implements ILoop interface
  - use Simulate class to perform step simulation (or use signal generator)
  
## Examples
###### Example setup
```cs
using JTControlSystem;
using JTControlSystem.Controllers;
using JTControlSystem.Models;
using JTControlSystem.SignalGenerators;
using JTControlSystem.Solvers;
using JTControlSystem.Systems;
using JTMath;

namespace ConsoleApp1
{
  class Program
  {
    static void Main(string[] args)
    {
      // model definition as state space equations
      var A = new Matrix(new double[,] { { 0d, 1d }, { -2d, -3d } });
      var B = new Vector(new double[] { 0, 4 });
      var C = new Vector(new double[] { 1, 0 });
      var D = 0d;
      IContinousModel model = new StateSpaceModel(A, B, C, D);
      // initial state - watch out on Vectors' sizes!
      var initialState = new Vector(new double[] { 1d, 0d });

      // use Runge-Kutty 4th solver
      ISolver solver = new SolverRK4();

      // create continous system from above components
      ISystem system = new ContinousSystem(model, solver, initialState);

      // structure with system itself
      var bareSystem = new BareSystem(system);

      // use step series as input
      ISignalGenerator steps = new StepsGenerator(new double[] { 0d, 5d, 10d }, new double[] { 2d, -2d, 2d });

      // simulation
      Simulate.Signal(bareSystem, 15d, 0.01d, steps);

      // write data to file
      FileWriter.ToFile(bareSystem.Data, @"C://bareSystem.txt");


      // add controller
      IController controller = new PID(4.2382d, 1.5278d, 0.1868d);

      // structure with system and controller with feedback
      var closeLoop = new CloseLoop(system, controller);

      // simulation
      Simulate.Signal(closeLoop, 15d, 0.01d, steps);

      // write data to file
      FileWriter.ToFile(closeLoop.Data, @"C://closeLoop.txt");
    }
  }
}
```

###### Bare system
```CSharp
IContinousModel model = new ContinousSecondOrder(2d, 1d, 3d);
ISystem system = new ContinousSystem(model, new SolverRK4(), Vector.Zeros(2));
BareSystem loop = new BareSystem(system);
Simulate.Step(loop, 10d, 0.01d);

var result = loop.Data;
```

###### Open loop
```CSharp
IContinousModel model = new ContinousSecondOrder(2d, 1d, 3d);
ISystem system = new ContinousSystem(model, new SolverRK4(), Vector.Zeros(2));
IController controller = new P(2d);
OpenLoop loop = new OpenLoop(system, controller);
Simulate.Step(loop, 10d, 0.01d);

var result = loop.Data;
```

###### Close loop
```CSharp
IContinousModel model = new ContinousSecondOrder(2d, 1d, 3d);
ISystem system = new ContinousSystem(model, new SolverRK4(), Vector.Zeros(2));
IController controller = new P(2d);
CloseLoop loop = new CloseLoop(system, controller);
Simulate.Step(loop, 10d, 0.01d);

var result = loop.Data;
```

###### Control system
```CSharp
IContinousModel model = new ContinousSecondOrder(2d, 1d, 3d);
ISystem system = new ContinousSystem(model, new SolverRK4(), Vector.Zeros(2));
IController controller = new P(2d);
ControlSystem loop = new ControlSystem(system, controller);
loop.mode = ControlSystemMode.CloseLoop;

Simulate.Step(loop, 10d, 0.01d, (iteration, time) =>
{
    // do something at specific time or iteration
    // for example: change mode to OpenLoop
});

var result = loop.Data;
```

To see more examples, check JTControlSystemExamples project or check this video:

[![JTControlSystemExamples](https://img.youtube.com/vi/-hzSQBJQrNg/0.jpg)](https://www.youtube.com/watch?v=-hzSQBJQrNg)

## Project parts

Project is splitted into several parts:
  - JTMath - provides Vector and Matrix objects
  - JTControlSystem - contains all systems, controllers, signal generators, models and utilities
  - JTControlSystemChart - contains Chart wrapper which displays Control System output, used in Offline and Realtime simulators
  - JTControlSystemExamples - simple WinForms application which shows how to use Control System's components
  - SolversTest - performs solvers comparison (performance and accuracy)
  - OfflineSimulator - WinForms application which simulates Control System in given time horizon (defined in SystemAndController class)
  - RealtimeSimulator - WinForms application which simulates Control System in real time. It uses MicroTimer library - [MicroLibrary](https://www.codeproject.com/Articles/98346/Microsecond-and-Millisecond-NET-Timer)
  
## OfflineSimulator

Perfoms simulation for defined system and controller. You can define some parameters:
  - time step, time horizon, points per second
  - mode: close or open loop
  - input: steps, sine, saw, triangle, square with given parameters like frequency etc.

You can also save generated data to file.
  
To see how it works, see this video:

[![Offline Simulator](https://img.youtube.com/vi/eZBIIx9ZL-U/0.jpg)](https://www.youtube.com/watch?v=eZBIIx9ZL-U)

## RealtimeSimulator

Performs simulation in realtime. You can tune parameters like:
  - input type (generator or manual sliders)
  - control system mode (open, close)
  - see the code, you can tune simulation step and UI refresh step

To see how it works take a look at this video:

[![Realtime Simulator](https://img.youtube.com/vi/k_87pImObNM/0.jpg)](https://www.youtube.com/watch?v=k_87pImObNM)

## SolversTest

To test solvers performance and accuracy, SolversTest project was created. You can define your own differential equation to check which solver is better. Example result are shown below:

[![solvers test](http://jtjt.pl/www/pages/symulator-obiektow-dynamicznych/symulator_obiektow_1.png)]
