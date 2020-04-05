using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore31.Demo1.Utility
{
    public class CustomerIOCFilterFactoryAttribute : Attribute,IFilterFactory 
    {
        private readonly Type type = null;
        public CustomerIOCFilterFactoryAttribute(Type _type)
        {
            type = _type;
        }
        public bool IsReusable => true;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
           return (IFilterMetadata)serviceProvider.GetService(type);
        }
    }
}
