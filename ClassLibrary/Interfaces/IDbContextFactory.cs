using ClassLibrary.Context;
using ClassLibrary.Pharmacy;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Interfaces
{
    /// <summary>
    /// factory pattern implemented for Db Contexices  can add as many Databases you want to the application
    /// </summary>
    public interface IDbContextFactory
    {
        HospitalContext HospitalContext();
        EFAutoGen.HospitalContext CreateEFAuto();

        PharmacyContext PharmacyContext();
    }
}