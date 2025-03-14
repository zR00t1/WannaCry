# WannaCry

![运行效果](https://user-images.githubusercontent.com/46400438/185957528-206dfb47-1397-40bf-ac7b-5686fb693835.gif)

### 实现功能：
1、修改桌面背景

2、模拟真实`WannaCry`病毒界面

3、对`Wannacry.exe`目录下除exe文件外的所有文件修改后缀名为`.WNCRY`

4、访问`www.iuqerfsodp9ifjaposdfjhgosurijfaewrwergwea.com`

5、随机对`192.168.0.0/16`网段的445端口进行端口扫描（不会对`MS17-010`进行漏洞利用）


### 适应系统：
仅在`Windows7`、`Windows10`、`Windows server 2008`等系统中进行过测试


### 使用方法：
将`WannaCry.exe`放置于合适的目录下双击运行，随后即可在态势感知等平台监测到访问恶意域名及对外扫描445端口


### 注意事项：
1、修改桌面背景是调用的Windows函数，不会对注册表进行修改

2、只对`wannacry.exe`同目录下的文件进行修改后缀名为`.WNCRY`的操作，不会对子目录下的文件进行操作

3、`.WNCRY`文件并非真正的加密，仅是为了达到加密效果修改的文件后缀名，对原文件无任何影响，可通过修改后缀名恢复原文件

4、因对外访问恶意域名和扫描高危端口，可能会报毒...

<br>
<br>
<br>

# Anti_WannaCry
![微信截图_20220823213056](https://user-images.githubusercontent.com/46400438/186171652-be3a0f0d-7bc9-41a4-9c48-0ac8a809415e.png)

### 介绍：
一个C#控制台程序，用于批量恢复被`Wannacry.exe` “加密”的文件并恢复`Windows`系统默认壁纸，源码在`Anti_WannaCry`文件夹下

### 使用方法：
将`Anti_WannaCry.exe`放置于需要恢复的目录下双击运行即可，只能恢复当前目录下的文件
