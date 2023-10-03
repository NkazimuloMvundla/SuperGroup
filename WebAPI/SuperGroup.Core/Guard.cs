using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperGroup.Core
{
    public static class Guard
    {
        public static void ArgumentNotDefault(int argumentValue, string argumentName)
        {
            if (argumentValue == default(int))
            {
                throw new ArgumentException("The provided argument must not be default.", argumentName);
            }
        }

        public static void ArgumentNotDefault(Guid argumentValue, string argumentName)
        {
            if (argumentValue == default(Guid))
            {
                throw new ArgumentException("The provided argument must not be default.", argumentName);
            }
        }

        public static void ArgumentNotNull(object argumentValue, string argumentName)
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void ArgumentNotNullOrEmpty<T>(IEnumerable<T> argumentValue, string argumentName)
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName);
            }

            if (!argumentValue.Any())
            {
                throw new ArgumentException("The provided argument must not be empty.", argumentName);
            }
        }

        public static void ArgumentNotNullOrWhiteSpace(string argumentValue, string argumentName)
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName);
            }

            if (String.IsNullOrWhiteSpace(argumentValue))
            {
                throw new ArgumentException("The provided argument must not be empty.", argumentName);
            }
        }
    }
}
