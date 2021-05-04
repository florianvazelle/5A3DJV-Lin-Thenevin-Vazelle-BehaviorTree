using System;

public sealed class Binder<T, TResult>
{
    private readonly T arg;
    private readonly Func<T, TResult> func;

    internal Binder(Func<T, TResult> func, T arg)
    {
        this.func = func;
        this.arg = arg;
    }

    public TResult Apply()
    {
        return func(arg);
    }
}