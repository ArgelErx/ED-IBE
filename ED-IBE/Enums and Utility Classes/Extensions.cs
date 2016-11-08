﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IBE;

namespace IBE.Enums_and_Utility_Classes
{
    
    static class Extensions_CheckBox
    {
        public static int? toNInt(this CheckBox thisCheckBox)
        {
            int? retValue = null ;

            switch (thisCheckBox.CheckState)
            {
                case CheckState.Checked:
                    retValue = 1;
                    break;
                case CheckState.Indeterminate:
                    retValue = null;
                    break;
                case CheckState.Unchecked:
                    retValue = 0;
                    break;
                default:
                    break;
            }

            return retValue;
        }
    }

    static class Extensions_IntNullable
    {
        public static CheckState toCheckState(this int? thisInt)
        {
            CheckState retValue = CheckState.Indeterminate;

            switch (thisInt)
	        {
                case null:
                    retValue = CheckState.Indeterminate;
                    break;
                case 0:
                    retValue = CheckState.Unchecked;
                    break;
                default:
                    retValue = CheckState.Checked;
                    break;
	        }

            return retValue;
        }

        public static string ToNString(this int? thisInt)
        {
            string retValue = null;

            switch (thisInt)
	        {
                case null:
                    retValue = Program.NULLSTRING;
                    break;
                default:
                    retValue = thisInt.ToString();
                    break;
	        }

            return retValue;
        }

        public static string ToNString(this int? thisInt, String NullString)
        {
            string retValue = null;

            switch (thisInt)
	        {
                case null:
                    retValue = NullString;
                    break;
                default:
                    retValue = thisInt.ToString();
                    break;
	        }

            return retValue;
        }
    }

    static class Extensions_LongNullable
    {

        public static string ToNString(this long? thisLong)
        {
            if(thisLong == null)
                return Program.NULLSTRING;
            else
                return thisLong.ToString();
        }

        public static string ToNString(this long? thisLong, string format, IFormatProvider provider)
        {
            if(thisLong == null)
                return Program.NULLSTRING;
            else
                return ((long)thisLong).ToString(format, provider);
        }

        public static string ToNString(this int? thisInt, string format, IFormatProvider provider)
        {
            if(thisInt == null)
                return Program.NULLSTRING;
            else
                return ((int)thisInt).ToString(format, provider);
        }
    }
    
    static class Extensions_Int32ArrayNullable
    {
        /// <summary>
        /// clones a string array and return null if the source array is null
        /// </summary>
        /// <param name="thisString">a string or null</param>
        /// <returns></returns>
        public static Int32[] CloneN(this Int32[] thisInt32Array)
        {
            if(thisInt32Array == null)
                return null;
            else
                return (Int32[])thisInt32Array.Clone();
        }
    }
    
    static class Extensions_StringArrayNullable
    {
        /// <summary>
        /// clones a string array and return null if the source array is null
        /// </summary>
        /// <param name="thisString">a string or null</param>
        /// <returns></returns>
        public static string[] CloneN(this string[] thisStringArray)
        {
            if(thisStringArray == null)
                return null;
            else
                return (string[])thisStringArray.Clone();
        }
    }

    static class Extensions_StringNullable
    {
        /// <summary>
        /// converts a string that can be null to a string that represents null as a string ("undefined")
        /// </summary>
        /// <param name="thisString">a string or null</param>
        /// <returns></returns>
        public static Boolean EqualsNullOrEmpty(this string thisString, String otherString)
        {
            if (string.IsNullOrEmpty(thisString))
            {
                return string.IsNullOrEmpty(otherString);
            }
            else
            {
                return string.Equals(thisString, otherString);
            }
        }

        /// <summary>
        /// converts a string that can be null to a string that represents null as a string ("undefined")
        /// </summary>
        /// <param name="thisString">a string or null</param>
        /// <returns></returns>
        public static string NToString(this string thisString, String NullString)
        {
            if(thisString == null)
                return NullString;
            else
                return thisString;
        }

