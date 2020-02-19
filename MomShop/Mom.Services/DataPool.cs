using DataClassWeb;

namespace Mom.Services
{
    public static class DataPool
    {
        public readonly static DataClassWeb.DataPool data = new DataClassWeb.DataPool(System.Configuration.ConfigurationManager.AppSettings["ConnStr"]); 
    }
}
