using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace E.Stadium.Abstraction.Json;

public static class Extensions
{
    public static IMvcBuilder AddDefaultJsonOptions(this IMvcBuilder builder)
    {
        builder.AddNewtonsoftJson(delegate (MvcNewtonsoftJsonOptions o)
        {
            PropertyInfo[] properties = JsonSettings.Settings.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                o.SerializerSettings.GetType().GetProperty(propertyInfo.Name)?.SetValue(o.SerializerSettings, propertyInfo.GetValue(JsonSettings.Settings), null);
            }
        });
        builder.Services.AddSingleton(JsonSettings.Settings);
        return builder;
    }
}
