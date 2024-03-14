
namespace EmployeeSystem.Domain.Common.CommonMethod
{
    public static class ObjectExtensions
    {
        #region Methods

        public static bool IsNotNull(this object s)
        {
            return null != s;
        }

        public static bool IsNotNullOrEmpty(this object s)
        {
            return !s.IsNullOrEmpty();
        }

        public static bool IsNull(this object s)
        {
            return null == s;
        }

        public static bool IsNullOrEmpty(this object s)
        {
            return "".IsNullOrEmpty(s);
        }

        public static bool IsNullOrEmptyOrDbNull(this object objectToCheck)
        {
            return (objectToCheck.IsNullOrEmpty() || objectToCheck == DBNull.Value);
        }

        public static bool IsNotNullOrEmptyOrDbNull(this object objectToCheck)
        {
            return !(objectToCheck.IsNullOrEmpty() || objectToCheck == DBNull.Value);
        }

        public static bool IsNullOrEmpty(this object o, object toCheck)
        {
            if (null == toCheck)
                return true;
            if (String.IsNullOrEmpty(toCheck.ToString().Trim()))
                return true;

            return false;
        }
        #endregion Methods 
    }
}