        /// <summary>
        /// converts a string that can be null to a string that represents null as a string ("undefined")
        /// </summary>
        /// <param name="thisString">a string or null</param>
        /// <returns></returns>
        public static string NToString(this string thisString)
        {
            return NToString(thisString, Program.NULLSTRING);
        }

        /// <summary>
        /// converts a possible null-representing string ("undefined") to a string or null
        /// </summary>
        /// <param name="thisString">a string or null</param>
        /// <returns></returns>
        public static string ToNString(this string thisString)
        {

            if(String.IsNullOrEmpty(thisString) || thisString.Equals(Program.NULLSTRING))
                return null;
            else
                return thisString;
        }

        public static Double ToDouble(this string thisString, string defaultValue="")
        {
            Double Value = 0.0;

            if(Double.TryParse(thisString, out Value))
                return Value;
            else
                return Double.Parse(defaultValue);
        }

        public static long? ToNLong(this string thisString, string defaultValue="")
        {
            long Value = 0;

            if(String.IsNullOrEmpty(thisString) || thisString.Equals(Program.NULLSTRING))
                return null;
            else
                if(long.TryParse(thisString, out Value))
                    return (long?)Value;
                else
                    return defaultValue.ToNLong();
        }

        public static int? ToNInt(this string thisString, string defaultValue="")
        {
            long Value = 0;

            if(String.IsNullOrEmpty(thisString) || thisString.Equals(Program.NULLSTRING))
                return null;
            else
                if(long.TryParse(thisString, out Value))
                    return (int?)Value;
                else
                    return defaultValue.ToNInt();
        }

    }

    static class Extensions_Object
    {
        /// <summary>
        /// converts a string that can be null to a string that represents null as a string ("undefined")
        /// </summary>
        /// <param name="thisString">a string or null</param>
        /// <returns></returns>
        public static string NToString(this Object thisObject)
        {

            if(thisObject == null)
                return Program.NULLSTRING;
            else
                return thisObject.ToString();
        }

    }

    static class Extensions_Control
    {
        /// <summary>
        /// Checks whether a control or its parent is in design mode.
        /// </summary>
        /// <param name="c">The control to check.</param>
        /// <returns>Returns TRUE if in design mode, false otherwise.</returns>
        public static bool IsDesignMode(this System.Windows.Forms.Control c)
        {
            if ( c == null )
            {
                return false;
            }
            else
            {
                while ( c != null )
                {
                if ( c.Site != null && c.Site.DesignMode )
                {
                    return true;
                }
                else
                {
                    c = c.Parent;
                }
                }

                return false;
            }
        }
    }

    static class Extensions_Event
    {

        /// <summary>
        /// adds a null-checking "Raise" mechanism to events
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventHandler"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Raise <T> (this EventHandler <T> eventHandler, Object sender, T e) where T : EventArgs
        {
           if (eventHandler != null) {
              eventHandler (sender, e);
           }
        }
    }

    static class Extensions_DateTime
    {
        public static DateTime Truncate(this DateTime dateTime, TimeSpan timeSpan)
        {
            if (timeSpan == TimeSpan.Zero) return dateTime; // Or could throw an ArgumentException
            return dateTime.AddTicks(-(dateTime.Ticks % timeSpan.Ticks));
        }
    }

    static class Extensions_IEnumerable
    {
        public static bool ContentEquals<T>(this IEnumerable<T> list1, IEnumerable<T> list2)
        {

            var cnt = new Dictionary<T, int>();

            foreach (T s in list1)
            {
                if (cnt.ContainsKey(s))
                    cnt[s]++;
                else
                    cnt.Add(s, 1);
            }

            foreach (T s in list2)
            {
                if (cnt.ContainsKey(s))
                    cnt[s]--;
                else
                    return false;
            }

            return cnt.Values.All(c => c == 0);
        }
    }

}
