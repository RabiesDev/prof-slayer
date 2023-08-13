using System.Runtime.CompilerServices;
using UnityEngine;

namespace InternalCheat.Modules;

public class BaseModule
{
    protected bool IsInstanced => ReferenceEquals(null, Camera.main) || ReferenceEquals(null, PlayerEntityRepository.Instance);
    public readonly ModuleType ModuleType;
    public readonly string Name;
    public bool Activated;

    protected BaseModule(string name, ModuleType type)
    {
        Name = name;
        ModuleType = type;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void OnStart()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void OnUpdate()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void OnScreen()
    {
    }
}