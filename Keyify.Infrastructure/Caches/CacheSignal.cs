namespace Keyify.Infrastructure.Caches;

public sealed class CacheSignal<T>
{
    private readonly SemaphoreSlim _semaphore = new(1, 1);

    public Task WaitAsync() => _semaphore.WaitAsync();

    public void Release() => _semaphore.Release();
}