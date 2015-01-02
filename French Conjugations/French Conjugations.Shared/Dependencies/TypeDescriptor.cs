using System;
using System.Collections;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel;
namespace French_Conjugations
{
    public sealed class TypeDescriptor
    {
        //
        // Summary:
        //     Gets or sets the provider for the Component Object Model (COM) type information
        //     for the target component.
        //
        // Returns:
        //     An System.ComponentModel.IComNativeDescriptorHandler instance representing the
        //     COM type information provider.
        [Obsolete("This property has been deprecated.  Use a type description provider to supply type information for COM types instead.  http://go.microsoft.com/fwlink/?linkid=14202")]
        public static IComNativeDescriptorHandler ComNativeDescriptorHandler { get; set; }
        //
        // Summary:
        //     Gets the type of the Component Object Model (COM) object represented by the target
        //     component.
        //
        // Returns:
        //     The System.Type of the COM object represented by this component, or null for
        //     non-COM objects.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Type ComObjectType { get; }
        //
        // Summary:
        //     Gets a type that represents a type description provider for all interface types.
        //
        // Returns:
        //     A System.Type that represents a custom type description provider for all interface
        //     types.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Type InterfaceType { get; }

        //
        // Summary:
        //     Occurs when the cache for a component is cleared.
        public static event RefreshEventHandler Refreshed;

