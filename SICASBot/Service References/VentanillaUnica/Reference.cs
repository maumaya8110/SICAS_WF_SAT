﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SICASBot.VentanillaUnica {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.eboletos.com.mx/Administrador/WebServices", ConfigurationName="VentanillaUnica.VunicaWSSoap")]
    public interface VunicaWSSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.eboletos.com.mx/Administrador/WebServices/VentaDiariaPorEmpresaMKTest", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet VentaDiariaPorEmpresaMKTest(string p_Usr, string p_Pwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.eboletos.com.mx/Administrador/WebServices/VentaDiariaPorEmpresa", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet VentaDiariaPorEmpresa(string p_Usr, string p_Pwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.eboletos.com.mx/Administrador/WebServices/CancelacionesDiariasPorEmpre" +
            "sa", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet CancelacionesDiariasPorEmpresa(string p_Usr, string p_Pwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.eboletos.com.mx/Administrador/WebServices/UnidadesPorEmpresa", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet UnidadesPorEmpresa(string p_Usr, string p_Pwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.eboletos.com.mx/Administrador/WebServices/ConductoresPorEmpresa", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ConductoresPorEmpresa(string p_Usr, string p_Pwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.eboletos.com.mx/Administrador/WebServices/ZonasPorEmpresa", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ZonasPorEmpresa(string p_Usr, string p_Pwd);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface VunicaWSSoapChannel : SICASBot.VentanillaUnica.VunicaWSSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VunicaWSSoapClient : System.ServiceModel.ClientBase<SICASBot.VentanillaUnica.VunicaWSSoap>, SICASBot.VentanillaUnica.VunicaWSSoap {
        
        public VunicaWSSoapClient() {
        }
        
        public VunicaWSSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VunicaWSSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VunicaWSSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VunicaWSSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet VentaDiariaPorEmpresaMKTest(string p_Usr, string p_Pwd) {
            return base.Channel.VentaDiariaPorEmpresaMKTest(p_Usr, p_Pwd);
        }
        
        public System.Data.DataSet VentaDiariaPorEmpresa(string p_Usr, string p_Pwd) {
            return base.Channel.VentaDiariaPorEmpresa(p_Usr, p_Pwd);
        }
        
        public System.Data.DataSet CancelacionesDiariasPorEmpresa(string p_Usr, string p_Pwd) {
            return base.Channel.CancelacionesDiariasPorEmpresa(p_Usr, p_Pwd);
        }
        
        public System.Data.DataSet UnidadesPorEmpresa(string p_Usr, string p_Pwd) {
            return base.Channel.UnidadesPorEmpresa(p_Usr, p_Pwd);
        }
        
        public System.Data.DataSet ConductoresPorEmpresa(string p_Usr, string p_Pwd) {
            return base.Channel.ConductoresPorEmpresa(p_Usr, p_Pwd);
        }
        
        public System.Data.DataSet ZonasPorEmpresa(string p_Usr, string p_Pwd) {
            return base.Channel.ZonasPorEmpresa(p_Usr, p_Pwd);
        }
    }
}