import {JetView} from "webix-jet";
import {persons} from "../../../models/persons";

export default class EstimateListView extends JetView {

    config(){

        return {
            view:"list",
            localId:"list",
            css:"persons_list",
            select:true,
            height:400,
            type:{
                template:obj => `<image class="userphoto" src="data/photos/${obj.photo}.jpg" />
                    <div class="text">
                        <h4>Estimate List</h4>
                          <span class="username">${obj.fname} ${obj.lname}</span>
                          <span class="money">$${obj.money}</span>
                    </div>`,
                height:66
            },
            on:{
                onAfterSelect:(id) => {
                    const person = persons.getItem(id);
                    this.app.callEvent("person:select",[person]);
                }
            }
        }
    }

    init(){
		const list = this.$$("list");
		persons.waitData.then(() => {
			list.sync(persons);
			list.select(list.getFirstId());
		});

		this.on(this.app,"task:select", id => {
			list.select(id);
			list.showItem(id);
		});
	}
}