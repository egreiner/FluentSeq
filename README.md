# FluentSeq

TBD ... Documentation must be completely reworked...  


FluentSeq provides a fluent interface for creating easy-to-read sequences, 
eliminating the need for lengthy if/else statements.  
The library is written in C# 14 and targets .NET Standard 2.0 (.NET (Core) and .NET Framework).  

FluentSeq is the successor of IegTools.Sequencer  


The library allows you to configure:  

- Sequences with States  
- different kinds of State-Triggers  
- Actions that can be executed on State-Entry, State-Exit or WhileInState  
- Validate a sequence on build  


### Build Status  
&nbsp; ![workflow tests](https://github.com/egreiner/FluentSeq/actions/workflows/run-tests.yml/badge.svg)  



# Table of Contents
[Installation](#installation)  
[Usage](#usage)  
[States](#states)  
[Validation](#validation)  
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


For more examples -> IntegrationsTestsFluentSeq/Examples  


[Top 🠉](#table-of-contents)


## Configurations in Detail

TBD  


[Top 🠉](#table-of-contents)


# States

States can be defined as strings, enums, int, objects...  

[Top 🠉](#table-of-contents)






# Validation

The sequence will be validated on build.  
`_sequence = builder.Build();` 


Validations

- The InitialState must be defined (not null or empty)  
- The InitialState must be configured  
- Every State must have a TriggeredBY(...)  
- A Sequence must at least have configured two States  

Validation could be disabled
- completely turn off validation  
    `builder.DisableValidation()`  

- or with specifying states that shouldn't be validated:  
    `builder.DisableValidationForStates("state1", "state2", ...)`  
    `builder.DisableValidationForStates(Enum.State1, Enum.State2, ...)`  


[Top 🠉](#table-of-contents)



# Version Changes  

[Top 🠉](#table-of-contents)  




# Breaking Changes

[Top 🠉](#table-of-contents)  



# Preview next Version v2


[Top 🠉](#table-of-contents)  
