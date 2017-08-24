### the step to use log4net
1. 引用log4net .dll
2. config中增加log4net.xml配置文件
3. 工具类中增加Log4NetHelper.cs文件
 >  
      public class Log4NetHelper{
   
     public Log4NetHelper(){
        var config=CachedConfigContext.Current.ConfigService.GetConfig("log4net");
        config.Replace("{connectionString}",CachedConfigContext.Current.DaoConfig.Log);
        var ms=new MemoryStream(Encoding.Default.GetBytes(config));
        log4net.Config.XmlConfigurator.Configure(ms);
     }
     
     //Debug
     public static void Debug(LoggerType loggerType,object message,Exception e){
        var logger=LogManager.GetLogger(loggerType.ToString());
        logger.Debug(SerializeObject(message),e);
     }
     //Error
     public static void Error(LoggerType loggerType,object message,Exception e){
      var logger=LogManager.GetLogger(loggerType.ToString());
      logger.Error(SerializeObject(mesasge),e);
     }
     //Fatal:致命的
     public static void Fatal(LoggerType loggerType,object message,Exception e){
      var logger=logManager.GetLogger(loggerType.ToString());
      logger.Fatal(SerializeObject(message),e);
     }
     //Warn
     public static void Warn(LoggerType loggerType,object message,Exception e){
      var logger=LogManager.GetLogger(loggerType.ToString());
      logger.Waran(SerializeObject(message),e);
     }
     //Info
     public static void Info(LoggerType loggerType,object message,Exception e){
      var logger=LogManager.GetLogger(loggerType.ToString());
      logger.Info(SerializeObject(message),e);
     }
     private static object SerializeObject(Object message){
       if(message is string ||message==null){
        return message;
       }else
        return JsonConvert.SerializeObject(message,new JsonSerializerSettings(){ReferenceLoopHanding=ReferenceLoopHanding.Ignore});
     }
    }
    public enum LoggerType{
     WebExceptionLog,
     ServiceExceptionLog
    }
 4. ControllerBase.cs中重写OnException方法
 > 
     public class ControllerBase:Controller{
     
        //重写Controller类中Exception方法
        
        protected override void OnException(ExceptionContext filterContext){
           base.OnException(filterContext);
           
           var e=filterContext.Exception;
           
           LogException(e,this.WebExceptionContext);
        }
        
        //虚方法，LogException
        
        protected virtual void LogException(Exception exception,WebExceptionContext exceptionContext==null){
        
          //todo 
        }
     }
