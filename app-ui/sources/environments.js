



var prodEndpoints = [
    {
        name : "sts",
        url : "https://sts-api.backlogrefiner.com"
    },
    {
        name : "comments",
        url : "https://comments-api.backlogrefiner.com"
    },
    {
        name : "tickets",
        url : "http://tickets-api.backlogrefiner.com"
    },
    {
        name : "questions",
        url : "http://questions-api.backlogrefiner.com"
    },
    {
        name : "bdd",
        url : "http://bdd-api.backlogrefiner.com"
    },
    {
        name : "notifications",
        url : "http://notifications-api.backlogrefiner.com"
    },
    {
        name : "boards",
        url : "http://boards-api.backlogrefiner.com"
    },
    {
        name : "emails",
        url : "http://email-api.backlogrefiner.com"
    }
]

// var devEndpoints = [
//     {
//         name : "sts",
//         url : "http://localhost:5000"
//     },
//     {
//         name : "comments",
//         url : "http://localhost:5001"
//     },
//     {
//         name : "tickets",
//         url : "http://localhost:5002"
//     },
//     {
//         name : "questions",
//         url : "http://localhost:5003"
//     },
//     {
//         name : "bdd",
//         url : "http://localhost:5004"
//     },
//     {
//         name : "notifications",
//         url : "http://localhost:5005"
//     },
//     {
//         name : "boards",
//         url : "http://localhost:5006"
//     },
//     {
//         name : "tasks",
//         url : "http://localhost:5007"
//     }
// ]

var devEndpoints = [
    {
        name : "sts",
        url : "http://localhost/sts-api"
    },
    {
        name : "comments",
        url : "http://localhost/comments-api"
    },
    {
        name : "tickets",
        url : "http://localhost/tickets-api"
    },
    {
        name : "questions",
        url : "http://localhost/questions-api"
    },
    {
        name : "bdd",
        url : "http://localhost/bdd-api"
    },
    {
        name : "notifications",
        url : "http://localhost/notifications-api"
    },
    {
        name : "boards",
        url : "http://localhost/boards-api"
    },
    {
        name : "tasks",
        url : "http://localhost/tasks-api"
    },
    {
        name : "test-cases",
        url : "http://localhost/test-cases-api"
    },
    {
        name : "notifications",
        url : "http://localhost/notifications-api"
    },
    {
        name : "emails",
        url : "http://localhost:5009" //"http://localhost/email-api"
    }
]

var ciEndpoints = [
    {
        name : "sts",
        url : "https://ci-sts-api.backlogrefiner.com"
    },
    {
        name : "comments",
        url : "https://ci-comments-api.backlogrefiner.com"
    },
    {
        name : "tickets",
        url : "https://ci-tickets-api.backlogrefiner.com"
    },
    {
        name : "questions",
        url : "https://ci-questions-api.backlogrefiner.com"
    },
    {
        name : "bdd",
        url : "https://ci-bdd-api.backlogrefiner.com"
    },
    {
        name : "notifications",
        url : "https://ci-notifications-api.backlogrefiner.com"
    },
    {
        name : "boards",
        url : "https://ci-boards-api.backlogrefiner.com"
    },
    {
        name : "tasks",
        url : "https://ci-tasks-api.backlogrefiner.com"
    },
    {
        name : "test-cases",
        url : "https://ci-test-cases-api.backlogrefiner.com"
    },
    {
        name : "notifications",
        url : "https://ci-notifications-api.backlogrefiner.com"
    },
    {
        name : "emails",
        url : "https://ci-email-api.backlogrefiner.com"
    }
]

export function getUrl(api){
    
    switch(process.env.NODE_ENV){   
        case "production" :
            return ciEndpoints.find(x => x.name == api).url; //return prodEndpoints.find(x => x.name == api).url;
        case "development" :
            return devEndpoints.find(x => x.name == api).url;
        case "continuous-integration" :
            return ciEndpoints.find(x => x.name == api).url;
    }
    
	return stats;
}
