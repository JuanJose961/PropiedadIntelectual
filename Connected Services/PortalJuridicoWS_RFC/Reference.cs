﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GISMVC.PortalJuridicoWS_RFC {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://xmlns.oracle.com/GIS_JURIDICO/WS_NombreProveedorCliente/BPELNomProvClien", ConfigurationName="PortalJuridicoWS_RFC.BPELNomProvClien")]
    public interface BPELNomProvClien {
        
        // CODEGEN: Generating message contract since the operation GisClienProvNom is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="GisClienProvNom", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        GISMVC.PortalJuridicoWS_RFC.GisClienProvNomResponse1 GisClienProvNom(GISMVC.PortalJuridicoWS_RFC.GisClienProvNomRequest1 request);
        
        [System.ServiceModel.OperationContractAttribute(Action="GisClienProvNom", ReplyAction="*")]
        System.Threading.Tasks.Task<GISMVC.PortalJuridicoWS_RFC.GisClienProvNomResponse1> GisClienProvNomAsync(GISMVC.PortalJuridicoWS_RFC.GisClienProvNomRequest1 request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://xmlns.oracle.com/GIS_JURIDICO/WS_NombreProveedorCliente/BPELNomProvClien")]
    public partial class GisClienProvNomRequest : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string p_RFCField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
        public string P_RFC {
            get {
                return this.p_RFCField;
            }
            set {
                this.p_RFCField = value;
                this.RaisePropertyChanged("P_RFC");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://xmlns.oracle.com/GIS_JURIDICO/WS_NombreProveedorCliente/BPELNomProvClien")]
    public partial class GisClienProvNomResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string gIS_CLIENTE_PROV_NOMBRE_FNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
        public string GIS_CLIENTE_PROV_NOMBRE_FN {
            get {
                return this.gIS_CLIENTE_PROV_NOMBRE_FNField;
            }
            set {
                this.gIS_CLIENTE_PROV_NOMBRE_FNField = value;
                this.RaisePropertyChanged("GIS_CLIENTE_PROV_NOMBRE_FN");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GisClienProvNomRequest1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://xmlns.oracle.com/GIS_JURIDICO/WS_NombreProveedorCliente/BPELNomProvClien", Order=0)]
        public GISMVC.PortalJuridicoWS_RFC.GisClienProvNomRequest GisClienProvNomRequest;
        
        public GisClienProvNomRequest1() {
        }
        
        public GisClienProvNomRequest1(GISMVC.PortalJuridicoWS_RFC.GisClienProvNomRequest GisClienProvNomRequest) {
            this.GisClienProvNomRequest = GisClienProvNomRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GisClienProvNomResponse1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://xmlns.oracle.com/GIS_JURIDICO/WS_NombreProveedorCliente/BPELNomProvClien", Order=0)]
        public GISMVC.PortalJuridicoWS_RFC.GisClienProvNomResponse GisClienProvNomResponse;
        
        public GisClienProvNomResponse1() {
        }
        
        public GisClienProvNomResponse1(GISMVC.PortalJuridicoWS_RFC.GisClienProvNomResponse GisClienProvNomResponse) {
            this.GisClienProvNomResponse = GisClienProvNomResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface BPELNomProvClienChannel : GISMVC.PortalJuridicoWS_RFC.BPELNomProvClien, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BPELNomProvClienClient : System.ServiceModel.ClientBase<GISMVC.PortalJuridicoWS_RFC.BPELNomProvClien>, GISMVC.PortalJuridicoWS_RFC.BPELNomProvClien {
        
        public BPELNomProvClienClient() {
        }
        
        public BPELNomProvClienClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BPELNomProvClienClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BPELNomProvClienClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BPELNomProvClienClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GISMVC.PortalJuridicoWS_RFC.GisClienProvNomResponse1 GISMVC.PortalJuridicoWS_RFC.BPELNomProvClien.GisClienProvNom(GISMVC.PortalJuridicoWS_RFC.GisClienProvNomRequest1 request) {
            return base.Channel.GisClienProvNom(request);
        }
        
        public GISMVC.PortalJuridicoWS_RFC.GisClienProvNomResponse GisClienProvNom(GISMVC.PortalJuridicoWS_RFC.GisClienProvNomRequest GisClienProvNomRequest) {
            GISMVC.PortalJuridicoWS_RFC.GisClienProvNomRequest1 inValue = new GISMVC.PortalJuridicoWS_RFC.GisClienProvNomRequest1();
            inValue.GisClienProvNomRequest = GisClienProvNomRequest;
            GISMVC.PortalJuridicoWS_RFC.GisClienProvNomResponse1 retVal = ((GISMVC.PortalJuridicoWS_RFC.BPELNomProvClien)(this)).GisClienProvNom(inValue);
            return retVal.GisClienProvNomResponse;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GISMVC.PortalJuridicoWS_RFC.GisClienProvNomResponse1> GISMVC.PortalJuridicoWS_RFC.BPELNomProvClien.GisClienProvNomAsync(GISMVC.PortalJuridicoWS_RFC.GisClienProvNomRequest1 request) {
            return base.Channel.GisClienProvNomAsync(request);
        }
        
        public System.Threading.Tasks.Task<GISMVC.PortalJuridicoWS_RFC.GisClienProvNomResponse1> GisClienProvNomAsync(GISMVC.PortalJuridicoWS_RFC.GisClienProvNomRequest GisClienProvNomRequest) {
            GISMVC.PortalJuridicoWS_RFC.GisClienProvNomRequest1 inValue = new GISMVC.PortalJuridicoWS_RFC.GisClienProvNomRequest1();
            inValue.GisClienProvNomRequest = GisClienProvNomRequest;
            return ((GISMVC.PortalJuridicoWS_RFC.BPELNomProvClien)(this)).GisClienProvNomAsync(inValue);
        }
    }
}
