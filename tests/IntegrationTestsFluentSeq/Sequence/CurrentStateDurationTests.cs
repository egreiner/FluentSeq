﻿namespace IntegrationTestsFluentSeq.Sequence;

public class CurrentStateDurationTests
{
    [Theory]
    [InlineData("Initializing")]
    [InlineData("Initialized")]
    [InlineData("Off")]
    [InlineData("On")]
    public async Task CurrentStateDuration_ShouldBe_correct(string startState)
    {
        var state = new DefaultSequenceStates();

        Func<TimeSpan> dwellTime() => () => TimeSpan.FromMilliseconds(1);

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized).TriggeredByState(state.Initializing, dwellTime())
            .ConfigureState(state.Off).TriggeredByState(state.Initialized, dwellTime())
            .ConfigureState(state.On).TriggeredByState(state.Off, dwellTime())
            .Builder()
            .Build();

        sequence.SetState(startState);

        await Task.Delay(3);

        sequence.CurrentStateDuration().ShouldBeGreaterThan(TimeSpan.FromMilliseconds(2.0));
    }
}