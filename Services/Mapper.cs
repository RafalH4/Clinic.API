using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Services
{
    public static class Mapper
    {
        public static void CopyPropertiesTo(this object source, object target)
        {
            Type sourceType = source.GetType();
            Type targetType = target.GetType();

            foreach(var sourceProperty in sourceType.GetProperties())
            {
                var targetProp = targetType.GetProperty(sourceProperty.Name);
                if(targetProp !=null)
                {
                    targetProp.SetValue(target, sourceProperty.GetValue(source, null), null);
                }
            }
        }
    }
}
