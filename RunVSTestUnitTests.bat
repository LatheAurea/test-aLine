@echo on

"%VS140COMNTOOLS%..\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" UnitTestFakes\bin\Debug\UnitTestFakes.dll /UseVsixExtensions:true
PAUSE

REM "C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" %list% /UseVsixExtensions:true %CodeCoverageArguments%
