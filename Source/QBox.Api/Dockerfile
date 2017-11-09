FROM microsoft/aspnet:4.7
ARG source
ARG dbfiles=../QBox.Database/bin/debug/QuizBoxDB.dacpac
WORKDIR /inetpub/wwwroot
COPY ${source:-obj/Docker/publish} .

COPY $dbfiles .
