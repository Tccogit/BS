﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBusManagement.GetData {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://service.avlsite.ir/", ConfigurationName="GetData.GetDataSoap")]
    public interface GetDataSoap {
        
        // CODEGEN: Generating message contract since element name SerialNumber from namespace http://service.avlsite.ir/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://service.avlsite.ir/SetLocation", ReplyAction="*")]
        WebBusManagement.GetData.SetLocationResponse SetLocation(WebBusManagement.GetData.SetLocationRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SetLocationRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SetLocation", Namespace="http://service.avlsite.ir/", Order=0)]
        public WebBusManagement.GetData.SetLocationRequestBody Body;
        
        public SetLocationRequest() {
        }
        
        public SetLocationRequest(WebBusManagement.GetData.SetLocationRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://service.avlsite.ir/")]
    public partial class SetLocationRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string SerialNumber;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Longitude;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Latitude;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string altitude;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string Speed;
        
        public SetLocationRequestBody() {
        }
        
        public SetLocationRequestBody(string SerialNumber, string Longitude, string Latitude, string altitude, string Speed) {
            this.SerialNumber = SerialNumber;
            this.Longitude = Longitude;
            this.Latitude = Latitude;
            this.altitude = altitude;
            this.Speed = Speed;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SetLocationResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SetLocationResponse", Namespace="http://service.avlsite.ir/", Order=0)]
        public WebBusManagement.GetData.SetLocationResponseBody Body;
        
        public SetLocationResponse() {
        }
        
        public SetLocationResponse(WebBusManagement.GetData.SetLocationResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://service.avlsite.ir/")]
    public partial class SetLocationResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string SetLocationResult;
        
        public SetLocationResponseBody() {
        }
        
        public SetLocationResponseBody(string SetLocationResult) {
            this.SetLocationResult = SetLocationResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GetDataSoapChannel : WebBusManagement.GetData.GetDataSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetDataSoapClient : System.ServiceModel.ClientBase<WebBusManagement.GetData.GetDataSoap>, WebBusManagement.GetData.GetDataSoap {
        
        public GetDataSoapClient() {
        }
        
        public GetDataSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GetDataSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetDataSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetDataSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebBusManagement.GetData.SetLocationResponse WebBusManagement.GetData.GetDataSoap.SetLocation(WebBusManagement.GetData.SetLocationRequest request) {
            return base.Channel.SetLocation(request);
        }
        
        public string SetLocation(string SerialNumber, string Longitude, string Latitude, string altitude, string Speed) {
            WebBusManagement.GetData.SetLocationRequest inValue = new WebBusManagement.GetData.SetLocationRequest();
            inValue.Body = new WebBusManagement.GetData.SetLocationRequestBody();
            inValue.Body.SerialNumber = SerialNumber;
            inValue.Body.Longitude = Longitude;
            inValue.Body.Latitude = Latitude;
            inValue.Body.altitude = altitude;
            inValue.Body.Speed = Speed;
            WebBusManagement.GetData.SetLocationResponse retVal = ((WebBusManagement.GetData.GetDataSoap)(this)).SetLocation(inValue);
            return retVal.Body.SetLocationResult;
        }
    }
}
