using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace French_Conjugations
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Delegate, Inherited = false)]
    [ComVisible(true)]
    public sealed class SerializableAttribute : Attribute
    {
        public SerializableAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = false)]
    [ComVisible(true)]
    public sealed class NonSerializedAttribute : Attribute
    {
        public NonSerializedAttribute() { }
    }
}
