using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Models
{
    /// <summary>
    /// Guard Class against Nulls Listkov Subsitution 
    /// </summary>
    public class Guard:IGuard
    {
        //method in guard class that you can call for any data type or class that will throw Argument null exception and guard against nulls
        public  void AgainstNull<T>(T value)
        {
            if (value ==null)
                throw new ArgumentNullException();
        }

        public void AgainstNull<T>(T value, string paramName)
        {
            if (value == null)
                throw new ArgumentNullException(paramName);
        }

        public  void AgainstNull<T>(T value, string paramName, string message)
        {
            if (value == null)
                throw new ArgumentNullException(paramName, message);
        }
        public T IsTypeOf<T>(object obj)
        {
            AgainstNull(obj);

            if (obj is T)
                return (T)obj;
            string t = typeof(T).Name;
            throw new ArgumentException("{0} is not an instance of type:"+""+t,obj.GetType().Name);
        }
       

    }
    /// <summary>
    /// interface for injection of guard class against nulls
    /// </summary>
    public interface IGuard
    {
        void AgainstNull<T>(T value);
        void AgainstNull<T>(T value, string paramName);
        void AgainstNull<T>(T value, string paramName, string message);
        T IsTypeOf<T>(object obj);
    }
}

