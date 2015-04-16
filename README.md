# EDNASS1
EDNASS 1
http://channel9.msdn.com/Series/Customizing-ASPNET-Authentication-with-Identity/02

identity customise database 从5分49秒


DKK 17-Aor-2015 1:17:
Using NuGet without committing packages to source control
1. Open VS2013
2. Options -> Package Manager -> General
3. Enable "Allow NuGet to download missing packages during build"
4. Right click on the Solution node in Solution Explorer and select Enable NuGet Package Restore.
5. Build

按照上面设置并且编译后，NuGet会自动下载缺少的package。如果编译后所需package还是没有自动下载，就先去packages目录删除对应的子目录（moq的目录,nunit的目录,asppose.barcode的目录），然后再编译。
