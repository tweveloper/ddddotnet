using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Module
{
    public static class DescriptionManager<T> where T : class
    {
        public static void UpdateHasComment(EntityTypeBuilder<T> builder)
        {
            foreach (var property in typeof(T).GetProperties())
            {
                var attrs = property.GetCustomAttributes(typeof(DescriptionAttribute), false);
                var description = ((DescriptionAttribute)attrs[0]).Description;
                builder.Property<T>(property.Name).HasComment(description);
            }
        }
    }
}
