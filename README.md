# Microsoft .Net Web OAuth

### [中文](https://github.com/JinGangRed/Web-NetFramework-OAuth/edit/master/README-cn.md)

## 目录

* [项目介绍](#项目介绍)
* [预备条件](#预备条件)
* [项目配置](#项目配置)
* [项目结构](#项目结构)
* [可用资源](#可用资源)
* [问题反馈](#问题反馈)

## 项目介绍

在使用Microsoft Graph API或调用各个产品自身Rest API时，需要从 Microsoft 的云标识服务 Azure Active Directory (Azure AD) 获取访问令牌。
虽然官方已经给出了许多关于如何获取Azure AD访问令牌的例子,但是这个项目是完全代码实现OAuth 2.0 的验证，并且使用.Net MVC完成对Graph的API和Office 365。
更多关于GraphAPI的使用,可参考文档：[Microsoft Graph API](https://developer.microsoft.com/zh-cn/graph/docs/concepts/overview)

## 预备条件

在使用这个项目代码的时候，需要在Azure 上或 [Graph API APP](https://apps.dev.microsoft.com)上注册一个应用。
可以参考文档：[注册Microsoft应用](https://developer.microsoft.com/zh-cn/graph/docs/concepts/aspnetmvc#register-the-application)


## 项目配置
在注册应用时，你需要保存应用的APPID(Client ID),APPSecret(Client Secret),并且将该平台上的RedirectUri修改为你项目运行的地址如http://localhost:54190
下载完项目之后，你需要在项目的根目录文件下，创建一个Azure.OAuth.config文件，并将以下代码加入到该文件中

```
<appSettings>
  <!--ClientID or APPId-->
  <add key="ClientID" value="Your APPID" />
  <!--ClientSecret or APPSecret-->
  <add key="ClientSecret" value="Your AppSecret" />
  <!--Tenant -->
  <!--The allowed values are 'common' for both Microsoft accounts and work or school accounts, 
    'organizations' for work or school accounts only, 
    'consumers' for Microsoft accounts only, 
    and tenant identifiers such as the tenant ID or domain name. 
  -->
  <!--Refer to https://developer.microsoft.com/en-us/graph/docs/concepts/auth_v2_user#3-get-a-token -->
  <add key="Tenant" value="common"/>
  <!--RedirectURL -->
  <!--This field should be the same as the callback URL configured in the place where the APP is registered.-->
  <add key="RedirectUri" value="http://localhost:54190" />
  <!--Application permission-->
  <add key="GraphScope" value="User.Read Mail.Read Files.ReadWrite.All" />
  <!--Azure OAuth Address-->
  <add key="EndPointUri" value="https://login.microsoftonline.com/"/>
  <add key="EndPointVersion" value="v2.0"/>
</appSettings>
```



## 项目结构

```
.
├── App_Data                        项目数据
├── App_Resources                   项目资源文件
├── App_Start                       项目启动文件
│   ├── RouteConfig.cs              路由配置
│   ├── Startup.Auth.cs             系统认证
│   ├── Startup.Injector.cs         服务注册
├── Content                         项目资源文件，CSS、SCSS
│   ├── bootstrap.css               bootstrap样式
│   ├── bootstrap.min.css           bootstrap样式
│   ├── Site.css                    全局样式
├── Controllers                     项目控制器
│   ├── User                        和用户相关的控制器
│       ├── UserController.cs       用户控制器
│   ├── Email                       邮件相关的控制器
│       ├── EmailController.cs      邮件控制器
│   ├── BaseController.cs           基础控制器，所有需要登陆认证的控制器建议继承该类
│   ├── ErrorController.cs          系统错误控制器
│   ├── HomeController.cs           默认控制器
├── fonts                           项目字体文件
├── Helpers                         项目帮助类
│   ├── GraphSdkHelper.cs           Graph API的帮助类
│   ├── IAuthProvider.cs            定义认证服务的接口
│   ├── MsalAuthProvider.cs         认证服务的实现类，继承自IAuthProvider
├── Models                          自定义模型类
├── Scripts                         项目JS文件
├── Services                        服务类
│   ├── IServiceImpls               服务接口实现类
│       ├── UserClientService.cs    使用Graph Client调用用户服务
│       ├── UserRestService.cs      使用REST API调用用户服务
│   ├── IServices                   服务接口
│       ├── IUserService.cs         用户服务接口定义
├── TokenStorage                    项目Token缓存类
│   ├── TokenSessionCache.cs        使用Session缓存Token
├── Views                           项目页面
├── Azure.OAuth.config              Azure AD 配置文件
├── Global.asax                     启动文件
├── packages.config                 项目包配置
├── Startup.cs                      Owin启动文件
├── Web.config                      系统配置文件
.

```

## 可用资源

* [Microsoft Graph 文档](https://developer.microsoft.com/zh-cn/graph/docs/concepts/overview)
* [Azure AD 认证](https://docs.microsoft.com/zh-cn/azure/active-directory/develop/azure-ad-developers-guide)



## 问题反馈
