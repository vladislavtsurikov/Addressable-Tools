using System;

namespace AddressableLoaderSystem.Runtime
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public abstract class FilterAttribute : Attribute
    {
    }
}