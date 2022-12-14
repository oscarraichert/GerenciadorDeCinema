using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Dominio.Compartilhado
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum e)
        {
            return e
                .GetType()
                .GetMember(e.ToString())
                .FirstOrDefault()
                ?.GetCustomAttribute<DescriptionAttribute>()
                ?.Description
            ?? e.ToString();
        }
    }
}
