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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MyProvider.Providers
{
    public static class WebHttpOptions
    {
        private static readonly XmlQualifiedName _httpMethodAndUrl = new WCF.HttpMethodAndUrl().Name;
        private static readonly XmlQualifiedName _operation = new BTS.Operation().Name;
        private static readonly XmlQualifiedName _httpHeaders = new WCF.HttpHeaders().Name;
        private static readonly XmlQualifiedName _variablePropertyMapping = new WCF.VariablePropertyMapping().Name;
        private static readonly XmlQualifiedName _suppressMessageBodyForHttpVerbs = new WCF.SuppressMessageBodyForHttpVerbs().Name;
        private static readonly XmlQualifiedName _securityMode = new WCF.SecurityMode().Name;
        private static readonly XmlQualifiedName _transportClientCredentialType = new WCF.TransportClientCredentialType().Name;
        private static readonly XmlQualifiedName _userName = new WCF.UserName().Name;
        private static readonly XmlQualifiedName _password = new WCF.Password().Name;
        private static readonly XmlQualifiedName _sendTimeOut = new WCF.SendTimeout().Name;
        private static readonly XmlQualifiedName _maxReceiveMessageSize = new WCF.MaxReceivedMessageSize().Name;


        private static readonly XmlQualifiedName _proxyAddress = new WCF.ProxyAddress().Name;
        private static readonly XmlQualifiedName _proxyToUse = new WCF.ProxyToUse().Name;
        private static readonly XmlQualifiedName _closeTimeOut = new WCF.CloseTimeout().Name;
        private static readonly XmlQualifiedName _openTimeOut = new WCF.OpenTimeout().Name;

        private static readonly XmlQualifiedName _action = new WCF.Action().Name;

        public static XmlQualifiedName Action
        {
            get
            {
                return _action;
            }
        }
        public static XmlQualifiedName CloseTimeout
        {
            get
            {
                return _closeTimeOut;
            }
        }





        public static XmlQualifiedName HttpMethodAndUrl
        {
            get
            {
                return _httpMethodAndUrl;
            }
        }
        public static XmlQualifiedName MaxReceiveMessageSize
        {
            get
            {
                return _maxReceiveMessageSize;
            }
        }
        public static XmlQualifiedName OpenTimeout
        {
            get
            {
                return _openTimeOut;
            }
        }
        public static XmlQualifiedName Operation
        {
            get
            {
                return _operation;
            }
        }
        public static XmlQualifiedName HttpHeaders
        {
            get
            {
                return _httpHeaders;
            }
        }
        public static XmlQualifiedName Password
        {
            get
            {
                return _password;
            }
        }

        public static XmlQualifiedName ProxyAddress
        {
            get
            {
                return _proxyAddress;
            }
        }
        public static XmlQualifiedName ProxyToUse
        {
            get
            {
                return _proxyToUse;
            }
        }
        public static XmlQualifiedName SecurityMode
        {
            get
            {
                return _securityMode;
            }
        }
        public static XmlQualifiedName SendTimeout
        {
            get
            {
                return _sendTimeOut;
            }
        }
        public static XmlQualifiedName SuppressMessageBodyForHttpVerbs
        {
            get
            {
                return _suppressMessageBodyForHttpVerbs;
            }
        }
        public static XmlQualifiedName TransportClientCredentialType
        {
            get
            {
                return _transportClientCredentialType;
            }
        }
        public static XmlQualifiedName UserName
        {
            get
            {
                return _userName;
            }
        }
        public static XmlQualifiedName VariablePropertyMapping
        {
            get
            {
                return _variablePropertyMapping;
            }
        }
    }
}
