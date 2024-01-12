# IMB.MQ.Sample


## Demo
![Console](https://github.com/richielybmp/IMB.MQ.Sample/blob/master/Console-sample.png)
![Queue](https://github.com/richielybmp/IMB.MQ.Sample/blob/master/Console-queue.png)


## Imagem docker
```
docker pull ibmcom/mq
```

## Inicializando container docker
```
docker run \
    --env LICENSE=accept \
    --env MQ_QMGR_NAME=QMGR \
    --publish 1414:1414 \
    --publish 9443:9443 \
    --detach \
    ibmcom/mq
```

## Acessando o console do IMB MQ
```
https://localhost:9443/ibmmq/console 
```

## Credenciais default
```
Username: admin
Password: passw0rd
```

## Execu��o
### Configura��o

Parametrize os dados de conex�o no arquivo `settings.json`
```
{
  "Channel": "DEV.APP.SVRCONN",
  "Hostname": "localhost",
  "Password": "passw0rd",
  "Port": 1414,
  "UserId": "app"
}
```

Obs.: essas s�o as configura��es padr�es. Deve usar o `channel` e o `userId` do exemplo. 

Para mais informa��es, acesse a documenta��o do IMB MQ [aqui](https://www.ibm.com/docs/en/ibm-mq/9.2?topic=programs-example-c-code-fragment-use-net).