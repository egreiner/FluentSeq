# FluentSeq

FluentSeq provides a fluent interface for creating easy-to-read sequences, 
eliminating the need for lengthy if/else statements.  
The library is written in C# 13 and multi-targets
- .NET 6.0 - .NET 9.0
- .NET Standard 2.0/2.1  

The library allows you to configure:  

- Sequences with States  
- different kinds of State-Triggers  
- Actions that can be executed on State-Entry, State-Exit or WhileInState    
- Validate a sequence on build to avoid misconfigurations (missing states, triggers, etc.)  

The Test coverage for .NET 6.0 - 9.0 is greater than 95%  

FluentSeq is the successor of [IegTools.Sequencer](https://github.com/egreiner/IegTools.Sequencer).  


### Build Status  
&nbsp; ![workflow tests](https://github.com/egreiner/FluentSeq/actions/workflows/run-tests.yml/badge.svg)  


# Table of Contents
[Installation](#installation)  
[Usage](#usage)  
[States](#states)  
[Trigger](#trigger)  
[Actions](#actions)  
[Validation](#sequence-validation)  
[Version Changes](#version-changes)  
[Breaking Changes](#breaking-changes)  
[Preview next Version v2.0](#preview-next-version-v2)  


# Installation
The library is available as a [NuGet package](https://www.nuget.org/packages/FluentSeq/).



# Usage
## Configure, build and run a sequence  
### Create a sequence in a compact style  

A simple example configuration and usage for an OnTimer-sequence as xUnit-Test:  

``` c#
using FluentSeq.Builder;
using FluentSeq.Core;

public class OnTimerCreateExampleTests
{
    private ISequence<TimerState>? _sequence;
    private bool _onTimerInput;


    private ISequenceBuilder<TimerState> GetOnTimerConfiguration(int dwellTimeInMs) =>
        new FluentSeq<TimerState>().Create(TimerState.Off)
            .ConfigureState(TimerState.Off)
                .TriggeredBy(() => !_onTimerInput)
            .ConfigureState(TimerState.Pending)
                .TriggeredBy(() => _onTimerInput)
                    .WhenInState(TimerState.Off)
            .ConfigureState(TimerState.On)
                .TriggeredBy(() => _onTimerInput)
                    .WhenInState(TimerState.Pending, () => TimeSpan.FromMilliseconds(dwellTimeInMs))
            .Builder();

    [Theory]
    [InlineData(false, 9, 0, TimerState.Off, TimerState.Off)]
    [InlineData(false, 9, 0, TimerState.Pending, TimerState.Off)]
    [InlineData(false, 9, 0, TimerState.On, TimerState.Off)]

    [InlineData(false, 1, 2, TimerState.Off, TimerState.Off)]
    [InlineData(false, 1, 2, TimerState.Pending, TimerState.Off)]
    [InlineData(false, 1, 2, TimerState.On, TimerState.Off)]

    [InlineData(true, 9, 0, TimerState.Off, TimerState.Pending)]
    [InlineData(true, 9, 0, TimerState.Pending, TimerState.Pending)]
    [InlineData(true, 9, 0, TimerState.On, TimerState.On)]

    [InlineData(true, 1, 2, TimerState.Off, TimerState.Pending)]
    [InlineData(true, 1, 2, TimerState.Pending, TimerState.On)]
    [InlineData(true, 1, 2, TimerState.On, TimerState.On)]
    public async Task Example_Usage_OnTimerConfiguration_Run_async(bool timerInput, int dwellTimeInMs, int sleepTimeInMs, TimerState currentState, TimerState expectedState)

    {
        _sequence     = GetOnTimerConfiguration(dwellTimeInMs).Build();
        _onTimerInput = timerInput;

        _sequence.SetState(currentState);

        await Task.Delay(sleepTimeInMs);
        await _sequence.RunAsync();

        var actual = _sequence.CurrentState;
        actual.ShouldBe(expectedState);
    }
}
```

[Top 🠉](#table-of-contents)


### Configure a sequence in a detailed style

A simple example configuration and usage for an OffTimer-sequence as xUnit-Test:  

``` c#
using FluentSeq.Builder;
using FluentSeq.Core;

public class OffTimerConfigureExampleTests
{
    private ISequence<TimerState>? _sequence;
    private bool _onTimerInput;


    private ISequenceBuilder<TimerState> GetOffTimerConfiguration(int dwellTimeInMs) =>
        new FluentSeq<TimerState>().Configure(TimerState.Off, builder =>
        {
            builder.ConfigureState(TimerState.On)
                .TriggeredBy(() => _onTimerInput);

            builder.ConfigureState(TimerState.Pending)
                .TriggeredBy(() => !_onTimerInput)
                    .WhenInState(TimerState.On);

            builder.ConfigureState(TimerState.Off)
                .TriggeredBy(() => !_onTimerInput)
                    .WhenInState(TimerState.Pending, () => TimeSpan.FromMilliseconds(dwellTimeInMs));
        }).Builder();


    [Theory]
    [InlineData(true, 9, 0, TimerState.Off, TimerState.On)]
    [InlineData(true, 9, 0, TimerState.Pending, TimerState.On)]
    [InlineData(true, 9, 0, TimerState.On, TimerState.On)]

    [InlineData(true, 1, 2, TimerState.Off, TimerState.On)]
    [InlineData(true, 1, 2, TimerState.Pending, TimerState.On)]
    [InlineData(true, 1, 2, TimerState.On, TimerState.On)]

    [InlineData(false, 9,  0, TimerState.Off, TimerState.Off)]
    [InlineData(false, 9,  0, TimerState.Pending, TimerState.Pending)]
    [InlineData(false, 9,  0, TimerState.On, TimerState.Pending)]

    [InlineData(false, 1, 2, TimerState.Off, TimerState.Off)]
    [InlineData(false, 1, 2, TimerState.Pending, TimerState.Off)]
    [InlineData(false, 1, 2, TimerState.On, TimerState.Pending)]
    public async Task Example_Usage_OffTimerConfiguration_Run_async(bool timerInput, int dwellTimeInMs, int sleepTimeInMs, TimerState currentState, TimerState expectedState)
    {
        _sequence     = GetOffTimerConfiguration(dwellTimeInMs).Build();
        _onTimerInput = timerInput;

        _sequence.SetState(currentState);

        await Task.Delay(sleepTimeInMs);
        await _sequence.RunAsync();

        var actual = _sequence.CurrentState;
        actual.ShouldBe(expectedState);
    }
}
```


For more examples -> IntegrationTestsFluentSeq/Examples  


[Top 🠉](#table-of-contents)


## Configuration in Detail

### States

States can be defined as strings, enums, int, objects, and so on.  
Internally they will be stored as type SeqState.


``` c#
        var builder = new FluentSeq<TimerState>().Create(TimerState.Off)
            .ConfigureState(TimerState.Off)
            .Builder()

// or
        var builder = new FluentSeq<string>().Create("Off")
            .ConfigureState("Off")
            .Builder()

```


[Top 🠉](#table-of-contents)



### Trigger

TBD

[Top 🠉](#table-of-contents)



### Actions

TBD

[Top 🠉](#table-of-contents)



# Sequence Validation

The validation process ensures the sequence configuration is complete and adheres to the defined principles.  
By default, validation is enabled but can be disabled either entirely or for specific states.  
The sequence is validated during the build process.

To build a sequence:  
`_sequence = builder.Build();` 


Validation Principles:  
- A sequence must have at least two configured states.
- The initial state must be defined and configured (not null or empty).
- Every state must have a TriggeredBy(...) method.
- Every TriggeredBy().WhenInState(s)(...) must point to a configured state.  


Validation could be disabled:  
- completely turn off validation  

``` c#
        var builder = new FluentSeq<TimerState>().Create(TimerState.Off)
            .DisableValidation()
            .ConfigureState(TimerState.Off)
            .Builder()
```

- or with specifying states that shouldn't be validated:  

``` c#
        var builder = new FluentSeq<TimerState>().Create(Enum.Off)
            .DisableValidationForStates(Enum.State1, Enum.State2, ...)
            .ConfigureState(Enum.Off)
            .Builder()
```


[Top 🠉](#table-of-contents)



# Version Changes

## Version 1.2.0
- Multi-Targeting to .NET 6.0 - .NET 9.0 and .NET Standard 2.0/2.1  
- working on warnings regarding nullable reference types (for States)  


## Version 1.1.0
- public Release of FluentSeq  


[Top 🠉](#table-of-contents)  




# Breaking Changes

[Top 🠉](#table-of-contents)  



# Preview next Version v2


[Top 🠉](#table-of-contents)  
