//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL.ServiceReferenceSuma {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceSuma.IService2")]
    public interface IService2 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService2/Saludar", ReplyAction="http://tempuri.org/IService2/SaludarResponse")]
        string Saludar();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService2/Saludar", ReplyAction="http://tempuri.org/IService2/SaludarResponse")]
        System.Threading.Tasks.Task<string> SaludarAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService2/Suma", ReplyAction="http://tempuri.org/IService2/SumaResponse")]
        int Suma(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService2/Suma", ReplyAction="http://tempuri.org/IService2/SumaResponse")]
        System.Threading.Tasks.Task<int> SumaAsync(int a, int b);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService2Channel : PL.ServiceReferenceSuma.IService2, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service2Client : System.ServiceModel.ClientBase<PL.ServiceReferenceSuma.IService2>, PL.ServiceReferenceSuma.IService2 {
        
        public Service2Client() {
        }
        
        public Service2Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service2Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service2Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service2Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Saludar() {
            return base.Channel.Saludar();
        }
        
        public System.Threading.Tasks.Task<string> SaludarAsync() {
            return base.Channel.SaludarAsync();
        }
        
        public int Suma(int a, int b) {
            return base.Channel.Suma(a, b);
        }
        
        public System.Threading.Tasks.Task<int> SumaAsync(int a, int b) {
            return base.Channel.SumaAsync(a, b);
        }
    }
}
