# WannaCry

![运行效果](https://user-images.githubusercontent.com/46400438/185957528-206dfb47-1397-40bf-ac7b-5686fb693835.gif)


### 实现功能：
1、修改桌面背景

2、模拟真实wannacry病毒界面

3、对Wannacry.exe目录下除exe文件外的所有文件均修改后缀名为.WNCRY


### 适应系统：
仅在Windows7、Windows10、Windows server 2008等系统中进行过测试


### 使用方法：
将WannaCry.exe放置于合适的目录下双击运行即可


### 注意事项：
1、修改为.WNCRY的文件为Wannacry.exe同目录下的文件，非桌面文件

2、修改桌面背景是调用的Windows函数，不会对注册表进行修改

3、只对wannacry.exe同目录下的文件进行修改后缀名操作，不会对子目录下的文件进行操作

4、为避免将大量文件修改为.WNCRY后缀导致无法使用，建议同目录下放置少量文件，留三五个做演示即可

5、.WNCRY文件并非真正的加密，仅是为了达到加密效果修改的文件后缀名，对原文件无任何影响，可通过修改后缀名恢复原文件

# Anti_WannaCry
![微信截图_20220823213056](https://user-images.githubusercontent.com/46400438/186171652-be3a0f0d-7bc9-41a4-9c48-0ac8a809415e.png)

一个C#控制台程序，用于批量恢复被Wannacry.exe “加密”的文件，源码在Anti_WannaCry文件夹下

### 使用方法：
将Anti_WannaCry.exe放置于需要恢复的目录下双击运行即可，只能恢复当前目录下的文件
