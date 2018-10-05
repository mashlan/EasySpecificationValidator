using System;

namespace EasySpecificationValidator.Tests
{
    public static class ExceptionUtilities
    {
        public static string ArgumentNullExceptionMessage(string parameterName) => $"Value cannot be null.{Environment.NewLine}Parameter name: {parameterName}";
    }
}
