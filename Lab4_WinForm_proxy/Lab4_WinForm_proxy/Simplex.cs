﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

// 
// Этот исходный код был создан с помощью wsdl, версия=4.8.3928.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name="SimplexSoap", Namespace="http://mtd/")]
public partial class Simplex : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    private System.Threading.SendOrPostCallback AddOperationCompleted;
    
    private System.Threading.SendOrPostCallback ConcatOperationCompleted;
    
    private System.Threading.SendOrPostCallback SumOperationCompleted;
    
    /// <remarks/>
    public Simplex() {
        this.Url = "http://localhost:64888/Simplex.asmx";
    }
    
    /// <remarks/>
    public event AddCompletedEventHandler AddCompleted;
    
    /// <remarks/>
    public event ConcatCompletedEventHandler ConcatCompleted;
    
    /// <remarks/>
    public event SumCompletedEventHandler SumCompleted;
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://mtd/Sum_1", RequestElementName="Sum_1", RequestNamespace="http://mtd/", ResponseElementName="Sum_1Response", ResponseNamespace="http://mtd/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("Sum_1Result")]
    public int Add(int x, int y) {
        object[] results = this.Invoke("Add", new object[] {
                    x,
                    y});
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginAdd(int x, int y, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("Add", new object[] {
                    x,
                    y}, callback, asyncState);
    }
    
    /// <remarks/>
    public int EndAdd(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void AddAsync(int x, int y) {
        this.AddAsync(x, y, null);
    }
    
    /// <remarks/>
    public void AddAsync(int x, int y, object userState) {
        if ((this.AddOperationCompleted == null)) {
            this.AddOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddOperationCompleted);
        }
        this.InvokeAsync("Add", new object[] {
                    x,
                    y}, this.AddOperationCompleted, userState);
    }
    
    private void OnAddOperationCompleted(object arg) {
        if ((this.AddCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.AddCompleted(this, new AddCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://mtd/Sum_2", RequestElementName="Sum_2", RequestNamespace="http://mtd/", ResponseElementName="Sum_2Response", ResponseNamespace="http://mtd/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("Sum_2Result")]
    public string Concat(string s, double d) {
        object[] results = this.Invoke("Concat", new object[] {
                    s,
                    d});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginConcat(string s, double d, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("Concat", new object[] {
                    s,
                    d}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndConcat(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public void ConcatAsync(string s, double d) {
        this.ConcatAsync(s, d, null);
    }
    
    /// <remarks/>
    public void ConcatAsync(string s, double d, object userState) {
        if ((this.ConcatOperationCompleted == null)) {
            this.ConcatOperationCompleted = new System.Threading.SendOrPostCallback(this.OnConcatOperationCompleted);
        }
        this.InvokeAsync("Concat", new object[] {
                    s,
                    d}, this.ConcatOperationCompleted, userState);
    }
    
    private void OnConcatOperationCompleted(object arg) {
        if ((this.ConcatCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.ConcatCompleted(this, new ConcatCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://mtd/Sum_3", RequestElementName="Sum_3", RequestNamespace="http://mtd/", ResponseElementName="Sum_3Response", ResponseNamespace="http://mtd/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("Sum_3Result")]
    public A Sum(A a1, A a2) {
        object[] results = this.Invoke("Sum", new object[] {
                    a1,
                    a2});
        return ((A)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginSum(A a1, A a2, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("Sum", new object[] {
                    a1,
                    a2}, callback, asyncState);
    }
    
    /// <remarks/>
    public A EndSum(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((A)(results[0]));
    }
    
    /// <remarks/>
    public void SumAsync(A a1, A a2) {
        this.SumAsync(a1, a2, null);
    }
    
    /// <remarks/>
    public void SumAsync(A a1, A a2, object userState) {
        if ((this.SumOperationCompleted == null)) {
            this.SumOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSumOperationCompleted);
        }
        this.InvokeAsync("Sum", new object[] {
                    a1,
                    a2}, this.SumOperationCompleted, userState);
    }
    
    private void OnSumOperationCompleted(object arg) {
        if ((this.SumCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.SumCompleted(this, new SumCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    public new void CancelAsync(object userState) {
        base.CancelAsync(userState);
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://mtd/")]
public partial class A {
    
    private string sField;
    
    private int kField;
    
    private float fField;
    
    /// <remarks/>
    public string s {
        get {
            return this.sField;
        }
        set {
            this.sField = value;
        }
    }
    
    /// <remarks/>
    public int k {
        get {
            return this.kField;
        }
        set {
            this.kField = value;
        }
    }
    
    /// <remarks/>
    public float f {
        get {
            return this.fField;
        }
        set {
            this.fField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
public delegate void AddCompletedEventHandler(object sender, AddCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class AddCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal AddCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public int Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
public delegate void ConcatCompletedEventHandler(object sender, ConcatCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class ConcatCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal ConcatCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public string Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((string)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
public delegate void SumCompletedEventHandler(object sender, SumCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class SumCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal SumCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public A Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((A)(this.results[0]));
        }
    }
}