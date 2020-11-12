
import { getUrl } from "../environments"

export function getBoards(teamGuid, callBack){ 
		
    var boards = null;

    webix
    .ajax()
    .get( getUrl("boards")  + "/api/Board/Search", {teamGuid: teamGuid}, 
    [{ 
        success:function(response, xml, ajax){ 
        
            boards = JSON.parse(response).data;
            
            if(boards.length <= 0){					
                webix.message({type:"debug", text: `No boards available`});
                return;
            }

        },
        error:function(response, xml, ajax){ 
            webix.message({type:"debug", text: `Error loading boards <br> ${ajax.status} ${ajax.statusText}`});
        }
    },
    callBack ]
    );

    return boards;
}