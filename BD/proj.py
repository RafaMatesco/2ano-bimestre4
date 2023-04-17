import pymongo
import pandas as pd
import openpyxl

cliente = pymongo.MongoClient("mongodb://localhost:27017/")

meu_banco = cliente['banco_de_dados']
table = meu_banco['acre']

def insertOne(dado1, dado2):
    global x
    data = { "_id": x, "município": dado1[x], "zona": dado2[x]}
    c = table.insert_one(data)
    x += 1

def deleteOne(id):
    query = {'_id': id}
    colecao.delete_one(query)

def selectMany():
    for itens in table.find():
        print(itens)


df = pd.read_excel(r'ccont_2t_AC_271020181441.xlsx', sheet_name='pl1', usecols=['NM_MUNICIPIO','NR_ZONA'])

municipios = list()
zona = list()

for value in df['NM_MUNICIPIO']:
    municipios.append(value)
for value in df['NR_ZONA']:
    zona.append(value)
try:
    for x in range(len(zona)):
        insertOne(municipios, zona)
except:
    #selectMany()
    print('Algum valor já foi inserido')



