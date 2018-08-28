# Microsoft .Net Web OAuth

## 目录

* 项目介绍
* 预备条件
* 项目配置
* 项目结构
* 可用资源
* 人员追踪

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



## 可用资源



## 人员追踪
