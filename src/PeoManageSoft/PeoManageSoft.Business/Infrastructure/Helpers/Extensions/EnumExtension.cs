using System.ComponentModel;
using System.Reflection;

namespace PeoManageSoft.Business.Infrastructure.Helpers.Extensions
{
    /// <summary>
    /// Provides a extension of the base class for enumerations.
    /// </summary>
    public static class EnumExtension
    {
        #region Methods public

        /// <summary>
        /// Get the description of the enumerator.
        /// </summary>
        /// <param name="source">Base class for enumerations.</param>
        /// <returns>Description</returns>
        public static string GetDescription(this Enum source)
        {
            if (source == null) { return null; }

            Type genericEnumType = source.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(source.ToString());

            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Length > 0))
                {
                    return ((DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }

            return source.ToString();
        }

        /// <summary>
        /// Try to get the item in a specified enumeration.
        /// </summary>
        /// <typeparam name="T">Enumerator type</typeparam>
        /// <param name="value">Value of the constant</param>
        /// <param name="defaultValue">Default Value of the constant</param>
        /// <returns>Enumerator item</returns>
        public static T TryGetByValue<T>(int value, T defaultValue) where T : Enum
        {
            return Enum.IsDefined(typeof(T), value) ? (T)Enum.ToObject(typeof(T), value) : defaultValue;
        }

        /// <summary>
        /// Try to get the item in a specified enumeration.
        /// </summary>
        /// <typeparam name="T">Enumerator type</typeparam>
        /// <param name="value">Value of the constant</param>
        /// <param name="outValue">Enumerator item</param>
        /// <returns>True if the value of the constant exists in the specified enumeration; otherwise, false.</returns>
        public static bool TryGetByValue<T>(int value, out T outValue) where T : Enum
        {
            bool isOk = Enum.IsDefined(typeof(T), value);

            outValue = isOk ? (T)Enum.ToObject(typeof(T), value) : default;

            return isOk;
        }

        #endregion
    }
}
