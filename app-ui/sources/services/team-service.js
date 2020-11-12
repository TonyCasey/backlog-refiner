
import { getUrl } from "../environments"


var teams = [];
var teamUsers = [];

export function getTeams(callBack){

	
		webix
		.ajax()
		.sync()
		.get( getUrl("sts")  + "/api/Team/Search",[ 
		{ 
			success:function(response, xml, ajax){ 
				
				teams = JSON.parse(response).data;
				
				if(teams.length <= 0){
					webix.message({type:"debug", text: `No teams available`});
					return;
				}	
							

			},
			error:function(response, xml, ajax){ 
				webix.message({type:"debug", text: `Error loading teams <br> ${ajax.status} ${ajax.statusText}`});
			}
		},
		callBack]
		);

        return teams;
        
}


