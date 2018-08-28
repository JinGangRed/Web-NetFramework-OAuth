# Microsoft .Net Web OAuth

##目录

* 项目介绍
* 预备条件
* 项目配置
* 项目结构
* 可用资源
* 人员追踪

## 项目介绍

在使用Microsoft Graph或调用Outlook、Excel的Rest API时，需要从 Microsoft 的云标识服务 Azure Active Directory (Azure AD) 获取访问令牌。
官方已经给出了许多关于如何获取Azure AD访问令牌的例子。这个项目是以此为基础，使用.Net MVC完成对Graph的API和Office 365。
可以选择不同的分支获取对应的示例代码。
更多关于GraphAPI的使用,可参考文档：[Microsoft Graph](https://developer.microsoft.com/zh-cn/graph/docs/concepts/overview)

## 预备条件

在使用这个项目大码的时候，需要在Azure 上或 [Graph APP](https://apps.dev.microsoft.com)上注册一个应用。
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
一个在线编辑markdown文档的编辑器

向Mac下优秀的markdown编辑器mou致敬

##MaHua有哪些功能？

* 方便的`导入导出`功能
    *  直接把一个markdown的文本文件拖放到当前这个页面就可以了
    *  导出为一个html格式的文件，样式一点也不会丢失
* 编辑和预览`同步滚动`，所见即所得（右上角设置）
* `VIM快捷键`支持，方便vim党们快速的操作 （右上角设置）
* 强大的`自定义CSS`功能，方便定制自己的展示
* 有数量也有质量的`主题`,编辑器和预览区域
* 完美兼容`Github`的markdown语法
* 预览区域`代码高亮`
* 所有选项自动记忆

##有问题反馈
在使用中有任何问题，欢迎反馈给我，可以用以下联系方式跟我交流

* 邮件(dev.hubo#gmail.com, 把#换成@)
* QQ: 287759234
* weibo: [@草依山](http://weibo.com/ihubo)
* twitter: [@ihubo](http://twitter.com/ihubo)

##捐助开发者
在兴趣的驱动下,写一个`免费`的东西，有欣喜，也还有汗水，希望你喜欢我的作品，同时也能支持一下。
当然，有钱捧个钱场（右上角的爱心标志，支持支付宝和PayPal捐助），没钱捧个人场，谢谢各位。

##感激
感谢以下的项目,排名不分先后

* [mou](http://mouapp.com/) 
* [ace](http://ace.ajax.org/)
* [jquery](http://jquery.com)

##关于作者

```javascript
  var ihubo = {
    nickName  : "草依山",
    site : "http://jser.me"
  }
```