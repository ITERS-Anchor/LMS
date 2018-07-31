# LMS
Note:

In LMS/App-start/ Webapiconfig.cs

config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =Newtonsoft.Json.ReferenceLoopHandling.Ignore;

and also disable Lazy Loading
        
