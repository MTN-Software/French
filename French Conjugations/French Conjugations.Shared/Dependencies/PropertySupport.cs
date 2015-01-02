using System;
using System.Linq.Expressions;
using System.Reflection;

namespace French_Conjugations
{

    #region PropertyInfo Hack
   /* public class PropertyHack : PropertyInfo
    {
        public override PropertyAttributes Attributes
        {
            get;
        }

        public override bool CanRead
        {
            get;
        }

        public override bool CanWrite
        {
            get;
        }

        public override Type DeclaringType
        {
            get;
        }

        public override string Name
        {
            get;
        }

        public override Type PropertyType
        {
            get;
        }

        public MethodInfo GetGetMethod(bool nonPublic) { return base.GetMethod; }

        public override ParameterInfo[] GetIndexParameters() { return new ParameterInfo[9]; }
    }*/

    #endregion

    public static class PropertySupport
    {
        public static String ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException("propertyExpression");
            }

            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("The expression is not a member access expression.", "propertyExpression");
            }

            var property = memberExpression.Member as PropertyInfo;
            if (property == null)
            {
                throw new ArgumentException("The member access expression does not access a property.", "propertyExpression");
            }

            var getMethod = property.GetMethod;
            if (getMethod.IsStatic)
            {
                throw new ArgumentException("The referenced property is a static property.", "propertyExpression");
            }

            return memberExpression.Member.Name;
        }
    }
}
