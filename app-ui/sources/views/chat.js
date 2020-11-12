import {JetView} from "webix-jet";
import {comments} from "models/comments";

export default class ChatView extends JetView {

    config(){
        return {
            view:"datalayout",
            type:"wide",
            id:"chat",
            scroll: true,
            rows:[
                { name:"$value", type:"header", template:"#question#" },
                { name:"comments", view:"list", template: "#body#"}
            ],
            //url : "data/comments.json"
            // data : [
            //         {
            //             "question": "Is this applicable to all reatilers?",
            //             "comments": [
            //                 {
            //                     "body": "No, only LSA, BUF"
            //                 },
            //                 {
            //                     "body": "Ok, thanks"
            //                 }
            //             ]
            //         },
            //         {
            //             "question": "What is the Vat threshold? "
            //         }
            //     ]
            data : comments            
        }

    }

    init(view){
        // view.parse(comments);
        // var data = this.parse(comments);
        
        //  this.$$("chat").parse(comments);
        // var data = [data
        //     { month:"January", 
        //       data:[
        //         { income: 122342, count:12 }, 
        //         { income: 92342, count:8 }, 
        //         { income: 222342, count:20 }
        //       ] 
        //     },
        //     { month:"February", data:[{ income: 2342, count:2 }] }
        // ]

        // this.$$("chat").sync(data);

        // const data = [
        //     {question : "Is this applicable to all reatilers?", comments: [
        //         {body : "No, only LSA, BUF"}, 
        //         {body : "Ok, thanks"}
        //     ]}
        //     , {question : "What is the Vat threshold? "}
        //     , {question : "What is the Duty threshold?"}
        //     , {question : "Question 5 "}
        //     , {question : "Question 6 "}
        //     , {question : "Question 7 "}
        //     , {question : "Question 8 "}
        //     , {question : "Question 9 "}
        //     , {question : "Question 10 "}
        //     , {question : "Question 11"}
        // ];
        // this.$$("question-list").parse(data);
    }
}