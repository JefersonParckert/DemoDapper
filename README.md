# DemoDapper

DOcumentação utilizada para instalar o [Sqlserver no docker](https://docs.microsoft.com/pt-br/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&pivots=cs1-bash)

1) Primeiramente baixe a versão do sqlservr para docker

```
docker pull mcr.microsoft.com/mssql/server:2019-latest
```

2) Execute a imagem do Container

```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Senha" -p 1433:1433 --name SQLServerLocal -h SQLServerLocal -d mcr.microsoft.com/mssql/server:2019-latest
```
