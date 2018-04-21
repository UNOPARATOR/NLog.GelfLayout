# NLog.GelfLayout
[![Version](https://img.shields.io/nuget/v/NLog.GelfLayout.svg)](https://www.nuget.org/packages/NLog.GelfLayout) 


GelfLayout is a custom layout renderer for [NLog] to format log meessages as [GELF] Json structures.

## Usage
### Install from Nuget
```
PM> Install-Package NLog.GelfLayout
```
Please note that the [NuGet package](https://nuget.org/packages/NLog.GelfLayout/) (at the moment) is only compiled for the latest .Net framework 4.5.

### NLog Configuration
1. Add ```<add assembly="NLog.Layouts.GelfLayout" />``` to ```<extensions>``` element in NLog.config
2. Set ```layout="${gelf:facility=MyFacility}"``` attribute for ```target``` element 

### Sample Usage with RabbitMQ Target
You can configure this layout for [NLog] Targets that respect Layout attribute. 
For instance the following configuration writes log messages to a [RabbitMQ-adolya] Exchange in [GELF] format.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" >
  <extensions>
    <add assembly="NLog.Targets.RabbitMQ" />
    <add assembly="NLog.Layouts.GelfLayout" />
  </extensions>
  
  <targets async="true">
    <target name="RabbitMQTarget"
            xsi:type="RabbitMQ"
            hostname="mygraylog.mycompany.com"
            exchange="logmessages-gelf"
            durable="true"
            useJSON="false"
            layout="${gelf:facility=MyFacility}"
    />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="RabbitMQTarget" />
  </rules>
</nlog>
```

In this example there would be a [Graylog2] server that consumes the queued [GELF] messages. 

## Credits
[GELF] converter module is all taken from [Gelf4NLog] by [Ozan Seymen](https://github.com/seymen)

[NLog]: http://nlog-project.org/
[GrayLog2]: http://graylog2.org/
[Gelf]: https://www.graylog2.org/resources/gelf/specification
[Gelf4NLog]: https://github.com/seymen/Gelf4NLog
[RabbitMQ-haf]: https://github.com/haf/NLog.RabbitMQ
[RabbitMQ-adolya]: https://www.nuget.org/packages/Nlog.RabbitMQ.Target/
