﻿using System.Collections;
using ExtensionFramework.Core.Common.Extensions;
using ExtensionFramework.Core.Common.Interfaces;

namespace ExtensionFramework.Core.Common.Services;

public class TaskCompletionSourceEnumerator : ITaskCompletionSourceEnumerator
{
    private Task current;
    private bool disposed;
    private TaskCompletionSource taskCompletionSource;

    public TaskCompletionSourceEnumerator()
    {
        taskCompletionSource = new ();
        current = taskCompletionSource.Task;
    }

    public Task Current
    {
        get
        {
            if (disposed)
            {
                this.ThrowDisposedException();
            }

            return current;
        }
    }

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (disposed)
        {
            this.ThrowDisposedException();
        }

        taskCompletionSource.SetResult();
        taskCompletionSource = new ();
        current = taskCompletionSource.Task;

        return true;
    }

    public void Reset()
    {
        MoveNext();
    }

    public void Dispose()
    {
        Dispose(true);
    }

    public Task MoveNextAndGetCurrent()
    {
        MoveNext();

        return Current;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
        {
            return;
        }

        if (disposing)
        {
            taskCompletionSource.SetResult();
            taskCompletionSource = null!;
            current = null!;
        }

        disposed = true;
    }
}