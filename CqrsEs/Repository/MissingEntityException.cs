using System;

namespace CqrsEs
{
    public class MissingEntityException : Exception
    {
        public MissingEntityException(Type idType) : base(String.Format("{0} not found", idType))
        {
        }
    }
}
