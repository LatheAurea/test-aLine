@echo BUILD STARTED
@date /t
@time /t

.nuget\nuget.exe restore TestFakes.sln

REM VERBOSITY=quiet|minimal|normal|detailed|diagnostic
set VERBOSITY=minimal

msbuild.exe TestFakes.sln /nologo /verbosity:%VERBOSITY% /t:Clean /p:Configuration=Debug

msbuild.exe TestFakes.sln /nologo /verbosity:%VERBOSITY% /t:Build /p:Configuration=Debug

@if %errorlevel% neq 0 goto FAIL

@echo BUILD SUCCESSFULL
@date /t
@time /t
@exit /B 0

:FAIL
@echo BUILD FAILED
@date /t
@time /t
@exit /B 1