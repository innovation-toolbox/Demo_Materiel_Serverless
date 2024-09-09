"""
Azure Function App to create a new item in CosmosDB.
"""

import uuid
import azure.functions as func

app = func.FunctionApp()


@app.route(route="create", auth_level=func.AuthLevel.FUNCTION)
@app.cosmos_db_output(arg_name="document",
                      database_name="DemoDb",
                      container_name="DemoContainer",
                      create_if_not_exists=True,
                      connection="CONNECTION_STRING")
def create(req: func.HttpRequest, document: func.Out[func.Document]) -> func.HttpResponse:
    new_item = {
        'id': str(uuid.uuid4())
    }
    document.set(func.Document.from_dict(new_item))

    return func.HttpResponse(
        "This HTTP triggered function executed successfully. New uuid created in CosmosDB",
        status_code=200
    )
