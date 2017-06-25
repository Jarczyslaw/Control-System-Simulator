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

[![OfflineSimulator](https://img.youtube.com/vi/eZBIIx9ZL-U/0.jpg)](https://www.youtube.com/watch?v=eZBIIx9ZL-U)

## RealtimeSimulator

Performs simulation in realtime. You can specify some parameters like input source, input type or current ControlSystem's mode. To see how it works take a look at this video:

[![RealtimeSimulator](https://img.youtube.com/vi/k_87pImObNM/0.jpg)](https://www.youtube.com/watch?v=k_87pImObNM)
