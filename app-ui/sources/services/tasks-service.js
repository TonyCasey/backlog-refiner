import { getUrl } from "../environments"



export function searchTasks(searchRequestObject, callBack){

    var results = null;

    webix
    .ajax()
    .get( getUrl("tasks")  + "/api/Task/Search", searchRequestObject, 
    [{ 
        success:function(response, xml, ajax){ 

            results = JSON.parse(response).data;
            
            if(results.length <= 0){					
                //webix.message({type:"debug", text: `No ticket members available`});
                return;
            }
                
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error loading Tasks <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}


export function getTask(taskGuid, callBack){

    var results = null;

    webix
    .ajax()
    .get( getUrl("tasks")  + "/api/Task/" + taskGuid, 
    [{ 
        success:function(response, xml, ajax){ 

            results = JSON.parse(response);
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error getting Task <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}

export function addTask(object, callBack){

    var results = null;

    webix
    .ajax()
    .headers({"Content-type":"application/json"})
    .post( getUrl("tasks")  + "/api/Task", object, 
    [{ 
        success:function(response, xml, ajax){ 

            results = ajax.status;
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error Task member <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}

export function addTaskSynchronous(object, callBack){

    var results = null;

    webix
    .ajax()
    .sync()
    .headers({"Content-type":"application/json"})
    .post( getUrl("tasks")  + "/api/Task", object, 
    [{ 
        success:function(response, xml, ajax){ 

            results = response;
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error Task <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}

export function deleteTask(taskGuid, callBack){

    var results = null;

    webix
    .ajax()
    .del( getUrl("tasks")  + "/api/Task/" + taskGuid, 
    [{ 
        success:function(response, xml, ajax){ 

            results = ajax.status;
                            
        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error deleting task <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack]
    );

    return results;
}