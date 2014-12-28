using System;
using System.Collections.Generic;
using System.Text;

namespace French_Conjugations
{
    // Summary:
    //     Represents and identifies a routed event and declares its characteristics.
    //[TypeConverter("System.Windows.Markup.RoutedEventConverter, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, Custom=null")]
    //[ValueSerializer("System.Windows.Markup.RoutedEventValueSerializer, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, Custom=null")]
    public sealed class RoutedEvent
    {
        // Summary:
        //     Gets the handler type of the routed event.
        //
        // Returns:
        //     The handler type of the routed event.
        public Type HandlerType { get; }
        //
        // Summary:
        //     Gets the identifying name of the routed event.
        //
        // Returns:
        //     The name of the routed event.
        public string Name { get; }
        //
        // Summary:
        //     Gets the registered owner type of the routed event.
        //
        // Returns:
        //     The owner type of the routed event.
        public Type OwnerType { get; }
        //
        // Summary:
        //     Gets the routing strategy of the routed event.
        //
        // Returns:
        //     One of the enumeration values. The default is the enumeration default, System.Windows.RoutingStrategy.Bubble.
        public RoutingStrategy RoutingStrategy { get; }

        // Summary:
        //     Associates another owner type with the routed event represented by a System.Windows.RoutedEvent
        //     instance, and enables routing of the event and its handling.
        //
        // Parameters:
        //   ownerType:
        //     The type where the routed event is added.
        //
        // Returns:
        //     The identifier field for the event. This return value should be used to set
        //     a public static read-only field that will store the identifier for the representation
        //     of the routed event on the owning type. This field is typically defined with
        //     public access, because user code must reference the field in order to attach
        //     any instance handlers for the routed event when using the System.Windows.UIElement.AddHandler(System.Windows.RoutedEvent,System.Delegate,System.Boolean)
        //     utility method.
        //public RoutedEvent AddOwner(Type ownerType);
        //
        // Summary:
        //     Returns the string representation of this System.Windows.RoutedEvent.
        //
        // Returns:
        //     A string representation for this object, which is identical to the value
        //     returned by System.Windows.RoutedEvent.Name.
        //public override string ToString();
    }
}
