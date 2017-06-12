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
using Microsoft.BizTalk.Message.Interop;
using Microsoft.Practices.ESB.Adapter;
using Microsoft.Practices.ESB.Exception.Management;
using Microsoft.XLANGs.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ESB.Common;
using Microsoft.Practices.ESB.GlobalPropertyContext;


namespace MyProvider.Providers
{
    public class WCFWebHttpAdapterProvider : BaseAdapterProvider
    {
        public override string AdapterName
        {
            get
            {
                return "WCF-WebHttp";
            }
        }



        protected override void SetContextProperties(IBaseMessageContext pipelineContext, System.Collections.Generic.Dictionary<string, string> ResolverDictionary)
        {
            var _transportLocation = ResolverDictionary["Resolver.TransportLocation"];
            var _endpointConfig = ResolverDictionary["Resolver.EndpointConfig"];
            var _operation = ResolverDictionary["Resolver.Action"];
            EventLogger.Write(string.Format("Resolver retorna la accion de {0}.", _operation));
            pipelineContext.Write(BtsProperties.OutboundTransportLocation.Name, BtsProperties.OutboundTransportLocation.Namespace, _transportLocation);
            pipelineContext.Write(BtsProperties.OutboundTransportType.Name, BtsProperties.OutboundTransportType.Namespace, AdapterName);

            var customProps = new Dictionary<string, string>();
            customProps = _endpointConfig.ParseKeyValuePairs(true);
            EventLogger.Write("Custom properties");




            pipelineContext.Promote(WebHttpOptions.Operation.Name, WebHttpOptions.Operation.Namespace, _operation);

            pipelineContext.Write(WebHttpOptions.Action.Name, WebHttpOptions.Action.Namespace, _operation);
            pipelineContext.Write(WebHttpOptions.HttpMethodAndUrl.Name, WebHttpOptions.HttpMethodAndUrl.Namespace, customProps.GetValue("HttpMethodAndUrl"));
            pipelineContext.Write(WebHttpOptions.HttpHeaders.Name, WebHttpOptions.HttpHeaders.Namespace, customProps.GetValue("HttpHeaders"));
            pipelineContext.Write(WebHttpOptions.VariablePropertyMapping.Name, WebHttpOptions.VariablePropertyMapping.Namespace, customProps.GetValue("VariablePropertyMapping"));
            pipelineContext.Write(WebHttpOptions.SuppressMessageBodyForHttpVerbs.Name, WebHttpOptions.SuppressMessageBodyForHttpVerbs.Namespace, customProps.GetValue("SuppressMessageBodyForHttpVerbs"));
            pipelineContext.Write(WebHttpOptions.SecurityMode.Name, WebHttpOptions.SecurityMode.Namespace, customProps.GetValue("SecurityMode"));
            pipelineContext.Write(WebHttpOptions.TransportClientCredentialType.Name, WebHttpOptions.TransportClientCredentialType.Namespace, customProps.GetValue("TransportClientCredentialType"));
            pipelineContext.Write(WebHttpOptions.UserName.Name, WebHttpOptions.UserName.Namespace, customProps.GetValue("UserName"));
            pipelineContext.Write(WebHttpOptions.Password.Name, WebHttpOptions.Password.Namespace, customProps.GetValue("Password"));
            pipelineContext.Write(WebHttpOptions.SendTimeout.Name, WebHttpOptions.SendTimeout.Namespace, customProps.GetValue("SendTimeout"));
            pipelineContext.Write(WebHttpOptions.OpenTimeout.Name, WebHttpOptions.OpenTimeout.Namespace, customProps.GetValue("OpenTimeout"));
            pipelineContext.Write(WebHttpOptions.CloseTimeout.Name, WebHttpOptions.CloseTimeout.Namespace, customProps.GetValue("CloseTimeout"));
            pipelineContext.Write(WebHttpOptions.ProxyToUse.Name, WebHttpOptions.ProxyToUse.Namespace, customProps.GetValue("ProxyToUse"));
            pipelineContext.Write(WebHttpOptions.ProxyAddress.Name, WebHttpOptions.ProxyAddress.Namespace, customProps.GetValue("ProxyAddress"));
        }



        public override void SetEndpoint(Dictionary<string, string> resolverDictionary, XLANGMessage message)
        {
            if (resolverDictionary == null)
            {
                throw new ArgumentNullException("resolverDictionary");
            }
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }
            try
            {
                var transportLocation = resolverDictionary["Resolver.TransportLocation"];

                var outboundTransportCLSID = resolverDictionary["Resolver.OutboundTransportCLSID"];
                var endpointConfig = resolverDictionary["Resolver.EndpointConfig"];
                var transportType = resolverDictionary["Resolver.TransportType"];
                var messageExchangePattern = resolverDictionary["Resolver.MessageExchangePattern"];
                var _operation = resolverDictionary["Resolver.Action"];

                var customProps = new Dictionary<string, string>();
                customProps = endpointConfig.ParseKeyValuePairs(true);
                message.SetMsgProperty(typeof(BTS.OutboundTransportLocation), transportLocation);
                message.SetMsgProperty(typeof(BTS.OutboundTransportType), transportType);
                message.SetMsgProperty(typeof(BTS.OutboundTransportCLSID), outboundTransportCLSID);
                message.SetMsgProperty(typeof(BTS.Operation), _operation);
                message.SetMsgProperty(typeof(BTS.MessageExchangePattern), messageExchangePattern);

                message.SetMsgProperty(typeof(WCF.Action), _operation);
                message.SetMsgProperty(typeof(WCF.HttpMethodAndUrl), customProps.GetValue("HttpMethodAndUrl"));
                message.SetMsgProperty(typeof(WCF.HttpHeaders), customProps.GetValue("HttpHeaders"));
                message.SetMsgProperty(typeof(WCF.VariablePropertyMapping), customProps.GetValue("VariablePropertyMapping"));
                message.SetMsgProperty(typeof(WCF.SuppressMessageBodyForHttpVerbs), customProps.GetValue("SuppressMessageBodyForHttpVerbs"));
                message.SetMsgProperty(typeof(WCF.SecurityMode), customProps.GetValue("SecurityMode"));
                message.SetMsgProperty(typeof(WCF.TransportClientCredentialType), customProps.GetValue("TransportClientCredentialType"));
                message.SetMsgProperty(typeof(WCF.UserName), customProps.GetValue("UserName"));
                message.SetMsgProperty(typeof(WCF.Password), customProps.GetValue("Password"));
                message.SetMsgProperty(typeof(WCF.SendTimeout), customProps.GetValue("SendTimeout"));
                message.SetMsgProperty(typeof(WCF.OpenTimeout), customProps.GetValue("OpenTimeout"));
                message.SetMsgProperty(typeof(WCF.CloseTimeout), customProps.GetValue("CloseTimeout"));
                message.SetMsgProperty(typeof(WCF.ProxyToUse), customProps.GetValue("ProxyToUse"));
                message.SetMsgProperty(typeof(WCF.ProxyAddress), customProps.GetValue("ProxyAddress"));
                SetEndpointContextProperties(message, endpointConfig);
            }
            catch (System.Exception ex)
            {
                EventLogger.LogMessage(ex.Message,System.Diagnostics.EventLogEntryType.Error,0);
                throw;
            }
        }
    }
}
