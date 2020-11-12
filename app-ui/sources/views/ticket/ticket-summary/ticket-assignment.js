
import {JetView} from "webix-jet";

export default class TicketAssignmentView extends JetView {

    config(){
      return {
        view:"form",
        margin:20,        
        cols:[
        //   { view:"text", css:"form_photo", borderless:true },
          {
            rows:[
                {
                    view:"richselect", label:"Developer assigned",
                    width:200,
                    labelPosition:"top",
                    options:[
                    "Manager","Sales Manager","General Manager"
                    ]
                  },
                  {
                    view:"richselect", label:"QA assigned",
                    labelPosition:"top",
                    options:[
                    "Manager","Sales Manager","General Manager"
                    ]
                  },

            //   {
            //     view:"text", label:"First name",
            //     labelPosition:"top"
            //   },
            //   {
            //     view:"text", label:"Last name",
            //     labelPosition:"top"
            //   },
              
            //   { view:"text", label:"Email", labelPosition:"top" },
            //   {
            //     view:"radio", label:"Notifications",
            //     labelPosition:"top",
            //     options:[
            //       { id:1, value:"Yes" },
            //       { id:2, value:"No" }
            //     ]
            //   }
            ]
          }
        ]
      };
    }

    // config(){
    //     return {
    //         view:"form",
    //         localId:"assignementForm",
    //             elements:[
    //                 { view:"text", css:"form_photo", borderless:true },
    //                 { 
    //                     cols:[
    //                     { view:"text", placeholder: "ask a question"},
    //                     {
    //                         cols:[
    //                             {
    //                                 view:"button", label: 'Send', width: 50, 
    //                                  align: 'left',
    //                                 //click:() => this.addQuestion()
    //                             }
    //                         ]
    //                     }
    //                     ]
    //                 }                    
                    
    //                 ]
                            
                    
    //     }
    // }
  }