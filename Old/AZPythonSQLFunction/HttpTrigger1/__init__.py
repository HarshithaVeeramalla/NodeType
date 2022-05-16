import logging

import azure.functions as func
import pyodbc


def main(req: func.HttpRequest) -> func.HttpResponse:
    logging.info('Python HTTP trigger function processed a request.')


def main(req: func.HttpRequest) -> func.HttpResponse:
    logging.info('Python HTTP trigger function processed a request.')
    error = ''
    try:
        BB_connection = 'Driver={ODBC Driver 17 for SQL Server};Server=tcp:delssqlservertest.database.windows.net,1433;Database=delssqldatabase;Uid=Admin@@delssqlservertest;Pwd=Ganeshid@007;Encrypt=yes;TrustServerCertificate=no;Connection Timeout=30;'
        cnxn = pyodbc.connect(BB_connection)  
        cursor = cnxn.cursor()
        cursor.execute("SELECT * FROM [ApplicationLogs]")   

    except Exception as e:
        error = str(e)

    return func.HttpResponse(f"Error: {error}")

    