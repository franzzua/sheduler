import { Api, Schedule, Task } from "@sheduler/sdk";
import { id } from "./helpers.js";

export class Monkey {
    
    public id = id();
    private taskCount = Math.floor(Math.random()*1); 
    private schedule: Schedule = {
        id: this.id,
        name: 'Schedule',
        description: "Schedule description",
        tasks: Array(this.taskCount + 1).fill('').map((_,i) => ({
            id: id(),
            cronExpression: '0 * * * * *',
            uri: this.uri + '/' + this.id
        } as Task))
    };
    constructor(private api: Api, private uri: string) {
        this.api.add(this.schedule).then(() => console.log(`created ${this.id}`)).catch(console.error);
    }

}
