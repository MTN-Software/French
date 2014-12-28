using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Security;
using System.Windows.Input;

namespace French_Conjugations
{
    public sealed class CommandManager
    {
        // Summary:
        //     Identifies the System.Windows.Input.CommandManager.CanExecute attached event.
        public static readonly RoutedEvent CanExecuteEvent;
        //
        // Summary:
        //     Identifies the System.Windows.Input.CommandManager.Executed attached event.
        public static readonly RoutedEvent ExecutedEvent;
        //
        // Summary:
        //     Identifies the System.Windows.Input.CommandManager.PreviewCanExecute attached
        //     event.
        public static readonly RoutedEvent PreviewCanExecuteEvent;
        //
        // Summary:
        //     Identifies the System.Windows.Input.CommandManager.PreviewExecuted attached
        //     event.
        public static readonly RoutedEvent PreviewExecutedEvent;

        // Summary:
        //     Occurs when the System.Windows.Input.CommandManager detects conditions that
        //     might change the ability of a command to execute.
        public static event EventHandler RequerySuggested;

        // Summary:
        //     Attaches the specified System.Windows.Input.CanExecuteRoutedEventHandler
        //     to the specified element.
        //
        // Parameters:
        //   element:
        //     The element to attach handler to.
        //
        //   handler:
        //     The can execute handler.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     element or handler is null.
        //public static void AddCanExecuteHandler(UIElement element, CanExecuteRoutedEventHandler handler);
        //
        // Summary:
        //     Attaches the specified System.Windows.Input.ExecutedRoutedEventHandler to
        //     the specified element.
        //
        // Parameters:
        //   element:
        //     The element to attach handler to.
        //
        //   handler:
        //     The executed handler.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     element or handler is null.
        //public static void AddExecutedHandler(UIElement element, ExecutedRoutedEventHandler handler);
        //
        // Summary:
        //     Attaches the specified System.Windows.Input.CanExecuteRoutedEventHandler
        //     to the specified element.
        //
        // Parameters:
        //   element:
        //     The element to attach handler to.
        //
        //   handler:
        //     The can execute handler.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     element or handler is null.
        //public static void AddPreviewCanExecuteHandler(UIElement element, CanExecuteRoutedEventHandler handler);
        //
        // Summary:
        //     Attaches the specified System.Windows.Input.ExecutedRoutedEventHandler to
        //     the specified element.
        //
        // Parameters:
        //   element:
        //     The element to attach handler to.
        //
        //   handler:
        //     The can execute handler.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     element or handler is null.
        //public static void AddPreviewExecutedHandler(UIElement element, ExecutedRoutedEventHandler handler);
        //
        // Summary:
        //     Forces the System.Windows.Input.CommandManager to raise the System.Windows.Input.CommandManager.RequerySuggested
        //     event.
        //public static void InvalidateRequerySuggested();
        //
        // Summary:
        //     Registers a System.Windows.Input.CommandBinding with the specified type.
        //
        // Parameters:
        //   type:
        //     The class with which to register commandBinding.
        //
        //   commandBinding:
        //     The command binding to register.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     type or commandBinding is null.
        //public static void RegisterClassCommandBinding(Type type, CommandBinding commandBinding);
        //
        // Summary:
        //     Registers the specified System.Windows.Input.InputBinding with the specified
        //     type.
        //
        // Parameters:
        //   type:
        //     The type to register inputBinding with.
        //
        //   inputBinding:
        //     The input binding to register.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     type or inputBinding is null.
        //public static void RegisterClassInputBinding(Type type, InputBinding inputBinding);
        //
        // Summary:
        //     Detaches the specified System.Windows.Input.CanExecuteRoutedEventHandler
        //     from the specified element.
        //
        // Parameters:
        //   element:
        //     The element to remove handler from.
        //
        //   handler:
        //     The can execute handler.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     element or handler is null.
        //public static void RemoveCanExecuteHandler(UIElement element, CanExecuteRoutedEventHandler handler);
        //
        // Summary:
        //     Detaches the specified System.Windows.Input.ExecutedRoutedEventHandler from
        //     the specified element.
        //
        // Parameters:
        //   element:
        //     The element to remove handler from.
        //
        //   handler:
        //     The executed handler.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     element or handler is null.
        //public static void RemoveExecutedHandler(UIElement element, ExecutedRoutedEventHandler handler);
        //
        // Summary:
        //     Detaches the specified System.Windows.Input.CanExecuteRoutedEventHandler
        //     from the specified element.
        //
        // Parameters:
        //   element:
        //     The element to remove handler from.
        //
        //   handler:
        //     The can execute handler.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     element or handler is null.
        //public static void RemovePreviewCanExecuteHandler(UIElement element, CanExecuteRoutedEventHandler handler);
        //
        // Summary:
        //     Detaches the specified System.Windows.Input.ExecutedRoutedEventHandler from
        //     the specified element.
        //
        // Parameters:
        //   element:
        //     The element to remove handler from.
        //
        //   handler:
        //     The executed handler.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     element or handler is null.
        //public static void RemovePreviewExecutedHandler(UIElement element, ExecutedRoutedEventHandler handler);
    }
}
