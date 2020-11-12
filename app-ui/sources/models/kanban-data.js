export const base_task_set = [
			{ id:1, status:"new", text:"Task 1", tags:"webix,docs", comments:[{text:"Comment 1"}, {text:"Comment 2"}], questions: [{text:"Comment 1"}, {text:"Comment 2"}] },
			{ id:2, status:"qa", text:`
			Task 2 with a lot of data how will this look, will it wrap?, 
			
			Task 2 with a lot of data how will this look, will it wrap? , 
			
			Task 2 with a lot of data how will this look, will it wrap? , 
			
			Task 2 with a lot of data how will this look, will it wrap?  `, color:"red", tags:"webix", votes:1, personId: 4, questions: [{text:"Comment 1"}, {text:"Comment 2"}]  },
			{ id:3, status:"qa", text:"Task 3", tags:"webix,docs", comments:[{text:"Comment 1"}], personId: 6, questions: [{text:"Comment 1"}, {text:"Comment 2"}] },
			{ id:4, status:"dev", text:"Task 4 pending", tags:"webix 2.5", votes:1, personId: 5, questions: [{text:"Comment 1"}, {text:"Comment 2"}]  },
			{ id:5, status:"new", text:"Task 5", tags:"webix,docs", votes:3, questions: [{text:"Comment 1"}, {text:"Comment 2"}]  },
			{ id:6, status:"new", text:"Task 6", tags:"webix,kanban", comments:[{text:"Comment 1"}, {text:"Comment 2"}], personId: 2, questions: [{text:"Comment 1"}, {text:"Comment 2"}] },
			{ id:7, status:"qa", text:"Task 7", tags:"webix", votes:2, personId: 7, image: "image001.png", questions: [{text:"Comment 1"}, {text:"Comment 2"}]  },
			{ id:8, status:"qa", text:"Task 8", tags:"webix", comments:[{text:"Comment 1"}, {text:"Comment 2"}], votes:5, personId: 4, questions: [{text:"Comment 1"}, {text:"Comment 2"}]  },
			{ id:9, status:"qa", text:"Task 9", tags:"webix", votes:1, personId: 2, questions: [{text:"Comment 1"}, {text:"Comment 2"}]},
			{ id:10, status:"qa", text:"Task 10", tags:"webix", comments:[{text:"Comment 1"}, {text:"Comment 2"}, {text:"Comment 3"}], votes:10, personId:1, questions: [{text:"Comment 1"}, {text:"Comment 2"}] },
			{ id:11, status:"qa", text:"Task 11", tags:"webix 2.5", votes:3, personId: 8, questions: [{text:"Comment 1"}, {text:"Comment 2"}] },
			{ id:12, status:"done", text:"Task 12", votes:2 , personId: 8, image: "image002.png", questions: [{text:"Comment 1"}, {text:"Comment 2"}]},
			{ id:13, status:"done", text:"Task 14",  personId: 8}  
		];





	export const task_set = new webix.DataCollection({
		data:[
			{ id:1, status:"new", text:"Task 1", tags:"webix,docs" },
			{ id:2, status:"new", text:"Task 2", tags:"webix" },
			{ id:3, status:"new", text:"Task 3", tags:"webix" },
			{ id:4, status:"new", text:"Task 4", tags:"webix" },
			{ id:5, status:"new", text:"Task 5", tags:"webix,docs" },

			{ id:6, status:"ready", text:"Task 6", tags:"webix,docs" },
			{ id:7, status:"ready", text:"Task 7", tags:"webix" },
			{ id:8, status:"ready", text:"Task 8", tags:"webix" },
			{ id:9, status:"ready", text:"Task 9", tags:"webix" },
			{ id:10, status:"ready", text:"Task 10", tags:"webix,docs" },

			{ id:11, color:"red", status:"qa", text:"Task 11", tags:"webix,docs" },
			{ id:12, status:"qa", text:"Task 12", tags:"webix" },
			{ id:13, status:"qa", text:"Task 13", tags:"webix" },
			{ id:14, color:"red", status:"qa", text:"Task 14", tags:"webix" },
			{ id:15, status:"qa", text:"Task 15", tags:"webix,docs" },

			{ id:16, status:"dev", text:"Task 16", tags:"webix,docs" },
			{ id:17, color:"red", status:"qa", text:"Task 17", tags:"webix" },

			{ id:18, status:"done", text:"Task 18", tags:"webix,docs" },
			{ id:19, color:"red", status:"done", text:"Task 19", tags:"webix" },

			{ id:20, status:"complete", text:"Task 20", tags:"webix,docs" },
			{ id:21, color:"red", status:"complete", text:"Task 21", tags:"webix" },


			{ id:22, status:"ready", text:"Task 22", tags:"webix,docs" },
			{ id:23, color:"red", status:"ready", text:"Task 23", tags:"webix" }
		]
});

export const staff = new webix.DataCollection({
    data:[
		{id:1, name:"Rick Lopes"},
		{id:2, name:"Martin Farrell"},
		{id:3, name:"Douglass Moore"},
		{id:4, name:"Eric Doe"},
		{id:5, name:"Sophi Elliman"},
		{id:6, name:"Anna O'Neal"},
		{id:7, name:"Marcus Storm"},
		{id:8, name:"Nick Branson"}    
	]
});


export const user_task_set = new webix.DataCollection({
    data:[
		{ id:1, status:"new", text:"dev new authentification service", tags:"webix", comments:[{text:"Comment 1"}, {text:"Comment 2"}] },
	{ id:2, status:"qa", user: 1, text:"Performance devs", color:"red", tags:"webix"  },
	{ id:3, status:"qa", user: 2, text:"Kanban tutorial", tags:"webix,docs", comments:[{text:"Comment 1"}] },
	{ id:4, status:"qa", user: 3, text:"SpreadSheet NodeJS", tags:"webix 3.0"  },
	{ id:5, status:"dev", user: 3, text:"Portlets view", tags:"webix 2.5"  }
	]
});		


export const team_task_set = new webix.DataCollection({
    data:[
		{ id:1, status:"new", text:"dev new authentification service", tags:"webix", comments:[{text:"Comment 1"}, {text:"Comment 2"}] },
	{ id:2, status:"qa", team: 1, text:"Kanban tutorial", color:"red", tags:"webix,docs"  },
	{ id:3, status:"qa", team: 2, text:"New skin", tags:"webix"},
	{ id:4, status:"qa", team: 1, text:"SpreadSheet NodeJS", tags:"webix 3.0"  },
	{ id:5, status:"dev", text:"Portlets view", tags:"webix 2.5"  }
	]
});		