        //
        // Summary:
        //     Adds class-level attributes to the target component instance.
        //
        // Parameters:
        //   instance:
        //     An instance of the target component.
        //
        //   attributes:
        //     An array of System.Attribute objects to add to the component's class.
        //
        // Returns:
        //     The newly created System.ComponentModel.TypeDescriptionProvider that was used
        //     to add the specified attributes.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     One or both of the parameters is null.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static TypeDescriptionProvider AddAttributes(object instance, params Attribute[] attributes);
        //
        // Summary:
        //     Adds class-level attributes to the target component type.
        //
        // Parameters:
        //   type:
        //     The System.Type of the target component.
        //
        //   attributes:
        //     An array of System.Attribute objects to add to the component's class.
        //
        // Returns:
        //     The newly created System.ComponentModel.TypeDescriptionProvider that was used
        //     to add the specified attributes.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     One or both of the parameters is null.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static TypeDescriptionProvider AddAttributes(Type type, params Attribute[] attributes);
        //
        // Summary:
        //     Adds an editor table for the given editor base type.
        //
        // Parameters:
        //   editorBaseType:
        //     The editor base type to add the editor table for. If a table already exists for
        //     this type, this method will do nothing.
        //
        //   table:
        //     The System.Collections.Hashtable to add.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static void AddEditorTable(Type editorBaseType, Hashtable table);
        //
        // Summary:
        //     Adds a type description provider for a single instance of a component.
        //
        // Parameters:
        //   provider:
        //     The System.ComponentModel.TypeDescriptionProvider to add.
        //
        //   instance:
        //     An instance of the target component.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     One or both of the parameters are null.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static void AddProvider(TypeDescriptionProvider provider, object instance);
        //
        // Summary:
        //     Adds a type description provider for a component class.
        //
        // Parameters:
        //   provider:
        //     The System.ComponentModel.TypeDescriptionProvider to add.
        //
        //   type:
        //     The System.Type of the target component.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     One or both of the parameters are null.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static void AddProvider(TypeDescriptionProvider provider, Type type);
        //
        // Summary:
        //     Adds a type description provider for a single instance of a component.
        //
        // Parameters:
        //   provider:
        //     The System.ComponentModel.TypeDescriptionProvider to add.
        //
        //   instance:
        //     An instance of the target component.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     One or both of the parameters are null.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static void AddProviderTransparent(TypeDescriptionProvider provider, object instance);
        //
        // Summary:
        //     Adds a type description provider for a component class.
        //
        // Parameters:
        //   provider:
        //     The System.ComponentModel.TypeDescriptionProvider to add.
        //
        //   type:
        //     The System.Type of the target component.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     One or both of the parameters are null.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static void AddProviderTransparent(TypeDescriptionProvider provider, Type type);
        //
        // Summary:
        //     Creates a primary-secondary association between two objects.
        //
        // Parameters:
        //   primary:
        //     The primary System.Object.
        //
        //   secondary:
        //     The secondary System.Object.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     One or both of the parameters are null.
        //
        //   T:System.ArgumentException:
        //     primary is equal to secondary.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static void CreateAssociation(object primary, object secondary);
        //
        // Summary:
        //     Creates an instance of the designer associated with the specified component and
        //     of the specified type of designer.
        //
        // Parameters:
        //   component:
        //     An System.ComponentModel.IComponent that specifies the component to associate
        //     with the designer.
        //
        //   designerBaseType:
        //     A System.Type that represents the type of designer to create.
        //
        // Returns:
        //     An System.ComponentModel.Design.IDesigner that is an instance of the designer
        //     for the component, or null if no designer can be found.
        public static IDesigner CreateDesigner(IComponent component, Type designerBaseType);
        //
        // Summary:
        //     Creates a new event descriptor that is identical to an existing event descriptor,
        //     when passed the existing System.ComponentModel.EventDescriptor.
        //
        // Parameters:
        //   componentType:
        //     The type of the component for which to create the new event.
        //
        //   oldEventDescriptor:
        //     The existing event information.
        //
        //   attributes:
        //     The new attributes.
        //
        // Returns:
        //     A new System.ComponentModel.EventDescriptor that has merged the specified metadata
        //     attributes with the existing metadata attributes.
        public static EventDescriptor CreateEvent(Type componentType, EventDescriptor oldEventDescriptor, params Attribute[] attributes);
        //
        // Summary:
        //     Creates a new event descriptor that is identical to an existing event descriptor
        //     by dynamically generating descriptor information from a specified event on a
        //     type.
        //
        // Parameters:
        //   componentType:
        //     The type of the component the event lives on.
        //
        //   name:
        //     The name of the event.
        //
        //   type:
        //     The type of the delegate that handles the event.
        //
        //   attributes:
        //     The attributes for this event.
        //
        // Returns:
        //     An System.ComponentModel.EventDescriptor that is bound to a type.
        public static EventDescriptor CreateEvent(Type componentType, string name, Type type, params Attribute[] attributes);
        //
        // Summary:
        //     Creates an object that can substitute for another data type.
        //
        // Parameters:
        //   provider:
        //     The service provider that provides a System.ComponentModel.TypeDescriptionProvider
        //     service. This parameter can be null.
        //
        //   objectType:
        //     The System.Type of object to create.
        //
        //   argTypes:
        //     An optional array of parameter types to be passed to the object's constructor.
        //     This parameter can be null or an array of zero length.
        //
        //   args:
        //     An optional array of parameter values to pass to the object's constructor. If
        //     not null, the number of elements must be the same as argTypes.
        //
        // Returns:
        //     An instance of the substitute data type if an associated System.ComponentModel.TypeDescriptionProvider
        //     is found; otherwise, null.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     objectType is null, or args is null when argTypes is not null.
        //
        //   T:System.ArgumentException:
        //     argTypes and args have different number of elements.
        public static object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args);
        //
        // Summary:
        //     Creates a new property descriptor from an existing property descriptor, using
        //     the specified existing System.ComponentModel.PropertyDescriptor and attribute
        //     array.
        //
        // Parameters:
        //   componentType:
        //     The System.Type of the component that the property is a member of.
        //
        //   oldPropertyDescriptor:
        //     The existing property descriptor.
        //
        //   attributes:
        //     The new attributes for this property.
        //
        // Returns:
        //     A new System.ComponentModel.PropertyDescriptor that has the specified metadata
        //     attributes merged with the existing metadata attributes.
        public static PropertyDescriptor CreateProperty(Type componentType, PropertyDescriptor oldPropertyDescriptor, params Attribute[] attributes);
        //
        // Summary:
        //     Creates and dynamically binds a property descriptor to a type, using the specified
        //     property name, type, and attribute array.
        //
        // Parameters:
        //   componentType:
        //     The System.Type of the component that the property is a member of.
        //
        //   name:
        //     The name of the property.
        //
        //   type:
        //     The System.Type of the property.
        //
        //   attributes:
        //     The new attributes for this property.
        //
        // Returns:
        //     A System.ComponentModel.PropertyDescriptor that is bound to the specified type
        //     and that has the specified metadata attributes merged with the existing metadata
        //     attributes.
        public static PropertyDescriptor CreateProperty(Type componentType, string name, Type type, params Attribute[] attributes);
        //
        // Summary:
        //     Returns an instance of the type associated with the specified primary object.
        //
        // Parameters:
        //   type:
        //     The System.Type of the target component.
        //
        //   primary:
        //     The primary object of the association.
        //
        // Returns:
        //     An instance of the secondary type that has been associated with the primary object
        //     if an association exists; otherwise, primary if no specified association exists.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     One or both of the parameters are null.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static object GetAssociation(Type type, object primary);
        //
        // Summary:
        //     Returns the collection of attributes for the specified component.
        //
        // Parameters:
        //   component:
        //     The component for which you want to get attributes.
        //
        // Returns:
        //     An System.ComponentModel.AttributeCollection containing the attributes for the
        //     component. If component is null, this method returns an empty collection.
        public static AttributeCollection GetAttributes(object component);
        //
        // Summary:
        //     Returns a collection of attributes for the specified type of component.
        //
        // Parameters:
        //   componentType:
        //     The System.Type of the target component.
        //
        // Returns:
        //     An System.ComponentModel.AttributeCollection with the attributes for the type
        //     of the component. If the component is null, this method returns an empty collection.
        public static AttributeCollection GetAttributes(Type componentType);
        //
        // Summary:
        //     Returns a collection of attributes for the specified component and a Boolean
        //     indicating that a custom type descriptor has been created.
        //
        // Parameters:
        //   component:
        //     The component for which you want to get attributes.
        //
        //   noCustomTypeDesc:
        //     true to use a baseline set of attributes from the custom type descriptor if component
        //     is of type System.ComponentModel.ICustomTypeDescriptor; otherwise, false.
        //
        // Returns:
        //     An System.ComponentModel.AttributeCollection with the attributes for the component.
        //     If the component is null, this method returns an empty collection.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static AttributeCollection GetAttributes(object component, bool noCustomTypeDesc);
        //
        // Summary:
        //     Returns the name of the class for the specified type.
        //
        // Parameters:
        //   componentType:
        //     The System.Type of the target component.
        //
        // Returns:
        //     A System.String containing the name of the class for the specified component
        //     type.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     componentType is null.
        public static string GetClassName(Type componentType);
        //
        // Summary:
        //     Returns the name of the class for the specified component using the default type
        //     descriptor.
        //
        // Parameters:
        //   component:
        //     The System.Object for which you want the class name.
        //
        // Returns:
        //     A System.String containing the name of the class for the specified component.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     component is null.
        public static string GetClassName(object component);
        //
        // Summary:
        //     Returns the name of the class for the specified component using a custom type
        //     descriptor.
        //
        // Parameters:
        //   component:
        //     The System.Object for which you want the class name.
        //
        //   noCustomTypeDesc:
        //     true to consider custom type description information; otherwise, false.
        //
        // Returns:
        //     A System.String containing the name of the class for the specified component.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     component is null.
        //
        //   T:System.NotSupportedException:
        //     component is a cross-process remoted object.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static string GetClassName(object component, bool noCustomTypeDesc);
        //
        // Summary:
        //     Returns the name of the specified component using the default type descriptor.
        //
        // Parameters:
        //   component:
        //     The System.Object for which you want the class name.
        //
        // Returns:
        //     A System.String containing the name of the specified component, or null if there
        //     is no component name.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     component is null.
        //
        //   T:System.NotSupportedException:
        //     component is a cross-process remoted object.
        public static string GetComponentName(object component);
        //
        // Summary:
        //     Returns the name of the specified component using a custom type descriptor.
        //
        // Parameters:
        //   component:
        //     The System.Object for which you want the class name.
        //
        //   noCustomTypeDesc:
        //     true to consider custom type description information; otherwise, false.
        //
        // Returns:
        //     The name of the class for the specified component, or null if there is no component
        //     name.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     component is null.
        //
        //   T:System.NotSupportedException:
        //     component is a cross-process remoted object.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static string GetComponentName(object component, bool noCustomTypeDesc);
        //
        // Summary:
        //     Returns a type converter for the specified type.
        //
        // Parameters:
        //   type:
        //     The System.Type of the target component.
        //
        // Returns:
        //     A System.ComponentModel.TypeConverter for the specified type.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     component is null.
        public static TypeConverter GetConverter(Type type);
        //
        // Summary:
        //     Returns a type converter for the type of the specified component.
        //
        // Parameters:
        //   component:
        //     A component to get the converter for.
        //
        // Returns:
        //     A System.ComponentModel.TypeConverter for the specified component.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     component is null.
        //
        //   T:System.NotSupportedException:
        //     component is a cross-process remoted object.
        public static TypeConverter GetConverter(object component);
        //
        // Summary:
        //     Returns a type converter for the type of the specified component with a custom
        //     type descriptor.
        //
        // Parameters:
        //   component:
        //     A component to get the converter for.
        //
        //   noCustomTypeDesc:
        //     true to consider custom type description information; otherwise, false.
        //
        // Returns:
        //     A System.ComponentModel.TypeConverter for the specified component.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     component is null.
        //
        //   T:System.NotSupportedException:
        //     component is a cross-process remoted object.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static TypeConverter GetConverter(object component, bool noCustomTypeDesc);
        //
        // Summary:
        //     Returns the default event for the specified component.
        //
        // Parameters:
        //   component:
        //     The component to get the event for.
        //
        // Returns:
        //     An System.ComponentModel.EventDescriptor with the default event, or null if there
        //     are no events.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     component is null.
        //
        //   T:System.NotSupportedException:
        //     component is a cross-process remoted object.
        public static EventDescriptor GetDefaultEvent(object component);
        //
        // Summary:
        //     Returns the default event for the specified type of component.
        //
        // Parameters:
        //   componentType:
        //     The System.Type of the target component.
        //
        // Returns:
        //     An System.ComponentModel.EventDescriptor with the default event, or null if there
        //     are no events.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     component is null.
        public static EventDescriptor GetDefaultEvent(Type componentType);
        //
        // Summary:
        //     Returns the default event for a component with a custom type descriptor.
        //
        // Parameters:
        //   component:
        //     The component to get the event for.
        //
        //   noCustomTypeDesc:
        //     true to consider custom type description information; otherwise, false.
        //
        // Returns:
        //     An System.ComponentModel.EventDescriptor with the default event, or null if there
        //     are no events.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     component is null.
        //
        //   T:System.NotSupportedException:
        //     component is a cross-process remoted object.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static EventDescriptor GetDefaultEvent(object component, bool noCustomTypeDesc);
        //
        // Summary:
        //     Returns the default property for the specified component.
        //
        // Parameters:
        //   component:
        //     The component to get the default property for.
        //
        // Returns:
        //     A System.ComponentModel.PropertyDescriptor with the default property, or null
        //     if there are no properties.
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     component is a cross-process remoted object.
        public static PropertyDescriptor GetDefaultProperty(object component);
        //
        // Summary:
        //     Returns the default property for the specified type of component.
        //
        // Parameters:
        //   componentType:
        //     A System.Type that represents the class to get the property for.
        //
        // Returns:
        //     A System.ComponentModel.PropertyDescriptor with the default property, or null
        //     if there are no properties.
        public static PropertyDescriptor GetDefaultProperty(Type componentType);
        //
        // Summary:
        //     Returns the default property for the specified component with a custom type descriptor.
        //
        // Parameters:
        //   component:
        //     The component to get the default property for.
        //
        //   noCustomTypeDesc:
        //     true to consider custom type description information; otherwise, false.
        //
        // Returns:
        //     A System.ComponentModel.PropertyDescriptor with the default property, or null
        //     if there are no properties.
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     component is a cross-process remoted object.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static PropertyDescriptor GetDefaultProperty(object component, bool noCustomTypeDesc);
        //
        // Summary:
        //     Returns an editor with the specified base type for the specified type.
        //
        // Parameters:
        //   type:
        //     The System.Type of the target component.
        //
        //   editorBaseType:
        //     A System.Type that represents the base type of the editor you are trying to find.
        //
        // Returns:
        //     An instance of the editor object that can be cast to the given base type, or
        //     null if no editor of the requested type can be found.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     type or editorBaseType is null.
        public static object GetEditor(Type type, Type editorBaseType);
        //
        // Summary:
        //     Gets an editor with the specified base type for the specified component.
        //
        // Parameters:
        //   component:
        //     The component to get the editor for.
        //
        //   editorBaseType:
        //     A System.Type that represents the base type of the editor you want to find.
        //
        // Returns:
        //     An instance of the editor that can be cast to the specified editor type, or null
        //     if no editor of the requested type can be found.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     component or editorBaseType is null.
        //
        //   T:System.NotSupportedException:
        //     component is a cross-process remoted object.
        public static object GetEditor(object component, Type editorBaseType);
        //
        // Summary:
        //     Returns an editor with the specified base type and with a custom type descriptor
        //     for the specified component.
        //
        // Parameters:
        //   component:
        //     The component to get the editor for.
        //
        //   editorBaseType:
        //     A System.Type that represents the base type of the editor you want to find.
        //
        //   noCustomTypeDesc:
        //     A flag indicating whether custom type description information should be considered.
        //
        // Returns:
        //     An instance of the editor that can be cast to the specified editor type, or null
        //     if no editor of the requested type can be found.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     component or editorBaseType is null.
        //
        //   T:System.NotSupportedException:
        //     component is a cross-process remoted object.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static object GetEditor(object component, Type editorBaseType, bool noCustomTypeDesc);
        //
        // Summary:
        //     Returns the collection of events for the specified component.
        //
        // Parameters:
        //   component:
        //     A component to get the events for.
        //
        // Returns:
        //     An System.ComponentModel.EventDescriptorCollection with the events for this component.
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     component is a cross-process remoted object.
        public static EventDescriptorCollection GetEvents(object component);
        //
        // Summary:
        //     Returns the collection of events for a specified type of component.
        //
        // Parameters:
        //   componentType:
        //     The System.Type of the target component.
        //
        // Returns:
        //     An System.ComponentModel.EventDescriptorCollection with the events for this component.
        public static EventDescriptorCollection GetEvents(Type componentType);
        //
        // Summary:
        //     Returns the collection of events for a specified component using a specified
        //     array of attributes as a filter.
        //
        // Parameters:
        //   component:
        //     A component to get the events for.
        //
        //   attributes:
        //     An array of type System.Attribute that you can use as a filter.
        //
        // Returns:
        //     An System.ComponentModel.EventDescriptorCollection with the events that match
        //     the specified attributes for this component.
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     component is a cross-process remoted object.
        public static EventDescriptorCollection GetEvents(object component, Attribute[] attributes);
        //
        // Summary:
        //     Returns the collection of events for a specified component with a custom type
        //     descriptor.
        //
        // Parameters:
        //   component:
        //     A component to get the events for.
        //
        //   noCustomTypeDesc:
        //     true to consider custom type description information; otherwise, false.
        //
        // Returns:
        //     An System.ComponentModel.EventDescriptorCollection with the events for this component.
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     component is a cross-process remoted object.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static EventDescriptorCollection GetEvents(object component, bool noCustomTypeDesc);
        //
        // Summary:
        //     Returns the collection of events for a specified type of component using a specified
        //     array of attributes as a filter.
        //
        // Parameters:
        //   componentType:
        //     The System.Type of the target component.
        //
        //   attributes:
        //     An array of type System.Attribute that you can use as a filter.
        //
        // Returns:
        //     An System.ComponentModel.EventDescriptorCollection with the events that match
        //     the specified attributes for this component.
        public static EventDescriptorCollection GetEvents(Type componentType, Attribute[] attributes);
        //
        // Summary:
        //     Returns the collection of events for a specified component using a specified
        //     array of attributes as a filter and using a custom type descriptor.
        //
        // Parameters:
        //   component:
        //     A component to get the events for.
        //
        //   attributes:
        //     An array of type System.Attribute to use as a filter.
        //
        //   noCustomTypeDesc:
        //     true to consider custom type description information; otherwise, false.
        //
        // Returns:
        //     An System.ComponentModel.EventDescriptorCollection with the events that match
        //     the specified attributes for this component.
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     component is a cross-process remoted object.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static EventDescriptorCollection GetEvents(object component, Attribute[] attributes, bool noCustomTypeDesc);
        //
        // Summary:
        //     Returns the fully qualified name of the component.
        //
        // Parameters:
        //   component:
        //     The System.ComponentModel.Component to find the name for.
        //
        // Returns:
        //     The fully qualified name of the specified component, or null if the component
        //     has no name.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     component is null.
        public static string GetFullComponentName(object component);
        //
        // Summary:
        //     Returns the collection of properties for a specified component.
        //
        // Parameters:
        //   component:
        //     A component to get the properties for.
        //
        // Returns:
        //     A System.ComponentModel.PropertyDescriptorCollection with the properties for
        //     the specified component.
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     component is a cross-process remoted object.
        public static PropertyDescriptorCollection GetProperties(object component);
        //
        // Summary:
        //     Returns the collection of properties for a specified type of component.
        //
        // Parameters:
        //   componentType:
        //     A System.Type that represents the component to get properties for.
        //
        // Returns:
        //     A System.ComponentModel.PropertyDescriptorCollection with the properties for
        //     a specified type of component.
        public static PropertyDescriptorCollection GetProperties(Type componentType);
        //
        // Summary:
        //     Returns the collection of properties for a specified component using a specified
        //     array of attributes as a filter.
        //
        // Parameters:
        //   component:
        //     A component to get the properties for.
        //
        //   attributes:
        //     An array of type System.Attribute to use as a filter.
        //
        // Returns:
        //     A System.ComponentModel.PropertyDescriptorCollection with the properties that
        //     match the specified attributes for the specified component.
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     component is a cross-process remoted object.
        public static PropertyDescriptorCollection GetProperties(object component, Attribute[] attributes);
        //
        // Summary:
        //     Returns the collection of properties for a specified component using the default
        //     type descriptor.
        //
        // Parameters:
        //   component:
        //     A component to get the properties for.
        //
        //   noCustomTypeDesc:
        //     true to not consider custom type description information; otherwise, false.
        //
        // Returns:
        //     A System.ComponentModel.PropertyDescriptorCollection with the properties for
        //     a specified component.
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     component is a cross-process remoted object.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static PropertyDescriptorCollection GetProperties(object component, bool noCustomTypeDesc);
        //
        // Summary:
        //     Returns the collection of properties for a specified type of component using
        //     a specified array of attributes as a filter.
        //
        // Parameters:
        //   componentType:
        //     The System.Type of the target component.
        //
        //   attributes:
        //     An array of type System.Attribute to use as a filter.
        //
        // Returns:
        //     A System.ComponentModel.PropertyDescriptorCollection with the properties that
        //     match the specified attributes for this type of component.
        public static PropertyDescriptorCollection GetProperties(Type componentType, Attribute[] attributes);
        //
        // Summary:
        //     Returns the collection of properties for a specified component using a specified
        //     array of attributes as a filter and using a custom type descriptor.
        //
        // Parameters:
        //   component:
        //     A component to get the properties for.
        //
        //   attributes:
        //     An array of type System.Attribute to use as a filter.
        //
        //   noCustomTypeDesc:
        //     true to consider custom type description information; otherwise, false.
        //
        // Returns:
        //     A System.ComponentModel.PropertyDescriptorCollection with the events that match
        //     the specified attributes for the specified component.
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     component is a cross-process remoted object.
        public static PropertyDescriptorCollection GetProperties(object component, Attribute[] attributes, bool noCustomTypeDesc);
        //
        // Summary:
        //     Returns the type description provider for the specified component.
        //
        // Parameters:
        //   instance:
        //     An instance of the target component.
        //
        // Returns:
        //     A System.ComponentModel.TypeDescriptionProvider associated with the specified
        //     component.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     instance is null.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static TypeDescriptionProvider GetProvider(object instance);
        //
        // Summary:
        //     Returns the type description provider for the specified type.
        //
        // Parameters:
        //   type:
        //     The System.Type of the target component.
        //
        // Returns:
        //     A System.ComponentModel.TypeDescriptionProvider associated with the specified
        //     type.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     type is null.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static TypeDescriptionProvider GetProvider(Type type);
        //
        // Summary:
        //     Returns a System.Type that can be used to perform reflection, given an object.
        //
        // Parameters:
        //   instance:
        //     An instance of the target component.
        //
        // Returns:
        //     A System.Type for the specified object.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     instance is null.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Type GetReflectionType(object instance);
        //
        // Summary:
        //     Returns a System.Type that can be used to perform reflection, given a class type.
        //
        // Parameters:
        //   type:
        //     The System.Type of the target component.
        //
        // Returns:
        //     A System.Type of the specified class.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     type is null.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Type GetReflectionType(Type type);
        //
        // Summary:
        //     Clears the properties and events for the specified module from the cache.
        //
        // Parameters:
        //   module:
        //     The System.Reflection.Module that represents the module to refresh. Each System.Type
        //     in this module will be refreshed.
        public static void Refresh(Module module);
        //
        // Summary:
        //     Clears the properties and events for the specified assembly from the cache.
        //
        // Parameters:
        //   assembly:
        //     The System.Reflection.Assembly that represents the assembly to refresh. Each
        //     System.Type in this assembly will be refreshed.
        public static void Refresh(Assembly assembly);
        //
        // Summary:
        //     Clears the properties and events for the specified type of component from the
        //     cache.
        //
        // Parameters:
        //   type:
        //     The System.Type of the target component.
        public static void Refresh(Type type);
        //
        // Summary:
        //     Clears the properties and events for the specified component from the cache.
        //
        // Parameters:
        //   component:
        //     A component for which the properties or events have changed.
        public static void Refresh(object component);
        //
        // Summary:
        //     Removes an association between two objects.
        //
        // Parameters:
        //   primary:
        //     The primary System.Object.
        //
        //   secondary:
        //     The secondary System.Object.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     One or both of the parameters are null.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static void RemoveAssociation(object primary, object secondary);
        //
        // Summary:
        //     Removes all associations for a primary object.
        //
        // Parameters:
        //   primary:
        //     The primary System.Object in an association.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     primary is null.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static void RemoveAssociations(object primary);
        //
        // Summary:
        //     Removes a previously added type description provider that is associated with
        //     the specified object.
        //
        // Parameters:
        //   provider:
        //     The System.ComponentModel.TypeDescriptionProvider to remove.
        //
        //   instance:
        //     An instance of the target component.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     One or both of the parameters are null.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static void RemoveProvider(TypeDescriptionProvider provider, object instance);
        //
        // Summary:
        //     Removes a previously added type description provider that is associated with
        //     the specified type.
        //
        // Parameters:
        //   provider:
        //     The System.ComponentModel.TypeDescriptionProvider to remove.
        //
        //   type:
        //     The System.Type of the target component.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     One or both of the parameters are null.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static void RemoveProvider(TypeDescriptionProvider provider, Type type);
        //
        // Summary:
        //     Removes a previously added type description provider that is associated with
        //     the specified object.
        //
        // Parameters:
        //   provider:
        //     The System.ComponentModel.TypeDescriptionProvider to remove.
        //
        //   instance:
        //     An instance of the target component.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     One or both of the parameters are null.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static void RemoveProviderTransparent(TypeDescriptionProvider provider, object instance);
        //
        // Summary:
        //     Removes a previously added type description provider that is associated with
        //     the specified type.
        //
        // Parameters:
        //   provider:
        //     The System.ComponentModel.TypeDescriptionProvider to remove.
        //
        //   type:
        //     The System.Type of the target component.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     One or both of the parameters are null.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static void RemoveProviderTransparent(TypeDescriptionProvider provider, Type type);
        //
        // Summary:
        //     Sorts descriptors using the name of the descriptor.
        //
        // Parameters:
        //   infos:
        //     An System.Collections.IList that contains the descriptors to sort.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     infos is null.
        public static void SortDescriptorArray(IList infos) { }

