/*
Copyright (C) 2017  Iván Rosales Rieloff

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
*/
using Microsoft.Practices.ESB.Exception.Management;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyProvider.Providers
{
    public static class Helpers
    {
        private const string STR_WCFWebHttpAdapterPropiedadEncontradaConElValor = " [WCFWebHttpAdapter] propiedad {0} encontrada con el valor {1}";
        private const string STR_WCFWebHttpAdapterPropiedadNoEncontradaEstablecie = " [WCFWebHttpAdapter] propiedad {0} No encontrada estableciendo valor por defecto";
        public static string GetValue(this IDictionary<string, string> customProps, string PropName)
        {
            string retVal;
            var name = PropName.ToUpper(System.Globalization.CultureInfo.InvariantCulture);
            if (customProps.TryGetValue(name, out retVal))
            {
                EventLogger.Write(string.Format(STR_WCFWebHttpAdapterPropiedadEncontradaConElValor, name, retVal));
                return retVal;
            }
            else
            {
                EventLogger.Write(string.Format(STR_WCFWebHttpAdapterPropiedadNoEncontradaEstablecie, name));
                switch (name)
                {
                    case "HTTPMETHODANDURL":
                        return "<BtsHttpUrlMapping></BtsHttpUrlMapping>";
                    case "HTTPHEADERS":
                        return "Content-Type: application/json";
                    case "VARIABLEPROPERTYMAPPING":
                        return "<BtsVariablePropertyMapping xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"></BtsVariablePropertyMapping>";
                    case "SUPPRESSMESSAGEBODYFORHTTPVERBS":
                        return string.Empty;
                    case "SECURITYMODE":
                        return "None";
                    case "TRANSPORTCLIENTCREDENTIALTYPE":
                        return "None";
                    case "USERNAME":
                        return string.Empty;
                    case "PASSWORD":
                        return string.Empty;
                    case "OPERATION":
                        return "Get";
                    case "SENDTIMEOUT":
                        return "00:01:00";
                    case "OPENTIMEOUT":
                        return "00:10:00";
                    case "CLOSETIMEOUT":
                        return "00:01:00";
                    case "PROXYADDRESS":
                        return string.Empty;
                    case "PROXYTOUSE":
                        return "Default";
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
