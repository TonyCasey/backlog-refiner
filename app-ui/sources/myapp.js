import "./styles/app.css";
import { JetApp, EmptyRouter, HashRouter, plugins } from "webix-jet";
import session from "./services/session";

export default class MyApp extends JetApp{
	constructor(config){
		const defaults = {
			id		: "Backlog Refiner",
			version : VERSION,
			// router 	: HashRouter,
			router 	: BUILD_AS_MODULE ? EmptyRouter : HashRouter,
			debug 	: !PRODUCTION,
			start 	: "/top/kanban",
			theme	: webix.storage.local.get("curr_theme_team_progress") || ""
		};

		super({ ...defaults, ...config });

		this.use(plugins.Locale,{ storage:webix.storage.local });
		this.use(plugins.User, { model: session });
	}

	
}



if (!BUILD_AS_MODULE){
	webix.ready(() => {
		if (!webix.env.touch && webix.env.scrollSize && webix.CustomScroll)
			webix.CustomScroll.init();
		new MyApp().render();
	});
}

//track js errors
if (PRODUCTION){
	window.Raven
		.config(
			"https://59d0634de9704b61ba83823ec3bf4787@sentry.webix.io/12"
		)
		.install();
}
