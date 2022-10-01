using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;


namespace ConsoleShapeDrawerArchitectured.Utilities
{
    public static class Extentions
    {
        public static int GetByteValue(this Enum e)
        {
            return e.GetValue<byte>();
        }
        public static T GetValue<T>(this Enum e) where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            return (T)(object)e;
        }
        public static IEnumerable<TEnum> EnumValues<TEnum>() where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var enumType = typeof(TEnum);

            // Optional runtime check for completeness    
            if (!enumType.IsEnum)
            {
                throw new ArgumentException();
            }

            return Enum.GetValues(enumType).Cast<TEnum>();
        }
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
            => self.Select((item, index) => (item, index));

        public static Structs.Coordinate GetValueByKey(this KeyValuePair<Char, Structs.Coordinate>[] collection, Char key)
        {
            return collection.FirstOrDefault(k => k.Key == key).Value;
        }
        public static List<T> TryGet<T>(this Dictionary<int, List<T>> dict, int key)
        {
            return dict.TryGetValue(key, out var output) ? output : new List<T>();
        }
        public static string DefaultValueAttribute<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());
            DefaultValueAttribute[] attributes = (DefaultValueAttribute[])fi.GetCustomAttributes(typeof(DefaultValueAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Value.ToString();
            else
                return string.Empty;
        }
        public static object? ReflectClassInstanceByTypeName(this string typeName)
        {
            object? retVal = null;
            // scan for the class type
            var type = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                        from t in assembly.GetTypes()
                        where t.Name == typeName  // you could use the t.FullName as well
                        select t).FirstOrDefault();

            if (type == null)
                throw new InvalidOperationException("Type not found");
            else
                retVal = Activator.CreateInstance(type);

            return retVal;
        }
        public static List<PropertyInfo> GetProperties(this object obj)
        {
            return obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
        }

        public static List<PropertyInfo> GetRequireds(this List<PropertyInfo> properties)
        {
            return properties.Where(p => p.GetCustomAttributes(typeof(RequiredAttribute), false).Any()).ToList();
        }
        public static object? ReflectShapeInstanceByShapeType(this Enums.ShapeTypes shapeType)
        {
            object? retVal = null;
            string typeName = shapeType.ToString();
            // scan for the class type
            var type = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                        from t in assembly.GetTypes()
                        where t.Name == typeName  // you could use the t.FullName as well
                        select t).FirstOrDefault();

            if (type == null)
                throw new InvalidOperationException("Type not found");
            else
                retVal = Activator.CreateInstance(type);

            return retVal;
        }
        public static string? DisplayAttributeFromResources(this PropertyInfo property)
        {
            string? retVal = string.Empty;
            //gets property display name by Display attribute
            var anonymouseAttributes = property.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault();
            if (anonymouseAttributes is not null)
            {
                DisplayAttribute? displayAttribute = (DisplayAttribute)anonymouseAttributes;
                if (displayAttribute.Name is not null)
                    retVal = Resources.MessageResource.ResourceManager.GetString(displayAttribute.Name);
            }
            return retVal;
        }
        public static Structs.Range RangeAttributeInByte(this PropertyInfo property)
        {
            Structs.Range retVal = new Structs.Range();
            //gets property display name by Display attribute
            var anonymouseAttributes = property.GetCustomAttributes(typeof(RangeAttribute), false).FirstOrDefault();
            if (anonymouseAttributes is not null)
            {
                RangeAttribute? rangeAttribute = (RangeAttribute)anonymouseAttributes;
                if (rangeAttribute is not null)
                {
                    retVal.MinValue = rangeAttribute.Minimum != null ? Convert.ToByte(rangeAttribute.Minimum) : null;
                    retVal.MaxValue = rangeAttribute.Maximum != null ? Convert.ToByte(rangeAttribute.Maximum) : null;
                }
            }
            return retVal;
        }
        public static string DefaultValueAttribute(this FieldInfo fi)
        {
            DefaultValueAttribute[] attributes = (DefaultValueAttribute[])fi.GetCustomAttributes(typeof(DefaultValueAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Value.ToString();
            else
                return string.Empty;

        }
        public static string DescriptionAttribute<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return string.Empty;
        }
        public static string DescriptionAttribute(this FieldInfo fi)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return string.Empty;
        }
        /// <summary>
        ///  Obtains the next character or function key pressed by the user and determindes the key is Enter key
        /// </summary>
        /// <returns></returns>
        public static bool IsEnterKey(this ConsoleKeyInfo keyInput)
        {
            return keyInput.Key == ConsoleKey.Enter ? true : false;
        }
        /// <summary>
        ///  Obtains the next character or function key pressed by the user and determindes the key is Esc key
        /// </summary>
        /// <returns></returns>
        public static bool IsEscapeKey(this ConsoleKeyInfo keyInput)
        {

            return keyInput.Key == ConsoleKey.Escape ? true : false;

        }
        public static string KeyCharRecognition(this char keyChar)
        {
            string retVal = string.Empty;
            switch (keyChar)
            {
                case (char)13: retVal = "Enter"; break;
                case (char)27: retVal = "Escape"; break;
                case (char)32: retVal = "Space"; break;
                default:
                    {
                        if (Char.IsLetterOrDigit(keyChar))
                            retVal = keyChar.ToString();
                        else
                            retVal = Resources.MessageResource.UnKnownKey;
                        break;
                    }
            }
            return retVal;
        }
        public static int GetNumberFromKeyValue(this char keyChar)
        {
            int retVal = -1;
            if (Char.IsNumber(keyChar))
                if (keyChar >= 48 && keyChar <= 57)
                {
                    return keyChar - 48;
                }
                else if (keyChar >= 96 && keyChar <= 105)
                {
                    return keyChar - 96;
                }
            return retVal;


        }
        public static string StringToUTF8(this string text)
        {
            return Encoding.UTF8.GetString(Encoding.Default.GetBytes(text));
        }
        public static string DrawingPrerestiquies(this Enums.ShapeTypes shape)
        {
            return ($" Drawing a {shape} {shape.DescriptionAttribute()}");
        }
        public static string AsStringItem(this Enum enumType)
        {
            return ($" #{enumType.GetByteValue()}({enumType.DefaultValueAttribute()}) - {enumType} " +
                $"{Resources.MessageResource.ArrowLetter} {enumType.DescriptionAttribute()}");
        }

    }
}
