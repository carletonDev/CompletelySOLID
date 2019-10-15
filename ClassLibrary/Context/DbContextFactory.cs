using ClassLibrary.EFAutoGen;
using ClassLibrary.Interfaces;
using ClassLibrary.Pharmacy;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Context
{
    /// <summary>
    /// a factory to instantiate the DbContext in my app can add more to interface and intergrate as many databases as you want
    /// need the factory because the connection doesn't work by itself.
    /// </summary>
    public class DbContextFactory : IDbContextFactory
    {
        //my custom DB Context
        public HospitalContext HospitalContext()
        {
            return new HospitalContext();
        }
        //the auto Generated Db Context
        public EFAutoGen.HospitalContext CreateEFAuto()
        {
            return new EFAutoGen.HospitalContext();
        }
        public PharmacyContext PharmacyContext()
        {
            return new PharmacyContext();
        }
    }
}
