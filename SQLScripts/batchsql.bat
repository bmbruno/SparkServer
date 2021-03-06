@ECHO OFF

SET BLD_DDLVER=%1
SET BLD_NOPAUSE=%2

SET BLD_SQLBASEDIR=.\
SET BLD_SQLSERV=.\SQLDEV01



ECHO ****************************************
ECHO Batch Start (%BLD_SQLBASEDIR%*.sql)
ECHO ****************************************
ECHO.


IF "%BLD_DDLVER%"=="ALL" GOTO DDLDMLALL
IF "%BLD_DDLVER%"=="" GOTO DDLDMLNONE

:DDLDMLSOME
ECHO ** DDL-DML Version #%BLD_DDLVER% **
FOR /R %BLD_SQLBASEDIR%DDL-DML\%BLD_DDLVER% %%f IN (*.sql) DO (
  ECHO Running %%f
  OSQL -S "%BLD_SQLSERV%" -E -i "%%f" -n -b
  IF ERRORLEVEL 1 GOTO END
)
GOTO DDLDMLEND

:DDLDMLALL
ECHO ** EXECUTING ALL DDL-DML **
FOR /R %BLD_SQLBASEDIR%DDL-DML %%f IN (*.sql) DO (
  ECHO Running %%f
  OSQL -S "%BLD_SQLSERV%" -E -i "%%f" -n -b
  IF ERRORLEVEL 1 GOTO END
)
GOTO DDLDMLEND

:DDLDMLNONE IF "%BLD_DDLVER%"=="" ECHO ** No DDL-DML To Execute **

:DDLDMLEND


ECHO.
ECHO ** FUNCTIONS **
FOR /R %BLD_SQLBASEDIR%FUNCTIONS %%f IN (*.sql) DO (
  ECHO Running %%f
  OSQL -S "%BLD_SQLSERV%" -E -i "%%f" -n -b
  IF ERRORLEVEL 1 GOTO END
)

ECHO.
ECHO ** VIEWS **
FOR /R %BLD_SQLBASEDIR%VIEWS %%f IN (*.sql) DO (
  ECHO Running %%f
  OSQL -S "%BLD_SQLSERV%" -E -i "%%f" -n -b
  IF ERRORLEVEL 1 GOTO END
)


ECHO.
ECHO ** PROCS **
FOR /R %BLD_SQLBASEDIR%PROCS %%f IN (*.sql) DO (

  ECHO Running %%f
  OSQL -S "%BLD_SQLSERV%" -E -i "%%f" -n -b
  IF ERRORLEVEL 1 GOTO END
)


ECHO.
ECHO ** TRIGGERS **
FOR /R %BLD_SQLBASEDIR%TRIGGERS %%f IN (*.sql) DO (

  ECHO Running %%f
  OSQL -S "%BLD_SQLSERV%" -E -i "%%f" -n -b
  IF ERRORLEVEL 1 GOTO END
)

GOTO END

:ERROR
ECHO BATCH ABORTED DUE TO ERROR

:END
ECHO.
ECHO ****************************************
ECHO Batch Execution Complete (%BLD_SQLBASEDIR%*.sql)
ECHO ****************************************
SET BLD_SQLBASEDIR=
SET BLD_SQLSERV=
SET BLD_DDLVER=
SET BLD_NOPAUSE=

IF "%BLD_NOPAUSE%" == "NOPAUSE" GOTO EXIT
PAUSE

:EXIT