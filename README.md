# Microsoft .Net Web OAuth

### [中文Readme](https://github.com/JinGangRed/Web-NetFramework-OAuth/blob/master/README-cn.md)

## Catalog

* [Introduction](#introduction)
* [Prerequisite](#prerequisite)
* [Configuration](#configuration)
* [Structure](#structure)
* [Resources](#resources)
* [Feedback](#feedback)

## Introduction

When we using Microsoft Graph API or using Office 365 products' Rest API, we have to identified by Azure Active Director (Azure AD) and retrieve access token. Although there are some official ways to retrieve published by Microsoft, this project use code to achieve OAuth 2.0 authentication. This project used ASP.NET MVC to call Graph API and Office 365 projects' rest API.
For more information about GraphAPI user guide, please read [Microsoft Graph API](https://developer.microsoft.com/zh-cn/graph/docs/concepts/overview)

## Prerequisite

Before you start using this project, you should register an app on Azure or [Graph API APP](https://apps.dev.microsoft.com)
User guide: [Register Microsoft Application](https://developer.microsoft.com/en-us/graph/docs/concepts/aspnetmvc#register-the-application)


## Configuration

When you register the application, you should save your AppID(Client Id) and AppSecret(Client Secret). Please also update your RedirectUri to your project's address. E.g. http://localhost:54190
After download the project, you should create an Azure.OAuth.config under your root folder and add code below inside the config file.

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



## Structure

```
.
├── App_Data                        Data
├── App_Resources                   Resources
├── App_Start                       Startup
│   ├── RouteConfig.cs              RouteConfig
│   ├── Startup.Auth.cs             Authentication
│   ├── Startup.Injector.cs         Service register
├── Content                         Assets folders
│   ├── bootstrap.css               bootstrap
│   ├── bootstrap.min.css           bootstrap
│   ├── Site.css                    css
├── Controllers                     Controller folder
│   ├── User                        User Controller folder
│       ├── UserController.cs       User Controller
│   ├── Email                       Email Controller folder
│       ├── EmailController.cs      Email Controller
│   ├── BaseController.cs           Basic Controller, include login authentication function
│   ├── ErrorController.cs          Error Controller
│   ├── HomeController.cs           Default Controller
├── fonts                           Fonts folder
├── Helpers                         Helpers folder
│   ├── GraphSdkHelper.cs           Graph API helper
│   ├── IAuthProvider.cs            Custom Authentication Interface
│   ├── MsalAuthProvider.cs         Authentication service class, inherit from IAuthProvider
├── Models                          Models
├── Scripts                         JS folder
├── Services                        Services folders
│   ├── IServiceImpls               Service classes
│       ├── UserClientService.cs    Graph Client Service 
│       ├── UserRestService.cs      Rest API Service
│   ├── IServices                   Service interface folder
│       ├── IUserService.cs         Service interface 
├── TokenStorage                    Token folder
│   ├── TokenSessionCache.cs        Token cache
├── Views                           Views
├── Azure.OAuth.config              Azure AD config
├── Global.asax                     Startup
├── packages.config                 packages config
├── Startup.cs                      Owin Startup
├── Web.config                      Web config
.

```

## Resources

* [Microsoft Graph docs](https://developer.microsoft.com/en-us/graph/docs/concepts/overview)
* [Azure AD Authentication](https://docs.microsoft.com/en-us/azure/active-directory/develop/azure-ad-developers-guide)



## Feedback
