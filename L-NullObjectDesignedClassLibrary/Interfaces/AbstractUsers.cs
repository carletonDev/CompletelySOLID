using System;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Interfaces
{
    /// <summary>
    /// Null object pattern implementation
    /// </summary>
    public abstract class AbstractUsers
    {
        //create a readonly null users object to singleton instantiate all default properties
        public static readonly NullUsers Null = NullUserInst;
        //create a private get property to instantiate the null users object
        private static NullUsers NullUserInst
        {
            get
            {
                return new NullUsers();
            }
        }

        public abstract int UserId { get; set; }
        public abstract string FirstName { get; set; }
        public abstract string LastName { get; set; }
        public abstract string Street { get; set; }
        public abstract string City { get; set; }
        public abstract int? Zip { get; set; }
        public abstract string Phone { get; set; }
        public abstract string Insurance { get; set; }

    }
    /// <summary>
    /// A Null users class inheriting abstract base class that will throw not implemented exceptions if any property field is null
    /// then set its default value C# 7.3 the ? operator for nullable throws errors
    /// </summary>
    public class NullUsers : AbstractUsers
    {
        public override int UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Street { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string City { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int? Zip { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Phone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Insurance { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }


}
