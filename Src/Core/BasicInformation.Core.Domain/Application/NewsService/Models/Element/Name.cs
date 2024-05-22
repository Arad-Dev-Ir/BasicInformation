﻿namespace BasicInformation.Core.NewsService.Models;

using Swan.Core;
using Swan.Core.Models;

public class Name : Element
{
    public string Value { get; private set; } = Empty;

    #region Initialize

    private Name(string value)
    => Initialize(act: () => OnCheckName(value), value: value);

    void Initialize(string value, Action? act = default)
    {
        act?.Invoke();
        Value = value;
    }

    public static Name Instance(string value)
    => new(value);

    #endregion

    #region Methods

    protected override IEnumerable<object> Lookup()
    {
        yield return Value;
    }

    public static implicit operator Name(string value)
    => new(value);
    public static explicit operator string(Name name)
    => name.Value;

    public override string ToString()
    => Value;

    private void OnCheckName(string value)
    {
        var element = nameof(Name);
        if (value.IsEmpty())
            throw new InvalidElementException("The value for {0} cannot be null!", element);

        var minChar = 3;
        var maxChar = 50;
        if (!value.IsLengthBetween(minChar, maxChar))
            throw new InvalidElementException("The value length for {0} must be between {1} and {2} characters!", element, $"{minChar}", $"{maxChar}");
    }

    #endregion
}