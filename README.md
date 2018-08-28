# Introduction
This repository is about integrating WeChat, Baidu Map and Youku Video on the website. This provides you implementation approach for:
1. Creating a contact in xDB using xConnect API when user visits web page through WeChat application
2. Displaying multiple locations with markup on Baidu map
3. Embedding Youku video on the web page

---
## Installation
1. Ensure you have a working Sitecore XP 9.0.1 instance.
2. Clone this repository.
3. Update TDSGlobal.config based on your configurations and sync items with sitecore.
4. Build and publish solution.

## Projects
This repository contains two projects:

### WeChat.Service ###
This project has implementation of below WeChat API methods:

  * Get Access Token
  * Generate QR Code of Official Account
  * Create Custom Menu in Official Account
  * Get User Information via Web Authorization

Also, contains code block for identifying contact & interactions in xDB and creating/setting Personal Information facet for a contact.

### WeChatIntegration.Mvc ###
MVC web application which contains implementation of WeChat, Baidu Map and Youku video view and controller renderings.

## Blog Posts
https://horizontalintegration.blog/2018/08/27/integrate-wechat-with-sitecore-and-create-contact-profile-of-wechat-user/