        public interface IComNativeDescriptorHandler
        {
        }
    }

    //
    // Summary:
    //     Specifies that a property or method is viewable in an editor. This class cannot
    //     be inherited.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate)]
    public sealed class EditorBrowsableAttribute : Attribute
    {
        //
        // Summary:
        //     Initializes a new instance of the System.ComponentModel.EditorBrowsableAttribute
        //     class with System.ComponentModel.EditorBrowsableAttribute.State set to the default
        //     state.
        public EditorBrowsableAttribute() { base.MemberwiseClone(); }
        //
        // Summary:
        //     Initializes a new instance of the System.ComponentModel.EditorBrowsableAttribute
        //     class with an System.ComponentModel.EditorBrowsableState.
        //
        // Parameters:
        //   state:
        //     The System.ComponentModel.EditorBrowsableState to set System.ComponentModel.EditorBrowsableAttribute.State
        //     to.
        public EditorBrowsableAttribute(EditorBrowsableState state) { base.MemberwiseClone(); }

        //
        // Summary:
        //     Gets the browsable state of the property or method.
        //
        // Returns:
        //     An System.ComponentModel.EditorBrowsableState that is the browsable state of
        //     the property or method.
        public EditorBrowsableState State { get; }

        //
        // Summary:
        //     Returns whether the value of the given object is equal to the current System.ComponentModel.EditorBrowsableAttribute.
        //
        // Parameters:
        //   obj:
        //     The object to test the value equality of.
        //
        // Returns:
        //     true if the value of the given object is equal to that of the current; otherwise,
        //     false.
        public override bool Equals(object obj) { return base.Equals(obj); }
        public override int GetHashCode() { return base.GetHashCode(); }
    }

    //
    // Summary:
    //     Provides a top-level mapping layer between a COM object and a System.ComponentModel.TypeDescriptor.
    [Obsolete("This interface has been deprecated. Add a TypeDescriptionProvider to handle type TypeDescriptor.ComObjectType instead.  http://go.microsoft.com/fwlink/?linkid=14202")]
    public interface IComNativeDescriptorHandler
    {
        //
        // Summary:
        //     Gets the attributes for the specified component.
        //
        // Parameters:
        //   component:
        //     The component to get attributes for.
        //
        // Returns:
        //     A collection of attributes for component.
        AttributeCollection GetAttributes(object component);
        //
        // Summary:
        //     Gets the class name for the specified component.
        //
        // Parameters:
        //   component:
        //     The component to get the class name for.
        //
        // Returns:
        //     The name of the class that corresponds with component.
        string GetClassName(object component);
        //
        // Summary:
        //     Gets the type converter for the specified component.
        //
        // Parameters:
        //   component:
        //     The component to get the System.ComponentModel.TypeConverter for.
        //
        // Returns:
        //     The System.ComponentModel.TypeConverter for component.
        TypeConverter GetConverter(object component);
        //
        // Summary:
        //     Gets the default event for the specified component.
        //
        // Parameters:
        //   component:
        //     The component to get the default event for.
        //
        // Returns:
        //     An System.ComponentModel.EventDescriptor that represents component's default
        //     event.
        EventDescriptor GetDefaultEvent(object component);
        //
        // Summary:
        //     Gets the default property for the specified component.
        //
        // Parameters:
        //   component:
        //     The component to get the default property for.
        //
        // Returns:
        //     A System.ComponentModel.PropertyDescriptor that represents component's default
        //     property.
        PropertyDescriptor GetDefaultProperty(object component);
        //
        // Summary:
        //     Gets the editor for the specified component.
        //
        // Parameters:
        //   component:
        //     The component to get the editor for.
        //
        //   baseEditorType:
        //     The base type of the editor for component.
        //
        // Returns:
        //     The editor for component.
        object GetEditor(object component, Type baseEditorType);
        //
        // Summary:
        //     Gets the events for the specified component.
        //
        // Parameters:
        //   component:
        //     The component to get events for.
        //
        // Returns:
        //     A collection of event descriptors for component.
        EventDescriptorCollection GetEvents(object component);
        //
        // Summary:
        //     Gets the events with the specified attributes for the specified component.
        //
        // Parameters:
        //   component:
        //     The component to get events for.
        //
        //   attributes:
        //     The attributes used to filter events.
        //
        // Returns:
        //     A collection of event descriptors for component.
        EventDescriptorCollection GetEvents(object component, Attribute[] attributes);
        //
        // Summary:
        //     Gets the name of the specified component.
        //
        // Parameters:
        //   component:
        //     The component to get the name of.
        //
        // Returns:
        //     The name of component.
        string GetName(object component);
        //
        // Summary:
        //     Gets the properties with the specified attributes for the specified component.
        //
        // Parameters:
        //   component:
        //     The component to get events for.
        //
        //   attributes:
        //     The attributes used to filter properties.
        //
        // Returns:
        //     A collection of property descriptors for component.
        PropertyDescriptorCollection GetProperties(object component, Attribute[] attributes);
        //
        // Summary:
        //     Gets the value of the property that has the specified dispatch identifier.
        //
        // Parameters:
        //   component:
        //     The object to which the property belongs.
        //
        //   dispid:
        //     The dispatch identifier.
        //
        //   success:
        //     A System.Boolean, passed by reference, that represents whether the property was
        //     retrieved.
        //
        // Returns:
        //     The value of the property that has the specified dispatch identifier.
        object GetPropertyValue(object component, int dispid, ref bool success);
        //
        // Summary:
        //     Gets the value of the property that has the specified name.
        //
        // Parameters:
        //   component:
        //     The object to which the property belongs.
        //
        //   propertyName:
        //     The name of the property.
        //
        //   success:
        //     A System.Boolean, passed by reference, that represents whether the property was
        //     retrieved.
        //
        // Returns:
        //     The value of the property that has the specified name.
        object GetPropertyValue(object component, string propertyName, ref bool success);
    }

}
